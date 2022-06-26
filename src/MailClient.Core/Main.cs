using System;
using System.IO;

namespace MailClient.Core
{
    /// <summary>
    /// 
    /// </summary>
    public static class Main
    {
        /// <summary>
        /// 
        /// </summary>
        static string UserProfileDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        /// <summary>
        /// 
        /// </summary>
        public static readonly string AppDirectoryPath = Path.Combine(UserProfileDirectoryPath, "MailClient");
        /// <summary>
        /// 
        /// </summary>
        public static readonly string TempDirectoryPath = Path.Combine(AppDirectoryPath, "Temp");
        /// <summary>
        /// 
        /// </summary>
        public static readonly string LicenseDirectoryPath = Path.Combine(AppDirectoryPath, "License");
        /// <summary>
        /// 
        /// </summary>
        public static readonly string GmailCredentialsDirectoryPath = Path.Combine(AppDirectoryPath, "GmailCredentials");

        /// <summary>
        /// 
        /// </summary>
        public static readonly string DatabaseDirectoryPath = Path.Combine(AppDirectoryPath, "Database");
        /// <summary>
        /// 
        /// </summary>
        public static readonly string ContactsDirectoryPath = Path.Combine(DatabaseDirectoryPath, "Contacts");
        /// <summary>
        /// 
        /// </summary>
        public static readonly string ContactsListsDirectoryPath = Path.Combine(DatabaseDirectoryPath, "ContactsLists");
        /// <summary>
        /// 
        /// </summary>
        public static readonly string MailsDirectoryPath = Path.Combine(DatabaseDirectoryPath, "Mails");
        /// <summary>
        /// 
        /// </summary>
        public static readonly string AccountsDirectoryPath = Path.Combine(DatabaseDirectoryPath, "Accounts");
        /// <summary>
        /// 
        /// </summary>
        public static readonly string ActiveAccountDirectoryPath = Path.Combine(AccountsDirectoryPath, "Active");

        /// <summary>
        /// 
        /// </summary>
        public static readonly string ContactsFileMainPath = Path.Combine(ContactsDirectoryPath, "Contacts.txt");
        /// <summary>
        /// 
        /// </summary>
        public static readonly string ContactsListFileMainPath = Path.Combine(ContactsListsDirectoryPath, "ContactsLists.txt");

        //public static readonly string BackupAppDirectoryPath = Path.Combine(UserProfileDirectoryPath, "MailClientBackup");

        //public static FileSystemWatcher appDirectoryWatcher = new FileSystemWatcher(AppDirectoryPath);

        /// <summary>
        /// 
        /// </summary>
        static Main()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="CoreNotInitalizedException"></exception>
        public static void Setup()
        {
            try
            {
                Directory.CreateDirectory(AppDirectoryPath);
                Directory.CreateDirectory(TempDirectoryPath);
                Directory.CreateDirectory(LicenseDirectoryPath);
                Directory.CreateDirectory(DatabaseDirectoryPath);
                Directory.CreateDirectory(ContactsDirectoryPath);
                Directory.CreateDirectory(ContactsListsDirectoryPath);
                Directory.CreateDirectory(MailsDirectoryPath);
                Directory.CreateDirectory(AccountsDirectoryPath);
                Directory.CreateDirectory(ActiveAccountDirectoryPath);

                if(!File.Exists(ContactsFileMainPath)) File.Create(ContactsFileMainPath).Close();
                if(!File.Exists(ContactsListFileMainPath)) File.Create(ContactsListFileMainPath).Close();

                //Directory.CreateDirectory(BackupAppDirectoryPath);
                //appDirectoryWatcher.EnableRaisingEvents = true;
                //appDirectoryWatcher.Renamed += AppDirectoryWatcher_Renamed;
            }
            catch (Exception ex)
            {
                // Log the issue
                throw new CoreNotInitalizedException("MailClient is failed to initialize", ex);
            }
        }

        //private static void AppDirectoryWatcher_Renamed(object sender, RenamedEventArgs e)
        //{
        //    var dd = new DirectoryInfo(AppDirectoryPath).Parent;
        //    Directory.CreateDirectory(AppDirectoryPath);
        //    var directory = dd.GetDirectories(e.Name)[0];
        //    directory.MoveTo(AppDirectoryPath);
        //    directory.Delete();
        //}
    }
}
