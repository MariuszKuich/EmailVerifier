using System;
using System.Threading;

namespace EmailVerifier
{
    class Program
    {
        static void Main(string[] args)
        {
            Display.DisplayHeader();
            Connection.LoadApiKey();
            Connection connect = new Connection();
            string address;
            bool empty;
            while (true)
            {
                Dialog(out address, out empty);
                if (empty) continue;
                CheckIfExit(address);
                connect.MakeRequest(address);
            }
        }
        static void Dialog(out string address, out bool empty)
        {
            empty = false;
            Console.WriteLine();
            Console.Write("Enter e-mail address (type 'exit' to terminate the application): ");
            address = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(address))
            {
                Console.WriteLine("Field 'Enter e-mail address' cannot be empty.");
                empty = true;
            }
        }

        static void CheckIfExit(string address)
        {
            if (address.ToLower() == "exit")
            {
                Console.WriteLine();
                Console.WriteLine("Thank You for your time.");
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }
    }
}