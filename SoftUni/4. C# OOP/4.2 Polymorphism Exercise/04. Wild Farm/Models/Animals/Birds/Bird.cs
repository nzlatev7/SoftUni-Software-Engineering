using _4.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Animals.Birds
{
    public abstract class Bird : Animal, IBird
    {
        protected Bird(string name, double weight, double wingSize, double increasedWeightPerPiece)
            : base(name, weight, increasedWeightPerPiece)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {WingSize}, {Weight}, {FoodEaten}]";
        }
    }
}
