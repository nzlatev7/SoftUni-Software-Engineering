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
                string[] carData = Console.ReadLine().Split();

                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumptionFor1km = double.Parse(carData[2]);

                //validate that we can have only one model - unique
                if (!cars.Any(x => x.Model == model))
                {
                    Car car = new Car(model, fuelAmount, fuelConsumptionFor1km);
                    cars.Add(car);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] info = command.Split();

                string carModel = info[1];
                int distance = int.Parse(info[2]);

                Car car = cars.Find(x => x.Model == carModel);
                car.Moving(distance);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
