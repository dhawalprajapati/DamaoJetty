using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace DamaoJetty.Web.Controllers
{
    public class OrderStatusController : Controller
    {
        private static readonly string _conStr = ConfigurationManager.ConnectionStrings["DamaoJettyContext"].ConnectionString;
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(int orderNumber)
        {
            ViewModels.OrderedStatus orderedStatus = new ViewModels.OrderedStatus();

            BusinessLayer.BLL.OrderStatusInfo OrderStatusBLL = new BusinessLayer.BLL.OrderStatusInfo(_conStr);
            BusinessLayer.BLL.OrderedFoodItems orderedFoodItemsBLL = new BusinessLayer.BLL.OrderedFoodItems(_conStr);

            orderedStatus.OrderStatus = OrderStatusBLL.getOrderStatus(orderNumber);
            orderedStatus.ListOfOrderedFoodItems = orderedFoodItemsBLL.GetAllOrderedFoodItems(orderNumber).ToList();

            return View(orderedStatus);
        }
    }
}