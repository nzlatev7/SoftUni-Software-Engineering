using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<string> equalityScale = new EqualityScale<string>("a", "a");

            Console.WriteLine(equalityScale.AreEqual());
        }
    }
}
