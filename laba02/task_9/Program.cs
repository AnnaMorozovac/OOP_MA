using System;
using System.Linq;

class Program
{
    static void Main()
    {
        char[] alphabet = { 'a', 'b', 'c', 'd', 'e', 'f', 'g',
                            'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
                            'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};

        Console.Write("Введiть слово(букви): ");
        char[] word = Console.ReadLine().ToCharArray();

        for(int i=0; i<word.Length; i++)
        {
            for(int j=0; j<alphabet.Length; j++)
            {
                if (word[i] == alphabet[j])
                {
                    Console.WriteLine($"Символ {word[i]} -> {j} iндекс");
                    break;
                }
            }
        }    
        
    }
}