using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            StreamReader wordsReader = new StreamReader(wordsFilePath);
            StreamReader textReader = new StreamReader(textFilePath);

            StreamWriter streamWriter = new StreamWriter(outputFilePath);

            var wordsCounter = new Dictionary<string, int>();

            
            using (wordsReader)
            {
                string allWords = wordsReader.ReadToEnd();
                List<string> words = allWords.Split(" ").ToList();

                string line;
                while ((line = textReader.ReadLine()) != null)
                {
                    foreach (var word in words)
                    {
                        if (!wordsCounter.ContainsKey(word))
                        {
                            wordsCounter.Add(word, 0);
                        }
                        string wordPattern = $@"\b{word}\b";
                        MatchCollection matches = Regex.Matches(line.ToLower(), wordPattern);
                        wordsCounter[word] += matches.Count;
                    }
                    //MatchCollection matches = Regex.Matches(line.ToLower(), word);
                    //currentMatches += matches.Count;
                }
            }

            using (streamWriter)
            {
                foreach (var word in wordsCounter.OrderByDescending(x => x.Value))
                {
                    streamWriter.WriteLine($"{word.Key} - {word.Value}");
                }
            }
        }
    }
}
