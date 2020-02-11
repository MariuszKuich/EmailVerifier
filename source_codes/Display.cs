using System;
using System.Threading;

namespace EmailVerifier
{
    public static class Display
    {
        public static void DisplayHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("# E-mail Verifier #");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("# Author: Mariusz #");
            Console.WriteLine("#   Version 1.0   #");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Application verifies correctness of entered e-mail address' syntax and performs SMTP check on given e-mail address.");
        }

        public static void ShowEmailInfo(EmailData email)
        {
            if (ColorPrint("Valid format:\t\t\t\t", email.Format_valid))
                if (ColorPrint("SMTP check (deliverability):\t\t", email.Smtp_check))
                    PrintScore(email.Score);
        }
        
        public static void ShowErrorInfo(ErrorContent error)
        {
            Console.WriteLine("Request failed.");
            Console.WriteLine("Error code:\t" + error.Error.Code);
            Console.WriteLine("Error type:\t" + error.Error.Type);
            Console.WriteLine("Error message:\t" + error.Error.Info);
        }
        
        public static void ClearLine()
        {
            if(Environment.OSVersion.ToString().ToLower().Contains("windows"))
            {
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, Console.CursorTop);
                Console.Write(new string(' ', Console.WindowWidth));
                Console.SetCursorPosition(0, currentLineCursor);
            }
            else Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
        }
        
        public static void ProcessingLoop()
        {
            Console.Write("Processing.");
            Thread.Sleep(100);
            ClearLine();
            Console.Write("Processing..");
            Thread.Sleep(100);
            ClearLine();
            Console.Write("Processing...");
            Thread.Sleep(100);
            ClearLine();
        }

        public static bool ColorPrint(string message, bool valid)
        {
            Console.Write(message);
            if (valid) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(valid.ToString());
            Console.ResetColor();
            return valid;
        }
        
        public static void PrintScore(float score)
        {
            Console.Write("Quality and deliverability (scale 0-1):\t");
            if (score <= 0.4) Console.ForegroundColor = ConsoleColor.Red;
            else if (score <= 0.7) Console.ForegroundColor = ConsoleColor.Yellow;
            else Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(score);
            Console.ResetColor();
        }
    }
}