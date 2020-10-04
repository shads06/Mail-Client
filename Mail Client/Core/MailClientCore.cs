using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail_Client.Core
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
