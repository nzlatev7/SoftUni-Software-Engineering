using _4.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        private readonly double increasedWeightPerPiece;
        protected Animal(string name, double weight, double increasedWeightPerPiece)
        {
            Name = name;
            Weight = weight;

            this.increasedWeightPerPiece = increasedWeightPerPiece;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }

        public void Feed(IFood food)
        {
            string animalType = this.GetType().Name;
            string foodType = food.GetType().Name;

            switch (animalType)
            {
                case "Hen":
                    FoodEaten += food.Quantity;
                    break;
                case "Mouse":

                    if (foodType != "Vegetable" && foodType != "Fruit")
                    {
                        throw new Exception($"{animalType} does not eat {foodType}!");
                    }

                    FoodEaten += food.Quantity;
                    break;
                case "Cat":

                    if (foodType != "Vegetable" && foodType != "Meat")
                    {
                        throw new Exception($"{animalType} does not eat {foodType}!");
                    }

                    FoodEaten += food.Quantity;
                    break;
                case "Tiger":
                case "Dog":
                case "Owl":

                    if (foodType != "Meat")
                    {
                        throw new Exception($"{animalType} does not eat {foodType}!");
                    }

                    FoodEaten += food.Quantity;
                    break;
                default:
                    break;
            }

            Weight += food.Quantity * increasedWeightPerPiece;
        }

        public abstract string ProduceSound();
    }
}
