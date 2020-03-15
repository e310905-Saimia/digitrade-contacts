using System.Collections.Generic;
using System.Linq;
using ContactsWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebApi.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactsdbContext _context;

        public ContactRepository(ContactsdbContext context)
        {
            _context = context;
        }
        #region Create
        public Contact Create(Contact contact)
        {
            _context.Add(contact);
            _context.SaveChanges();
            return contact;
        }
        #endregion
        #region Read
        public List<Contact> Read()
        {
            return _context.Contact
               .ToList();
        }

        public Contact Read(int id)
        {
            return _context.Contact
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id);
        }
        #endregion
        #region Update
        public Contact Update(Contact contact)
        {
            _context.Update(contact);
            _context.SaveChanges();
            return contact;
        }
        #endregion
        #region Delete
        public StatusCodeResult Delete(int id)
        {
            var deletedContact = Read(id);
            _context.Remove(deletedContact);
            _context.SaveChanges();
            return new OkResult();
        }
        #endregion
    }
}
