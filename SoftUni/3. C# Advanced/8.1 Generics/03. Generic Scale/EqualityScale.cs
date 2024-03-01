using System;
using System.Collections.Generic;
using System.Text;

namespace GenericScale
{
    public class EqualityScale<T> where T : IComparable
    {
        public EqualityScale(T left, T rigth)
        {
            Left = left;
            Right = rigth;
        }

        public T Left { get; set; }
        public T Right { get; set; }

        public bool AreEqual()
        {
            if (Left.CompareTo(Right) == 0)
            {
                return true;
            }

            return false;
        }
    }
}
