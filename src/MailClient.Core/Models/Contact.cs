using System;
using System.Collections.Generic;
using System.Text;

namespace MailClient.Core.Models
{
    public class Contact : IDBEntity, IComparable
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; } = Status.Active;
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdatedOn { get; set; }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Contact contact = obj as Contact;
            if (contact != null)
                return CreatedOn.CompareTo(contact.CreatedOn);
            else
                throw new InvalidOperationException("Object is not a Contact");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType()) return false;
            var contact = (Contact)obj;
            return contact.ID == ID && contact.Name == Name && contact.PhoneNumber == PhoneNumber && contact.Email == Email && contact.Status == Status;
        }
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
