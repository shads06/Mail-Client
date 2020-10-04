using Mail_Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail_Client.Managers
{

    public interface IManagerDB<T> : IManager<T> where T : IDBEntity
    {
    }

}
