using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://172.22.149.120/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "AddUser1", e =>
                {
                    e.Consumer<AddUserConsumer>();
                });
            });
            busControl.Start();
            Console.WriteLine("Running");
            Console.ReadLine();
        }
    }
}
