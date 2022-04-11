using ControllerSamples.Models;

namespace ControllerSamples.Data
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        IEnumerable<Contact> GetAll();
        Contact Get(int key);
        Contact Remove(int key);
        void Update(Contact contact);
    }
}
