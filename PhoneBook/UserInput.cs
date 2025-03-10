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
}