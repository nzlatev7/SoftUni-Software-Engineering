using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1wi_proekt
{
    internal class Beautiful_Binary_String
    {
        public static int BeautifulBinaryString(string b)
        {
            StringBuilder beautiful = new StringBuilder(b);

            int moveCount = 0;

            int index;
            while (beautiful.ToString().Contains("010"))
            {
                index = beautiful.ToString().IndexOf("010");
                beautiful[index + 2] = beautiful[index + 2] == '0' ? '1' : '0';

                moveCount++;
            }

            return moveCount;
        }
    }
}
