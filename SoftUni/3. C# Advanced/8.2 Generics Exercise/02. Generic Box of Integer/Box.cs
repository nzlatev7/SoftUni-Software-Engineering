using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfString
{
    public class Box<T>
    {
        private List<T> collection;

        public Box()
        {
            collection = new List<T>();
        }

        public void Add(T value)
        {
            collection.Add(value);
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();

            foreach (var value in collection)
            {
                output.AppendLine($"{value.GetType()}: {value}");
            }

            return output.ToString().TrimEnd();
        }
    }
}
