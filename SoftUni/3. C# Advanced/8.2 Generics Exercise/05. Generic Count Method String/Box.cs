using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfString
{
    public class Box<T> where T : IComparable
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
            //example of tuple
            (collection[secondIndex], collection[firstIndex]) = (collection[firstIndex], collection[secondIndex]);
        }
        public int GreaterCount(T value)
        {
            int count = 0;

            foreach (var currentValue in collection)
            {
                if (currentValue.CompareTo(value) > 0)
                {
                    count++;
                }
            }

            return count;
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
