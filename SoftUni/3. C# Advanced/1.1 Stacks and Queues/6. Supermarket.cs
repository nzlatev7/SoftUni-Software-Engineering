using System;
using System.Collections;

namespace _6._Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue queue = new Queue();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                if (command == "Paid")
                {
                    PrintQueue(queue);
                    ;
                    for (int i = 0; i < queue.Count; i++)
                    {
                        queue.Dequeue();
                        i--;
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
        static void PrintQueue(Queue queue)
        {
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }
        }
    }
}
