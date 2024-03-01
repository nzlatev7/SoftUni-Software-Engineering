using CarManufacturer;
using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Car car = new Car();

            car.Make = "a";
            car.Model = "a";
            car.Year = 1999;
            car.FuelQuantity = 20;
            car.FuelConsumpsion = 2;

            car.Drive(5);

            Console.WriteLine(car.WhoAmI());
        }
    }
}