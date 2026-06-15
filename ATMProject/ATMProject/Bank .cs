using ATMProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.IO;

namespace ATMProject
{
    internal class Bank
    {
        Client[][] Clients = new Client[5][];
        public Bank()
        {

            Clients[0] = new Client[]
            {
                new Client(1, "Murad", "Aliyev", 30, 1500.00m, new BankCard("ABB", "Murad Aliyev", "4169123456781234", "1234", "123", new DateTime(2027, 5, 1), 500.00m)),
                new Client(2, "Leyla", "Hasanova", 25, 2000.00m, new BankCard("ABB", "Leyla Hasanova", "4169123456785678", "5678", "456", new DateTime(2026, 8, 1), 1200.00m))
            };

            Clients[1] = new Client[]
            {
             new Client(3, "Tural", "Mammadov", 35, 3000.00m, new BankCard("Kapital", "Tural Mammadov", "5168123456781111", "2222", "789", new DateTime(2028, 3, 1), 800.00m))
            };

            Clients[2] = new Client[]
            {
                new Client(4, "Ayten", "Guliyeva", 28, 1800.00m, new BankCard("PASHA", "Ayten Guliyeva", "4111123456782222", "3333", "321", new DateTime(2027, 11, 1), 2500.00m)),
                new Client(5, "Rauf", "Babayev", 40, 5000.00m, new BankCard("PASHA", "Rauf Babayev", "4111123456783333", "4444", "654", new DateTime(2026, 12, 1), 700.00m)),
                new Client(6, "Nigar", "Suleymanova", 22, 1200.00m, new BankCard("PASHA", "Nigar Suleymanova", "4111123456784444", "5555", "987", new DateTime(2029, 1, 1), 300.00m))
            };

            Clients[3] = new Client[]
            {
                new Client(7, "Elchin", "Huseynov", 45, 6000.00m, new BankCard("Xalq Bank", "Elchin Huseynov", "6219123456785555", "6666", "111", new DateTime(2027, 7, 1), 1500.00m))
            };

            Clients[4] = new Client[]
            {
                new Client(8, "Sabina", "Nasirov", 33, 2500.00m, new BankCard("ABB", "Sabina Nasirov", "4169123456786666", "7777", "222", new DateTime(2028, 6, 1), 950.00m)),
                new Client(9, "Kamran", "Ismayilov", 29, 3200.00m, new BankCard("Kapital", "Kamran Ismayilov", "5168123456787777", "8888", "333", new DateTime(2027, 2, 1), 400.00m))
            };
        }

        public Client SelectClient()
        {  
            int total = 0;
            for (int i = 0; i < Clients.Length; i++)
                total += Clients[i].Length;
             
            Client GetClient(int index)
            {
                int count = 0;
                for (int i = 0; i < Clients.Length; i++)
                    for (int j = 0; j < Clients[i].Length; j++)
                    {
                        if (count == index) return Clients[i][j];
                        count++;
                    }
                return null;
            }

            short select = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============================");
                Console.WriteLine("||     SELECT CUSTOMER      ||");
                Console.WriteLine("=============================");

                int idx = 0;
                for (int i = 0; i < Clients.Length; i++)
                {
                    for (int j = 0; j < Clients[i].Length; j++)
                    {
                        if (idx == select)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine($" >> {Clients[i][j].Name} {Clients[i][j].Surname} <<");
                            Console.ResetColor();
                        }
                        else
                            Console.WriteLine($"    {Clients[i][j].Name} {Clients[i][j].Surname}");
                        idx++;
                    }
                }

