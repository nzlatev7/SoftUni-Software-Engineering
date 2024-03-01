using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    class ListyIterator<T>
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
    }
}
