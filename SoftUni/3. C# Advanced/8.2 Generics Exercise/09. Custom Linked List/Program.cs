using System;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Console.WriteLine("int");
            DoublyLinkedList<int> doublyLinkedListInteger = new DoublyLinkedList<int>();

            doublyLinkedListInteger.AddLast(10);
            doublyLinkedListInteger.AddLast(20);
            doublyLinkedListInteger.AddFirst(5);

            doublyLinkedListInteger.RemoveFirst();

            doublyLinkedListInteger.ForEach(x => Console.WriteLine(x));

            int[] array = doublyLinkedListInteger.ToArray();
            Console.WriteLine(string.Join(" ", array));

            Console.WriteLine("string");

            DoublyLinkedList<string> doublyLinkedListString = new DoublyLinkedList<string>();

            doublyLinkedListString.AddLast("gosho");
            doublyLinkedListString.AddLast("pesho");
            doublyLinkedListString.AddFirst("vasko");

            doublyLinkedListString.RemoveFirst();

            doublyLinkedListString.ForEach(x => Console.WriteLine(x));

            string[] array2 = doublyLinkedListString.ToArray();
            Console.WriteLine(string.Join(" ", array2));
        }
    }
}
