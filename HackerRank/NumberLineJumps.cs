using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace _1wi_proekt
{
    internal class NumberLineJumps
    {
        public static string Kangaroo(int x1, int v1, int x2, int v2)
        {
            // first - x1, v1
            // second - x2, v2

            // return yes,no

            // x1 - 2, v1 - 1
            // x2 - 1, v2 - 2

            // 21,6,47,3

            if ((v1 > v2 && x1 > x2)
                || (v2 > v1 && x2 > x1))
            {
                return "NO";
            }

            if ((x1 < x2 && v1 <= v2)
                || (x2 < x1 && v2 <= v1))
            {
                return "NO";
            }

            if ((x1 % 2 != 0 && x2 % 2 == 0)
                && (v1 % 2 == 0 && v2 % 2 == 0))
            {
                return "NO";
            }

            if ((x2 % 2 != 0 && x1 % 2 == 0)
                && (v2 % 2 == 0 && v1 % 2 == 0))
            {
                return "NO";
            }

            int pos1 = x1;
            int pos2 = x2;

            while (x1 != x2)
            {
                x1 += v1;
                x2 += v2;
            }

            return "YES";
        }

        // the solution passed all tests!!!
        public static string Kangaroo2(int x1, int v1, int x2, int v2)
        {
            // first - x1, v1
            // second - x2, v2

            // return yes,no

            // x1 - 2, v1 - 1
            // x2 - 1, v2 - 2

            // 21,6,47,3

            if ((v1 > v2 && x1 > x2)
                || (v2 > v1 && x2 > x1))
            {
                return "NO";
            }

            if ((x1 < x2 && v1 <= v2)
                || (x2 < x1 && v2 <= v1))
            {
                return "NO";
            }

            if ((x1 % 2 != 0 && x2 % 2 == 0)
                && (v1 % 2 == 0 && v2 % 2 == 0))
            {
                return "NO";
            }

            if ((x2 % 2 != 0 && x1 % 2 == 0)
                && (v2 % 2 == 0 && v1 % 2 == 0))
            {
                return "NO";
            }

            int pos1 = x1;
            int pos2 = x2;

            bool isX1Bigger = x1 > x2 ? true : false;

            // count of jumps to be the same!
            while (x1 != x2)
            {
                x1 += v1;
                x2 += v2;

                if (isX1Bigger)
                {
                    if (x2 > x1)
                    {
                        return "NO";
                    }
                }
                else
                {
                    if (x1 > x2)
                    {
                        return "NO";
                    }
                }
            }

            return "YES";
        }
    }
}
