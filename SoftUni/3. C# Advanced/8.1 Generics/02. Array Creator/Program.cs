using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] strings = ArrayCreator.Create(5, "pesho");
            int[] integers = ArrayCreator.Create(10, 33);
        }
    }
}
