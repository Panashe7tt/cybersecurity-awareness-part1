using System;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Media;
//this code makes sure that the plays the audio file when the program starts, it checks both the current directory and one level up to find the file, and handles cases where the file is missing or cannot be played.

namespace Panashe.CybersecurityAwareness
{
    class Audio
    {
        public static void PlayGreeting()
        {
            string wavFileName = "greetings (1).wav";
            string? audioPath = null;

            // Check current directory (bin/Debug/net8.0 etc.)
            string currentPath = Path.Combine(Directory.GetCurrentDirectory(), wavFileName);
            if (File.Exists(currentPath))
            {
                audioPath = currentPath;
            }
            else
            {
                // Check one level up (project root - where your file actually is)
                var parent = Directory.GetParent(Directory.GetCurrentDirectory());
                if (parent != null)
                {
                    string parentPath = Path.Combine(parent.FullName, wavFileName);
                    if (File.Exists(parentPath))
                        audioPath = parentPath;
                }
            }

            if (string.IsNullOrEmpty(audioPath))
            {
                Console.WriteLine($"Warning: Could not find '{wavFileName}'");
                return;
            }

            try
            {
                // Use OS-specific players so audio will play on Windows, macOS and Linux
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    // Use SoundPlayer directly on Windows for reliable WAV playback
                    try
                    {
                        using (var player = new SoundPlayer(audioPath))
                        {
                            player.Load();
                            player.PlaySync();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Warning: Could not play audio on Windows - {ex.Message}");
                    }
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    // macOS has afplay
                    using (var p = Process.Start(new ProcessStartInfo
                    {
                        FileName = "afplay",
                        Arguments = $"\"{audioPath}\"",
                        UseShellExecute = false,
                        CreateNoWindow = true,
                    }))
                    {
                        p?.WaitForExit();
                    }
                }
                else // assume Linux/Unix
                {
                    // Try a few common players: paplay, aplay, ffplay
                    bool played = false;
                    string[] candidates = new[] { "paplay", "aplay", "ffplay" };
                    foreach (var cmd in candidates)
                    {
                        try
                        {
                            string args = cmd == "ffplay" ? $"-autoexit -nodisp \"{audioPath}\"" : $"\"{audioPath}\"";
                            using (var p = Process.Start(new ProcessStartInfo
                            {
                                FileName = cmd,
                                Arguments = args,
                                UseShellExecute = false,
                                CreateNoWindow = true,
                            }))
                            {
                                p?.WaitForExit();
                                played = true;
                                break;
                            }
                        }
                        catch
                        {
                            // try next
                        }
                    }

                    if (!played)
                    {
                        Console.WriteLine("Warning: No suitable audio player found on this system.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Warning: Could not play audio - {ex.Message}");
            }
        }
    }
}