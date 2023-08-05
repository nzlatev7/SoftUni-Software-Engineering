using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;


        public Captain(string fullName)
        {
            FullName = fullName;

            Vessels = new List<IVessel>();
        }

        public string FullName
        {
            get => fullName;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Captain full name cannot be null or empty string.");
                }

                fullName = value;
            }
        }

        public int CombatExperience
        {
            get => combatExperience;
            private set
            {
                if (value == 0)
                {
                    value += 10;
                }

                combatExperience = value;
            }
        }

        public ICollection<IVessel> Vessels { get; private set; }

        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException("Null vessel cannot be added to the captain.");
            }

            Vessels.Add(vessel);
        }

        public void IncreaseCombatExperience()
        {
            CombatExperience += 10;
        }

        public string Report()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");

            if (Vessels.Count > 0)
            {
                foreach (var vessel in Vessels)
                {
                    report.AppendLine(vessel.ToString());
                }
            }

            return report.ToString().TrimEnd();
        }
    }
}
