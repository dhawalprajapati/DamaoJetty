using DamaoJetty.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DamaoJetty.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            DamaoJettyContext damaoJettyContext = new DamaoJettyContext();
            List<FoodItem> foodItemList = damaoJettyContext.FoodItems.ToList();
           
            
            return View(foodItemList);
        }

    }
}