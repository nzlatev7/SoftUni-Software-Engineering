using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private readonly IRepository<ISupplement> supplements;
        private readonly IRepository<IRobot> robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            IRobot robot;

            switch (typeName)
            {
                case nameof(DomesticAssistant):
                    robot = new DomesticAssistant(model);
                    break;
                case nameof(IndustrialAssistant):
                    robot = new IndustrialAssistant(model);
                    break;
                default:
                    return $"Robot type {typeName} cannot be created.";
            }

            robots.AddNew(robot);

            return $"{typeName} {model} is created and added to the RobotRepository.";
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement;

            switch (typeName)
            {
                case nameof(LaserRadar):
                    supplement = new LaserRadar();
                    break;
                case nameof(SpecializedArm):
                    supplement = new SpecializedArm();
                    break;
                default:
                    return $"{typeName} is not compatible with our robots.";
            }

            supplements.AddNew(supplement);

            return $"{typeName} is created and added to the SupplementRepository.";
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            List<IRobot> robotModels = robots.Models()
                .Where(x => x.InterfaceStandards.Contains(intefaceStandard))
                .ToList();

            if (robotModels.Count == 0)
            {
                return $"Unable to perform service, {intefaceStandard} not supported!";
            }

            robotModels = robotModels
                .OrderByDescending(x => x.BatteryLevel)
                .ToList();

            int availablePower = robotModels.Sum(x => x.BatteryLevel);

            if (availablePower < totalPowerNeeded)
            {
                return $"{serviceName} cannot be executed! {totalPowerNeeded - availablePower} more power needed.";
            }

            int counter = 0;

            foreach (var robot in robotModels)
            {
                counter++;

                if (robot.BatteryLevel >= totalPowerNeeded)
                {
                    robot.ExecuteService(totalPowerNeeded);

                    break;
                }

                totalPowerNeeded -= robot.BatteryLevel;

                robot.ExecuteService(robot.BatteryLevel);
                
            }

            return $"{serviceName} is performed successfully with {counter} robots.";
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();

            foreach (var robot in robots.Models()
                .OrderByDescending(x => x.BatteryLevel)
                .ThenBy(x => x.BatteryCapacity))
            {
                report.AppendLine(robot.ToString());
            }

            return report.ToString().TrimEnd();
        }

        public string RobotRecovery(string model, int minutes)
        {
            List<IRobot> robotModels = robots.Models()
                .Where(x => x.Model == model)
                .Where(x => ((double)x.BatteryLevel / x.BatteryCapacity) * 100 < 50)
                .ToList();

            foreach (var robot in robotModels)
            {
                robot.Eating(minutes);
            }

            return $"Robots fed: {robotModels.Count}";
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            var supplement = supplements.Models()
                .FirstOrDefault(x => x.GetType().Name == supplementTypeName);

            int interfaceValue = supplement.InterfaceStandard;

            List<IRobot> robotModels = robots.Models()
                .Where(x => !x.InterfaceStandards.Contains(interfaceValue))
                .Where(x => x.Model == model)
                .ToList();

            if (robotModels.Count == 0)
            {
                return $"All {model} are already upgraded!";
            }

            IRobot robot = robotModels.First();

            robot.InstallSupplement(supplement);

            supplements.RemoveByName(supplementTypeName);

            return $"{model} is upgraded with {supplementTypeName}.";
        }
    }
}
