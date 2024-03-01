namespace EvenLines
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string currentLine = string.Empty;

                int counter = 0;
                while (!reader.EndOfStream)
                {
                    currentLine = reader.ReadLine();

                    if (counter % 2 == 0)
                    {
                        currentLine = Replacement(currentLine);

                        List<string> words = currentLine.Split(" ").ToList();

                        words.Reverse();

                        sb.AppendLine(string.Join(" ", words));
                    }

                    counter++;
                }
            }

            return sb.ToString();
        }
        static string Replacement(string currentLine)
        {
            if (currentLine.Contains('-'))
            {
                currentLine = currentLine.Replace('-', '@');
            }
            if (currentLine.Contains(','))
            {
                currentLine = currentLine.Replace(',', '@');
            }
            if (currentLine.Contains('.'))
            {
                currentLine = currentLine.Replace('.', '@');
            }
            if (currentLine.Contains('!'))
            {
                currentLine = currentLine.Replace('!', '@');
            }
            if (currentLine.Contains('?'))
            {
                currentLine = currentLine.Replace('?', '@');
            }

            return currentLine;
        }
    }
}
