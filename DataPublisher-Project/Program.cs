using DataPublisher_Project.Model;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
//using System.Timers;
using System.Threading;

namespace DataPublisher_Project
{
    class Program
    {
        static void Main(string[] args)
        {

            Timer t = new Timer(DisplayTimeEvent, null, 0, 5000);
            Console.ReadLine();
        }

        public static byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private static void DisplayTimeEvent(object source)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" , UserName="guest" , Password = "guest" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "SimpleQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);


                var body = ObjectToByteArray(new StudentModel() { Id = 1, Name = "Mohamamd", Family = "Neghabanfard", Tell = "22356891", Address = "tehran" });

                channel.BasicPublish(exchange: "",
                                     routingKey: "SimpleQueue",
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent Data into queue name SimpleQueue");
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }


    }
}
