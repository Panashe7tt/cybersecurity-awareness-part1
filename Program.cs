using System;

namespace Panashe.CybersecurityAwareness
{
    class Program
    {
        static void Main(string[] args)
        {
            Audio.PlayGreeting();

            // Show logo after greeting sound
            Chatbot.ShowLogo();

            // Ask for user name
            Console.Write("Bot: Hello! What is your name?\n");
            string? nameInput = Console.ReadLine();
            string name = string.IsNullOrWhiteSpace(nameInput) ? "User" : nameInput.Trim();

            Console.WriteLine($"Bot: Welcome {name}!");

            User user = new User(name);

            // Start chatbot with the exact KanyaShield introduction
            Chatbot.Start(user.Name);
        }
    }
}