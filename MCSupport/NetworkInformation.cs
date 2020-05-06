using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCSupport
{
    public class NetworkInformation
    {
        public bool isConnectedToInternet()
        {
            //TODO: Find an alternative to this solution
            try
            {
                using (var client = new System.Net.WebClient())
                using (client.OpenRead("http://client3.google.com/generate_204"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
