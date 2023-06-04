using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class ListNode<T>
    {
        public ListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }
        public ListNode<T> Next { get; set; }
        public ListNode<T> Previous { get; set; }
    }
}
