using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    public class Truck : Vehicle
    {
        private const double FuelConsumptionForAirConditioners = 1.6;
        public Truck(double fuelQuantity, double fuelConsuptionPerKm, double tankCapacity)
            : base(fuelQuantity, fuelConsuptionPerKm, tankCapacity, FuelConsumptionForAirConditioners)
        {
        }

        public override void Refuel(double amountOfFuel)
        {
            if (amountOfFuel + FuelQuantity > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amountOfFuel} fuel in the tank");
            }

            base.Refuel(amountOfFuel * 0.95);
        }
    }
}
