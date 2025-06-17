using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MailClient.API.Controllers
{
    public class ContactController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<string> contacts = new List<string>();
            contacts.Add("Contact 1");
            contacts.Add("Contact 2");
            contacts.Add("Contact 3");
            contacts.Add("Contact 4");
            contacts.Add("Contact 5");
            contacts.Add("Contact 6");
            return Ok(contacts);
        }
    }
}