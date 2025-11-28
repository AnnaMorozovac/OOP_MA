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
            ZipArchive archive = ZipFile.Open(zipArchiveFilePath, ZipArchiveMode.Create);

            try
            {
                archive.CreateEntryFromFile(inputFilePath, Path.GetFileName(inputFilePath));
            }
            finally
            {
                archive.Dispose();
            }
        }

        public static void ExtractFileFromArchive(string zipArchiveFilePath, string fileName, string outputFilePath)
        {
            ZipArchive archive = ZipFile.OpenRead(zipArchiveFilePath);

            try
            {
                var entry = archive.GetEntry(fileName);
                if (entry != null)
                {
                    entry.ExtractToFile(outputFilePath, overwrite: true);
                }
            }
            finally
            {
                archive.Dispose();
            }
        }
    }
}
