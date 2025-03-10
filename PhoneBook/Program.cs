using PhoneBook.Models;

var db = new ContactsContext();
db.Add(new Contact { });
db.SaveChanges();