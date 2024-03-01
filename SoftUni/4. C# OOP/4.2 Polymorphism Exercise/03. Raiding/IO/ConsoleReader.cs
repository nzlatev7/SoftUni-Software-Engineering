using _3.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
