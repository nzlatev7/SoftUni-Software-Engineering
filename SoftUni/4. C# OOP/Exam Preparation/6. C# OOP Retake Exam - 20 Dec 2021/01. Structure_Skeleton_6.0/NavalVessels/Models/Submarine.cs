using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private const double InitialArmorThickness = 200;
        public Submarine(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public bool SubmergeMode { get; private set; }

        public override void RepairVessel()
        {
            ArmorThickness = InitialArmorThickness;
        }

        public void ToggleSubmergeMode()
        {
            SubmergeMode = SubmergeMode ? false : true;

            if (SubmergeMode)
            {
                MainWeaponCaliber += 40;
                Speed -= 5;
            }
            else
            {
                MainWeaponCaliber -= 40;
                Speed += 5;
            }
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine(base.ToString());
            report.AppendLine($" *Submerge mode: {(SubmergeMode ? "ON" : "OFF")}");

            return report.ToString().TrimEnd();
        }
    }
}
