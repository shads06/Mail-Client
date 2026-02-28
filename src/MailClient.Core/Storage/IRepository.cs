using MailClient.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailClient.Core.Storage
{
    /// <summary>
    /// Generic repository operations for storage providers.
    /// Storage implementations should implement these methods.
    /// </summary>
    public interface IRepository<T> where T : IDBEntity
    {
        Task<T> GetSingleAsync(dynamic id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<T> DeleteAsync(dynamic id);
    }
}