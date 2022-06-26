using MailClient.Core;
using MailClient.DAL.Managers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.Processor
{
    public class MailProcessor
    {
        private GmailManager _gmailManager = new GmailManager();
        private MailManager _mailManager = new MailManager();
        public async Task Send(string contactListName, string mailSubject, string mailContent, string fromEmail)
        {
            int count_mail_ids = 0;
            var userCredential = _gmailManager.Authorize();

            string contactListFilePath = Path.Combine(Main.ContactsListsDirectoryPath, contactListName + ".txt");
            count_mail_ids = File.ReadAllLines(contactListFilePath).Count();

            //Open the file to read from.
            using (StreamReader sr = File.OpenText(contactListFilePath))
            {
                List<Task> sendMailTasks = new List<Task>();
                string s = "";
                await userCredential;
                while ((s = sr.ReadLine()) != null)
                {
                    string receipientAddress = s;
                    string subject = mailSubject;
                    string body = mailContent;
                    string senderAddress = fromEmail;
                    var newSendMailTask = Task.Run(() => SendMail(receipientAddress, subject, body, senderAddress));
                    sendMailTasks.Add(newSendMailTask);
                }
                await Task.WhenAll(sendMailTasks);
            }

            _mailManager.SaveSentMail(contactListName, mailSubject, mailContent);
        }

        private void SendMail(string receipientAddress, string subject, string body, string senderAddress)
        {
            MailAddress adrs = new MailAddress(receipientAddress);

            //Creating Message
            MailMessage mail = new MailMessage();
            mail.To.Add(adrs);
            mail.Subject = subject;
            mail.Body = body;
            mail.From = new MailAddress(senderAddress);
            mail.IsBodyHtml = true;

            MimeKit.MimeMessage mimeMessage = MimeKit.MimeMessage.CreateFromMailMessage(mail);
            //await Task.Delay(2000);

            //Sending Mail
            _gmailManager.SendMail(mimeMessage.ToString(), "me");
        }
    }
}
