using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mail_Client.Core
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
