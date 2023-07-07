using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Interfaces
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }

        string ProduceSound();

        void Feed(IFood food);
    }
}
