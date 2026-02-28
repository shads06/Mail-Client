using System.IO;

namespace MailClient.DAL.Managers
{
    public class ContactManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException"></exception>
        public Contact Add(Contact contact)
        {
            if (!File.Exists(MailClient.Core.Main.ContactsFileMainPath)) throw new FileNotFoundException("Failed to add contact", MailClient.Core.Main.ContactsFileMainPath);
            using(StreamWriter contactsSW = new StreamWriter(MailClient.Core.Main.ContactsFileMainPath))
                contactsSW.WriteLine(contact.ToString());
            return contact;
        }

        public Contact Update(Contact contact)
        {
            return null;
        }
    }
}
