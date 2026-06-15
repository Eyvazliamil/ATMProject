using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopManagementSystem
{
    internal class Animal  
    {
        private string _nickname;
        private short _age;
        private bool _gender;
        private double _energy;
        private decimal _price;
        private float _mealQuantity;

        protected string Nickname { get => _nickname; set => _nickname = value; }
        protected short Age { get => _age; set => _age = value; }
        protected bool Gender { get => _gender; set => _gender = value; }
        protected double Energy { get => _energy; set => _energy = value; }
        protected decimal Price { get => _price; set => _price = value; }
        protected float MealQuantity { get; set; }
        public decimal GetPrice() => Price;
        public string GetName() => Nickname;

        public Animal()
        {

        }
        public Animal(string nickname, short age, bool gender, float energy, decimal price, float mealQuantity)
        {
            Nickname = nickname;
            Age = age;
            Gender = gender;
            Energy = energy;
            Price = price;
            MealQuantity = mealQuantity;
        }
        public Animal(Animal other)
        {
            Nickname = other.Nickname;
            Age = other.Age;
            Gender = other.Gender;
            Energy = other.Energy;
            Price = other.Price;
            MealQuantity = other.MealQuantity;
        }

        virtual public void Eat()  { }
        virtual public void Sleep()  { }
        virtual public void Play() { }
        virtual public void ShowMoreInfo()  {  }
    }
}
