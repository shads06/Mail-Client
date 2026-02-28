using MailClient.Core.Models;
using MailClient.Core.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MailClient.DAL.Managers
{
    public class ContactRepository : IContactRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public Contact Add(Contact contact)
        {
            if (!File.Exists(MailClient.Core.Main.ContactsFileMainPath)) throw new FileNotFoundException("Failed to add contact", MailClient.Core.Main.ContactsFileMainPath);
            using(StreamWriter contactsSW = new StreamWriter(MailClient.Core.Main.ContactsFileMainPath))
                contactsSW.WriteLine(contact.ToString());
            return contact;
        }

        public Task<Contact> AddAsync(Contact item)
        {
            throw new NotImplementedException();
        }

        public Task<Contact> DeleteAsync(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetSingleAsync(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Contact Update(Contact contact)
        {
            return null;
        }

        public Task<Contact> UpdateAsync(Contact item)
        {
            throw new NotImplementedException();
        }
    }
}