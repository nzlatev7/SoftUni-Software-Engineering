using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Animals.Mammal.Feline
{
    public class Tiger : Feline
    {
        private const double IncreasedWeightPerPiece = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed, IncreasedWeightPerPiece)
        {
        }

        public override string ProduceSound()
        {
            return "ROAR!!!";
        }
    }
}
