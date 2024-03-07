using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1wi_proekt
{
    public class Super_Reduced_String
    {
        public static string SuperReducedString(string s)
        {
            string output = s;
            int indexOf;

            for (int i = 0; i < s.Length; i++)
            {
                char current = s[i];
                string pattern = $"{current}{current}";

                indexOf = output.IndexOf(pattern);

                if (indexOf != -1)
                {
                    output = output.Replace(pattern, "");

                    // reset it
                    i = 0;
                }
            }

            if (output.Length == 0)
            {
                output = "Empty String";
            }

            return output;
        }

        // another way (with Stack)
        public static string SuperReducedStringStack(string s)
        {
            Stack<char> chars = new Stack<char>();


            for (int i = 0; i < s.Length; i++)
            {
                if (chars.Count == 0)
                {
                    chars.Push(s[i]);
                    continue;
                }

                if (chars.Peek() == s[i])
                {
                    chars.Pop();
                }
                else
                {
                    chars.Push(s[i]);
                }
            }

            Stack<char> helper = new Stack<char>(chars);
            string output = string.Empty;

            for (int i = 0; i < chars.Count; i++)
            {
                output += helper.Pop();
            }

            return output;
        }
    }
}
