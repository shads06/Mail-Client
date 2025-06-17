using MailClient.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient.DAL.Managers
{
    public class MailManager
    {
        public void SaveSentMail(string contactListName, string subject, string content)
        {
            // 
            int Total_Mail_Contact_List_Sent_Previously = 0;

            // Reading Total Mail Sent Quota and storing in variable
            string mailSentQuotaFilePath = Path.Combine(Main.MailsDirectoryPath, "Total Mails Sent Quota.txt");

            //Open the file to read from.
            Total_Mail_Contact_List_Sent_Previously = Convert.ToInt32(File.ReadAllText(mailSentQuotaFilePath));

            // Creating New Directory for last Sent Mail as named "Mail <mail number>"
            DirectoryInfo newMailGroupSentDirectoryPath = new DirectoryInfo(Path.Combine(Main.MailsDirectoryPath, "Mail " + ++Total_Mail_Contact_List_Sent_Previously));
            newMailGroupSentDirectoryPath.Create();

            // Setting Path for File to read where contacts are stored of last sent mail
            string contactListSentNowPath = Path.Combine(Main.ContactsListsDirectoryPath, contactListName + ".txt");

            // Setting Path for storing last mail sent reciepients ID
            string receipientToFilePath = Path.Combine(newMailGroupSentDirectoryPath.FullName, "To.txt");

            // Create a file to write to Reciepients of last mail.
            using (StreamWriter receipientToFileWriter = File.CreateText(receipientToFilePath))
            {
                //Open the file to read from.
                using (StreamReader receipientReader = File.OpenText(contactListSentNowPath))
                {
                    string receipientEmailID = string.Empty;
                    while (!string.IsNullOrWhiteSpace(receipientEmailID = receipientReader.ReadLine())) receipientToFileWriter.WriteLine(receipientEmailID);
                }
            }

            File.WriteAllText(Path.Combine(newMailGroupSentDirectoryPath.FullName, "Subject.txt"), subject);
            File.WriteAllText(Path.Combine(newMailGroupSentDirectoryPath.FullName, "Content.txt"), content);
            File.WriteAllText(Path.Combine(Main.MailsDirectoryPath, "Total Mails Sent Quota.txt"), Total_Mail_Contact_List_Sent_Previously.ToString());
        }
    }
}
