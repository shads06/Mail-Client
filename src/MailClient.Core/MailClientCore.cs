namespace MailClient.Core
{

    public static class MailClientCore
    {

        //public static string DataStorageLocation { get; set; }

        public static void Initialize()
        {

            ApplicationConfiguration applicationConfiguration = new ApplicationConfiguration();
            applicationConfiguration.init();

        }

        

    }

}
