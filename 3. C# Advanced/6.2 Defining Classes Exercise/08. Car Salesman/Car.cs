using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }
        public Car(string model, Engine engine, string color)
        {
            Model = model;
            Engine = engine;
            Color = color;
        }
        public Car(string model, Engine engine, int weight)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
        }
        public Car(string model, Engine engine, int weight, string color)
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder carInfo = new StringBuilder();
            carInfo.AppendLine($"{Model}:");
            carInfo.AppendLine($"  {Engine.Model}:");
            carInfo.AppendLine($"    Power: {Engine.Power}");
            carInfo.AppendLine($"    Displacement: {IsHavingData(Engine.Displacement)}");
            carInfo.AppendLine($"    Efficiency: {IsHavingData(Engine.Efficiency)}");
            carInfo.AppendLine($"  Weight: {IsHavingData(Weight)}");
            carInfo.AppendLine($"  Color: {IsHavingData(Color)}");

            return carInfo.ToString();
        }
        static string IsHavingData(string value)
        {
            string substitute = "n/a";
            string replacement = string.Empty;

            replacement = value == null ? substitute : value;

            return replacement;
        }
        static string IsHavingData(int value)
        {
            string substitute = "n/a";
            string replacement = string.Empty;

            replacement = value == 0 ? substitute : value.ToString();

            return replacement;
        }
    }
}
