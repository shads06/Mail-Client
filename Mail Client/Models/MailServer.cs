using Mail_Client.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail_Client.Models
{

    public class MailServer : IDBEntity
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FromAddress { get; set; }

        public bool IsSecured { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

    }

}
