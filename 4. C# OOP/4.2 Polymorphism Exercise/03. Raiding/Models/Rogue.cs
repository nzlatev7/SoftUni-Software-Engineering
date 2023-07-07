using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Models
{
    public class Rogue : BaseHero 
    {
        private const int power = 80;
        public Rogue(string name)
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
