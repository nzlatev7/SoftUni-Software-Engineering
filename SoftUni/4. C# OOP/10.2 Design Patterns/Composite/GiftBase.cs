using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class GiftBase
    {
        private string name;
        private int price;

        public GiftBase(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public string Name { get; private set; }
        public int Price { get; private set; }

        public abstract int CalculateTotalPrice();
    }
}
