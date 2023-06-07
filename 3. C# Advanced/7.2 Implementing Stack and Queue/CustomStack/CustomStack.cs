using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStackAndQueue
{
    public class CustomStack
    {
        private const int InitialCapacity = 4;
        private const int FirstElementIndex = 0;

        private int[] items;
        public CustomStack()
        {
            items = new int[InitialCapacity];
        }

        public int Count { get; private set; }

        public void Push(int element)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            ShiftToRight(FirstElementIndex);
            items[FirstElementIndex] = element;
            Count++;
        }
        public int Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            int element = items[FirstElementIndex];

            items[FirstElementIndex] = default(int);

            ShiftToLeft(FirstElementIndex);

            Count--;
            if (Count <= items.Length / 4)
            {
                Shrink();
            }

            return element;
        }
        public int Peek()
        {
            return items[FirstElementIndex];
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
        private void ShiftToRight(int index)
        {
            for (int i = Count - 1; i >= index; i--)
            {
                items[i + 1] = items[i];
            }
        }
        private void ShiftToLeft(int index)
        {
            for (int i = index; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
        }
        private void Resize()
        {
            int[] copy = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
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
    }
}
