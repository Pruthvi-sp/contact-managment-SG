using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManagement.Models
{
    public class ContactsRepository : IContactRepository
    {
            private static ConcurrentDictionary<string, ContactsModel> _todos =
                  new ConcurrentDictionary<string, ContactsModel>();

            public ContactsRepository()
            {
                Add(new ContactsModel { FirstName = "Item1", LastName = "121212", HomeNumber = "12121221", MobileNumber = 89719827, PersonalNumber = "8767867868", ProfessionalNumber = "12121212" });
            }

            public IEnumerable<ContactsModel> GetAll()
            {
                return _todos.Values;
            }

            public void Add(ContactsModel item)
            {
                //item.Id = Guid.NewGuid().ToString();
                //_todos[item.Id] = item;
            }

            public ContactsModel Find(string key)
            {
                ContactsModel item;
                _todos.TryGetValue(key, out item);
                return item;
            }

            public ContactsModel Delete(string key)
            {
                ContactsModel item;
                _todos.TryGetValue(key, out item);
                _todos.TryRemove(key, out item);
                return item;
            }

            public void Update(ContactsModel item)
            {
               // _todos[item.Id] = item;
            }
        }
    }

