using System;
using System.Text;
using System.Threading;
using NATS.Client;

namespace NATS_Pub
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to the NATS server
            IConnection connection = new ConnectionFactory().CreateConnection();

            // Publish a message
            string message = "Message is: ";
            string sub1 = "sub1";
            string sub2 = "sub2";


            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(100);
                if (i % 2 == 0)
                {
                    connection.Publish(sub2, Encoding.UTF8.GetBytes(message + i));
                }
                else
                {
                    connection.Publish(sub1, Encoding.UTF8.GetBytes(message + i));
                }
                Console.WriteLine("Published: [" + message + i+"]");
            }

            
            Console.Read();
            // Close the connection
            //connection.Close();
        }
    }
}
