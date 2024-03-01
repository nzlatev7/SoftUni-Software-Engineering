using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDoublyLinkedList
{
    public class ListNode
    {
        public ListNode(int value)
        {
            Value = value;
        }
        public int Value { get; set; }
        public ListNode Next { get; set; }
        public ListNode Previous { get; set; }
    }
}
