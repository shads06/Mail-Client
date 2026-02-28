//using System;
//using MailClient.Core;
//using MailClient.Core.Storage;

//namespace MailClient.Core.Storage
//{
//    /// <summary>
//    /// Simple resolver/factory that picks the concrete storage provider.
//    /// Replace with DI/MEF or configuration-based selection when you publish the packages.
//    /// </summary>
//    public static class StorageResolver
//    {
//        /// <summary>
//        /// Creates an IContactRepository according to requested DataStorageKinds.
//        /// The resolver can be extended to accept configuration (paths, connection strings).
//        /// </summary>
//        public static IContactRepository CreateContactRepository(DataStorageKinds kind, StorageConfiguration configuration = null)
//        {
//            configuration = configuration ?? new StorageConfiguration();

//            switch (kind)
//            {
//                case DataStorageKinds.Text:
//                    return new MailClient.Storage.Text.TextContactRepository(configuration.TextDirectory);
//                case DataStorageKinds.XML:
//                case DataStorageKinds.XMLSupport:
//                    return new MailClient.Storage.Xml.XmlContactRepository(configuration.XmlFilePath);
//                case DataStorageKinds.SQL:
//                case DataStorageKinds.Relational:
//                    return new MailClient.Storage.Sql.SqlContactRepository(configuration.SqlConnectionString);
//                default:
//                    throw new NotSupportedException($"Data storage kind '{kind}' is not supported by StorageResolver.");
//            }
//        }

//        // Likewise you can add CreateMailServerRepository(...) etc.
//    }

//    public class StorageConfiguration
//    {
//        // Providers can use the relevant fields; keep them optional for now.
//        public string TextDirectory { get; set; } = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\MailClient\\Contacts";
//        public string XmlFilePath { get; set; } = AppDomain.CurrentDomain.BaseDirectory + "\\Data\\Contacts.xml";
//        public string SqlConnectionString { get; set; } = string.Empty;
//    }
//}