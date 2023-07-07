using _4.Factories.Interfaces;
using _4.Factories.Interfaces;
using _4.Models;
using _4.Models.Foods;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Factories
{
    public class FoodFactory : IFoodFactory
    {
        public IFood Create(string foodType, int quantity)
        {
            switch (foodType)
            {
                case "Vegetable":
                    return new Vegetable(quantity);
                case "Fruit":
                    return new Fruit(quantity);
                case "Meat":
                    return new Meat(quantity);
                case "Seeds":
                    return new Seeds(quantity);

                default:
                    throw new Exception("Invalid Food Type!");
            }
        }
    }
}
