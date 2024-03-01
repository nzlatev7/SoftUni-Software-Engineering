using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double IncreasedWeightPerPiece = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize, IncreasedWeightPerPiece)
        {
        }
        public override string ProduceSound()
        {
            return "Cluck";
        }
    }
}
