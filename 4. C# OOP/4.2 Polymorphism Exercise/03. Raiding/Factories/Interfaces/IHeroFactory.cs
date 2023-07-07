using _3.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Factories.Interfaces
{
    public interface IHeroFactory
    {
        IBaseHero Create(string heroName, string heroType);
    }
}
