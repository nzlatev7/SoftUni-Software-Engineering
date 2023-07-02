using PersonInfo3.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo3.IO
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
