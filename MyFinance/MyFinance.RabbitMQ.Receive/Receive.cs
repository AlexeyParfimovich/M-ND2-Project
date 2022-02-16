using System;
using System.Text;
using System.Threading;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MyFinance.RabbitMQ.Receive
{
    class Receive
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "tack_queue", // Just change the queue name to redefine it with new parameters
                                     durable: true, // Make the queue durable - prevent it from deleting when the Server quits or crashes
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // Don't dispatch a new message until the previous one has processed and acknowledged
                channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                Console.WriteLine(" [*] Waiting for messages.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, args) =>
                {
                    var body = args.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine(" [x] Received {0}", message);
                    
                    // Fake task proceed simulation
                    int dots = message.Split('.').Length - 1;
                    Thread.Sleep(dots * 1000);
                    Console.WriteLine(" [x] Tack done");

                    // Manual acknowledge delivered message(s)
                    channel.BasicAck(deliveryTag: args.DeliveryTag, multiple: false);
                };

                channel.BasicConsume(queue: "tack_queue", 
                    autoAck: false, //true
                    consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
