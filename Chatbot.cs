using System;
using System.IO;
using System.Linq;

namespace Panashe.CybersecurityAwareness
{
    class Chatbot
    {
        // Helper: print a bordered box around the provided text
        private static void PrintBox(string content, int padding = 1, ConsoleColor borderColor = ConsoleColor.DarkGray, ConsoleColor textColor = ConsoleColor.White)
        {
            if (content == null) content = string.Empty;
            var lines = content.Replace("\r", "").Trim('\n').Split('\n');
            int max = lines.Any() ? lines.Max(l => l.Length) : 0;
            int innerWidth = max + padding * 2;

            Console.ForegroundColor = borderColor;
            Console.Write('╔');
            Console.Write(new string('═', innerWidth));
            Console.WriteLine('╗');

            foreach (var raw in lines)
            {
                string line = raw;
                Console.ForegroundColor = borderColor;
                Console.Write('║');
                Console.ForegroundColor = textColor;
                Console.Write(new string(' ', padding));
                Console.Write(line.PadRight(max));
                Console.Write(new string(' ', padding));
                Console.ForegroundColor = borderColor;
                Console.WriteLine('║');
            }

            Console.ForegroundColor = borderColor;
            Console.Write('╚');
            Console.Write(new string('═', innerWidth));
            Console.WriteLine('╝');
            Console.ResetColor();
        }
        public static void ShowLogo()
        {
            // Clear screen to ensure logo shows first
            Console.Clear();

            // Logo + title box
            string logo = @" ███╗   ██╗ █████╗ ███████╗██╗  ██╗
 ████╗  ██║██╔══██╗██╔════╝██║  ██║
 ██╔██╗ ██║███████║███████╗███████║
 ██║╚██╗██║██╔══██║╚════██║██╔══██║
 ██║ ╚████║██║  ██║███████║██║  ██║
 ╚═╝  ╚═══╝╚═╝  ╚═╝╚══════╝╚═╝  ╚═╝";

            string title = "NASH CYBER AWARENESS BOT\nSmart • Secure • Reliable\n\nStay Safe. Stay Smart. Stay Secure.";

            PrintBox(logo, padding: 2, borderColor: ConsoleColor.Cyan, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            PrintBox(title, padding: 2, borderColor: ConsoleColor.Green, textColor: ConsoleColor.DarkYellow);

            // Pause so user sees logo first
            System.Threading.Thread.Sleep(1200);

            // Separator
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("====================================================\n");
            Console.ResetColor();
        }
        public static void Start(string userName)
        {
            // Show menu and introduction (logo is shown from Program.Main via ShowLogo)
            string intro = $"Bot: Hey {userName}! I'm Nash Cyber Awareness Bot, your Coolest Cybersecurity Awareness Assistant.";
            PrintBox(intro, padding: 1, borderColor: ConsoleColor.DarkGray, textColor: ConsoleColor.White);

            // Small delay before showing menu
            System.Threading.Thread.Sleep(500);

            // Show menu
            ShowMenu();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{userName}: ");
                Console.ResetColor();

                string input = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    continue;
                }

                string lowerInput = input.ToLower();

                if (lowerInput == "exit")
                {
                    Console.WriteLine($"\nBot: Goodbye {userName}! Remember to stay safe online Darling.");
                    break;
                }
                else if (lowerInput == "help")
                {
                    ShowMenu();
                }
                else
                {
                    string response = GetResponse(input);
                    Console.WriteLine($"Bot: {response}");
                }
            }
        }

        private static void ShowMenu()
        {
            var topics = new string[]
            {
                "1. how are you",
                "2. purpose",
                "3. phishing",
                "4. strong password",
                "5. malware",
                "6. ransomware",
                "7. browse safely",
                "8. suspicious links",
                "9. avoid scams",
                "10. two-factor (2fa)",
                "11. vpn",
                "12. encryption",
                "13. software update",
                "14. firewall",
                "15. mobile security",
                "16. social engineering",
                "17. fake website",
                "18. email security",
                "19. backup",
                "20. why cybersecurity",
                "21. get hacked",
                "22. personal information"
            };

            string menu = "AVAILABLE TOPICS (type a keyword)\n\n" + string.Join("\n", topics) + "\n\nType the keyword shown above (for example: 'phishing' or 'backup').\nType 'help' anytime to see this again.\nType 'exit' to close the chatbot.";

            PrintBox(menu, padding: 1, borderColor: ConsoleColor.DarkGray, textColor: ConsoleColor.White);
        }

