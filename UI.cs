using System;
using System.Threading;

namespace Panashe.CybersecurityAwareness
{
    class UI
    {
        public static void ShowLogo()
        {
            Console.Clear();                    // <-- This helps remove any leftover text
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("=====================================");
            Console.WriteLine("   CYBERSECURITY AWARENESS CHATBOT   ");
            Console.WriteLine("=====================================\n");
            Console.ResetColor();
        }

        public static void TypeEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(40);
            }
            Console.WriteLine();
        }
    }
}