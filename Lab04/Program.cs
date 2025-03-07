using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LexicalAnalyzerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Taking user input from the console
            Console.WriteLine("Enter the code to analyze (Press Enter twice to finish):");
            string userInput = "";
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                userInput += line + "\n"; // Collecting multi-line input
            }

            // List of keywords to separate keywords from variables
            List<String> keywordList = new List<String>
            {
                "int", "float", "while", "main", "if", "else", "new"
            };

            // Regular Expressions for Variables, Constants, Operators, Special Characters
            Regex variable_Reg = new Regex(@"^[A-Za-z|_][A-Za-z|0-9]*$");
            Regex constants_Reg = new Regex(@"^[0-9]+([.][0-9]+)?([e]([+|-])?[0-9]+)?$");
            Regex operators_Reg = new Regex(@"^[-*+/><&&||=]$");
            Regex special_Reg = new Regex(@"^[.,'\[\]{}();:?]$");

            // Initialize the buffers
            char[] inputBuffer = userInput.ToCharArray();  // Input buffer with all characters
            List<char> lexemeBuffer = new List<char>();    // Second buffer (used to hold current lexeme)

            // Pointer for inputBuffer
            int bufferPointer = 0;
            int line_num = 1;

            // Loop to process the input
            while (bufferPointer < inputBuffer.Length)
            {
                char currentChar = inputBuffer[bufferPointer];

                // Process the lexeme if the character is not a space or newline
                if (!char.IsWhiteSpace(currentChar))
                {
                    lexemeBuffer.Clear(); // Clear the lexeme buffer for a new lexeme

                    // Process the current character and continue reading if part of a lexeme
                    while (bufferPointer < inputBuffer.Length && !char.IsWhiteSpace(inputBuffer[bufferPointer]) && inputBuffer[bufferPointer] != '\n')
                    {
                        lexemeBuffer.Add(inputBuffer[bufferPointer]);
                        bufferPointer++;
                    }

                    string lexeme = new string(lexemeBuffer.ToArray());

                    // Match and print the type of lexeme (Keyword, Variable, Constant, Operator, or Special Character)
                    Match match_Variable = variable_Reg.Match(lexeme);
                    Match match_Constant = constants_Reg.Match(lexeme);
                    Match match_Operator = operators_Reg.Match(lexeme);
                    Match match_Special = special_Reg.Match(lexeme);

                    if (match_Variable.Success)
                    {
                        if (keywordList.Contains(lexeme)) // It's a keyword
                        {
                            Console.WriteLine($"<keyword, {lexeme}>");
                        }
                        else // It's a variable
                        {
                            Console.WriteLine($"<var, {lexeme}>");
                        }
                    }
                    else if (match_Constant.Success)
                    {
                        Console.WriteLine($"<digit, {lexeme}>");
                    }
                    else if (match_Operator.Success)
                    {
                        Console.WriteLine($"<op, {lexeme}>");
                    }
                    else if (match_Special.Success)
                    {
                        Console.WriteLine($"<punc, {lexeme}>");
                    }
                    else
                    {
                        Console.WriteLine($"<invalid, {lexeme}>");
                    }
                }
                else if (currentChar == '\n')
                {
                    // Handle newline, increment line number
                    line_num++;
                    bufferPointer++;
                }
                else
                {
                    // If it's a space, just move the pointer
                    bufferPointer++;
                }
            }

            Console.ReadKey();
        }
    }
}