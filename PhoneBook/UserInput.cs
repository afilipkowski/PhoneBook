using System.Text.RegularExpressions;

namespace PhoneBook;

internal static class UserInput
{
    internal static int GetInt(string prompt)
    {
        int input;
        Console.Write(prompt);
        while (!int.TryParse(Console.ReadLine(), out input))
        {
            Console.WriteLine("Invalid input. Please try again.");
        }
        return input;
    }

    internal static int GetMenuOption()
    {
        int input = GetInt("Select the option: ");
        while (input < 1 || input > 5)
        {
            Console.WriteLine("Invalid option. Please try again.");
            input = GetInt("Select the option: ");
        }
        return input;
    }

    internal static string ValidateInput(bool email=false)
    {
        string input;
        string pattern = email ? @"^\S+@\S+\.\S+$" : @"^\d{3}-\d{3}-\d{3}$";

        input = Console.ReadLine();
        while (!Regex.Match(input, pattern).Success)
        {
            Console.Write("Incorrect input. Enter the data in correct format: ");
            input = Console.ReadLine();
        }
        return input;
    }
}