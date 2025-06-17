using Mail_Client.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail_Client.Models
{

    public class Contact : IDBEntity
    {

        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public Status Status { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public override string ToString()
        {

            StringBuilder contactString = new StringBuilder();

            contactString.Append("ID: ");
            contactString.Append(ID.ToString());
            contactString.Append("\n");
            contactString.Append("Name: ");
            contactString.Append(Name);
            contactString.Append("\n");
            contactString.Append("Email: ");
            contactString.Append(Email);
            contactString.Append("\n");
            contactString.Append("Status: ");
            contactString.Append(Status);
            contactString.Append("\n");
            contactString.Append("Created On: ");
            contactString.Append(CreatedOn.ToString());
            contactString.Append("\n");
            contactString.Append("Last Updated On: ");
            contactString.Append(LastUpdatedOn.ToString());
            return contactString.ToString();

        }

    }

}
