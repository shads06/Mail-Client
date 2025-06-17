using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail_Client.Managers
{

    /// <summary>
    /// Represent the base functionality to be implemented by every manager in Mail Client
    /// </summary>
    /// <typeparam name="T">Type of Entity</typeparam>
    public interface IManager<T>
    {

        /// <summary>
        /// Add new entity of type T
        /// </summary>
        /// <param name="item"></param>
        void Add(T item);

        /// <summary>
        /// Delete entity using it's unique ID
        /// </summary>
        /// <param name="itemID"></param>
        void Delete(dynamic itemID);

        /// <summary>
        /// Update entity of type T
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);

        /// <summary>
        /// Get entity of type T
        /// </summary>
        /// <param name="itemID">Unique ID of Entity to fetch</param>
        /// <returns>Instance of entity of type T</returns>
        T GetSingle(dynamic itemID);

        /// <summary>
        /// Get all instances of entity of type T
        /// </summary>
        /// <returns>Multiple instances of type T</returns>
        IEnumerable<T> GetAll();

    }

}
