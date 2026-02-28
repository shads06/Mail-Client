using System.Collections.Generic;
using System.Data;

namespace MailClient.DAL.XMLManagers
{

    public abstract class AbstractManagerDB<T> : IManagerDB<T> where T : IDBEntity
    {

        public abstract void Add(T item);

        public abstract void Delete(dynamic ItemId);

        public abstract void Update(T item);

        public abstract T GetSingle(dynamic ItemId);

        public abstract T GetItem(IDataReader reader);

        public abstract IEnumerable<T> GetAll();

    }

}
