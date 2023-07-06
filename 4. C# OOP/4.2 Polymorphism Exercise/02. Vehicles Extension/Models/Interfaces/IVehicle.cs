using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsuptionPerKm { get; }
        double TankCapacity { get; }

        string Drive(double distance, bool isIncreasedConsumption = true);
        void Refuel(double amountOfFuel);
    }
}
