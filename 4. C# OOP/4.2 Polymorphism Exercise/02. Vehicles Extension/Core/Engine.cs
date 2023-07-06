using _2.Core.Interfaces;
using _2.Factories.Interfaces;
using _2.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        private IVehicleFactory vehicleFactory;

        private ICollection<IVehicle> vehicles;

        public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.vehicleFactory = vehicleFactory;

            vehicles = new List<IVehicle>();
        }

        public void Run()
        {
            try
            {
                IVehicle car = CreateVehicle();
                IVehicle truck = CreateVehicle();
                IVehicle bus = CreateVehicle();

                vehicles.Add(car);
                vehicles.Add(truck);
                vehicles.Add(bus);
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message);
            }

            int n = int.Parse(reader.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    ProcessCommand();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var vehicle in vehicles)
            {
                writer.WriteLine(vehicle.ToString());
            }
        }
        private IVehicle CreateVehicle()
        {
            string[] carInfo = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string vehicleType = carInfo[0];
            double fuelQuantity = double.Parse(carInfo[1]);
            double fuelConsumption = double.Parse(carInfo[2]);
            double tankCapacity = double.Parse(carInfo[3]);

            return vehicleFactory.Create(vehicleType, fuelQuantity, fuelConsumption, tankCapacity);
        }
        private void ProcessCommand()
        {
            string[] commands = reader.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string command = commands[0];
            string vehicleTypeName = commands[1];

            IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleTypeName);

            if (vehicle == null)
            {
                throw new ArgumentException("Invalid vehicle type!");
            }

            try
            {
                if (commands[0] == "Drive")
                {
                    double distance = double.Parse(commands[2]);

                    writer.WriteLine(vehicle.Drive(distance));
                }
                else if (command == "Refuel")
                {
                    double liters = double.Parse(commands[2]);

                    vehicle.Refuel(liters);
                }
                else if (command == "DriveEmpty")
                {
                    double distance = double.Parse(commands[2]);

                    writer.WriteLine(vehicle.Drive(distance, false));
                }
            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
        }
    }
}
