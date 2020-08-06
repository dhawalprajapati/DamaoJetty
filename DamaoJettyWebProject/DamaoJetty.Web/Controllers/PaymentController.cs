using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
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
            return View();
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

            Session["cart"] = null;
            ViewBag.NewOrderID = newOrderID;
            return newOrderID.ToString();
        }

        public ActionResult Success(int id)
        {
            ViewBag.NewOrderID = id;
            return View();
        }
    }
}