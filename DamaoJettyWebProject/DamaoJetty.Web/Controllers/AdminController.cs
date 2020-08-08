using DamaoJetty.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DamaoJetty.Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index(string username, string password)
        {
            if (username != null && password != null)
            {
                if (password == "pass")
                    return RedirectToAction("AdminView");
                else
                    ViewBag.LoginMessage = "Invalid Login.";
            }

            return View();
        }

        public ActionResult AdminView()
        {
            BusinessLayer.FoodItemLayer foodItemLayer = new BusinessLayer.FoodItemLayer();
            List<BusinessLayer.FoodItems> foodItems = foodItemLayer.FoodItems.ToList();

            return View(foodItems);
        }
    }
}