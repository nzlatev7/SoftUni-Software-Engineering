using System;
using System.Collections.Generic;

namespace BoxOfString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string personName = $"{personInfo[0]} {personInfo[1]}";
            string address = personInfo[2];

            string town;
            if (personInfo.Length == 5)
            {
                town = $"{personInfo[3]} {personInfo[4]}";
            }
            else
            {
                town = $"{personInfo[3]}";
            }

            Threeuple<string, string, string> tuple = 
                new Threeuple<string, string, string>(personName, address, town);

            string[] drunkPerson = Console.ReadLine().Split();
            string drunkName = drunkPerson[0];
            double litters = double.Parse(drunkPerson[1]);
            string drunkOrNot = drunkPerson[2];

            bool isDrunk = drunkOrNot == "drunk" ? true : false;

            Threeuple<string, double, bool> tuple1 = 
                new Threeuple<string, double, bool>(drunkName, litters, isDrunk);

            string[] info = Console.ReadLine().Split();
            string bankPersonName = info[0];
            double accountBalance = double.Parse(info[1]);
            string bankName = info[2];

            Threeuple<string, double, string> tuple2 = 
                new Threeuple<string, double, string>(bankPersonName, accountBalance, bankName);

            Console.WriteLine(tuple);
            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
        }
    }
}
