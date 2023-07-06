using _1.Core;
using _1.Core.Interfaces;
using _1.IO;
using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());

            engine.Run();
        }
    }
}
