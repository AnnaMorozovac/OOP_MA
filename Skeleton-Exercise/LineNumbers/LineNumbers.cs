namespace LineNumbers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Not found text.txt");
                return;
            }

            ProcessLines(inputFilePath, outputFilePath);

            Console.WriteLine("Done!");
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            string[] lines = File.ReadAllLines(inputFilePath);
            var output = new List<string>();

            int lineNumber = 1;

            foreach (var line in lines)
            {
                int letters = line.Count(char.IsLetter);
                int punctution = line.Count(ch => char.IsPunctuation(ch));

                string formatted = $"Line {lineNumber}: {line} ({letters})({punctution})";
                output.Add(formatted);

                lineNumber++;
            }

            File.WriteAllLines(outputFilePath, output);
        }
    }
}
