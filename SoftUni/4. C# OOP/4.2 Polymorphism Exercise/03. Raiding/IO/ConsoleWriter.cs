using _3.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
