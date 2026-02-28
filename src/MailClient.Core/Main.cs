using System;
using System.IO;

namespace MailClient.Core
{
    public static class Main
    {
        static string UserProfileDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        public static readonly string AppDirectoryPath = Path.Combine(UserProfileDirectoryPath, Constants.AppName);
        public static readonly string TempDirectoryPath = Path.Combine(AppDirectoryPath, Constants.TempLocationName);
        public static readonly string LicenseDirectoryPath = Path.Combine(AppDirectoryPath, Constants.LicenseLocationName);
        public static readonly string GmailCredentialsDirectoryPath = Path.Combine(AppDirectoryPath, Constants.GmailCredentialsLocationName);
        public static readonly string DatabaseDirectoryPath = Path.Combine(AppDirectoryPath, Constants.DatabaseLocationName);
        public static readonly string ContactsDirectoryPath = Path.Combine(DatabaseDirectoryPath, Constants.ContactsLocationName);
        public static readonly string ContactsListsDirectoryPath = Path.Combine(DatabaseDirectoryPath, Constants.ContactsListsLocationName);
        public static readonly string MailsDirectoryPath = Path.Combine(DatabaseDirectoryPath, Constants.MailsLocationName);
        public static readonly string AccountsDirectoryPath = Path.Combine(DatabaseDirectoryPath, Constants.AccountsLocationName);
        public static readonly string ActiveAccountDirectoryPath = Path.Combine(AccountsDirectoryPath, Constants.ActiveAccountLocationName);
        public static readonly string ContactsFileMainPath = Path.Combine(ContactsDirectoryPath, Constants.ContactsFileName);
        public static readonly string ContactsListFileMainPath = Path.Combine(ContactsListsDirectoryPath, Constants.ContactsListFileName);
        public static readonly string MailsTotalQuotaFilePath = Path.Combine(MailsDirectoryPath, Constants.MailsTotalQuotaFileName);
        //public static readonly string BackupAppDirectoryPath = Path.Combine(UserProfileDirectoryPath, "MailClientBackup");
        //public static FileSystemWatcher appDirectoryWatcher = new FileSystemWatcher(AppDirectoryPath);

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
