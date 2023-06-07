using System;

namespace CustomStackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQueue queue = new CustomQueue();

            queue.Enqueue(5);
            queue.Enqueue(5);
            queue.Enqueue(5);
            queue.Enqueue(5);

            queue.Clear();

            queue.Enqueue(10);

            queue.ForEach(x => Console.WriteLine(x));
        }
    }
}
