using _4.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Factories.Interfaces
{
    public interface IAnimalFactory
    {
        IAnimal Create(string animalType, string name, double weight, double wingSize);
        IAnimal Create(string animalType, string name, double weight, string livingRegion);
        IAnimal Create(string animalType, string name, double weight, string livingRegion, string breed);
    }
}
