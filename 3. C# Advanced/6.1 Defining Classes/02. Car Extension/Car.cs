using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumpsion;


        public string Make 
        {
            get { return make; }
            set { make = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set { fuelQuantity = value; }
        }
        public double FuelConsumpsion
        {
            get { return fuelConsumpsion; }
            set { fuelConsumpsion = value; }
        }

        public void Drive(double distance)
        {
            if (FuelQuantity - distance * FuelConsumpsion > 0)
            {
                Console.WriteLine(FuelQuantity -= distance * FuelConsumpsion);
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }
        public string WhoAmI()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Make: {Make}");
            sb.AppendLine($"Model: {Model}");
            sb.AppendLine($"Year: {Year}");
            sb.AppendLine($"Fuel: {FuelQuantity:f2}");

            return sb.ToString().Trim();
        }
    }
}
