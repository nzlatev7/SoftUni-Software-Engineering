using _1.Core.Interfaces;
using _1.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            IVehicle car = null;
            IVehicle truck = null;

            try
            {
                car = ReadVehicleInfo();
                truck = ReadVehicleInfo();
            }
            catch (Exception ex)
            {
                writer.Write(ex.Message);
            }

            int n = int.Parse(reader.Read());

            for (int i = 0; i < n; i++)
            {
                string[] commands = reader.Read()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Drive")
                {
                    double distance = double.Parse(commands[2]);

                    try
                    {
                        if (commands[1] == "Car")
                        {
                            writer.Write(car.Drive(distance));
                        }
                        else
                        {
                            writer.Write(truck.Drive(distance));
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        writer.Write(ex.Message);
                    }                    
                }
                else
                {
                    double liters = double.Parse(commands[2]);

                    if (commands[1] == "Car")
                    {
                        car.Refuel(liters);
                    }
                    else
                    {
                        truck.Refuel(liters);
                    }
                }
            }

            writer.Write(car.ToString());
            writer.Write(truck.ToString());
        }
        static IVehicle ReadVehicleInfo()
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = carInfo[0];

            switch (vehicleType)
            {
                case "Car":
                    return new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
                case "Truck":
                    return new Truck(double.Parse(carInfo[1]), double.Parse(carInfo[2]));
                default:
                    throw new ArgumentException($"Invalid vehicle type: {vehicleType}");
            }
        }
    }
}
