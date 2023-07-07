using _4.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
