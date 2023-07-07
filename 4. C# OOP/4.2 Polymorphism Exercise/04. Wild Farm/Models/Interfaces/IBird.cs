using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Interfaces
{
    public interface IBird : IAnimal
    {
        double WingSize { get; }
    }
}
