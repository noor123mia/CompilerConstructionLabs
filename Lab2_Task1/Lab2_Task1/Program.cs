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

        // Regular Expression for logical operators (AND, OR, NOT, XOR)

        Regex regex = new Regex(@"^(and|or|not|\|\||&&|!|\^|&|\||~|<<|>>|\?\?|:\?)$");


        Console.WriteLine("Logical operators found:");
        foreach (string word in words)
        {
            if (regex.IsMatch(word))
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