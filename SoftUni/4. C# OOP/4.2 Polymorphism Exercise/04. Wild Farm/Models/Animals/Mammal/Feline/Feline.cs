using _4.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Animals.Mammal.Feline
{
    public abstract class Feline : Mammal, IFeline
    {
        protected Feline(string name, double weight, string livingRegion, string breed, double increasedWeightPerPiece) 
            : base(name, weight, livingRegion, increasedWeightPerPiece)
        {
            Breed = breed;
        }

        public string Breed { get; private set; }

        public override string ToString()
        {
            return $"{this.GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
