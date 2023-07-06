using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    public class Bus : Vehicle
    {
        private const double FuelConsumptionForAirConditioners = 1.4;
        public Bus(double fuelQuantity, double fuelConsuptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsuptionPerKm, tankCapacity, FuelConsumptionForAirConditioners)
        {
        }
    }
}
