using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    internal class Client  
    {
        private int _id { get; set; }
        private string _name { get; set; }
        private string _surname { get; set; }
        private int _age { get; set; }
        private decimal _salary { get; set; }
        private BankCard _BankCardBankAccount { get; set; }

        public Client(int id, string name, string surname, int age, decimal salary, BankCard bankCardBankAccount)
        {
            _id = id;
            _name = name;
            _surname = surname;
            _age = age;
            _salary = salary;
            _BankCardBankAccount = bankCardBankAccount;
        }

        public int Id => _id;
        public string Name => _name;
        public string Surname => _surname;
        public int Age => _age;
        public decimal Salary => _salary;
        public BankCard BankCardBankAccount => _BankCardBankAccount;
    }
}
