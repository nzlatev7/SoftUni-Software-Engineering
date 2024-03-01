using System;
using System.Collections.Generic;
using System.Text;

namespace _1
{
    public interface IVehicle
    {
        double FuelQuantity { get; }
        double FuelConsuptionPerKm { get; }

        string Drive(double distance);
        void Refuel(double amountOfFuel);
    }
}
