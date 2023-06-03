using System;
using System.Collections.Generic;
using System.Linq;
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
        public void SwapElements(int firstIndex, int secondIndex)
        {
            //T firstValue = collection[firstIndex];
            //collection[firstIndex] = collection[secondIndex];
            //collection[secondIndex] = firstValue;

            //example of tuple
            (collection[secondIndex], collection[firstIndex]) = (collection[firstIndex], collection[secondIndex]);

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
