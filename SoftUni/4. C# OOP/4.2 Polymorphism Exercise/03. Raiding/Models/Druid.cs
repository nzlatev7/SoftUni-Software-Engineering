using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Models
{
    public class Druid : BaseHero
    {
        private const int power = 80;
        public Druid(string name)
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
