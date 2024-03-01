using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Interfaces
{
    public interface IMammal : IAnimal
    {
        string LivingRegion { get; }
    }
}
