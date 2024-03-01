namespace ZipAndExtract
{
    using System;
    using System.IO;
    using System.IO.Compression;

    public class ZipAndExtract
    {
        static void Main()
        {
            string inputFile = @"..\..\..\copyMe.png";
            string zipArchiveFile = @"..\..\..\archive.zip";
            string extractedFile = @"..\..\..\extracted.png";

            ZipFileToArchive(inputFile, zipArchiveFile);

            var fileNameOnly = Path.GetFileName(inputFile);
            ExtractFileFromArchive(zipArchiveFile, fileNameOnly, extractedFile);
        }

        public static void ZipFileToArchive(string inputFilePath, string zipArchiveFilePath)
        {
            using (ZipArchive zipArchive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create))
            {
                zipArchive.CreateEntryFromFile(inputFilePath, Path.GetFileName(inputFilePath));
            }
        }


        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            using (ZipArchive zipArchive = ZipFile.OpenRead(zipArchiveFilePath))
            {
                ZipArchiveEntry entry = zipArchive.Entries[0];
                entry.ExtractToFile(outputFilePath, overwrite: true);
            }
        }
    }
}
