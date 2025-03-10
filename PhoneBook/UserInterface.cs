namespace PhoneBook;

internal class UserInterface
{
    private readonly ContactController _contactController = new();
    internal void DisplayInterface()
    {
        Console.WriteLine("Welcome to the Phone Book!");
        Console.WriteLine("1. Add a new contact");
        Console.WriteLine("2. See all contacts");
        Console.WriteLine("3. Update a contact");
        Console.WriteLine("4. Delete a contact");
        Console.WriteLine("5. Exit");

        int choice = UserInput.GetMenuOption();

        switch (choice)
        {
            case 1:
                _contactController.AddContact();
                break;
            case 2:
                _contactController.GetContacts();
                break;
            case 3:
                _contactController.UpdateContact();
                break;
            case 4:
                _contactController.DeleteContact();
                break;
            case 5:
                Environment.Exit(0);
                break;
        }
    }
}