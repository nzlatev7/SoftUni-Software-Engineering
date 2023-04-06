using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;

namespace testing
{
    class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            var validMessages = new Dictionary<string, string>();

            string pattern = @"\@(?<name>[A-Za-z]+)[^@!:>-]+!(?<type>(N)|(G))!";
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string encryptedMessage = command;
                string decryptedMessage = Decrypted(encryptedMessage, key);

                Match match = Regex.Match(decryptedMessage, pattern);

                if (match.Success)
                {
                    string name = match.Groups["name"].Value;
                    string type = match.Groups["type"].Value;
                    validMessages.Add(name, type);
                }
            }
            foreach (var message in validMessages.Where(x => x.Value == "G"))
            {
                Console.WriteLine(message.Key);
            }
        }
        static string Decrypted(string encryptedMessage, int key)
        {
            StringBuilder decryptedMessage = new StringBuilder();
            foreach (var ch in encryptedMessage)
            {
                int currentChar = ch - key;
                decryptedMessage.Append((char)currentChar);
            }
            return decryptedMessage.ToString();
        }
    }
}
