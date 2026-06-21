using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaManagementSystem.EmailSpace;

namespace SocialMediaManagementSystem.PostNameSpace
{
    internal class User
    {
        public Guid _id { get; set; }
        public string _name { get; set; } 
        public string _surname { get; set; }
        public short _age { get; set; }
        public Mail _email { get; set; }
        public string _password { get; set; }

        public User()
        {
            
        }
        public User(Guid id, string name, string surname, short age, Mail email, string password)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _age = age;
            _email = email;
            _password = password; 
        }

        public Guid getId() => _id;
        public string getName() => _name;
        public short getAge() => _age;
        public string getSurname() => _surname;
        public Mail getEmail() => _email;
        public string getPassword() => _password;

    }
}
