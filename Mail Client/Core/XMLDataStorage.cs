using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mail_Client.Core
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
