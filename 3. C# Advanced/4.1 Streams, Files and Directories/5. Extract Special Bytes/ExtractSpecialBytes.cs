namespace ExtractSpecialBytes
{
    using System;
    using System.IO;
    public class ExtractSpecialBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            FileStream photoStream = new FileStream(binaryFilePath, FileMode.Open);

            FileStream numStream = new FileStream(bytesFilePath, FileMode.Open);

            FileStream outputStream = new FileStream(outputPath, FileMode.OpenOrCreate);

            byte[] buffer = new byte[photoStream.Length];
            byte[] buffer1 = new byte[numStream.Length];

            using (photoStream)
            {
                photoStream.Read(buffer, 0, buffer.Length);

                using (numStream)
                {
                    numStream.Read(buffer, 0, buffer1.Length);
                }

                Console.WriteLine(string.Join(" ", buffer));

                Console.WriteLine();
                Console.WriteLine(string.Join(" ", buffer1));
            }

            using (outputStream)
            {
                outputStream.Write(buffer, 0, buffer.Length);
                outputStream.Write(buffer1, buffer.Length, buffer1.Length);
            }
        }
    }
}
