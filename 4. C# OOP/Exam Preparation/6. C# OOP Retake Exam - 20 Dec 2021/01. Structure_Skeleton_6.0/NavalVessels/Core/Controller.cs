using NavalVessels.Core.Contracts;
using NavalVessels.Models;
using NavalVessels.Models.Contracts;
using NavalVessels.Repositories;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Core
{
    internal class Controller : IController
    {
        private readonly IRepository<IVessel> vessels;
        private readonly ICollection<ICaptain> captains;

        public Controller()
        {
            vessels = new VesselRepository();
            captains = new HashSet<ICaptain>();
        }
        public string HireCaptain(string fullName)
        {
            ICaptain captain = captains
                .FirstOrDefault(x => x.FullName == fullName);

            if (captain != null)
            {
                return $"Captain {fullName} is already hired.";
            }

            captain = new Captain(fullName);
            captains.Add(captain);

            return $"Captain {fullName} is hired.";
        }

        public string ProduceVessel(string name, string vesselType, double mainWeaponCaliber, double speed)
        {
            IVessel vessel = vessels.FindByName(name);

            if (vessel != null)
            {
                return $"{vessel.GetType().Name} vessel {name} is already manufactured.";
            }

            switch (vesselType)
            {
                case nameof(Battleship):
                    vessel = new Battleship(name, mainWeaponCaliber, speed);
                    break;
                case nameof(Submarine):
                    vessel = new Submarine(name, mainWeaponCaliber, speed);
                    break;
                default:
                    return "Invalid vessel type.";
            }

            vessels.Add(vessel);

            return $"{vesselType} {name} is manufactured with the main weapon caliber of {mainWeaponCaliber} inches and a maximum speed of {speed} knots.";
        }

        public string AssignCaptain(string selectedCaptainName, string selectedVesselName)
        {
            ICaptain captain = captains
                .FirstOrDefault(x => x.FullName == selectedCaptainName);

            IVessel vessel = vessels.FindByName(selectedVesselName);

            if (captain == null)
            {
                return $"Captain {selectedCaptainName} could not be found.";
            }

            if (vessel == null)
            {
                return $"Vessel {selectedVesselName} could not be found.";
            }

            if (vessel.Captain != null)
            {
                return $"Vessel {selectedVesselName} is already occupied.";
            }
  
            captain.AddVessel(vessel);
            vessel.Captain = captain;

            return $"Captain {selectedCaptainName} command vessel {selectedVesselName}.";
        }

        public string CaptainReport(string captainFullName)
        {
            ICaptain captain = captains
                .FirstOrDefault(x => x.FullName == captainFullName);

            return captain.Report();
        }

        public string VesselReport(string vesselName)
        {
            IVessel vessel = vessels
                .FindByName(vesselName);

            return vessel?.ToString();
        }

        public string ToggleSpecialMode(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            if (vessel.GetType().Name == nameof(Battleship))
            {
                Battleship battleship = (Battleship)vessel;

                battleship.ToggleSonarMode();

                return $"Battleship {vesselName} toggled sonar mode.";
            }
            else
            {
                Submarine submarine = (Submarine)vessel;

                submarine.ToggleSubmergeMode();

                return $"Submarine {vesselName} toggled submerge mode.";
            }
        }

        public string ServiceVessel(string vesselName)
        {
            IVessel vessel = vessels.FindByName(vesselName);

            if (vessel == null)
            {
                return $"Vessel {vesselName} could not be found.";
            }

            vessel.RepairVessel();

            return $"Vessel {vesselName} was repaired.";
        }

        public string AttackVessels(string attackingVesselName, string defendingVesselName)
        {
            IVessel attackingVessel = vessels.FindByName(attackingVesselName);
            IVessel defendingVessel = vessels.FindByName(defendingVesselName);

            if (attackingVessel == null)
            {
                return $"Vessel {attackingVesselName} could not be found.";
            }

            if (defendingVessel == null)
            {
                return $"Vessel {defendingVesselName} could not be found.";
            }

            if (attackingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {attackingVesselName} cannot attack or be attacked.";
            }

            if (defendingVessel.ArmorThickness == 0)
            {
                return $"Unarmored vessel {defendingVesselName} cannot attack or be attacked.";
            }

            attackingVessel.Attack(defendingVessel);

            attackingVessel.Captain.IncreaseCombatExperience();
            defendingVessel.Captain.IncreaseCombatExperience();

            return $"Vessel {defendingVesselName} was attacked by vessel {attackingVesselName} - current armor thickness: {defendingVessel.ArmorThickness}.";
        }
    }
}
