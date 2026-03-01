using MailClient.Core;
using MailClient.Core.Models;
using MailClient.Core.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MailClient.DAL.Managers
{
    public class ContactRepository : IContactRepository
    {
        public Task<Contact> AddAsync(Contact item)
        {
            try
            {
                if (item == null)
                    throw new ArgumentNullException(nameof(item));

                var contactsFilePath = MailClient.Core.Main.ContactsFileMainPath;

                if (!File.Exists(contactsFilePath))
                    throw new FileNotFoundException("Contacts file not found.", contactsFilePath);

                // Append the contact to the file
                using (var sw = File.AppendText(contactsFilePath))
                {
                    sw.WriteLine(item.ToString());
                }

                return Task.FromResult(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Contact> DeleteAsync(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetAllAsync()
        {
            try
            {
                var contactsFilePath = MailClient.Core.Main.ContactsFileMainPath;

                if (!File.Exists(contactsFilePath))
                    return Task.FromResult<IEnumerable<Contact>>(new List<Contact>());

                var lines = File.ReadAllLines(contactsFilePath)
                                .Where(l => !string.IsNullOrWhiteSpace(l))
                                .ToArray();

                List<Contact> contacts = new List<Contact>();

                foreach (var line in lines)
                {
                    var contact = ParseContactFromLine(line);
                    if (contact != null)
                    {
                        contacts.Add(contact);
                    }
                }

                return Task.FromResult<IEnumerable<Contact>>(contacts);
            }
            catch (Exception)
            {
                throw;
            }
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

        /// <summary>
        /// Parses a contact from a line in the format:
        /// ID: {id}, Name: {name}, PhoneNumber: {phone}, Email: {email}, Status: {status}, Created On: {createdOn}, Last Modified On: {lastUpdatedOn}
        /// </summary>
        private Contact ParseContactFromLine(string line)
        {
            try
            {
                var parts = line.Split(new[] { ", " }, StringSplitOptions.None);
                if (parts.Length < 7)
                    return null;

                var contact = new Contact();

                foreach (var part in parts)
                {
                    if (part.StartsWith("ID: ") && int.TryParse(part.Substring(4), out int id))
                        contact.ID = id;

                    else if (part.StartsWith("Name: "))
                        contact.Name = part.Substring(6);

                    else if (part.StartsWith("PhoneNumber: "))
                        contact.PhoneNumber = part.Substring(13);

                    else if (part.StartsWith("Email: "))
                        contact.Email = part.Substring(7);

                    else if (part.StartsWith("Status: ") && byte.TryParse(part.Substring(8), out var status))
                        contact.Status = (Status)status;

                    else if (part.StartsWith("Created On: ") && DateTime.TryParse(part.Substring(12), out DateTime createdOn))
                        contact.CreatedOn = createdOn;

                    else if (part.StartsWith("Last Modified On: ") && DateTime.TryParse(part.Substring(18), out var lastUpdated))
                        contact.LastUpdatedOn = lastUpdated;
                }

                return contact;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}