using _4.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Animals.Mammal
{
    public abstract class Mammal : Animal, IMammal
    {
        protected Mammal(string name, double weight, string livingRegion, double increasedWeightPerPiece) 
            : base(name, weight, increasedWeightPerPiece)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
