using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();

                string model = data[0];

                int engineSpeed = int.Parse(data[1]);
                int enginePower = int.Parse(data[2]);

                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(data[3]);
                string cargoType = data[4];

                Cargo cargo = new Cargo(cargoType, cargoWeight);

                double tire1Pressure = double.Parse(data[5]);
                int tire1Age = int.Parse(data[6]);
                double tire2Pressure = double.Parse(data[7]);
                int tire2Age = int.Parse(data[8]);
                double tire3Pressure = double.Parse(data[9]);
                int tire3Age = int.Parse(data[10]);
                double tire4Pressure = double.Parse(data[11]);
                int tire4Age = int.Parse(data[12]);

                Tire[] tires = new Tire[4]
                {
                    new Tire(tire1Age, tire1Pressure),
                    new Tire(tire2Age, tire2Pressure),
                    new Tire(tire3Age, tire3Pressure),
                    new Tire(tire4Age, tire4Pressure)
                };

                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                foreach (var car in cars
                    .Where(x => x.Cargo.Type == "fragile")
                    .Where(x => x.Tires.Any(x => x.Pressure < 1)))
                {
                    Console.WriteLine(car.Model);
                }
            }
            else if (command == "flammable")
            {
                foreach (var car in cars
                    .Where(x => x.Cargo.Type == "flammable")
                    .Where(x => x.Engine.Power > 250))
                {
                    Console.WriteLine(car.Model);
                }
            }
        }
    }
}