                Console.WriteLine("=============================");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && select > 0) select--;
                if (key.Key == ConsoleKey.DownArrow && select < total - 1) select++;
                if (key.Key == ConsoleKey.Enter) return GetClient(select);
            }
        }

        public void ShowCardBalance(Client client)
        {
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine($"  Name:     {client.Name} {client.Surname}");
            Console.WriteLine($"  Bank:     {client.BankCardBankAccount.BankName}");
            Console.WriteLine($"  Balance:  {client.BankCardBankAccount.Balance} AZN");
            Console.WriteLine("=============================");
            Console.WriteLine("Press the button to continue...");
            Console.ReadKey();
        }


        public string SelectMoney(Client client)
        {
            string[] CashMenu = { "10 AZN", "20 AZN", "50 AZN", "100 AZN", "Others" };
            short select = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============================");
                Console.WriteLine("||     WITHDRAW MONEY      ||");
                Console.WriteLine("=============================");

                for (int i = 0; i < CashMenu.Length; i++)
                {
                    if (i == select)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($" >> {CashMenu[i]}  <<");
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine($"    {CashMenu[i]}    ");
                }

                Console.WriteLine("=============================");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && select > 0) select--;
                if (key.Key == ConsoleKey.DownArrow && select < CashMenu.Length - 1) select++;
                if (key.Key == ConsoleKey.Enter)
                {
                    if (select != 4) return CashMenu[select];
                    else
                    {
                        Console.Write("How much money do you want to withdraw? ");
                        string money = Console.ReadLine(); 
                        try
                        {
                            if (decimal.Parse(money) <= client.BankCardBankAccount.Balance) 
                                return money;

                            else
                            { 
                                throw new Exception("Insufficient balance!");
                            }
                        }
                        catch (Exception exp)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"Error: {exp.Message}");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public bool pinSystem(Client client)
        {
            Console.Clear();
            Console.Write("Please enter your PIN: ");
            string pin = Console.ReadLine();

            if (pin == client.BankCardBankAccount.PIN) 
                return true; 

            else
                return false;
        }

        public bool panSystem(Client client)
        {
            Console.Clear();
            Console.Write("Please enter your PAN: ");
            string pan = Console.ReadLine();

            if (pan == client.BankCardBankAccount.PAN) 
                return true; 

            else
                return false;
        }
        public void showWithdrawMoney(Client client)
        {
            bool isTrue = pinSystem(client);
            if (isTrue)
            {
                string amount = SelectMoney(client);
                string onlyNumber = amount.Replace(" AZN", "");
                decimal amountDecimal = decimal.Parse(onlyNumber);
                client.BankCardBankAccount.Withdraw(amountDecimal);
                Console.Clear();
                Console.WriteLine("====== Withdraw Money ======");
                Console.WriteLine($"  Amount: {amount}");
                Console.WriteLine($"  Balance: {client.BankCardBankAccount.Balance} AZN");
                Console.WriteLine("============================");
                Console.WriteLine("Press the button to continue...");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("PIN is not correct!");
                Console.ResetColor();
                Console.ReadKey();
            }

        }

        public string SelectMoneyToTransfer(Client client)
        {
            string[] CashMenu = { "10 AZN", "20 AZN", "50 AZN", "100 AZN", "Others" };
            short select = 0;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============================");
                Console.WriteLine("||     TRANSFER MONEY      ||");
                Console.WriteLine("=============================");

                for (int i = 0; i < CashMenu.Length; i++)
                {
                    if (i == select)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($" >> {CashMenu[i]}  <<");
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine($"    {CashMenu[i]}    ");
                }

                Console.WriteLine("=============================");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && select > 0) select--;
                if (key.Key == ConsoleKey.DownArrow && select < CashMenu.Length - 1) select++;
                if (key.Key == ConsoleKey.Enter)
                {
                    if (select != 4) return CashMenu[select];
                    else
                    {
                        Console.Write("How much money do you want to transfer? ");
                        string money = Console.ReadLine();
                        try
                        {
                            if (decimal.Parse(money) <= client.BankCardBankAccount.Balance)
                                return money;

                            else
                            {
                                throw new Exception("Insufficient balance!");
                            }
                        }
                        catch (Exception exp)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine($"Error: {exp.Message}");
                            Console.ResetColor();
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        public void trasferMoney(Client client)
        { 
            bool isTrue1 = pinSystem(client);;
            if (isTrue1)
            {
                Client toWhom = SelectClient();
                
                if(client.Id != toWhom.Id)
                {
                    bool isTrue2 = panSystem(toWhom);
                    if (isTrue2)
                    {
                        string amount = SelectMoneyToTransfer(client);
                        string onlyNumber = amount.Replace(" AZN", "");
                        decimal amountDecimal = decimal.Parse(onlyNumber);

                        Console.Clear();
                        client.BankCardBankAccount.Transfer(amountDecimal, toWhom);

                        Console.Clear();
                        Console.WriteLine("====== Transfer Money ======");
                        Console.WriteLine($"Bank:       {client.BankCardBankAccount.BankName}");
                        Console.WriteLine($"From:       {client.BankCardBankAccount.FullName}");
                        Console.WriteLine($"To:         {toWhom.BankCardBankAccount.FullName} ({toWhom.BankCardBankAccount.BankName})");
                        Console.WriteLine($"Amount::    {amountDecimal}");
                        Console.WriteLine("============================");
                        Console.WriteLine("Press the button to continue...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("PAN is not correct!");
                        Console.ResetColor();
                        Console.ReadKey();
                    }
                }
                else
                { 
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("You can't transfer money to yourself!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("PIN is not correct!");
                Console.ResetColor();
                Console.ReadKey();
            }
        }


        string path = "history.txt";
        public void saveProcess(string process)
        {   
            File.AppendAllText(path, $"\n{process}\n"); 
        } 
        public void showHistory()
        {
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                Console.Clear();
                Console.WriteLine("======= File Content =======");
                Console.WriteLine(content);
                Console.WriteLine("============================");
                Console.WriteLine("Press the button to continue...");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("File not found.!");
                Console.ResetColor(); Console.ReadKey();
            }
            Console.ReadKey();
        }

        // For Admin
        // ==================================================================
        //public void clearHistory()
        //{
        //    if (File.Exists(path))
        //    {
        //        File.WriteAllText(path, "");  
        //        Console.WriteLine("History cleared.");
        //    }
        //    else
        //    { 
        //        Console.ForegroundColor = ConsoleColor.DarkRed;
        //        Console.WriteLine("No history found.");
        //        Console.ResetColor();

        //    }
        //}
        // ==================================================================
    }

}
