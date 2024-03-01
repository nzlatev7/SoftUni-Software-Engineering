using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Models
{
    public class LaserRadar : Supplement
    {
        private const int InterfaceStandardConst = 20082;
        private const int BatteryUsageConst = 5_000;
        public LaserRadar()
            : base(InterfaceStandardConst, BatteryUsageConst)
        {
        }
    }
}
