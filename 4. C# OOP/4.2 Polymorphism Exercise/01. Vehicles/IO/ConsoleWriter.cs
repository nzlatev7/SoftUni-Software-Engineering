using _1.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(string line)
        {
            Console.WriteLine(line);
        }
    }
}
