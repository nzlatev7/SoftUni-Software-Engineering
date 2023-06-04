using System;
using System.Collections.Generic;

namespace BoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Tuple<string, string> tuple = new Tuple<string, string>();
            Tuple<string, double> tuple1 = new Tuple<string, double>();
            Tuple<int, double> tuple2 = new Tuple<int, double>();

            string[] personInfo = Console.ReadLine().Split();
            string personName = $"{personInfo[0]} {personInfo[1]}";
            string address = personInfo[2];

            tuple.Add(personName, address);

            string[] drunkPerson = Console.ReadLine().Split();
            string drunkName = drunkPerson[0];
            double litters = double.Parse(drunkPerson[1]);

            tuple1.Add(drunkName, litters);

            string[] info = Console.ReadLine().Split();
            int firstInput = int.Parse(info[0]);
            double secondInput = double.Parse(info[1]);

            tuple2.Add(firstInput, secondInput);

            Console.WriteLine(tuple);
            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
        }
    }
}
