using Mail_Client.Views;
using System;
using System.Windows.Forms;

namespace Mail_Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MailClient.Core.MailClientCore.Initialize();
            MailClient.Core.Main.Setup();
            Application.Run(new SendMailForm());
        }
    }
}
