using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Animals.Mammal.Feline
{
    public class Cat : Feline
    {
        private const double IncreasedWeightPerPiece = 0.30;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed, IncreasedWeightPerPiece)
        {
        }

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
