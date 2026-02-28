using MailClient.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailClient.Core.Storage
{
    public interface IContactListRepository : IRepository<ContactList>
    {
        Task<IEnumerable<Contact>> GetContactsInListAsync(string listName);
        Task<IEnumerable<Contact>> AddContactsToListAsync(string listName, IEnumerable<string> entries);
    }
}
