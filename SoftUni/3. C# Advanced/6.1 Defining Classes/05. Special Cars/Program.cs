using CarManufacturer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _5
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Tire[]> allTires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string command;
            while ((command = Console.ReadLine()) != "No more tires")
            {
                //2 2.6 3 1.6 2 3.6 3 1.6
                List<double> data = command.Split().Select(double.Parse).ToList();

                Tire[] tires =
                {
                    new Tire((int)data[0], data[1]),
                    new Tire((int)data[2], data[3]),
                    new Tire((int)data[4], data[5]),
                    new Tire((int)data[6], data[7]),
                };

                allTires.Add(tires);
            }

            while ((command = Console.ReadLine()) != "Engines done")
            {
                string[] data = command.Split();

                Engine engine = new Engine(int.Parse(data[0]), double.Parse(data[1]));
                engines.Add(engine);
            }

            while ((command = Console.ReadLine()) != "Show special")
            {
                string[] data = command.Split();

                int engineInex = int.Parse(data[5]);
                int tiresIndex = int.Parse(data[6]);

                Car car = new Car(data[0], data[1], int.Parse(data[2]), double.Parse(data[3]),
                    double.Parse(data[4]), engineInex, tiresIndex);
                cars.Add(car);
            }

            var carsForPrinting = cars.Where(x => x.Year >= 2017
                && engines[x.EngineIndex].HorsePower > 300
                && allTires[x.TiresIndex].Sum(x => x.Pressure) >= 9
                && allTires[x.TiresIndex].Sum(x => x.Pressure) <= 10);

            foreach (var specialCar in carsForPrinting)
            {
                specialCar.Drive(20);

                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {engines[specialCar.EngineIndex].HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }
    }
}
