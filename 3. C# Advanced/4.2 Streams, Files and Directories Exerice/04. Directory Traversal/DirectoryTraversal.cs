namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            StringBuilder reportFile = new StringBuilder();

            DirectoryInfo info = new DirectoryInfo(inputFolderPath);

            Dictionary<string, Dictionary<string, long>> typesFiles = new Dictionary<string, Dictionary<string, long>>();

            long fileSizeInBytes = 0;
            long fileSizeInKB = 0;

            foreach (FileInfo file in info.GetFiles())
            {
                fileSizeInBytes = file.Length;
                fileSizeInKB = fileSizeInBytes / 1024;

                if (!typesFiles.ContainsKey(file.Extension))
                {
                    typesFiles.Add(file.Extension, new Dictionary<string, long>());
                }

                typesFiles[file.Extension].Add(file.Name, fileSizeInKB);
            }
            
            foreach (var typeFiles in typesFiles
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key))
            {
                reportFile.AppendLine(typeFiles.Key);

                foreach (var file in typeFiles.Value
                    .OrderBy(x => x.Value))
                {
                    reportFile.AppendLine($"--{file.Key} - {file.Value}kb");
                }
            }

            return reportFile.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            using (StreamWriter writer = new StreamWriter(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "report.txt")))
            {
                writer.WriteLine(textContent);
            }
        }
    }
}
