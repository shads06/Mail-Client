using MailClient.Core.Models;

namespace MailClient.Core.Storage
{
    /// <summary>
    /// MailServer-specific repository contract.
    /// </summary>
    public interface IMailServerRepository : IRepository<MailServer>
    {
        // Add server-specific operations here if needed
    }
}