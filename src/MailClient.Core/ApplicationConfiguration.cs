using System.IO;
using System.Reflection;

namespace MailClient.Core
{
    public class ApplicationConfiguration
    {

        public ApplicationConfiguration()
        {

        }

        public void init()
        {

            XMLDataStorage.SetLocation(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\Data\\");

        }

    }

}
