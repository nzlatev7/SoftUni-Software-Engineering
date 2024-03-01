namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            decimal size = GetFolderSize(folderPath);

            size = size / 1000;
            StreamWriter streamWriter = new StreamWriter(outputFilePath);

            using (streamWriter)
            {
                streamWriter.WriteLine($"{size} KB");
            }
        }
        public static long GetFolderSize(string path)
        {
            string[] filePaths = Directory.GetFiles(path);

            long size = 0;

            foreach (var filePath in filePaths)
            {
                FileInfo fileInfo = new FileInfo(filePath);

                size += fileInfo.Length;
            }
            foreach (var dirPath in Directory.GetDirectories(path))
            {
                size += GetFolderSize(dirPath);
            }

            return size;
        }
    }
}
