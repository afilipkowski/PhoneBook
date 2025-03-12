using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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

        contactsContext.Add(new Contact { Name = name, PhoneNumber = phoneNumber, Email = email });
        contactsContext.SaveChanges();
        Console.WriteLine("Contact added succesfully. Press any key to continue...");
        Console.ReadLine();
        Console.Clear();
    }

    internal void DeleteContact()
    {
        ContactsContext contactsContext = new();

        int id = UserInput.GetInt("\nEnter ID of the contact you want to delete or enter 0 to return: ");
        if (id == 0) return;
        var contact = contactsContext.Contacts.Find(id);
        if (contact != null)
        {
            contactsContext.Remove(contact);
            contactsContext.SaveChanges();
            Console.WriteLine("Contact deleted succesfully. Press any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }
        else
            Console.WriteLine("Contact not found!");
    }

    internal List<Contact> GetContacts()
    {
        ContactsContext contactsContext = new();
        List<Contact> contacts = contactsContext.Contacts.ToList();
        return contacts;
    }

    internal void UpdateContact()
    {
        ContactsContext contactsContext = new();

        int id = UserInput.GetInt("\nEnter ID of the contact you want to update or enter 0 to return: ");
        if (id == 0) return;
        var contact = contactsContext.Contacts.Find(id);
        if (contact != null)
        {
            Console.Write("Insert new name (or leave it blank if you don't want to change the name): ");
            string name = Console.ReadLine();
            if (name != "") contact.Name = name;

            Console.Write("Insert new phone number (or leave it blank if you don't want to change the phone number): ");
            string phoneNumber = UserInput.ValidateInput(email: false, update: true);
            if (phoneNumber != "") contact.PhoneNumber = phoneNumber;

            Console.Write("Insert new email address (or leave it blank if you don't want to change the email address): ");
            string email = UserInput.ValidateInput(email: true, update: true);
            if (email != "") contact.Email = email;

            contactsContext.SaveChanges();
            Console.WriteLine("Contact updated succesfully. Press any key to continue...");
            Console.ReadLine();
        }
        else
            Console.WriteLine("Contact not found!");
    }
}