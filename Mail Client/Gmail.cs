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

namespace Mail_Client
{
    public class Gmail
    {
        // If modifying these scopes, delete your previously saved credentials
        // at ~/.credentials/gmail-dotnet-quickstart.json
        static string[] Scopes = { GmailService.Scope.GmailReadonly, GmailService.Scope.GmailCompose, GmailService.Scope.GmailLabels };
        public static string ApplicationName = "Mail Client";
        GmailService service = new GmailService();
        // User Credential Declaration
        public static UserCredential credential;
        string credPath;

        public async Task Authorize()
        {
            try
            {
                using (var stream = new FileStream("client_secret.json", FileMode.Open, FileAccess.Read))
                {
                    credPath = System.Environment.GetFolderPath(
                        System.Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/main");

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
                message.Raw = Base64UrlEncode(mimeMessage);

                service.Users.Messages.Send(message, userId).Execute();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }

        private string Base64UrlEncode(string input)
        {
            //Using System.Text.Encoding.UTF8.GetBytes method
            var inputBytes = Encoding.UTF8.GetBytes(input);
            // Special "url-safe" base64 encode.
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
    }
}
