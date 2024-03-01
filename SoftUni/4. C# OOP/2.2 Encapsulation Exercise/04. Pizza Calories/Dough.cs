using System;
using System.Collections.Generic;
using System.Text;

namespace _4
{
    public class Dough
    {
        private const decimal caloriesPerGram = 2;

        private readonly Dictionary<string, decimal> modifiers;

        private string flourType;
        private string bakingTechnique;
        private decimal grams;

        public Dough(string type, string bakingTechniquetisanal, decimal grams)
        {
            modifiers = new Dictionary<string, decimal>()
            {
                {"white", 1.5m},
                {"wholegrain", 1.0m},
                {"crispy", 0.9m},
                {"chewy", 1.1m},
                {"homemade", 1.0m},
            };

            FlourType = type;
            BakingTechnique = bakingTechniquetisanal;
            Grams = grams;
        }

        public string FlourType
        {
            get => flourType;
            set
            {
                value = value.ToLower();

                if (value != "white" && value != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }
        public string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                value = value.ToLower();

                if (value != "crispy" && value != "chewy" && value != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }
        public decimal Grams
        {
            get => grams;
            set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
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
            return (caloriesPerGram * Grams) * modifiers[FlourType] * modifiers[BakingTechnique];
        }
    }
}
