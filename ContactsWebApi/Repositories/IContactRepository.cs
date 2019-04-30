using ContactsWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebApi.Repositories
{
    public interface IContactRepository
    {
        // CRUD
        Contact Create(Contact contact);
        List<Contact> Read();
        Contact Read(int id);
        Contact Update(Contact contact);
        StatusCodeResult Delete(int id);
    }
}
