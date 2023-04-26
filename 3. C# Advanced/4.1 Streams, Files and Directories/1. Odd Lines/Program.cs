using System.IO;

namespace OddLines
{
    public class OddLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\Files\input.txt";
            string outputFilePath = @"..\..\..\Files\output.txt";

            ExtractOddLines(inputFilePath, outputFilePath);
        }

        public static void ExtractOddLines(string inputFilePath, string outputFilePath)
        {
            StreamReader streamReader = new StreamReader(inputFilePath);

            StreamWriter writer = new StreamWriter(outputFilePath);

            using (streamReader)
            {
                using (writer)
                {
                    string expresion = streamReader.ReadLine();

                    int counter = 0;
                    while (expresion != null)
                    {
                        if (counter % 2 != 0)
                        {
                            writer.WriteLine(expresion);
                        }
                        counter++;
                        expresion = streamReader.ReadLine();
                    }
                }
            }
        }
    }
}
