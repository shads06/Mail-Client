namespace MailClient.Core
{
    public static class XMLDataStorage
    {

        public static string Location { get; private set; }

        public static void SetLocation(string location)
        {

            Location = location;

        }

    }

}
