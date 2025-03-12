using Microsoft.IdentityModel.Tokens;
using PhoneBook.Models;

namespace PhoneBook;

internal class UserInterface
{
    private readonly ContactController _contactController = new();
    bool isRunning = true;
    internal void DisplayInterface()
    {
        while (isRunning)
        {
            Console.Clear();
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
                    DisplayContacts(_contactController.GetContacts());
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadLine();
                    break;
                case 3:
                    DisplayContacts(_contactController.GetContacts());
                    _contactController.UpdateContact();
                    break;
                case 4:
                    DisplayContacts(_contactController.GetContacts());
                    _contactController.DeleteContact();
                    break;
                case 5:
                    isRunning = false;
                    break;
            }
        }
    }

    internal void DisplayContacts(List<Contact> contacts)
    {
        if (contacts.IsNullOrEmpty())
        {
            Console.WriteLine("No contacts found!");
        }
        else
        {
            foreach (var contact in contacts)
            {
                Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Phone Number: {contact.PhoneNumber}, E-mail: {contact.Email}");
            }
        }
    }
}