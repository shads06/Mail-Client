using System;

namespace MailClient.DAL
{
    public interface IDBEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime? LastUpdatedOn { get; set; }
    }
}
