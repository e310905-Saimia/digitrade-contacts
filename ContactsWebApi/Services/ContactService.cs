using ContactsWebApi.Models;
using ContactsWebApi.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ContactsWebApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        #region Create
        public Contact Create(Contact contact)
        {
            return _contactRepository.Create(contact);
        }
        #endregion
        #region Read
        public List<Contact> Read()
        {
            return _contactRepository.Read();
        }

        public Contact Read(int id)
        {
            return _contactRepository.Read(id);
        }
        #endregion
        #region Update
        public Contact Update(int id, Contact contact)
        {
            var savedContact = _contactRepository.Read(id);
            if (savedContact == null)
                throw new Exception("Contacts not found");

            return _contactRepository.Update(contact);
        }
        #endregion
        #region Delete
        public StatusCodeResult Delete(int id)
        {
            var deletedContact = _contactRepository.Read(id);
            if (deletedContact == null)
                return new NotFoundResult();
                //throw new Exception("Contacts not found");

            return _contactRepository.Delete(id);
        }
        #endregion
    }
}
