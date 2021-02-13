using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Models
{
    public interface IContactRepository
    {
        void Add(ContactsModel item);
        IEnumerable<ContactsModel> GetAll();
        ContactsModel Find(string key);
        ContactsModel Delete(string key);
        void Update(ContactsModel item);
    }
}
