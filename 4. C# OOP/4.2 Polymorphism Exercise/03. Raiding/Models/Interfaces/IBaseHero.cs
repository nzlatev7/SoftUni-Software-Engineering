using System;
using System.Collections.Generic;
using System.Text;

namespace _3.Models
{
    public interface IBaseHero
    {
        string Name { get; }
        int Power { get; }

        string CastAbility();
    }
}
