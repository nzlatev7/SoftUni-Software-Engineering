using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int index = 0;

        public ListyIterator(List<T> collection)
        {
            this.collection = collection;
        }

        public bool Move()
        {
            if (index < collection.Count - 1)
            {
                index++;

                return true;
            }

            return false;
        }
        public bool HasNext()
        {
            return index < collection.Count - 1;
        }
        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(collection[index]);
        }
        public void PrintAll()
        {
            foreach (var item in collection)
            {
                Console.Write(item + " ");
            }

            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var current in collection)
            {
                yield return current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
