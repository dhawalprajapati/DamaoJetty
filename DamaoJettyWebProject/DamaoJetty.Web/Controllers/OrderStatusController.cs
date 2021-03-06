﻿using System;
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
            Session["Login"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Index(int OrderNumber=0)
        {
            if (OrderNumber != 0)
            {
                Session["Login"] = null;
                ViewModels.OrderedStatus orderedStatus = new ViewModels.OrderedStatus();

                BusinessLayer.BLL.OrderStatusInfo OrderStatusBLL = new BusinessLayer.BLL.OrderStatusInfo(_conStr);
                BusinessLayer.BLL.OrderedFoodItems orderedFoodItemsBLL = new BusinessLayer.BLL.OrderedFoodItems(_conStr);

                orderedStatus.OrderStatus = OrderStatusBLL.getOrderStatus(OrderNumber);
                orderedStatus.ListOfOrderedFoodItems = orderedFoodItemsBLL.GetAllOrderedFoodItems(OrderNumber).ToList();
                if (orderedStatus.ListOfOrderedFoodItems.Count == 0)
                {
                    orderedStatus.ErrorMessage = "Order Not Found!";
                }

                return View(orderedStatus);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}