using System;

namespace MailClient.Core.Models
{
    public interface IDBEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime? LastUpdatedOn { get; set; }
    }
}
