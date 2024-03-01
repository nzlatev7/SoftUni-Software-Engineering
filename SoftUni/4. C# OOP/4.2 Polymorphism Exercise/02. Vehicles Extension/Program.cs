using _2.Core;
using _2.Core.Interfaces;
using _2.Factories;
using _2.IO;
using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new VehicleFactory());

            engine.Run();
        }
    }
}
