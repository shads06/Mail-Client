using MailClient.Core.Models;

namespace MailClient.DAL.XMLManagers
{

    public interface IManagerDB<T> : IManager<T> where T : IDBEntity
    {
    }

}
