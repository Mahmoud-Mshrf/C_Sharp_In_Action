using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Abstraction
{
    public class Notifier : INotifier
    {
        public Notifier(string stmpServer ,int port,string senderAddress,string senderPassword)
        {
            StmpServer = stmpServer;
            Port = port;
            SenderAddress = senderAddress;
            SenderPassword = senderPassword;
        }

        public string StmpServer { get; }
        public int Port { get; }
        public string SenderAddress { get; }
        public string SenderPassword { get; }

        public void Notify(string email,string subject ,string body)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"You have a new email from {SenderAddress} with subject {subject}");
            Console.WriteLine(body);
            Console.WriteLine($"message sent successfully to {email}");
            Console.WriteLine("**************************************");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
