using PersonInfo3.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PersonInfo3.IO.FileSystem
{
    public class FileWriter : IWriter
    {
        public void WriteLine(string line)
        {
            StreamWriter writer = new StreamWriter("../../../output.txt", true);

            using (writer)
            {
                writer.WriteLine(line);
            }
            
        }
    }
}
