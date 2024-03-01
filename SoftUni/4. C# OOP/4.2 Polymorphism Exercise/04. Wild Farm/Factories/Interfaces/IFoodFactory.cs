using _4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Factories.Interfaces
{
    public interface IFoodFactory
    {
        IFood Create(string foodType, int quantity);
    }
}
