using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    class CustomStack<T> : IEnumerable<T>
    {
        private List<T> collection;

        public CustomStack()
        {
            this.collection = new List<T>();
        }

        public void Push(T item)
        {
            collection.Insert(0, item);
        }
        public T Pop()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("No elements");
            }

            T item = collection[0];
            collection.RemoveAt(0);

            return item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
