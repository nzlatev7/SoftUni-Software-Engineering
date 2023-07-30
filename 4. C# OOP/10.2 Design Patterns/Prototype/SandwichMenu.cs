using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class SandwichMenu
    {
        private Dictionary<string, SandwichPrototype> sandwiches =
            new Dictionary<string, SandwichPrototype>();

        public SandwichPrototype this[string name] 
        {
            get => sandwiches[name];
            set
            {
                sandwiches.Add(name, value);
            }
        }
    }
}
