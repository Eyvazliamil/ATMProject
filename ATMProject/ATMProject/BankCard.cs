using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject
{
    internal class BankCard
    {

        private string _bankName { get; set; }
        private string _fullName{ get; set; }
        private string _PAN{ get; set; }
        private string _PIN{ get; set; }
        private string _CVC { get; set; }
        private DateTime _expireDate{ get; set; }
        private decimal _balance{ get; set; }
        
        public BankCard(string bankName, string fullName, string PAN, string PIN, string CVC, DateTime expireDate, decimal balance)
        {
            _bankName = bankName;
            _fullName = fullName;
            _PAN = PAN;
            _PIN = PIN;
            _CVC = CVC;
            _expireDate = expireDate;
            _balance = balance;
        }

        public string BankName => _bankName;
        public string FullName => _fullName;
        public string PAN => _PAN;
        public string PIN => _PIN;
        public string CVC => _CVC;
        public DateTime ExpireDate => _expireDate;
        public decimal Balance => _balance;
        public void Withdraw(decimal amount)
        {
            _balance -= amount;
        }

        public void Transfer(decimal amount, Client Toclient)
        {
            _balance -= amount;
            Toclient.BankCardBankAccount._balance += amount;
        }


    }
}
