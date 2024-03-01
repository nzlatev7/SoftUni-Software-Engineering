using _3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3
{
    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name, int power)
        {
            Name = name;
            Power = power;
        }

        public string Name { get; private set; }
        public int Power { get; private set; }

        public abstract string CastAbility();
    }
}
