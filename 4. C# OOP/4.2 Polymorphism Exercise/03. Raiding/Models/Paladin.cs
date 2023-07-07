using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Models
{
    public class Paladin : BaseHero
    {
        private const int power = 100;
        public Paladin(string name)
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
