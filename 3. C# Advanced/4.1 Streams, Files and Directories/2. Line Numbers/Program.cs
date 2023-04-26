using System.IO;

namespace LineNumbers
{
    public class LineNumbers
    {
        static void Main()
        {
            string inputPath = @"..\..\..\Files\input.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            RewriteFileWithLineNumbers(inputPath, outputPath);
        }

        public static void RewriteFileWithLineNumbers(string inputFilePath, string outputFilePath)
        {
            StreamReader streamReader = new StreamReader(inputFilePath);
            StreamWriter streamWriter = new StreamWriter(outputFilePath);

            using (streamReader)
            {
                using (streamWriter)
                {
                    int counter = 1;

                    string expresion;
                    while ((expresion = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine($"{counter++}. {expresion}");
                    }
                }
            }
        }
    }
}
