using _4.Factories.Interfaces;
using _4.Core.Interfaces;
using _4.Factories.Interfaces;
using _4.IO;
using _4.IO.Interfaces;
using _4.Models;
using _4.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IFoodFactory foodFactory;
        private readonly IAnimalFactory animalFactory;

        private ICollection<IAnimal> animals;
        private ICollection<IFood> foods;

        public Engine(
            IReader reader, 
            IWriter writer, 
            IFoodFactory foodFactory, 
            IAnimalFactory animalFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.foodFactory = foodFactory;
            this.animalFactory = animalFactory;

            animals = new List<IAnimal>();
            foods = new List<IFood>();
        }

        public void Run()
        {
            int lineCounter = 0;

            string command;
            while ((command = reader.ReadLine()) != "End")
            {
                try
                {
                    string[] data = command
                   .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    if (lineCounter % 2 == 0)
                    {
                        IAnimal animal = CreateAnimal(data);

                        writer.WriteLine(animal.ProduceSound());

                        animals.Add(animal);
                    }
                    else
                    {
                        IAnimal animal = animals.Last();

                        animal.Feed(CreateFood(data));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                lineCounter++;
            }

            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
        private IAnimal CreateAnimal(string[] data)
        {
            string animalType = data[0];
            string name = data[1];
            double weight = double.Parse(data[2]);

            switch (animalType)
            {
                case "Hen":
                case "Owl":
                    return animalFactory.Create(animalType, name, weight, double.Parse(data[3]));
                case "Dog":
                case "Mouse":
                    return animalFactory.Create(animalType, name, weight, data[3]);
                case "Cat":
                case "Tiger":
                    return animalFactory.Create(animalType, name, weight, data[3], data[4]);
                default:
                    throw new Exception("Invalid Animal Type!");
            }
        }
        private IFood CreateFood(string[] data)
        {
            string foodType = data[0];
            int quantity = int.Parse(data[1]);

            return foodFactory.Create(foodType, quantity);
        }
    }
}
