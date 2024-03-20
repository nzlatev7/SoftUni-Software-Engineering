using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1wi_proekt.Solutions
{
    public class SherlockAndTheValidString
    {
        public static string IsValid(string s)
        {
            Dictionary<char, int> charactersCount = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                if (!charactersCount.Keys.Contains(s[i]))
                {
                    charactersCount[s[i]] = 0;
                }

                charactersCount[s[i]]++;
            }

            int firstValue = charactersCount[s[0]];
            if (charactersCount.Values.All(v => v == firstValue))
            {
                return "YES";
            }

            char diffKey = charactersCount.First(ch => ch.Value != firstValue).Key;
            charactersCount[diffKey]--;

            if (charactersCount[diffKey] == 0)
            {
                charactersCount.Remove(diffKey);
            }

            if (charactersCount.Values.All(v => v == firstValue))
            {
                return "YES";
            }

            return "NO";
        }
    }
}
