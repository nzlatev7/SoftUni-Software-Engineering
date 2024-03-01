using System;
using System.Collections.Generic;
using System.Text;

namespace _2
{
    public abstract class Vehicle : IVehicle
    {
        private double increasedConsumption;
        private double fuelQuantity;

        protected Vehicle(double fuelQuantity, double fuelConsuptionPerKm, double tankCapacity, double increasedConsumption)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsuptionPerKm = fuelConsuptionPerKm;
            this.increasedConsumption = increasedConsumption;       
        }

        public double FuelQuantity 
        {
            get { return fuelQuantity; }
            private set
            {
                if (value > TankCapacity)
                {
                    fuelQuantity = 0;
                }
                else
                {
                    fuelQuantity = value;
                }
            }
        }

        public double FuelConsuptionPerKm { get; private set; }

        public double TankCapacity { get; private set; }

        public string Drive(double distance, bool isIncreasedConssumption = true)
        {
            double consumption = isIncreasedConssumption 
                ? FuelConsuptionPerKm + increasedConsumption
                : FuelConsuptionPerKm;

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
            if (amountOfFuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }

            if (FuelQuantity + amountOfFuel > TankCapacity)
            {
                throw new ArgumentException($"Cannot fit {amountOfFuel} fuel in the tank");
            }

            FuelQuantity += amountOfFuel;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {FuelQuantity:f2}";
        }
    }
}
