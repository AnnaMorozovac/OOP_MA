namespace DirectoryTraversal
{
    using System;
    using System.IO;
    using System.Collections.Generic;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = "report.txt";

            string reportContent = TraverseDirectory(path);

            Console.WriteLine(reportContent);
            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            string[] files = Directory.GetFiles(inputFolderPath);
            Dictionary<string, List<FileInfo>> groups = new Dictionary<string, List<FileInfo>>();

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                string ext = info.Extension.ToLower();

                if (!groups.ContainsKey(ext))
                {
                    groups[ext] = new List<FileInfo>();
                }
                groups[ext].Add(info);
            }

            string report = "";

            foreach (var group in groups)
            {
                report += group.Key + Environment.NewLine;

                group.Value.Sort((a, b) => a.Length.CompareTo(b.Length));

                foreach (var file in group.Value)
                {
                    double sizeKb = file.Length / 1024.0;
                    report += $"--{file.Name} - {sizeKb:F3}kb" + Environment.NewLine;
                }
            }

            return report;
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullPath = Path.Combine(desktopPath, reportFileName);
            File.WriteAllText(fullPath, textContent);
        }
    }
}
