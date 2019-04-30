using ContactsWebApi.Models;
using ContactsWebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebApi.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public Contact Create(Contact contact)
        {
            return _contactRepository.Create(contact);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> Read()
        {
            return _contactRepository.Read();
        }

        public Contact Read(int id)
        {
            return _contactRepository.Read(id);
        }

        public Contact Update(int id, Contact contact)
        {
            var savedContact = _contactRepository.Read(id);
            if (savedContact == null)
                throw new Exception("Contacts not found");

            return _contactRepository.Update(contact);
        }
    }
}
