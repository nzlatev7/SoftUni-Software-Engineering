using CarManufacturer;
using System;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var tires = new Tire[4]
            {
                new Tire(1, 2.5),
                new Tire(1, 2.5),
                new Tire(1, 2.5),
                new Tire(1, 2.5)
            };

            Engine engine = new Engine(560, 6300);

            Car car = new Car("1", "1", 1999, 20, 5, engine, tires);

            foreach (var item in car.Tires)
            {
                Console.WriteLine(item.Pressure);
            }
        }
    }
}
