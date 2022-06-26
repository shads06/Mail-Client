using MailClient.Core;
using MailClient.DAL.Managers;
using MailClient.Processor;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace MailClient.API.Controllers
{
    public class SendMailController : ApiController
    {
        MailProcessor _mailProcessor = new MailProcessor();
        public SendMailController()
        {
        }

        [HttpPost]
        public async Task<IHttpActionResult> Send([FromBody]string data)
        {
            string toGroup, fromEmail, mailSubject, mailContent = string.Empty;
            var splittedData = data.Split(':');
            toGroup = splittedData[0];
            fromEmail = splittedData[1];
            mailSubject = splittedData[2];
            mailContent = splittedData[3];
            try
            {
                await _mailProcessor.Send(toGroup, mailSubject, mailContent, fromEmail);
                return Ok("Successfully sent emails");
            }
            catch (Exception t)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}