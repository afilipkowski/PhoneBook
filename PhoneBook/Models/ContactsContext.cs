using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace PhoneBook.Models;

internal class ContactsContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    public string DbPath { get; }

    public ContactsContext()
    {
        DbPath = ConfigurationManager.ConnectionStrings["DbPath"].ConnectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(DbPath);
    }
}