using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNums = new HashSet<string>();

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] inputCommand = command.Split(", ");

                string inOutCommand = inputCommand[0];
                string carNum = inputCommand[1];

                if (inOutCommand == "IN")
                {
                    carNums.Add(carNum);
                }
                else if (inOutCommand == "OUT")
                {
                    carNums.Remove(carNum);
                }
            }
            //if the parking does not have cars
            if (carNums.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var carNum in carNums)
            {
                Console.WriteLine(carNum);
            }
        }
    }
}
