using ControllerSamples.Models;
using System.Collections.Concurrent;

namespace ControllerSamples.Data
{
    public class ContactRepository : IContactRepository
    {
        private static ConcurrentDictionary<int, Contact> _contacts =
            new ConcurrentDictionary<int, Contact>();

        public void Add(Contact contact)
        {
            _contacts[contact.Id] = contact;
        }

        public Contact Get(int key)
        {
            _contacts.TryGetValue(key, out Contact contact);
            return contact;
        }

        public IEnumerable<Contact> GetAll()
        {
          return _contacts.Values;
        }

        public Contact Remove(int key)
        {
            _contacts.TryRemove(key, out Contact contact);
            return contact;
        }

        public void Update(Contact contact)
        {
            _contacts[contact.Id] = contact;
        }
    }
}
