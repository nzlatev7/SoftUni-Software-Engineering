using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStackAndQueue
{
    public class CustomList
    {
        private const int InitialCapacity = 2;

        private int[] items;
        public CustomList()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }
        public int Indexer { get; set; }

        public int this[int index]
        {
            get
            {
                ThrowExceptionIfIndexOutOfRange(index);
                return items[index];
            }
            set 
            {
                ThrowExceptionIfIndexOutOfRange(index);
                items[index] = value;
            }
        }

        public void Add(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = element;
            Count++;
        }
        public int RemoveAt(int index)
        {
            ThrowExceptionIfIndexOutOfRange(index);

            int element = items[index];
            items[index] = default(int);
            ShiftToLeft(index);

            Count--;
            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return element;
        }
        public void Insert(int index, int element)
        {
            ThrowExceptionIfIndexOutOfRange(index);

            if (Count == items.Length)
            {
                Resize();
            }
            
            ShiftToRight(index);
            items[index] = element;
            Count++;
        }
        public bool Contains(int element)
        {
            //return items.Contains(element);

            for (int i = 0; i < Count; i++)
            {
                if (items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            ThrowExceptionIfIndexOutOfRange(firstIndex);
            ThrowExceptionIfIndexOutOfRange(secondIndex);

            int swapper = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = swapper;
        }
        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < items.Length; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }
        private void Shrink()
        {
            int[] copy = new int[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                copy[i] = items[i];
            }

            items = copy;
        }
        private void ShiftToLeft(int index)
        {
            for (int i = index; i < items.Length; i++)
            {
                items[i] = items[i + 1];
            }
        }
        private void ShiftToRight(int index)
        {
            for (int i = Count; i >= index; i--)
            {
                items[i] = items[i - 1];
            }
        }
        private void ThrowExceptionIfIndexOutOfRange(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
        }
    }
}
