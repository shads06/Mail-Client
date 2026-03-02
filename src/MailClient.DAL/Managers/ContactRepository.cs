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
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            var contactsFilePath = MailClient.Core.Main.ContactsFileMainPath;
            if (!File.Exists(contactsFilePath))
                throw new FileNotFoundException("Contacts file not found.", contactsFilePath);
            using (var sw = File.AppendText(contactsFilePath))
                sw.WriteLine(item.ToString());
            return Task.FromResult(item);
        }

        public Task<Contact> DeleteAsync(dynamic id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (!int.TryParse(id.ToString(), out int contactId))
                throw new ArgumentException("Invalid contact ID.", nameof(id));
            var contactsFilePath = MailClient.Core.Main.ContactsFileMainPath;
            if (!File.Exists(contactsFilePath))
                throw new FileNotFoundException("Contacts file not found.", contactsFilePath);
            var lines = File.ReadAllLines(contactsFilePath);
            var updatedLines = new List<string>();
            Contact deletedContact = null;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    updatedLines.Add(line);
                    continue;
                }
                var contact = ParseContactFromLine(line);
                if (contact != null && contact.ID == contactId)
                {
                    contact.Status = Status.Deleted;
                    contact.LastUpdatedOn = DateTime.UtcNow;
                    updatedLines.Add(contact.ToString());
                    deletedContact = contact;
                }
                else
                    updatedLines.Add(line);
            }
            if (deletedContact == null)
                throw new InvalidOperationException($"Contact with ID {contactId} not found.");
            File.WriteAllLines(contactsFilePath, updatedLines);
            return Task.FromResult(deletedContact);
        }

        public Task<IEnumerable<Contact>> GetAllAsync()
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
                    contacts.Add(contact);
            }
            return Task.FromResult<IEnumerable<Contact>>(contacts);
        }

        public Task<Contact> GetSingleAsync(dynamic id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (!int.TryParse(id.ToString(), out int contactId))
                throw new ArgumentException("Invalid contact ID.", nameof(id));
            var contactsFilePath = MailClient.Core.Main.ContactsFileMainPath;
            if (!File.Exists(contactsFilePath))
                throw new FileNotFoundException("Contacts file not found.", contactsFilePath);
            var lines = File.ReadAllLines(contactsFilePath)
                            .Where(l => !string.IsNullOrWhiteSpace(l))
                            .ToArray();
            foreach (var line in lines)
            {
                var contact = ParseContactFromLine(line);
                if (contact != null && contact.ID == contactId)
                    return Task.FromResult(contact);
            }
            throw new InvalidOperationException($"Contact with ID {contactId} not found.");
        }

        public Task<Contact> UpdateAsync(Contact item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (item.ID <= 0)
                throw new ArgumentException("Contact ID must be greater than zero.", nameof(item));
            var contactsFilePath = MailClient.Core.Main.ContactsFileMainPath;
            if (!File.Exists(contactsFilePath))
                throw new FileNotFoundException("Contacts file not found.", contactsFilePath);
            var lines = File.ReadAllLines(contactsFilePath);
            var updatedLines = new List<string>();
            Contact updatedContact = null;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    updatedLines.Add(line);
                    continue;
                }
                var contact = ParseContactFromLine(line);
                if (contact != null && contact.ID == item.ID)
                {
                    // Update contact properties
                    contact.Name = item.Name;
                    contact.Email = item.Email;
                    contact.PhoneNumber = item.PhoneNumber;
                    contact.Status = item.Status;
                    contact.LastUpdatedOn = DateTime.UtcNow;

                    updatedLines.Add(contact.ToString());
                    updatedContact = contact;
                }
                else
                {
                    updatedLines.Add(line);
                }
            }
            if (updatedContact == null)
                throw new InvalidOperationException($"Contact with ID {item.ID} not found.");
            File.WriteAllLines(contactsFilePath, updatedLines);
            return Task.FromResult(updatedContact);
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