using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public bool SonarMode { get; private set; }

        public void ToggleSonarMode()
        {
            SonarMode = SonarMode ? false : true;

            if (SonarMode)
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

        public override void RepairVessel()
        {
            ArmorThickness = InitialArmorThickness;
        }

        public override string ToString()
        {
            StringBuilder report = new StringBuilder();
            report.AppendLine(base.ToString());
            report.AppendLine($" *Sonar mode: {(SonarMode ? "ON" : "OFF")}");

            return report.ToString().TrimEnd();
        }
    }
}
