using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Animals.Mammal
{
    public class Dog : Mammal
    {
        private const double IncreasedWeightPerPiece = 0.40;
        public Dog(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion, IncreasedWeightPerPiece)
        {
        }

        public override string ProduceSound()
        {
            return "Woof!";
        }
    }
}
