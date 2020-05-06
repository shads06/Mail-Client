using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Data.SqlClient;

namespace Contacts
{
    public class ManageContact
    {
        private string ContactString;
        SqlConnection Con;
        public ManageContact()
        {
        }
        //public ManageContact(int ID, string FirstName, string MiddleName, string LastName, int PhoneNumber, string Email) : base(ID, FirstName, MiddleName, LastName, PhoneNumber, Email){
        //    ContactString = "(" + this.FirstName + "," + this.MiddleName + "," + this.LastName + "," + this.PhoneNumber + "," + this.EmailContact + ")\n";
        //}

        #region Operations on Data
        //METHODS
        public bool AddContact(Contact ContactInfoCard)
        {
            try
            {
                //XmlSerializer Serial = new XmlSerializer(typeof (Contact));
                //using (FileStream FS = new FileStream(@"C:\Users\Sharad Gaur\Documents\GITHUB Private Repository\Mail-Client\Mail Client\bin\Debug\Data\Groups\Sample1.xml", FileMode.Append, FileAccess.Write))
                //{
                //    Serial.Serialize(FS, ContactInfoCard);
                //    //IndContact = Serial.Deserialize(FS) as Contact;
                //}
                //using (StreamWriter ContactFile = File.AppendText(@"C:\Users\Sharad Gaur\Documents\GITHUB Private Repository\Mail-Client\extra.txt"))
                //{
                //    ContactFile.WriteLine(ContactString);
                //}

                //Con = new SqlConnection("");
                //SqlCommand CMD = new SqlCommand("", Con);
                //Con.Open();
                //CMD.ExecuteNonQuery();
                //Con.Close();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool ReadContact()
        {
            return true;
        }

        public bool UpdateContact()
        {
            return true;
        }

        #region FindContact Overloaded Methods
        public bool FindContact(int ID)
        {
            return true;
        }

 /*       public bool FindContact(string FirstName)
        {
            return true;
        }

        public bool FindContact(int PhoneNumber)
        {
            return true;
        }

        public bool FindContact(string EmailID)
        {
            return true;
        }
        */
        #endregion

        public bool DeleteContact(int ContactID)
        {
            return true;
        }

        #endregion
    }
}
