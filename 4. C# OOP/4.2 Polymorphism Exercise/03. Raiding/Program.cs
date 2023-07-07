using _3.Core;
using _3.Core.Interfaces;
using _3.Factories;
using _3.IO;
using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter(), new HeroFactory());

            engine.Run();
        }
    }
}
