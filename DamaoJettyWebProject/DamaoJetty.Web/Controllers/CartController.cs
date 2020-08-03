using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DamaoJetty.Web.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Remove(int id)
        {
            List<DamaoJetty.Web.Models.CartItem> cart = (List<DamaoJetty.Web.Models.CartItem>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        private int isExist(int id)
        {
            List<DamaoJetty.Web.Models.CartItem> cart = (List<DamaoJetty.Web.Models.CartItem>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].foodItem.FoodItemId.Equals(id))
                    return i;
            return -1;
        }
    }
}