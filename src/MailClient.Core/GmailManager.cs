using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailClient.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class GmailManager
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        static string[] Scopes = { GmailService.Scope.GmailReadonly, GmailService.Scope.GmailCompose, GmailService.Scope.GmailLabels };
        
        /// <summary>
        /// 
        /// </summary>
        string ApplicationName = "Mail Client";

        /// <summary>
        /// 
        /// </summary>
        GmailService service = new GmailService();

        /// <summary>
        /// User Credential Declaration
        /// </summary>
        UserCredential credential;

        /// <summary>
        /// 
        /// </summary>
        string credPath = Main.ActiveAccountDirectoryPath;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task Authorize()
        {
            try
            {
                using (var stream = new FileStream(Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "MailClient", "client_secret.json"), FileMode.Open, FileAccess.Read))
                {
                    //credPath = System.Environment.GetFolderPath(
                    //    System.Environment.SpecialFolder.Personal);
                    //credPath = Path.Combine(credPath, ".credentials/main");

                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true));
                }
            }
            catch (Exception t)
            {
                // Log error
                throw new Exception("Failed to authorize account", t);
            }
        }

        /// <summary>
        /// Send an email from the user's mailbox to its recipient.
        /// </summary>
        /// <param name="mimeMessage">Email to be sent.</param>
        /// <param name="userId">User's email address. The special value "me" can be used to indicate the authenticated user.</param>
        public void SendMail(string mimeMessage, string userId)
        {
            // Create Gmail API service.
            service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            try
            {
                // Converting Message to Base64UrlEncode
                Google.Apis.Gmail.v1.Data.Message message = new Google.Apis.Gmail.v1.Data.Message();
                message.Raw = Utility.Base64UrlEncode(mimeMessage);

                service.Users.Messages.Send(message, userId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

    }
}
