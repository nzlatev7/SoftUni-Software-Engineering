using _4.Factories.Interfaces;
using _4.Models.Animals.Birds;
using _4.Models.Animals.Mammal;
using _4.Models.Animals.Mammal.Feline;
using _4.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal Create(string animalType, string name, double weight, double wingSize)
        {
            switch (animalType)
            {
                case "Hen":
                    return new Hen(name, weight, wingSize);
                case "Owl":
                    return new Owl(name, weight, wingSize);
                default:
                    throw new Exception("Invalid Animal Type!");
            }
        }

        public IAnimal Create(string animalType, string name, double weight, string livingRegion)
        {
            switch (animalType)
            {
                case "Dog":
                    return new Dog(name, weight, livingRegion);
                case "Mouse":
                    return new Mouse(name, weight, livingRegion);
                default:
                    throw new Exception("Invalid Animal Type!");
            }
        }

        public IAnimal Create(string animalType, string name, double weight, string livingRegion, string breed)
        {
            switch (animalType)
            {
                case "Cat":
                    return new Cat(name, weight, livingRegion, breed);
                case "Tiger":
                    return new Tiger(name, weight, livingRegion, breed);
                default:
                    throw new Exception("Invalid Animal Type!");
            }
        }
    }
}
