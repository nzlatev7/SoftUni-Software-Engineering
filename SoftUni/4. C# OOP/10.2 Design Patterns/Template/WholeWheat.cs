using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    public
        class WholeWheat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking the Whole Wheat Bread. (15min)");
        }

        public override void MixIngredients()
        {
            Console.WriteLine("Gathering ingredients for Whole Wheat Bread.");
        }

        public override void Slice()
        {
            Console.WriteLine("Slicing is hard!");
            base.Slice();
        }
    }
}
