﻿using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MyFinance.RabbitMQ.ReceiveLog
{
    class ReceiveLog
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
				channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Topic);
				
				// Create a non-durable, exclusive, autodelete queue with a autogenerated name
                var queueName = channel.QueueDeclare().QueueName;

                // Bind queue to exchange
                if (args.Length < 1)
                {
                    Console.Error.WriteLine("Usage: {0} [binding_key...]",
                                        Environment.GetCommandLineArgs()[0]);
                    Console.WriteLine(" Press [enter] to exit.");
                    Console.ReadLine();
                    Environment.ExitCode = 1;
                    return;
                }

                foreach (var bindingKey in args)
                {
                    channel.QueueBind(queue: queueName, exchange: "logs", routingKey: bindingKey);
                }

                Console.WriteLine(" [*] Waiting for logs.");

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, args) =>
                {
                    var body = args.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var routingKey = args.RoutingKey;

                    Console.WriteLine(" [x] Received '{0}':'{1}'", routingKey, message);
                };

				// Using autoack mode - there is no matter to miss some messages via processing errors
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}