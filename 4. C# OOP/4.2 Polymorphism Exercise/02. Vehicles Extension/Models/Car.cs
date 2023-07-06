using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    public class Car : Vehicle
    {
        private const double FuelConsumptionForAirConditioners = 0.9;
        public Car(double fuelQuantity, double fuelConsuptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsuptionPerKm, tankCapacity, FuelConsumptionForAirConditioners)
        {
        }
    }
}
