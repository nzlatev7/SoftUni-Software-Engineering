using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public abstract class SandwichPrototype
    {
        public abstract SandwichPrototype Clone();

        public abstract SandwichPrototype DeepCopy();
    }
}
