using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1wi_proekt
{
    internal class CamelCase
    {
        public static int Camelcase(string s)
        {
            s = "saveChangesInTheEditor";

            int count = 1;

            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsUpper(s[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
