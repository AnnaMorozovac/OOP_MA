namespace WordCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;

    public class WordCount
    {
        static void Main()
        {
            string wordsFilePath = @"..\..\..\words.txt";
            string textFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\actualResult.txt";
            string expectedFilePath = @"..\..\..\expectedResult.txt";

            ProcessWordCount(wordsFilePath, textFilePath, outputFilePath, expectedFilePath);

            Console.WriteLine("Done!");
        }

        public static void ProcessWordCount(string wordsFilePath, string textFilePath, string outputFilePath, string expectedFilePath)
        {
            var words = File.ReadAllLines(wordsFilePath).Select(w => w.Trim().ToLower()).Where(w => w.Length > 0).ToList();

            string text = File.ReadAllText(textFilePath).ToLower();

            char[] separators = { ' ', '\n', '\r', '.', ',', '!', '?', '-', ';', ':' };
            var textWords = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (var word in words)
            {
                int count = textWords.Count(w => w == word);
                counts[word] = count;
            }

            var sorted = counts.OrderByDescending(x => x.Value).Select(x => $"{x.Key} - {x.Value}");
            var standart = counts.Select(x => $"{x.Key} - {x.Value}");

            File.WriteAllLines(outputFilePath, standart);
            File.WriteAllLines(expectedFilePath, sorted);
        }
    }
}
