namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            const int bufferSize = 4096;

            FileStream inputStream = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read);

            FileStream outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write);

            try
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead;

                while ((bytesRead = inputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outputStream.Write(buffer, 0, bytesRead);
                }
            }
            finally
            {
                inputStream.Close();
                outputStream.Close();
            }
        }
    }
}
