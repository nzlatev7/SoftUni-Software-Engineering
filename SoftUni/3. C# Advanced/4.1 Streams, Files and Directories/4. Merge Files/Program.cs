using System.Collections.Generic;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader firstReader = new StreamReader(firstInputFilePath);
            StreamReader secondReader = new StreamReader(secondInputFilePath);

            StreamWriter writer = new StreamWriter(outputFilePath);

            List<string> firstLines = Reading(firstReader);
            List<string> secondLines = Reading(secondReader);

            List<string> output = MergeOperation(firstLines, secondLines);

            PrintLines(output, writer);


        }
        static void PrintLines(List<string> output, StreamWriter writer)
        {
            using (writer)
            {
                foreach (var line in output)
                {
                    writer.WriteLine(line);
                }
            }
        }
        static List<string> MergeOperation(List<string> firstLines, List<string> secondLines)
        {
            List<string> output = new List<string>();

            int smallerLength = 0;
            List<string> bigger;
            if (firstLines.Count <= secondLines.Count)
            {
                smallerLength = firstLines.Count;
                bigger = secondLines;
            }
            else
            {
                smallerLength = secondLines.Count;
                bigger = firstLines;
            }

            for (int i = 0; i < smallerLength; i++)
            {
                output.Add(firstLines[i]);
                output.Add(secondLines[i]);
            }

            for (int i = smallerLength; i < bigger.Count; i++)
            {
                output.Add(bigger[i]);
            }

            return output;
        }
        static List<string> Reading(StreamReader reader)
        {
            List<string> lines = new List<string>();

            using (reader)
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }

            return lines;
        }
    }
}
