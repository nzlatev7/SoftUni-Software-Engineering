using _2.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
