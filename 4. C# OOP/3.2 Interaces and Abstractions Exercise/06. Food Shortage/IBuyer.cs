using System;
using System.Collections.Generic;
using System.Text;

namespace _6
{
    interface IBuyer : INamable
    {
        public void BuyFood();
        public int Food { get; }
    }
}
