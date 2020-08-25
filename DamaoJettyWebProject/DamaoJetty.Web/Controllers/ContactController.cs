using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DamaoJetty.Web.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            Session["Login"] = null;
            return View();
        }

        public ActionResult SendMail()
        {
            Session["Login"] = null;
            return View();
        }
    }
}