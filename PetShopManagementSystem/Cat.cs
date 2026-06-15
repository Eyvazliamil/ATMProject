using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PetShopManagementSystem
{
    internal class Cat : Animal
    {
        public Cat(string nickname, short age, bool gender, float energy, decimal price, float mealQuantity) 
            : base(nickname, age, gender, energy, price, mealQuantity) {}
        public Cat(Cat other) : base(other) { }

        public Cat()
        {

        }

        public override void Eat()
        {
            if(MealQuantity == 100.0)
                Console.WriteLine($"{Nickname} is full.");
            else
                Console.WriteLine($"{Nickname} is eating.");
        }
        public override void Sleep()
        {
            if (Energy == 100.0) 
                Console.WriteLine($"{Nickname} is not tired."); 
            else
            {
                Console.WriteLine($"{Nickname} is sleeping."); Energy += 20; 
            }
        }
        public override void Play()
        {
            Energy -= 15;
            MealQuantity -= 10;

            if (Energy <= 0)
            {
                Energy = 0;  
                Console.WriteLine($"{Nickname} went to bed. Zzz...");
                Sleep();
            }
            else if (Energy < 15)   
                Console.WriteLine($"{Nickname} is tired, give {Nickname} some rest."); 
            else if (MealQuantity < 30)
                Console.WriteLine($"{Nickname} is hungry, give {Nickname} some food.");
            else
                Console.WriteLine($"{Nickname} is playing.");
        }
        public void Show()
        {
            Console.WriteLine($"Nickname: {Nickname}");
            Console.WriteLine($"Energy: {Energy}");
            Console.WriteLine($"MealQuantity: {MealQuantity}");
            Console.WriteLine($"Price: {Price}");   
        }
        public void ShowMoreInfo()
        {
            Console.WriteLine($"Nickname: {Nickname}");
            Console.WriteLine($"Energy: {Energy}");
            Console.WriteLine($"MealQuantity: {MealQuantity}");
            Console.WriteLine($"Price: {Price}");   
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Gender: {(Gender ? "Male" : "Female")}");
        }

        public void RemoveByNickName()
        {
                                          
        }
        public string getNickName() => Nickname;
    }
}
