using System;
using System.Collections.Generic;
using System.Text;

namespace _1
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption; 
        protected Vehicle(double fuelQuantity, double fuelConsuptionPerKm, double increasedConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsuptionPerKm = fuelConsuptionPerKm;
            this.increasedConsumption = increasedConsumption;
        }

        public double FuelQuantity { get; private set; }

        public double FuelConsuptionPerKm { get; private set; }

        public string Drive(double distance)
        {
            double consumption = FuelConsuptionPerKm + increasedConsumption;

            if (FuelQuantity < consumption * distance)
            {
                throw new InvalidOperationException($"{this.GetType().Name} needs refueling");
            }

            FuelQuantity -= consumption * distance;

            return $"{this.GetType().Name} travelled {distance} km";
        }

        //basic implementation of this method, if someone wants another procedure
        //need to override this method
        public virtual void Refuel(double amountOfFuel)
        {
            FuelQuantity += amountOfFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
