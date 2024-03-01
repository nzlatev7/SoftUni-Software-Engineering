using _3.Factories.Interfaces;
using _3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Factories
{
    public class HeroFactory : IHeroFactory
    {
        public IBaseHero Create(string heroName, string heroType)
        {
            switch (heroType)
            {
                case "Druid":
                    return new Druid(heroName);
                case "Paladin":
                    return new Paladin(heroName);
                case "Rogue":
                    return new Rogue(heroName);
                case "Warrior":
                    return new Warrior(heroName);

                default:
                    throw new Exception("Invalid hero!");
            }
        }
    }
}
