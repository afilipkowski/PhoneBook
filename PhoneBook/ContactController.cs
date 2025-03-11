using PhoneBook.Models;

namespace PhoneBook;

internal class ContactController
{
    internal void AddContact()
    {
        string name;
        string phoneNumber;
        string email;
        ContactsContext contactsContext = new();

        Console.WriteLine("Insert contact details.");
        Console.Write("Name: ");
        name = Console.ReadLine();
        Console.Write("Phone number (xxx-xxx-xxx): ");
        phoneNumber = UserInput.ValidateInput(email: false);
        Console.Write("Email address: ");
        email = UserInput.ValidateInput(email: true);

        contactsContext.Add(new Contact { Name=name, PhoneNumber=phoneNumber, Email=email});
        contactsContext.SaveChanges();
        Console.WriteLine("Contact added succesfully. Press any key to continue...");
        Console.ReadLine();
        Console.Clear();
    }

    internal void DeleteContact()
    {
        throw new NotImplementedException();
    }

    internal void GetContacts()
    {
        throw new NotImplementedException();
    }

    internal void UpdateContact()
    {
        throw new NotImplementedException();
    }
}