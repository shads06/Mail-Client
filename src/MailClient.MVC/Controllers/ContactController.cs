using MailClient.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MailClient.MVC.Controllers
{
    public class ContactController : Controller
    {
        public ContactController()
        {

        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add([Bind(Exclude = "Status,CreatedOn,LastUpdatedOn")]Contact contact)
        {
            return View("Add");
        }
    }
}