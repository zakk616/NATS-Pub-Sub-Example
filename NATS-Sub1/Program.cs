using System;
using System.Text;
using NATS.Client;

namespace NATS_Sub1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to the NATS server
            IConnection connection = new ConnectionFactory().CreateConnection();

            // Subscribe to a subject
            IAsyncSubscription subscription = connection.SubscribeAsync("sub1");
            subscription.MessageHandler += (sender, argz) =>
            {
                string message = Encoding.UTF8.GetString(argz.Message.Data);
                Console.WriteLine("Received: " + message);
            };
            subscription.Start();

            Console.WriteLine("Subscriber started. Press Enter to exit.");
            Console.ReadLine();

            // Unsubscribe and close the connection
            //subscription.Unsubscribe();
            //connection.Close();
        }
    }
}
