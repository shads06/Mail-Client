using System;

namespace MailClient.Core.Models
{
    public class ContactList : IDBEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
