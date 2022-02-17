using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MyFinance.RabbitMQ.Receive
{
    class Receive
    {
        static void Main()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "tack_queue", // Just change the queue name to redefine it with new parameters
                                     durable: false, // Make the queue durable - prevent it from deleting when the Server quits or crashes
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // Don't dispatch a new message until the previous one has processed and acknowledged
                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                var consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume(queue: "tack_queue", autoAck: false, consumer: consumer);

                consumer.Received += (model, args) =>
                {
                    var response = string.Empty;

                    var body = args.Body.ToArray();
                    var props = args.BasicProperties;

                    var replyProps = channel.CreateBasicProperties();
                    replyProps.CorrelationId = props.CorrelationId;

                    try
                    {
                        var message = Encoding.UTF8.GetString(body);
                        int n = int.Parse(message);
                        Console.WriteLine(" [.] fib({0})", message);
                        response = Fib(n).ToString();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(" [.] " + e.Message);
                        response = "";
                    }
                    finally
                    {
                        var responseBytes = Encoding.UTF8.GetBytes(response);
                        channel.BasicPublish(exchange: "", routingKey: props.ReplyTo, basicProperties: replyProps, body: responseBytes);
                        channel.BasicAck(deliveryTag: args.DeliveryTag, multiple: false);
                    }
                };

                Console.WriteLine(" [*] Awaiting RPC requests");
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }

        private static int Fib(int n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }

            return Fib(n - 1) + Fib(n - 2);
        }
    }
}
