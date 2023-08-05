using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;


        public Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            Name = name;
            MainWeaponCaliber = mainWeaponCaliber;
            Speed = speed;
            ArmorThickness = armorThickness;

            Targets = new List<string>();
        }
        public string Name 
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Vessel name cannot be null or empty.");
                }

                name = value;
            }
        }

        public ICaptain Captain 
        {
            get => captain;
            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Captain cannot be null.");
                }

                captain = value;
            }
        }

        public double ArmorThickness { get; set; }

        public double MainWeaponCaliber { get; protected set; }

        public double Speed { get; protected set; }

        public ICollection<string> Targets { get; private set; }

        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException("Target cannot be null.");
            }

            target.ArmorThickness -= MainWeaponCaliber;

            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }

            Targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();

            report.AppendLine($"- {Name}");
            report.AppendLine($" *Type: {this.GetType().Name}");
           
           
            report.AppendLine($" *Armor thickness: {ArmorThickness}");
            report.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            report.AppendLine($" *Speed: {Speed} knots");
            report.AppendLine($" *Targets: {(Targets.Count == 0 ? "None" : string.Join(", ", Targets))}");

            return report.ToString().TrimEnd();
        }
    }
}
