namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);

            string line;
            int lineNumber = 0;

            string result = "";

            while ((line = reader.ReadLine()) != null)
            {
                if (lineNumber % 2 == 0)
                {
                    char[] chars = { '-', ',', '.', '!', '?' };
                    foreach (var ch in chars)
                    {
                        line = line.Replace(ch, '@');
                    }

                    string reversed = string.Join(" ", line.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse());

                    result += reversed + Environment.NewLine;
                }

                lineNumber++;
            }

            return result.TrimEnd();
        }
    }
}
