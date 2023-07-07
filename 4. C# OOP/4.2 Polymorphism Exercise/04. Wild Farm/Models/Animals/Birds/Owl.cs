using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double IncreasedWeightPerPiece = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize, IncreasedWeightPerPiece)
        {
        }

        public override string ProduceSound()
        {
            return "Hoot Hoot";
        }
    }
}
