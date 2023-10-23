using System;
using System.Text;
using NATS.Client;

namespace NATS_Sub2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to the NATS server
            IConnection connection = new ConnectionFactory().CreateConnection();

            // Subscribe to a subject
            IAsyncSubscription subscription = connection.SubscribeAsync("sub2");
            subscription.MessageHandler += (sender, argz) =>
            {
                string message = Encoding.UTF8.GetString(argz.Message.Data);
                Console.WriteLine("Received: " + message);
            };
            subscription.Start();

            Console.WriteLine("Subscriber started. Press Enter to exit.");
            Console.ReadLine();

        }
    }
}


