using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4
{
    public class Pizza
    {
        private string name;
        private int numberOfTopping;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            Name = name;
            Dough = dough;

            toppings = new List<Topping>();
        }

        public string Name 
        { 
            get => name; 
            private set 
            {
                if (value == string.Empty || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            } 
        }
        public Dough Dough { get; private set; }

        public int NumberOfTopping
        { 
            get => numberOfTopping;

            private set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }

                numberOfTopping = value;
            }
        }
        public decimal Calories { get => CalculateTotalCal(); }

        public void AddToppings(Topping topping)
        {
            toppings.Add(topping);

            NumberOfTopping++;
        }
        public override string ToString()
        {
            return $"{Name} - {Calories:f2} Calories.";
        }
        private decimal CalculateTotalCal()
        {
            return Dough.Calories + toppings.Sum(t => t.Calories);
        }
    }
}
