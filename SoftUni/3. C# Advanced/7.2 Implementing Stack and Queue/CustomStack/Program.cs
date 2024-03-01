using System;

namespace CustomStackAndQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack stack = new CustomStack();

            stack.Push(4);
            stack.Push(10);
            stack.Push(28);

            Console.WriteLine(stack.Pop()); // 28
            Console.WriteLine(stack.Pop()); // 10

            stack.Push(100);
            stack.Push(200);
            stack.Push(300);

            Console.WriteLine(stack.Peek()); // 300

            stack.ForEach(x =>
            {
                if (x > 10)
                {
                    Console.WriteLine(x);
                }
            }); // 300 200 100
        }
    }
}
