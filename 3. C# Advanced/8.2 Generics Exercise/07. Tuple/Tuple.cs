using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BoxOfString
{
    public class Tuple<Item1, Item2>
    {
        List<(Item1, Item2)> pairs;

        public Tuple()
        {
            pairs = new List<(Item1, Item2)>();
        }

        public void Add(Item1 item1, Item2 item2)
        {
            pairs.Add((item1, item2));
        }

        public override string ToString()
        {
            (Item1, Item2) pair = pairs.FirstOrDefault();
            return $"{pair.Item1} -> {pair.Item2}";
        }
    }
}
