using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.Core
{
    public class CoreNotInitalizedException : Exception
    {
        public CoreNotInitalizedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
