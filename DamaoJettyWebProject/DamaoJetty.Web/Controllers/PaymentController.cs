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
    public class PaymentController : Controller
    {
        private static readonly string _conStr = ConfigurationManager.ConnectionStrings["DamaoJettyContext"].ConnectionString;

        public ActionResult Index()
        {
            Session["Login"] = null;
            if (Session["cart"] != null)
                return View();
            else
                return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [WebMethod]
        [ActionName("PlaceOrder")]
        public string save(
            string FirstName,
            string LastName,
            string Email,
            string Phone,
            string CardNumber,
            string PaymentType
            )
        {
            //SAVE CUSTOMER
            BusinessLayer.Model.Customer NewCustomer = new BusinessLayer.Model.Customer {FirstName = FirstName, LastName= LastName, Email = Email, PhoneNumber = Phone };
            BusinessLayer.BLL.Customer CustomerBLL = new BusinessLayer.BLL.Customer(_conStr);

            List<Models.CartItem> cart = (List<Models.CartItem>)Session["cart"];
            decimal cartTotalBill = cart.Sum(item => item.foodItem.Price * item.quantity);
            int newOrderID = CustomerBLL.Save(NewCustomer);            

            //SAVE ORDER DETAILS
            BusinessLayer.BLL.OrderDetails OrderDetailsBLL = new BusinessLayer.BLL.OrderDetails(_conStr);
            foreach (var item in cart)
            {
                OrderDetailsBLL.Save(new BusinessLayer.Model.OrderDetails { OrderID = newOrderID, FoodItemId = item.foodItem.FoodItemId, Quantity = item.quantity });
            }

            //SAVE PAYMENT            
            BusinessLayer.BLL.Payment PaymentBLL = new BusinessLayer.BLL.Payment(_conStr);
            PaymentBLL.Save(new BusinessLayer.Model.Payment { OrderId = newOrderID, TotalAmount = cartTotalBill, PaymentType = PaymentType, FourDigitCardNumber = PaymentType == "card" ? CardNumber.Substring(CardNumber.Length - 4) : "0" });

            
            ViewBag.NewOrderID = newOrderID;

            //SEND EMIAL TO CUSTOMER
            SendEmail(Email, newOrderID);


            return newOrderID.ToString();
        }

        public ActionResult Success(int id)
        {
            if (Session["cart"] != null)
            {
                Session["cart"] = null;
                ViewBag.NewOrderID = id;
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public void SendEmail(string customerEmail, int orderNumber)
        {
            string HostAdd = ConfigurationManager.AppSettings["Host"].ToString();
            string FromEmailId = ConfigurationManager.AppSettings["FromMail"].ToString();
            string Pass = ConfigurationManager.AppSettings["Password"].ToString();

            MailMessage mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(FromEmailId);
            mailMessage.Subject = "Confirmation of your order and receipt.";
            mailMessage.Body = @"Thank you for placing your order with us. <br/> Your order number is " + orderNumber + ". You can check your order status <a href=\"google.com\">Here</a>";
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(new MailAddress(customerEmail));

            SmtpClient smtp = new SmtpClient();
            smtp.Host = HostAdd;

            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = mailMessage.From.Address;
            NetworkCred.Password = Pass;
            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mailMessage);
        }
    }
}