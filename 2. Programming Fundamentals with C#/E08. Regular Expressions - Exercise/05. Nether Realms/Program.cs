using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            //string pattern = @"(?<health>[^\+\-\*\/\.\/\d])|(?<damage>[\+\-]?\d+(\.\d+?)?)[\/\*]*";
            //string pattern = @"(?<health>[^\+\-\*\/\.\/\d])|(?<damage>[\+\-]?\d+(\.\d+?)?)|(?<multiplyOrDevide>[\*\\]+)";
            //Regex regex = new Regex(pattern);

            string damagePattern = @"(?<damage>[\+\-]?\d+(\.\d+?)?)";
            string mulOrDev = @"(?<multiplyOrDevide>[\*\\])";
            string healthPattern = @"(?<health>[^\+\-\*\/\.\/\d])";

            List<string> demons = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).OrderBy(x => x).ToList();

            for (int i = 0; i < demons.Count; i++)
            {
                string currentDemon = demons[i];

                MatchCollection charsForHealth = Regex.Matches(currentDemon, healthPattern);
                int health = HealthCalculation(charsForHealth);

                MatchCollection damageNums = Regex.Matches(currentDemon, damagePattern);
                MatchCollection multiplyOrDevide = Regex.Matches(currentDemon, mulOrDev);
                double resultDamage = DamageCalculation(damageNums, multiplyOrDevide);

                Console.WriteLine($"{currentDemon} - {health} health, {resultDamage:f2} damage");
            }
        }
        static int HealthCalculation(MatchCollection charsForHealth)
        {
            int health = 0;
            foreach (Match ch in charsForHealth)
            {
                char currentChar = char.Parse(ch.ToString());
                health += currentChar;
            }
            return health;
        }
        static double DamageCalculation(MatchCollection damageNums, MatchCollection multiplyOrDevide)
        {
            double result = 0;
            foreach (Match num in damageNums)
            {
                double curNum = double.Parse(num.ToString());
                result += curNum;
            }
            foreach (Match sign in multiplyOrDevide)
            {
                if (sign.ToString() == "*")
                {
                    result *= 2;
                }
                else if (sign.ToString() == "/")
                {
                    result /= 2;
                }
            }
            return result;
        }
    }
}

