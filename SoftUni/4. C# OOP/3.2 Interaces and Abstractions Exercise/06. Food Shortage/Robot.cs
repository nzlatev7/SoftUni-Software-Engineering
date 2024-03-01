using System;
using System.Collections.Generic;
using System.Text;

namespace _6
{
    public class Robot : IIdentified
    {
        public Robot(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public string Name { get; private set; }
        public string Id { get; private set; }
    }
}
