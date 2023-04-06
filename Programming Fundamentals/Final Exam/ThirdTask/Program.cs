using System;
using System.Collections.Generic;

namespace _6._3_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] pairs = Console.ReadLine().Split(" | ");

            var words = new Dictionary<string, List<string>>();

            foreach (var pair in pairs)
            {
                string[] info = pair.Split(": ");
                string word = info[0];
                string definition = info[1];

                if (words.ContainsKey(word))
                {
                    words[word].Add(definition);
                    continue;
                }
                List<string> definitions = new List<string>();
                definitions.Add(definition);
                words.Add(word, definitions);
            }

            string[] teacherWords = Console.ReadLine().Split(" | ");
            string command = Console.ReadLine();

            if (command == "Test")
            {
                List<string> wordsForTest = new List<string>();
                foreach (var word in teacherWords)
                {
                    if (words.ContainsKey(word))
                    {
                        wordsForTest.Add(word);
                    }
                }

                foreach (var word in wordsForTest)
                {
                    var definitions = words[word];
                    Console.WriteLine($"{word}:");
                    foreach (var definition in definitions)
                    {
                        Console.WriteLine($" -{definition}");
                    }
                }
            }
            else if (command == "Hand Over")
            {
                Console.WriteLine(string.Join(" ", words.Keys));
            }
        }
    }
}
