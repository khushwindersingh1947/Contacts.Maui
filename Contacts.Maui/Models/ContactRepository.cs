
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Maui.Models
{
    public static class ContactRepository
    {
        public static List<Contact> _contacts = new List<Contact>() 
        {
            new Contact { ContactId = 1, Name="John Doe", Email="aoe@email.com"},
            new Contact {ContactId = 2, Name="Jahn Aoe", Email="boe@email.com"},
            new Contact {ContactId = 3, Name="Jehn Boe", Email="coe@email.com"},
            new Contact {ContactId = 4, Name="Jrhn Coe", Email="doe@email.com"}
        };

        public static List<Contact> GetContacts() => _contacts;

        public static Contact GetContactById(int id) 
        {
            var contact = _contacts.FirstOrDefault(x => x.ContactId == id);
            if (contact != null) 
            {
                return new Contact()
                {
                    ContactId = contact.ContactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    Address = contact.Address,
                    Phone = contact.Phone
                };
            }
            return contact;
        }

        public static void UpdateContact(int contactId, Contact contact)
        {
            if (contactId != contact.ContactId) return;

            var contactToUpdate = _contacts.FirstOrDefault(x => x.ContactId == contactId);

            //can also use automapper
            if (contactToUpdate != null) 
            {
                contactToUpdate.Address = contact.Address;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Phone = contact.Phone;
            }


        }

        public static void AddContact(Contact contact) 
        {
            var maxId = _contacts.Max(x => x.ContactId) + 1;
            contact.ContactId = maxId;
            _contacts.Add(contact);
        }


    };
    
}
