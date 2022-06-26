using MailClient.MVC.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MailClient.MVC.Controllers
{
    public class SendMailController : Controller
    {
        public SendMailController()
        {

        }

        [HttpGet]
        public ActionResult SendMailView()
        {
            // Loading 
            FileReadWrite.path = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "MailClient", "Data", "Group Names.txt");

            var groupNames = System.IO.File.ReadAllLines(FileReadWrite.path);

            List<SelectListItem> list = new List<SelectListItem>();
            foreach (var group in groupNames)
            {
                list.Add(new SelectListItem()
                {
                    Text = group,
                    Value = group
                });
            }
            ViewData["toGroup"] = list;

            return View();
        }

        [HttpPost]
        public ActionResult SendMail(FormCollection data)
        {
            var fromEmail = data["fromEmail"];
            var toGroup = data["toGroup"];
            return Content("Returned From Send Mail Action");
        }
    }
}