        private static string GetResponse(string input)
        {
            string lower = input.ToLower();

            if (lower.Contains("how are you"))
                return "I'm doing very well, thank you for asking! I'm ready to help you stay safe online. Example: Ask 'phishing' to learn about fake emails.";

            if (lower.Contains("purpose") || lower.Contains("what is your purpose"))
                return "I help you learn about common cyber threats and practical steps to protect yourself. Example: Type 'strong password' to get tips on creating one.";

            if (lower.Contains("phishing"))
                return "Explanation: Phishing is when attackers pretend to be someone you trust (like your bank) to steal information.\nExample: A fake email asking you to 'verify your account' with a link is often phishing—don't click it and verify directly with the company.";

            if (lower.Contains("strong password") || lower.Contains("create a strong password"))
                return "Explanation: A strong password is long and unique so attackers can't guess or reuse it.\nExample: Use a passphrase like 'Blue-Car!7River-Tea' or a password manager to generate and store one.";

            if (lower.Contains("malware"))
                return "Explanation: Malware is software designed to harm or take control of devices (viruses, trojans, spyware).\nExample: Downloading cracked software can install malware—stick to official sources and scan new files.";

            if (lower.Contains("ransomware"))
                return "Explanation: Ransomware encrypts your files and demands payment to unlock them.\nExample: If your documents suddenly can't be opened and you see a ransom note, that's ransomware—restore from backups and get professional help.";

            if (lower.Contains("browse safely") || lower.Contains("safe browsing"))
                return "Explanation: Safe browsing reduces the chance of infection or scams while online.\nExample: Check for 'https://' and a padlock before entering passwords, avoid suspicious pop-ups, and update your browser regularly.";

            if (lower.Contains("suspicious links"))
                return "Explanation: Suspicious links hide malicious sites or downloads.\nExample: Hover over a link to see the real address—if it goes to 'bank-login.xyz' instead of your bank's domain, don't click it.";

            if (lower.Contains("avoid scams"))
                return "Explanation: Scams pressure you to act fast or give money/info.\nExample: If someone claims you won a prize but asks for payment to claim it, it's a scam—ignore and verify through official channels.";

            if (lower.Contains("two-factor") || lower.Contains("2fa") || lower.Contains("two factor authentication"))
                return "Explanation: 2FA requires a second step (SMS code, authenticator app, or hardware key) beyond your password.\nExample: After entering your password, a code from an authenticator app prevents attackers who only have your password from signing in.";

            if (lower.Contains("vpn"))
                return "Explanation: A VPN encrypts your connection and can hide your IP address on public Wi-Fi.\nExample: Use a trusted VPN when on airport Wi-Fi to prevent others on the same network from eavesdropping on your traffic.";

            if (lower.Contains("encryption") || lower.Contains("encrypt"))
                return "Explanation: Encryption scrambles data so only authorized people can read it.\nExample: HTTPS encrypts the data between your browser and a website so login info isn't sent in plain text.";

            if (lower.Contains("software update") || lower.Contains("update software") || lower.Contains("keep my software updated"))
                return "Explanation: Updates fix security bugs attackers can exploit.\nExample: Enable automatic OS and browser updates so important patches install without you having to remember them.";

            if (lower.Contains("firewall"))
                return "Explanation: A firewall filters network traffic to block unauthorized access.\nExample: Keep your computer's firewall enabled and be careful when allowing apps to accept incoming connections.";

            if (lower.Contains("mobile") || lower.Contains("mobile device") || lower.Contains("phone") || lower.Contains("mobile security"))
                return "Explanation: Mobile security protects your phone and the data on it.\nExample: Use a strong passcode or biometrics, only install apps from official stores, and enable 'find my device' to erase it if stolen.";

            if (lower.Contains("spot fake website") || lower.Contains("fake website") || lower.Contains("pharming") || lower.Contains("spot fake sites"))
                return "Explanation: Fake websites try to look like real ones to steal your credentials.\nExample: Check the domain name for typos and the HTTPS padlock; if unsure, type the company's URL yourself instead of following a link.";

            if (lower.Contains("secure my email") || lower.Contains("email security") || lower.Contains("email"))
                return "Explanation: Email is a common attack vector, so protect it like other accounts.\nExample: Use a unique password, enable 2FA, and don't open attachments from unknown senders.";

            if (lower.Contains("backup") || lower.Contains("backup my data") || lower.Contains("back up"))
                return "Explanation: Backups let you restore files after hardware failure or ransomware.\nExample: Use the 3-2-1 rule: keep 3 copies of important files, on 2 types of media (local and external), with 1 copy offsite or in cloud storage.";

            if (lower.Contains("why is cybersecurity important") || lower.Contains("why cybersecurity"))
                return "Explanation: Cybersecurity protects your data, money, and identity from malicious actors.\nExample: Strong passwords, 2FA, and cautious browsing reduce the chance of account theft or fraud.";

            if (lower.Contains("get hacked") || lower.Contains("if i get hacked"))
                return "Friendly steps: 1) Change passwords for affected accounts and enable 2FA, 2) Run antivirus scans, 3) Contact banks if financial data was exposed, 4) Restore from backups if needed.\nExample: If your email is compromised, reset its password and any accounts that use that email to log in.";

            if (lower.Contains("protect my personal information") || lower.Contains("personal information"))
                return "Explanation: Protecting personal info reduces identity theft risk.\nExample: Limit what you post on social media, use unique passwords, and avoid entering personal data on unsecured sites.";

            if (lower.Contains("social engineering"))
                return "Explanation: Social engineering tricks people into giving secrets rather than hacking systems.\nExample: A caller pretending to be IT support asking for your password is social engineering—never share passwords over the phone.";

            return "I didn't quite understand that. Please type 'help' to see the list of questions I can answer.";
        }
    }
}