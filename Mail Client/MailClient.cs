using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail_Client
{
    public static class MailClient
    {
        public static string UserDirectory = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static string AppDirectory = Path.Combine(UserDirectory, "MailClient");
        public static string ContactsDirectory = Path.Combine(AppDirectory, "Contacts");
        public static string ContactsListsDirectory = Path.Combine(AppDirectory, "ContactsLists");
        public static string MailsDirectory = Path.Combine(AppDirectory, "Mails");
        public static string LicenseDirectory = Path.Combine(AppDirectory, "License");
        public static string GmailCredentialsDirectory = Path.Combine(AppDirectory, "Credentials");
        public static string TempDirectory = Path.Combine(AppDirectory, "Temp");

        public static void Setup()
        {
            if (!Directory.Exists(AppDirectory))
                Directory.CreateDirectory(AppDirectory);
            if (!Directory.Exists(ContactsDirectory))
                Directory.CreateDirectory(ContactsDirectory);
            if (!Directory.Exists(ContactsListsDirectory))
                Directory.CreateDirectory(ContactsListsDirectory);
            if (!Directory.Exists(MailsDirectory))
                Directory.CreateDirectory(MailsDirectory);
            if (!Directory.Exists(LicenseDirectory))
                Directory.CreateDirectory(LicenseDirectory);
            if (!Directory.Exists(GmailCredentialsDirectory))
                Directory.CreateDirectory(GmailCredentialsDirectory);
            if (!Directory.Exists(TempDirectory))
                Directory.CreateDirectory(TempDirectory);
        }
    }
}
