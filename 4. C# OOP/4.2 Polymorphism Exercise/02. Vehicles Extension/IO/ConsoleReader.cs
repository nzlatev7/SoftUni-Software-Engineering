using _2.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
