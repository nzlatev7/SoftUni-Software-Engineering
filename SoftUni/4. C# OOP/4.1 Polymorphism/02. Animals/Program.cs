using System;

namespace Animals
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Animal dog = new Dog("sharo", "lazanq");
            Animal cat = new Cat("sharo", "lazanq");

            Console.WriteLine(cat.ExplainSelf());
            Console.WriteLine(dog.ExplainSelf());
        }
    }
}
