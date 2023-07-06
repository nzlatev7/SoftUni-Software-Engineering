using System;
using System.Collections.Generic;
using System.Text;

namespace _1
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionForAirConditioners = 1.6;
        public Truck(double fuelQuantity, double fuelConsuptionPerKm)
            : base(fuelQuantity, fuelConsuptionPerKm, FuelConsumptionForAirConditioners)
        {
        }

        public override void Refuel(double amountOfFuel)
        {
            base.Refuel(amountOfFuel * 0.95);
        }
    }
}
