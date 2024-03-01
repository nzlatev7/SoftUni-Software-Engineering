using System;

namespace CustomStackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomList list = new CustomList();

            //1. public int Count { get { return items.Length; } private set { } } - to be access from user interface
            //2. is it correct to have 2 elements by default - to ask later

            list.Add(1);
            list.Add(2);

            list.Add(3);
            list.Add(4);

            list.Insert(2, 2);

            
        }
    }
}
