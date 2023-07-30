using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private IRepository<IPilot> pilots;
        private IRepository<IFormulaOneCar> cars;
        private IRepository<IRace> races;

        public Controller()
        {
            pilots = new PilotRepository();
            cars = new FormulaOneCarRepository();
            races = new RaceRepository();
        }

        public string AddCarToPilot(string pilotName, string carModel)
        {
            IPilot pilot = pilots.FindByName(pilotName);
            IFormulaOneCar car = cars.FindByName(carModel);

            if (pilot == null || pilot.Car != null)
            {
                throw new InvalidOperationException($"Pilot {pilotName} does not exist or has a car.");
            }

            if (car == null)
            {
                throw new NullReferenceException($"Car {carModel} does not exist.");
            }

            pilot.AddCar(car);

            cars.Remove(car);

            return $"Pilot {pilotName} will drive a {car.GetType().Name} {carModel} car.";

        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            IRace race = races.FindByName(raceName);
            IPilot pilot = pilots.FindByName(pilotFullName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            if (pilot == null || pilot.CanRace == false || race.Pilots.Contains(pilot))
            {
                throw new InvalidOperationException($"Can not add pilot {pilotFullName} to the race.");
            }

            race.AddPilot(pilot);

            return $"Pilot {pilotFullName} is added to the {raceName} race.";
        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            IFormulaOneCar car = cars.FindByName(model);

            if (car != null)
            {
                throw new InvalidOperationException($"Formula one car {model} is already created.");
            }

            switch (type)
            {
                case nameof(Ferrari):
                    car = new Ferrari(model, horsepower, engineDisplacement);
                    break;
                case nameof(Williams):
                    car = new Williams(model, horsepower, engineDisplacement);
                    break;
                default:
                    throw new InvalidOperationException($"Formula one car type {type} is not valid.");
            }

            cars.Add(car);

            return $"Car {type}, model {model} is created.";
        }

        public string CreatePilot(string fullName)
        {
            IPilot pilot = pilots.FindByName(fullName);

            if (pilot != null)
            {
                throw new InvalidOperationException($"Pilot {fullName} is already created.");
            }

            pilot = new Pilot(fullName);
            pilots.Add(pilot);

            return $"Pilot {fullName} is created.";
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            IRace race = races.FindByName(raceName);

            if (race != null)
            {
                throw new InvalidOperationException($"Race {raceName} is already created.");
            }

            race = new Race(raceName, numberOfLaps);
            races.Add(race);

            return $"Race {raceName} is created.";
        }

        public string PilotReport()
        {
            StringBuilder report = new StringBuilder();

            foreach (var pilot in pilots.Models
                .OrderByDescending(x => x.NumberOfWins))
            {
                report.AppendLine(pilot.ToString());
            }

            return report.ToString().TrimEnd();
        }

        public string RaceReport()
        {
            StringBuilder report = new StringBuilder();

            foreach (var race in races.Models
                .Where(x => x.TookPlace == true))
            {
                report.AppendLine(race.RaceInfo());
            }

            return report.ToString().TrimEnd();
        }

        public string StartRace(string raceName)
        {
            IRace race = races.FindByName(raceName);

            if (race == null)
            {
                throw new NullReferenceException($"Race {raceName} does not exist.");
            }

            if (race.Pilots.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than three participants.");
            }

            if (race.TookPlace)
            {
                throw new InvalidOperationException($"Can not execute race {raceName}.");
            }

            List<IPilot> topPilots = race.Pilots
                .OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps))
                .Take(3)
                .ToList();

            StringBuilder competition = new StringBuilder();

            race.TookPlace = true;
            topPilots[0].WinRace();

            competition.AppendLine($"Pilot {topPilots[0].FullName} wins the {raceName} race.");
            competition.AppendLine($"Pilot {topPilots[1].FullName} is second in the {raceName} race.");
            competition.AppendLine($"Pilot {topPilots[2].FullName} is third in the {raceName} race.");

            return competition.ToString().TrimEnd();
        }
    }
}
