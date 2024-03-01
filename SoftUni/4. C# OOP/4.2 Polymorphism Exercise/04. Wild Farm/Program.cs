using _4.Factories;
using _4.Core;
using _4.Core.Interfaces;
using _4.Factories;
using _4.IO;
using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(
                new ConsoleReader(),
                new ConsoleWriter(),
                new FoodFactory(),
                new AnimalFactory());

            engine.Run();
        }
    }
}
