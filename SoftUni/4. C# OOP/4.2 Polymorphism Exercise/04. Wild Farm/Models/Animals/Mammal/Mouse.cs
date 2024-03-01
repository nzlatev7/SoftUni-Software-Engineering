using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Animals.Mammal
{
    public class Mouse : Mammal
    {
        private const double IncreasedWeightPerPiece = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion, IncreasedWeightPerPiece)
        {
        }

        public override string ProduceSound()
        {
            return "Squeak";
        }
    }
}
