namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new StringBuilder();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string currentLine = string.Empty;

                int lineCounter = 1;

                while (!reader.EndOfStream)
                {
                    currentLine = reader.ReadLine();

                    int letterCounter = 0;
                    int puncMarks = 0;

                    foreach (var ch in currentLine)
                    {
                        if (char.IsLetter(ch))
                        {
                            letterCounter++;
                        }
                        if (char.IsPunctuation(ch))
                        {
                            puncMarks++;
                        }
                    }

                    sb.Append($"Line {lineCounter++}: ");
                    sb.Append(currentLine);
                    sb.AppendLine($"({letterCounter})({puncMarks})");
                }
            }

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine(sb.ToString());
            }
        }
    }
}
