using System;
using System.Collections.Generic;
using System.Text;

namespace _4
{
    public class Topping
    {
        private decimal caloriesPerGram = 2;

        private string type;
        private decimal grams;

        private string currentType;

        private Dictionary<string, decimal> modifiers = new Dictionary<string, decimal>()
        {
            {"meat", 1.2m},
            {"veggies", 0.8m},
            {"cheese", 1.1m},
            {"sauce", 0.9m},
        };

        public Topping(string type, decimal grams)
        {
            currentType = type;

            Type = type;
            Grams = grams;
        }

        public string Type
        {
            get => type;
            set
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {currentType} on top of your pizza.");
                }

                type = value;
            }
        }
        public decimal Grams
        {
            get => grams;
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{currentType} weight should be in the range [1..50].");
                }

                grams = value;
            }
        }

        public decimal Calories
        {
            get => CalculateCal();
        }
        public decimal CalculateCal()
        {
            return Grams * caloriesPerGram *  modifiers[Type.ToLower()];
        } 
    }
}
