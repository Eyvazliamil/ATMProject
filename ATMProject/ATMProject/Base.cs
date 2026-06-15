using System;

namespace ATMProject
{
    internal class Base
    { 
        static void Main(string[] args)
        {

            Bank bank = new Bank();
            string[] mainMenu = { "Balance", "Cash", "Transfer", "History", "Exit" };

            short mainSelected = 0;
            short cashSelected = 0;


            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============================");
                Console.WriteLine("||       ATM MACHINE       ||");
                Console.WriteLine("=============================");

                for (short i = 0; i < mainMenu.Length; i++)
                {
                    if (i == mainSelected)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine($" >>  {mainMenu[i]}  <<");
                        Console.ResetColor();
                    }
                    else 
                        Console.WriteLine($"   {mainMenu[i]}  "); 
                }

                Console.WriteLine("=============================");
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && mainSelected > 0)
                    mainSelected--;

                if (key.Key == ConsoleKey.DownArrow && mainSelected < mainMenu.Length - 1)
                    mainSelected++;

                if (key.Key == ConsoleKey.Enter)
                {
                    if (mainSelected == 0)
                    {
                        Client selectedClient = bank.SelectClient();
                        bank.ShowCardBalance(selectedClient);
                        bank.saveProcess($"Process: {mainMenu[mainSelected]}\nDate: {DateTime.Now}");
                    } 
                    else if (mainSelected == 1)
                    {
                        Client selectedClient = bank.SelectClient();
                        bank.showWithdrawMoney(selectedClient);
                        bank.saveProcess($"Process: {mainMenu[mainSelected]}\nDate: {DateTime.Now}");
                    }
                    else if (mainSelected == 2)
                    {
                        Client selectedClient = bank.SelectClient();
                        bank.trasferMoney(selectedClient);
                        bank.saveProcess($"Process: {mainMenu[mainSelected]}\nDate: {DateTime.Now}");
                    }
                    else if (mainSelected == 3)
                    { 
                        bank.showHistory();
                    }
                    else if (mainSelected == 4) break; 

                }

            }
        }
    }
}
