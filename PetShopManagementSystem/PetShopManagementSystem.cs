using System;
using System.Diagnostics;
using System.Linq;

namespace PetShopManagementSystem
{ 
    internal class PetShopManagementSystem
    {
        static short ShowMenu(string[] items, string header = "")
        {
            short selected = 0;
            while (true)
            {
                Console.Clear();
                if (header != "") Console.WriteLine(header);

                for (short i = 0; i < items.Length; i++)
                {
                    if (i == selected) 
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"  >> {items[i]} <<");
                        Console.ResetColor();
                    }
                    else
                        Console.WriteLine($"    {items[i]}");
                }

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.UpArrow && selected > 0) selected--;
                if (key.Key == ConsoleKey.DownArrow && selected < items.Length - 1) selected++;
                if (key.Key == ConsoleKey.Enter) return selected;
                if (key.Key == ConsoleKey.Escape) return -1;
            }
        }
        static void Main(string[] args)
        {
            decimal balance = 300m;

            string[] insideMypets = { "Show them", "PLay" };
            string[] animalTypes = { "Cats", "Dogs", "Fish" }; 
            string[] playMenu = { "Eat", "Sleep", "Play", "Show More Information" }; 
            string[] mainMenu = { "Buy pets", "My pets", "Balance", "Exit" }; 

            short indMyPtes = 0;
            Animal[] myPets = new Animal[10];

            Animal[][] pets = new Animal[][]
            {
                new Cat[]
                {
                    new Cat("Tom", 1, true, 100.0f, 150.0m, 100.0f),
                    new Cat("Bella", 1, false, 100.0f, 120.0m, 100.0f),
                    new Cat("Whisker", 1, true, 100.0f, 200.0m, 100.0f),
                },
                new Dog[]
                {
                    new Dog("Rex", 1, true, 100.0f, 300.0m, 100.0f),
                    new Dog("Buddy", 1, true, 100.0f, 250.0m, 100.0f),
                    new Dog("Luna", 1, false, 100.0f, 180.0m, 100.0f),
                },
                new Fish[]
                {
                    new Fish("Nemo", 1, true, 100.0f, 50.0m, 100.0f),
                    new Fish("Dory", 1, false, 100.0f, 45.0m, 100.0f),
                    new Fish("Goldie", 1, true, 100.0f, 30.0m, 100.0f),
                },
            };

            short mainSelected = ShowMenu(mainMenu, "|| Pet Management System ||");

            while (true)
            {
                if (mainSelected == 0)
                {
                    short typeSelected = ShowMenu(animalTypes, "=== Select Animal Type ===");

                    if (typeSelected != -1)
                    {
                        short animalSelected = ShowMenu( Array.ConvertAll(pets[typeSelected], a => a.GetName()), "=== Select Animal ===" );
                        if (balance < pets[typeSelected][animalSelected].GetPrice())
                        {
                            Console.Write("You have not enough money!");
                            Console.ReadKey(true);
                        }
                        else if (balance >= pets[typeSelected][animalSelected].GetPrice() && indMyPtes < 10)
                        {
                            myPets[indMyPtes] = pets[typeSelected][animalSelected];
                            indMyPtes++;
                            balance -= pets[typeSelected][animalSelected].GetPrice();
                            Console.Write($"You got {pets[typeSelected][animalSelected].GetName()}.");
                            Console.ReadKey(true);
                        } 
                    }
                }
                else if (mainSelected == 1)
                {   
                        short indInsideMypets = ShowMenu(insideMypets, "=== My Pets ===");

                        if(indInsideMypets == 0)
                        {
                            if (indMyPtes == 0)
                            {
                                Console.Clear();
                                Console.Write("=== My Pets ===\nEmpty.");
                                Console.ReadKey(true);
                            }

                            else
                            {
                                Console.Clear();
                                Console.Write("=== My Pets ===\n");

                                for (short i = 0; i < indMyPtes; i++)
                                {
                                    Console.WriteLine($"{i + 1}. {myPets[i].GetName()}");
                                }
                                Console.ReadKey(true);
                            }
                        }

                        else if(indInsideMypets == 1)  
                        {
                            if (indMyPtes == 0)
                            { 
                                Console.Write("Please buy a pet.");
                                Console.ReadKey(true);
                            }
                            else
                            {
                                short indPetSelected = ShowMenu( Array.ConvertAll(myPets.Take(indMyPtes).ToArray(), a => a.GetName()), "=== Choose a pet ===");

                                if (indPetSelected != -1)
                                {
                                    short indPlay = ShowMenu(playMenu, "=== Play Section ===");

                                    switch (indPlay)
                                    {
                                        case 0: myPets[indPetSelected].Eat(); break;
                                        case 1: myPets[indPetSelected].Play(); break;
                                        case 2: myPets[indPetSelected].Sleep(); break;
                                        case 3: myPets[indPetSelected].ShowMoreInfo(); break;
                                        default: break;
                                    }
                                    Console.ReadKey(true);
                                }
                            }
                        } 
                    }
                else if (mainSelected == 2)
                {
                    Console.Clear();
                    Console.Write($"Current Balance: {balance}");
                    Console.ReadKey(true);
                }
                else if (mainSelected == 3) break;

                mainSelected = ShowMenu(mainMenu, "|| Pet Management System ||");
            }
        }
    }
}

//short indMP = ShowMenu(Array.ConvertAll(pets[indInsideMypets], a => a.GetName()), "=== Select Animal ===");