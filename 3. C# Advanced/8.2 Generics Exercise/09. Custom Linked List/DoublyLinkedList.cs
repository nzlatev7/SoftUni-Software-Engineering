using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;

        public ListNode<T> First
        {
            get { return head; }
        }
        public ListNode<T> Last
        {
            get { return tail; }
        }

        public int Count { get; private set; }
        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode<T>(element);
            }
            else
            {
                var newHead = new ListNode<T>(element);
                newHead.Next = head;
                head.Previous = newHead;
                head = newHead;
            }

            Count++;
        }
        public void AddLast(T element)
        {
            if (Count == 0)
            {
                head = tail = new ListNode<T>(element);
            }
            else
            {
                var newTail = new ListNode<T>(element);
                newTail.Previous = tail;
                tail.Next = newTail;
                tail = newTail;
            }

            Count++;
        }
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var firstElement = head.Value;

            head = head.Next;
            if (head != null)
            {
                head.Previous = null;
            }
            else
            {
                tail = null;
            }
            Count--;

            return firstElement;
        }
        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            var lastElement = tail.Value;

            tail = tail.Previous;
            if (tail != null)
            {
                tail.Next = null;
            }
            else
            {
                head = null;
            }
            Count--;

            return lastElement;
        }
        public void ForEach(Action<T> acton)
        {
            var element = head;
            while (element != null)
            {
                acton(element.Value);
                element = element.Next;
            }
        }
        public T[] ToArray()
        {        
            T[] array = new T[Count];

            int i = 0;
            ForEach(x => array[i++] = x);


            return array;
        }
    }
}
