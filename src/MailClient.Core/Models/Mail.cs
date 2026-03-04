using System;
using System.Collections.Generic;

namespace MailClient.Core.Models
{
    public class Mail : IDBEntity
    {
        public Guid Id { get; set; }
        public Contact Sender { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public List<Contact> Recipients { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
