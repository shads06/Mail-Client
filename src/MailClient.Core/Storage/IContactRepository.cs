using MailClient.Core.Models;

namespace MailClient.Core.Storage
{
    /// <summary>
    /// Contact-specific repository contract (specialize if you need additional methods).
    /// </summary>
    public interface IContactRepository : IRepository<Contact>
    {
        // Add contact-specific operations here if needed
    }
}