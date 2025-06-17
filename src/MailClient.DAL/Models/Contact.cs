using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.DAL
{
    public class Contact : IDBEntity
    {
        public Guid ID { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailID { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public override string ToString()
        {

            StringBuilder contactString = new StringBuilder();

            contactString.Append("ID: ");
            contactString.Append(ID.ToString());
            contactString.Append(", ");
            contactString.Append("FullName: ");
            contactString.Append(FullName);
            contactString.Append(", ");
            contactString.Append("PhoneNumber: ");
            contactString.Append(PhoneNumber);
            contactString.Append(", ");
            contactString.Append("Email: ");
            contactString.Append(EmailID);
            contactString.Append(", ");
            contactString.Append("Status: ");
            contactString.Append("");
            contactString.Append(", ");
            contactString.Append("Created On: ");
            contactString.Append(CreatedOn.ToString());
            contactString.Append(", ");
            contactString.Append("Last Modified On: ");
            contactString.Append(LastModifiedOn.ToString());
            return contactString.ToString();

        }
    }
}
