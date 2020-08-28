using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

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

        [HttpPost]
        [WebMethod]
        [ActionName("SendContactDetail")]
        public string save(
           string Message,
           string Name,
           string Email
           )
        {

            string HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
            string Pass = ConfigurationManager.AppSettings["Password"].ToString();
            string ToEmail = "info@damaojetty.co.uk";

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(Email);
            mailMessage.Subject = "Customet feedback message from Contact form ";
            mailMessage.Body = Message;
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(new MailAddress(ToEmail));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = HostAdd;

            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = "donotreply@damaojetty.co.uk";
            NetworkCred.Password = Pass;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mailMessage);

            return "Success";
        }


        public void SendEmail(string customerEmail)
        {
            
        }

    }
}