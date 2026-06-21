using DocumentFormat.OpenXml.Spreadsheet;
using SocialMediaManagementSystem.EmailSpace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaManagementSystem.NetworkNamespace
{
    internal class LoginAndRegter
    {
        Mail mail = new Mail();

        public static bool Login(string fileName)
        {
            if (File.Exists(fileName))
            {
                Console.Clear();
                Console.WriteLine("=== Log in ===");
                string[] lines = File.ReadAllLines(fileName);
                Console.Write("Enter password: "); string ent_pasw = Console.ReadLine();

                for (short i = 2; i < lines.Length; i += 4)
                {
                    if (ent_pasw == lines[i])
                    {
                        Console.WriteLine("access granted!");
                        return true;
                    } 
                }
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Access Denied");
                Console.ResetColor();
                return false;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("File Not Found!");
                Console.ResetColor();
                return false;
            }
        }

        public void Register(string fileName)
        {
            Console.Clear();
            Console.WriteLine("=== Register ===");
            Console.Write("User Name: "); string us_n = Console.ReadLine();
            Console.Write("E-mail: "); string em = Console.ReadLine();
            if (em.Contains("@"))
                mail.SetMail(em); 
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("E-Mail must contain '@'");
                Console.ResetColor(); return;
            }
            Console.Write("Set a password: "); string s_pasw = Console.ReadLine();
            Console.Write("Verify your password: "); string vrf_pasw = Console.ReadLine();

            if (s_pasw == vrf_pasw)
            {
                File.WriteAllText(fileName, $"{us_n}\n{em}\n{s_pasw}\n{vrf_pasw}"); 
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Press any button to continue...");
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Incorrect password!");
                Console.ResetColor();
            }
        }
    }
}
