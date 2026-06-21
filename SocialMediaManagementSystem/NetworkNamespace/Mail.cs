using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SocialMediaManagementSystem.EmailSpace
{
    internal class Mail
    { 
        private string _mail { get; set; }
        public string mailFile = "mail.txt";

        public Mail(string mail)
        {
            _mail = mail;
        }

        public Mail()  { }

        public string getMail() => _mail;

        public void SetMail(string email)
        {
            _mail = email;
             
            if (File.Exists(mailFile))
            {
                string[] existing = File.ReadAllLines(mailFile);
                if (existing.Contains(_mail))
                    return;  
            }

            File.AppendAllText(mailFile, _mail + "\n");
        }

        public void showEmail()
        {
            Console.Clear();
            Console.WriteLine("=== E-Mail ===");
            string[] lines = File.ReadAllLines(mailFile);
            foreach (string l in lines) 
                Console.WriteLine(l); 
        }

        public void DeleteMail()
        {
            var lines = File.ReadAllLines(mailFile).ToList();
            if (lines.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("===== Your E-Mails =====");
                Console.WriteLine("No e-mail yet."); return;
            }
            else
            {
                short ind = main.showMenu(lines.ToArray(), "===== Your E-Mails =====");
                if (ind == -1) return;

                lines.RemoveAt(ind);

                File.WriteAllLines(mailFile, lines);
                Console.Clear();
                Console.WriteLine("=== Delete E-Mail ===");
                Console.Write("E-Mail was deleted.");
            }
        }
    }


}
