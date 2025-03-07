using System;
using System.Linq;
using System.Text;

class RandomPasswordGenerator
{
    static Random random = new Random();

    static string GeneratePassword(string firstName, string lastName, string regNumber, string movie, string food)
    {
        string specialChars = "!@#$%^&*";
        string allChars = firstName + lastName + regNumber + movie + food;

        // Ensure at least one uppercase letter
        char upperChar = firstName.ToUpper()[0];

        // Ensure at least one special character
        char specialChar = specialChars[random.Next(specialChars.Length)];

        // Ensure at least one number from regNumber
        char numberChar = regNumber[random.Next(regNumber.Length)];

        // Take random letters from name, movie, or food
        string mixedChars = new string(allChars.OrderBy(c => random.Next()).Take(6).ToArray());

        // Combine all elements
        string password = $"{upperChar}{specialChar}{numberChar}{mixedChars}";

        // Shuffle password for randomness
        return new string(password.OrderBy(c => random.Next()).ToArray());
    }

    static void Main()
    {
        Console.Write("Enter your first name: ");
        string firstName = Console.ReadLine();

        Console.Write("Enter your last name: ");
        string lastName = Console.ReadLine();

        Console.Write("Enter your registration number (3 digits only): ");
        string regNumber = Console.ReadLine();

        Console.Write("Enter your favorite movie: ");
        string movie = Console.ReadLine();

        Console.Write("Enter your favorite food: ");
        string food = Console.ReadLine();

        if (regNumber.Length != 3 || !regNumber.All(char.IsDigit))
        {
            Console.WriteLine("Error: Registration number must be exactly 3 digits.");
            return;
        }

        string password = GeneratePassword(firstName, lastName, regNumber, movie, food);
        Console.WriteLine("\n Generated Password: " + password);

        Console.ReadKey();
    }
}