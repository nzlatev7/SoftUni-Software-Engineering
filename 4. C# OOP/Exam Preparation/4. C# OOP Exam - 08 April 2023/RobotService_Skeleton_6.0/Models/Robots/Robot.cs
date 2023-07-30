using RobotService.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public abstract class Robot : IRobot
    {
        private string model;
        private int batteryCapacity;

        public Robot(string model, int batteryCapacity, int conversionCapacityIndex)
        {
            Model = model;
            BatteryCapacity = batteryCapacity;
            ConvertionCapacityIndex = conversionCapacityIndex;

            BatteryLevel = BatteryCapacity;

            InterfaceStandards = new List<int>();
        }

        public string Model 
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model cannot be null or empty.");
                }

                model = value;
            }
        }

        public int BatteryCapacity 
        {
            get => batteryCapacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Battery capacity cannot drop below zero.");
                }

                batteryCapacity = value;
            }
        }

        public int BatteryLevel { get; private set; }

        public int ConvertionCapacityIndex { get; private set; }

        public IReadOnlyCollection<int> InterfaceStandards { get; private set; }

        public void Eating(int minutes)
        {
            int totalCapacity = ConvertionCapacityIndex * minutes;

            if (totalCapacity > BatteryCapacity - BatteryLevel)
            {
                BatteryLevel = BatteryCapacity;
            }
            else
            {
                BatteryLevel += totalCapacity;
            }
        }

        public bool ExecuteService(int consumedEnergy)
        {
            if (BatteryLevel >= consumedEnergy)
            {
                BatteryLevel -= consumedEnergy;

                return true;
            }

            return false;
        }

        public void InstallSupplement(ISupplement supplement)
        {
            List<int> standards = InterfaceStandards.ToList();

            standards.Add(supplement.InterfaceStandard);

            InterfaceStandards = standards.AsReadOnly();

            BatteryLevel -= supplement.BatteryUsage;
            BatteryCapacity -= supplement.BatteryUsage;
        }

        public override string ToString()
        {
            StringBuilder robotInfo = new StringBuilder();

            robotInfo.AppendLine($"{this.GetType().Name} {Model}:");
            robotInfo.AppendLine($"--Maximum battery capacity: {BatteryCapacity}");
            robotInfo.AppendLine($"--Current battery level: {BatteryLevel}");
            robotInfo.AppendLine($"--Supplements installed: {(InterfaceStandards.Count == 0 ? "none" : String.Join(" ", InterfaceStandards))}");
        
            return robotInfo.ToString().TrimEnd();
        }
    }
}
