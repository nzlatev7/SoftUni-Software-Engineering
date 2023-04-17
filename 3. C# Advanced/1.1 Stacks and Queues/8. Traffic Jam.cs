using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            //the number of cars that can pass during the green light
            int n = int.Parse(Console.ReadLine());
            
            Queue<string> queue = new Queue<string>();
            int numberOfCars = 0;

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "green")
                {
                    numberOfCars += PrintCars(queue, n);
                }
                else
                {
                    queue.Enqueue(command);
                }
            }
            Console.WriteLine($"{numberOfCars} cars passed the crossroads.");
        }
        // this method returns the number of cars and print all the cars that have green light
        static int PrintCars(Queue<string> queue, int n)
        {
            bool isHavingElements = true;

            if (queue.Count < n)
            {
                isHavingElements = false;
            }

            int numberOfCars = 0;
            if (isHavingElements)
            {
                for (int i = 0; i < n; i++)
                {                     
                    //i--;
                    numberOfCars++;

                    string car = queue.Dequeue();
                    Console.WriteLine($"{car} passed!");
                }
            }
            else
            {
                for (int i = 0; i < queue.Count; i++)
                {   
                    i--;
                    numberOfCars++;

                    string car = queue.Dequeue();
                    Console.WriteLine($"{car} passed!");
                }
            }
            return numberOfCars;
        }
    }
}
