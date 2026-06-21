using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagementSystem.EmailSpace;
using SocialMediaManagementSystem.NetworkNamespace;

namespace SocialMediaManagementSystem.AdminNamespace
{
    internal class Admin  
    {
        public Guid _id { get; set; }
        public string _username { get; set; }
        public Mail _email { get; set; }
        public string _password { get; set; }
        public string _posts { get; set; }
        public Notification _notifications { get; set; }

        public Admin()
        {
            
        }
        public Admin(Guid id, string username, Mail email, string password, string posts, Notification notifications)
        {
            _id = id;
            _username = username;
            _email = email;
            _password = password;
            _posts = posts;
            _notifications = notifications;
        }

        public Guid getId() => _id;
        public string getUsername() => _username;
        public Mail getEmail() => _email;
        public string getPassword() => _password;
        public string getPosts() => _posts;
        public Notification getNotifications() => _notifications; 
         
    }
}
