using System;
using System.Collections.Generic;
using System.Text;

namespace _4.Models.Interfaces
{
    public interface IFeline : IMammal
    {
        string Breed { get; }
    }
}
