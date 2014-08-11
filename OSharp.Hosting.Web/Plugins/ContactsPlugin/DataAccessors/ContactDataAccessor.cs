using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContactsPlugin.Models;
using ContactsPlugin.ViewModels;

namespace ContactsPlugin.DataAccessors
{
    public class ContactDataAccessor
    {
        private static List<Contact> _contacts;
        static ContactDataAccessor()
        {
            var result = new List<Contact>();
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry1", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry2", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry3", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry4", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry5", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry6", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry7", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry8", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry9", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry10", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry11", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry12", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry13", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry14", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry15", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry16", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry17", Phone = "88332685", Email = "zhenbao@uishell.com" });
            result.Add(new Contact { Id = Contact.NewId(), Name = "Lorry18", Phone = "88332685", Email = "zhenbao@uishell.com" });
            _contacts = result;
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public List<Contact> GetPage(int pageSize, ref int pageNum, out int contactCount, out int pageCount)
        {
            contactCount = _contacts.Count;
            if (contactCount % pageSize == 0)
            {
                pageCount = contactCount / pageSize;
            }
            else
            {
                pageCount = contactCount / pageSize + 1;
            }

            if (pageNum <= 1)
            {
                pageNum = 1;
            }
            if (pageNum >= pageCount)
            {
                pageNum = pageCount;
            }

            return _contacts.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
        }

        public Contact GetById(int id)
        {
            return _contacts.Single(c => c.Id == id);
        }

        public void Save(Contact contact)
        {
            var c = GetById(contact.Id);
            c.Name = contact.Name;
            c.Phone = contact.Phone;
            c.Email = contact.Email;
        }

        public void Add(Contact contact)
        {
            _contacts.Add(contact);
        }

        public void Delete(int id)
        {
            _contacts.Remove(GetById(id));
        }
    }
}