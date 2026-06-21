using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SocialMediaManagementSystem.NetworkNamespace
{
    internal class Notification
    {
        public string notificationsFile = "notifications.txt";

        public Guid _id { get; set; }
        public string _text { get; set; }
        public DateTime _dateTime { get; set; }
        public string _fromUser { get; set; } 
        public Notification(Guid id, string text, DateTime dateTime, string fromUser)
        {
            _id = id;
            _text = text;
            _dateTime = dateTime;
            _fromUser = fromUser;
        }

        public Notification() { }

        public Guid getId() => _id;
        public string getText() => _text;
        public DateTime getDateTime() => _dateTime;
        public string getFromUser() => _fromUser;

        public void sendMessage(string message, string fromUser = "Unknown")
        {
            _text = message;
            _fromUser = fromUser;
            _dateTime = DateTime.Now;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.ResetColor();

            File.AppendAllText(notificationsFile, $"{fromUser}: {message} , {_dateTime}\n");
        }

        public void showNotification()
        {
            Console.Clear();
            Console.WriteLine("=== Notifications ===");

            if (!File.Exists(notificationsFile))
            {
                Console.WriteLine("No notifications yet.");
                Console.ReadKey(true);
                return;
            }

            string[] notf = File.ReadAllLines(notificationsFile);
            foreach (string n in notf)
                Console.WriteLine(n);
        }

    }
}
