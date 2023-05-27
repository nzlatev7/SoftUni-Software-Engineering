using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, 
            int engineIndex, int tiresIndex)
        {
            Make = make;
            Model = model;
            Year = year;
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
            EngineIndex = engineIndex;
            TiresIndex = tiresIndex;
        }

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public int EngineIndex { get; set; }
        public int TiresIndex { get; set; }

        public void Drive(double distance)
        {
            if (FuelQuantity - (distance * FuelConsumption / 100) > 0)
            {
                FuelQuantity -= (distance * FuelConsumption / 100);
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
    }
}
