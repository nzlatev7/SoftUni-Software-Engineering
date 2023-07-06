using _2.Factories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle Create(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            switch (vehicleType)
            {
                case "Car":
                    return new Car(fuelQuantity, fuelConsumption, tankCapacity);
                case "Truck":
                    return new Truck(fuelQuantity, fuelConsumption, tankCapacity);
                case "Bus":
                    return new Bus(fuelQuantity, fuelConsumption, tankCapacity);
                default:
                    throw new ArgumentException($"Invalid vehicle type: {vehicleType}");
            }
        }
    }
}
