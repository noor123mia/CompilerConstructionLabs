using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter input:");
        string input = Console.ReadLine();

        // Split the input based on spaces
        string[] words = input.Split(' ');

        // Regular Expression for relational operators
        Regex regex1 = new Regex("^(==|!=|<=|>=|<|>)$");

        Console.WriteLine("Relational operators found:");
        foreach (string word in words)
        {
            if (regex1.IsMatch(word))
            {
                Console.WriteLine($"Valid: {word}");
            }
            else
            {
                Console.WriteLine($"Invalid: {word}");
            }
        }
        Console.ReadKey();
    }
}