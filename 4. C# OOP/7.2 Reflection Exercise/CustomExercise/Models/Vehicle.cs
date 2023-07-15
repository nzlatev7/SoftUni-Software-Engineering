using CustomExer.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomExer.Models
{
    public abstract class Vehicle : IVehicle
    {
        private const int MinNameLength = 2;
        private const int MaxNameLength = 12;

        private const int MinYearLength = 2000;

        public Vehicle(string name, int year)
        {
            Name = name;
            Year = year;
        }

        [MyLength(MinNameLength, MaxNameLength)]
        public string Name { get; private set; }


        [MyYear(MinYearLength)]
        public int Year { get; set; }

        public void Drive(double distance)
        {
            Console.WriteLine($"{this.Name} is driving!");
        }
    }
}
