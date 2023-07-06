using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Factories.Interfaces
{
    public interface IVehicleFactory
    {
        IVehicle Create(string vehicleType, double fuelQuantity, double fuelConsumption, double tankCapacity);
    }
}
