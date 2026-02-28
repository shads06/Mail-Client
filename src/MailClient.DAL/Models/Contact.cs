using MailClient.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.DAL
{
    public class Contact : IDBEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
        public override string ToString()
        {

            StringBuilder contactString = new StringBuilder();

            contactString.Append("ID: ");
            contactString.Append(ID.ToString());
            contactString.Append(", ");
            contactString.Append("Name: ");
            contactString.Append(Name);
            contactString.Append(", ");
            contactString.Append("PhoneNumber: ");
            contactString.Append(PhoneNumber);
            contactString.Append(", ");
            contactString.Append("Email: ");
            contactString.Append(Email);
            contactString.Append(", ");
            contactString.Append("Status: ");
            contactString.Append("");
            contactString.Append(", ");
            contactString.Append("Created On: ");
            contactString.Append(CreatedOn.ToString());
            contactString.Append(", ");
            contactString.Append("Last Modified On: ");
            contactString.Append(LastUpdatedOn.ToString());
            return contactString.ToString();

        }
    }
}
