using System;

namespace MailClient.Core.Models
{
    public class Mail : IDBEntity
    {
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
