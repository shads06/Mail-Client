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
    public class ContactListRepository : IContactListRepository
    {
        public Task<ContactList> AddAsync(ContactList item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            var name = (item.Name ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Contact list name is required.", nameof(item));
            var invalidChars = Path.GetInvalidFileNameChars();
            if (name.IndexOfAny(invalidChars) >= 0)
                throw new ArgumentException("Contact list name contains invalid file name characters.", nameof(item));
            var listsFilePath = Main.ContactsListFileMainPath;
            var listsDirectory = Main.ContactsListsDirectoryPath;
            if (!Directory.Exists(listsDirectory))
                Directory.CreateDirectory(listsDirectory);
            // Read existing list names (if any) and check duplicates (case-insensitive)
            var existing = File.Exists(listsFilePath)
                ? File.ReadAllLines(listsFilePath).Where(l => !string.IsNullOrWhiteSpace(l)).Select(l => l.Trim()).ToList()
                : new List<string>();
            if (existing.Any(e => string.Equals(e, name, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException("A contact list with the same name already exists.");
            // Append the new list name to the master lists file
            using (var sw = File.AppendText(listsFilePath))
                sw.WriteLine(name);
            // Create the actual contact-list file (one contact per line) if it doesn't exist
            var listFile = Path.Combine(listsDirectory, name + ".txt");
            if (!File.Exists(listFile))
                using (File.Create(listFile)) { /* create and close */ }
            // Populate returned item metadata
            item.Name = name;
            item.Id = existing.Count + 1;
            item.CreatedOn = DateTime.UtcNow;
            item.LastUpdatedOn = null;
            return Task.FromResult(item);
        }

        public Task<ContactList> DeleteAsync(dynamic id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (!int.TryParse(id.ToString(), out int listId))
                throw new ArgumentException("Invalid contact list ID.", nameof(id));
            var listsFilePath = Main.ContactsListFileMainPath;
            if (!File.Exists(listsFilePath))
                throw new FileNotFoundException("Contact lists file not found.", listsFilePath);
            var lines = File.ReadAllLines(listsFilePath);
            var updatedLines = new List<string>();
            ContactList deletedList = null;
            int currentIndex = 0;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    updatedLines.Add(line);
                    continue;
                }
                currentIndex++;
                if (currentIndex == listId)
                {
                    // Mark as deleted by not adding to updatedLines (remove the line)
                    deletedList = new ContactList
                    {
                        Id = listId,
                        Name = line.Trim(),
                        CreatedOn = DateTime.UtcNow,
                        LastUpdatedOn = DateTime.UtcNow
                    };

                    // Delete the associated contact-list file
                    var listFilePath = Path.Combine(Main.ContactsListsDirectoryPath, line.Trim() + ".txt");
                    if (File.Exists(listFilePath))
                        File.Delete(listFilePath);
                }
                else
                {
                    updatedLines.Add(line);
                }
            }
            if (deletedList == null)
                throw new InvalidOperationException($"Contact list with ID {listId} not found.");
            File.WriteAllLines(listsFilePath, updatedLines);
            return Task.FromResult(deletedList);
        }

        public Task<IEnumerable<ContactList>> GetAllAsync()
        {
            var path = MailClient.Core.Main.ContactsListFileMainPath;
            if (!File.Exists(path))
                return Task.FromResult<IEnumerable<ContactList>>(new List<ContactList>());
            var lines = File.ReadAllLines(path)
                            .Where(l => !string.IsNullOrWhiteSpace(l))
                            .ToArray();
            var result = new List<ContactList>(lines.Length);
            for (int i = 0; i < lines.Length; i++)
            {
                result.Add(new ContactList
                {
                    Id = i + 1,
                    Name = lines[i].Trim(),
                    CreatedOn = DateTime.UtcNow,
                    LastUpdatedOn = null
                });
            }
            return Task.FromResult<IEnumerable<ContactList>>(result);
        }

        public Task<ContactList> GetSingleAsync(dynamic id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));
            if (!int.TryParse(id.ToString(), out int listId))
                throw new ArgumentException("Invalid contact list ID.", nameof(id));
            var listsFilePath = Main.ContactsListFileMainPath;
            if (!File.Exists(listsFilePath))
                throw new FileNotFoundException("Contact lists file not found.", listsFilePath);
            var lines = File.ReadAllLines(listsFilePath)
                            .Where(l => !string.IsNullOrWhiteSpace(l))
                            .ToArray();
            int currentIndex = 0;
            foreach (var line in lines)
            {
                currentIndex++;
                if (currentIndex == listId)
                {
                    var contactList = new ContactList
                    {
                        Id = listId,
                        Name = line.Trim(),
                        CreatedOn = DateTime.UtcNow,
                        LastUpdatedOn = null
                    };
                    return Task.FromResult(contactList);
                }
            }
            throw new InvalidOperationException($"Contact list with ID {listId} not found.");
        }

        public Task<ContactList> UpdateAsync(ContactList item)
        {
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            if (item.Id <= 0)
                throw new ArgumentException("Contact list ID must be greater than zero.", nameof(item));
            var newName = (item.Name ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Contact list name is required.", nameof(item));
            var invalidChars = Path.GetInvalidFileNameChars();
            if (newName.IndexOfAny(invalidChars) >= 0)
                throw new ArgumentException("Contact list name contains invalid file name characters.", nameof(item));
            var listsFilePath = Main.ContactsListFileMainPath;
            var listsDirectory = Main.ContactsListsDirectoryPath;
            if (!File.Exists(listsFilePath))
                throw new FileNotFoundException("Contact lists file not found.", listsFilePath);
            var lines = File.ReadAllLines(listsFilePath);
            var updatedLines = new List<string>();
            ContactList updatedList = null;
            int currentIndex = 0;
            string oldName = null;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    updatedLines.Add(line);
                    continue;
                }
                currentIndex++;
                if (currentIndex == item.Id)
                {
                    oldName = line.Trim();

                    // Check if new name already exists (case-insensitive, excluding current list)
                    if (lines
    .Select((l, idx) => new { Line = l, Index = idx })
    .Any(x => x.Index != (currentIndex - 1) &&
              !string.IsNullOrWhiteSpace(x.Line) &&
              string.Equals(x.Line.Trim(), newName, StringComparison.OrdinalIgnoreCase)))
                        throw new InvalidOperationException("A contact list with the same name already exists.");

                    updatedLines.Add(newName);
                    updatedList = new ContactList
                    {
                        Id = item.Id,
                        Name = newName,
                        CreatedOn = item.CreatedOn,
                        LastUpdatedOn = DateTime.UtcNow
                    };
                }
                else
                {
                    updatedLines.Add(line);
                }
            }
            if (updatedList == null)
                throw new InvalidOperationException($"Contact list with ID {item.Id} not found.");
            // Rename the contact-list file if the name changed
            if (oldName != null && !string.Equals(oldName, newName, StringComparison.OrdinalIgnoreCase))
            {
                var oldListFile = Path.Combine(listsDirectory, oldName + ".txt");
                var newListFile = Path.Combine(listsDirectory, newName + ".txt");

                if (File.Exists(oldListFile) && !File.Exists(newListFile))
                    File.Move(oldListFile, newListFile);
            }
            File.WriteAllLines(listsFilePath, updatedLines);
            return Task.FromResult(updatedList);
        }

        /// <summary>
        /// Loads contacts included in a named contact list file.
        /// This reads the list file only (no lookup in contacts directory or XML store).
        /// Each line is treated as a contact entry (typically an email); a Contact object
        /// is created for each non-empty line.
        /// </summary>
        public Task<IEnumerable<Contact>> GetContactsInListAsync(string listName)
        {
            if (string.IsNullOrWhiteSpace(listName))
                return Task.FromResult<IEnumerable<Contact>>(new List<Contact>());
            var listFile = Path.Combine(MailClient.Core.Main.ContactsListsDirectoryPath, listName + ".txt");
            if (!File.Exists(listFile))
                return Task.FromResult<IEnumerable<Contact>>(new List<Contact>());
            var entries = File.ReadAllLines(listFile)
                              .Where(l => !string.IsNullOrWhiteSpace(l))
                              .Select(l => l.Trim())
                              .ToArray();
            var contacts = new List<Contact>(entries.Length);
            for (int i = 0; i < entries.Length; i++)
            {
                contacts.Add(new Contact
                {
                    // list files typically store email addresses; ID is unknown here
                    ID = 0,
                    Name = entries[i],           // keep original text in Name so UI can display it
                    Email = entries[i],
                    PhoneNumber = null,
                    Status = MailClient.Core.Status.Active,
                    CreatedOn = DateTime.UtcNow,
                    LastUpdatedOn = null
                });
            }
            return Task.FromResult<IEnumerable<Contact>>(contacts);
        }

        /// <summary>
        /// Add contact entries (one per line) to the specified contact-list file.
        /// - Ensures the lists directory and master lists file exist.
        /// - Adds the list name to the master lists file when missing.
        /// - Appends only unique, non-empty entries (case-insensitive) to the list file.
        /// Returns the Contact objects that were actually added.
        /// </summary>
        public Task<IEnumerable<Contact>> AddContactsToListAsync(string listName, IEnumerable<string> entries)
        {
            if (string.IsNullOrWhiteSpace(listName))
                throw new ArgumentException("List name is required.", nameof(listName));
            if (entries == null)
                return Task.FromResult<IEnumerable<Contact>>(new List<Contact>());
            var name = listName.Trim();
            var invalidChars = Path.GetInvalidFileNameChars();
            if (name.IndexOfAny(invalidChars) >= 0)
                throw new ArgumentException("Contact list name contains invalid file name characters.", nameof(listName));
            var listsDir = Main.ContactsListsDirectoryPath;
            var masterListsFile = Main.ContactsListFileMainPath;
            if (!Directory.Exists(listsDir))
                Directory.CreateDirectory(listsDir);
            // Ensure master lists file contains the list name
            var masterLists = File.Exists(masterListsFile)
                ? File.ReadAllLines(masterListsFile).Where(l => !string.IsNullOrWhiteSpace(l)).Select(l => l.Trim()).ToList()
                : new List<string>();
            if (!masterLists.Any(m => string.Equals(m, name, StringComparison.OrdinalIgnoreCase)))
                using (var sw = File.AppendText(masterListsFile))
                    sw.WriteLine(name);
            var listFile = Path.Combine(listsDir, name + ".txt");
            if (!File.Exists(listFile))
                using (File.Create(listFile)) { }
            // Load existing entries to avoid duplicates
            var existingEntries = File.ReadAllLines(listFile)
                                      .Where(l => !string.IsNullOrWhiteSpace(l))
                                      .Select(l => l.Trim());
            //.ToHashSet(StringComparer.OrdinalIgnoreCase);
            // Normalize incoming entries: trim, ignore empty, dedupe
            var normalized = entries
                .Where(e => !string.IsNullOrWhiteSpace(e))
                .Select(e => e.Trim())
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
            var toAdd = normalized.Where(e => !existingEntries.Contains(e)).ToList();
            if (toAdd.Count > 0)
                using (var sw = File.AppendText(listFile))
                    foreach (var entry in toAdd)
                        sw.WriteLine(entry);
            var addedContacts = toAdd.Select(e => new Contact
            {
                ID = 0,
                Name = e,
                Email = e,
                PhoneNumber = null,
                Status = Status.Active,
                CreatedOn = DateTime.UtcNow,
                LastUpdatedOn = null
            }).ToList();
            return Task.FromResult<IEnumerable<Contact>>(addedContacts);
        }

        public Task<bool> DeleteContactListByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Contact list name is required.", nameof(name));
            var trimmedName = name.Trim();
            var listsFilePath = Main.ContactsListFileMainPath;
            var listsDirectory = Main.ContactsListsDirectoryPath;
            if (!File.Exists(listsFilePath))
                throw new FileNotFoundException("Contact lists file not found.", listsFilePath);
            var lines = File.ReadAllLines(listsFilePath);
            var updatedLines = new List<string>();
            bool listFound = false;
            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    updatedLines.Add(line);
                    continue;
                }

                var currentName = line.Trim();
                if (string.Equals(currentName, trimmedName, StringComparison.OrdinalIgnoreCase))
                {
                    // Delete the associated contact-list file
                    var listFilePath = Path.Combine(listsDirectory, currentName + ".txt");
                    if (File.Exists(listFilePath))
                        File.Delete(listFilePath);

                    listFound = true;
                    // Skip adding this line to updatedLines (hard delete)
                }
                else
                {
                    updatedLines.Add(line);
                }
            }
            if (!listFound)
                throw new InvalidOperationException($"Contact list with name '{trimmedName}' not found.");
            // Write updated lines back to the file
            File.WriteAllLines(listsFilePath, updatedLines);
            return Task.FromResult(true);
        }
    }
}
