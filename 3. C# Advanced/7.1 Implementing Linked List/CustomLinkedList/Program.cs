using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            DoublyLinkedList doublyLinkedList = new DoublyLinkedList();

            doublyLinkedList.AddLast(10);
            doublyLinkedList.AddLast(20);
            doublyLinkedList.AddFirst(5);

            doublyLinkedList.RemoveFirst();

            doublyLinkedList.ForEach(x => Console.WriteLine(x));

            int[] array = doublyLinkedList.ToArray();
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
