using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Contacts
{
    public class Contact
    {
        #region Variables
        private int ID;
        private string First_Name;
        private string Middle_Name;
        private string Last_Name;
        private ulong Phone_Number;
        private string Email;
        #endregion
        
        #region Properties
        public int GetID
        {
            get { return this.ID; }
        }
        
        public string FirstName
        {
            get { return this.First_Name; }
        }
        
        public string MiddleName
        {
            get { return this.Middle_Name; }
        }
        
        public string LastName
        {
            get { return this.Last_Name; }
        }

        public ulong PhoneNumber
        {
            get { return this.Phone_Number; }
        }
        
        public string EmailContact
        {
            get { return this.Email; }
        }
        #endregion

        #region Constructors

        public Contact()
        {

        }
        public Contact(int ID, string FirstName, string MiddleName, string LastName, ulong PhoneNumber, string Email)
        {
            this.ID = ID;
            this.First_Name = FirstName;
            this.Middle_Name = MiddleName;
            this.Last_Name = LastName;
            this.Phone_Number = PhoneNumber;
            this.Email = Email;
        }

        #endregion
    }
}
