using PersonInfo3.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo3.IO
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
