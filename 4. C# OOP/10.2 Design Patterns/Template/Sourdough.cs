using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Sourdough Bread. (20min)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Sourdough Bread.");
        }
    }
}
