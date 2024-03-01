using System;
using System.Collections.Generic;
using System.Text;

namespace _1
{
    public class Car : Vehicle
    {
        private const double FuelConsumptionForAirConditioners = 0.9;
        public Car(double fuelQuantity, double fuelConsuptionPerKm)
            : base(fuelQuantity, fuelConsuptionPerKm, FuelConsumptionForAirConditioners)
        {
        }
    }
}
