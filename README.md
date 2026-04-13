Cybersecurity Awareness Chatbot

A friendly, interactive C# console chatbot that teaches users about cybersecurity threats and best practices. Named "Nash", this bot provides easy-to-understand explanations and examples for common security topics.

Features

- Audio greeting on startup (works on Windows, macOS, and Linux)
- Clean bordered UI with colored console output
- Typing effect support (ready to integrate)
- 22+ cybersecurity topics including phishing, ransomware, strong passwords, two-factor authentication (2FA), VPNs, firewalls, encryption, mobile security, social engineering, and more
- Help menu available anytime by typing "help"
- Exit command to close the chatbot by typing "exit"

Available Commands

Type "help" to show the full menu of topics
Type "exit" to close the chatbot

Example Topics to Type

phishing
strong password
ransomware
2fa or two-factor
vpn
backup
social engineering
get hacked
personal information

Type "help" in the chatbot to see the complete list of topics.

Technologies Used

Language: C# (.NET 8.0)
Framework: .NET Console Application
Audio: Cross-platform support using SoundPlayer for Windows, afplay for macOS, and paplay/aplay/ffplay for Linux

Project Structure

CybersecurityChatbot/
├── Program.cs          Entry point
├── User.cs             User class that stores the user's name
├── Chatbot.cs          Main chatbot logic and responses
├── Audio.cs            Cross-platform audio playback
├── UI.cs               UI helpers for logo and typing effect
├── CybersecurityChatbot.csproj  Project file
└── README.md           This file

How to Run Locally

Prerequisites:
- .NET 8.0 SDK or later installed
- Audio file named "greetings (1).wav" in the project directory (optional)

Steps:
1. Clone the repository
2. Navigate to the project folder
3. Run the command: dotnet run
4. Interact with Nash by typing "help" to see all topics or "exit" to quit

Continuous Integration (CI)

This project uses GitHub Actions for CI. On every push or pull request, the workflow will:
- Restore dependencies using dotnet restore
- Build the project using dotnet build
- Run tests if added later (currently optional)

Future Improvements

- Integrate UI.TypeEffect() for more natural conversations
- Add unit tests
- Add more cybersecurity topics
- Save conversation history
- Add quiz mode to test user knowledge

Author

Created as a Cybersecurity Awareness tool.

Stay Safe. Stay Smart. Stay Secure.
