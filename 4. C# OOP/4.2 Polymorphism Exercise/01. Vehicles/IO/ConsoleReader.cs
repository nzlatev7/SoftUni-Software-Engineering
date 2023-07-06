using _1.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.IO
{
    public class ConsoleReader : IReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
