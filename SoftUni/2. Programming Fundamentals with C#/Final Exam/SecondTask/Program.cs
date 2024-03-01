using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _6._2_Message_Decrypter
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string validPattern = @"^(\$|\%)(?<tag>[A-Z][a-z]{2,})(\1)\:\s(?<numbers>\[\d+\]\|\[\d+\]\|\[\d+\]\|)$";

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine();
                Match validMessage = Regex.Match(message, validPattern);

                if (!validMessage.Success)
                {
                    Console.WriteLine("Valid message not found!");
                    continue;
                }
                string tag = validMessage.Groups["tag"].Value;
                string decryptedMessage = DecryptedMesage(validMessage);

                Console.WriteLine($"{tag}: {decryptedMessage}");
            }
        }
        static string DecryptedMesage(Match validMesage)
        {
            string allCharacters = validMesage.Groups["numbers"].Value;

            //replace all '[' , ']' or '|'
            allCharacters = allCharacters.Replace("[", "");
            allCharacters = allCharacters.Replace("]", "");
            allCharacters = allCharacters.Replace("|", " ");
            int[] numbers = allCharacters.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var num in numbers)
            {
                sb.Append((char)num);
            }

            return sb.ToString();
        }
    }
}
