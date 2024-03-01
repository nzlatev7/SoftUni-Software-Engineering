using PersonInfo3.Core.Interfaces;
using PersonInfo3.Core;
using PersonInfo;
using System;
using PersonInfo3.IO;
using PersonInfo3.IO.FileSystem;

namespace PersonInfo3
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine(new ConsoleReader(), new ConsoleWriter());

            engine.Run();
        }
    }
}
