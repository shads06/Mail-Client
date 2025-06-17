using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MailClient.MVC.Models
{
    public interface IDBEntity
    {
        DateTime CreatedOn { get; set; }
        DateTime? LastUpdatedOn { get; set; }
    }
}