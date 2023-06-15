using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Renovator
    {
        public Renovator(string name, string type, double rate, int days)
        {
            Name = name;
            Type = type;
            Rate = rate;
            Days = days;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public double Rate { get; set; }
        public int Days { get; set; }
        public bool Hired { get; set; } = false;

        public override string ToString()
        {
            StringBuilder renovatorInfo = new StringBuilder();

            renovatorInfo.AppendLine($"-Renovator: {Name}");
            renovatorInfo.AppendLine($"--Specialty: {Type}");
            renovatorInfo.AppendLine($"--Rate per day: {Rate} BGN");

            return renovatorInfo.ToString().TrimEnd();
        }

    }
}
