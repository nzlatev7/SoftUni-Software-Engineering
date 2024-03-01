using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public abstract class Bread
    {
        public abstract void MixIngredients();
        public abstract void Bake();

        public virtual void Slice()
        {
            Console.WriteLine($"Slicing the {this.GetType().Name} bread!");
        }

        //the template method
        public void Make()
        {
            MixIngredients();
            Bake();
            Slice();
        }
    }
}
