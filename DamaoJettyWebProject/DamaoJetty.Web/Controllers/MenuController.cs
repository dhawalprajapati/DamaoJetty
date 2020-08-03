using DamaoJetty.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DamaoJetty.Web.Controllers
{
    public class MenuController : Controller
    {
        DamaoJettyContext damaoJettyContext = new DamaoJettyContext();
        public ActionResult Index()
        {            
            List<FoodItem> foodItemList = damaoJettyContext.FoodItems.ToList();

            return View(foodItemList);
        }

        public ActionResult AddToCart(int id)
        {
            List<FoodItem> foodItemList = damaoJettyContext.FoodItems.ToList();

            if (Session["cart"] == null)
            {
                List<CartItem> myCart = new List<CartItem>();
                myCart.Add(new CartItem { foodItem = foodItemList.Single(p => p.FoodItemId.Equals(id)), quantity = 1 });

                Session["cart"] = myCart;
            }
            else
            {
                List<CartItem> myCart = (List<CartItem>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    myCart[index].quantity++;
                }
                else
                {
                    myCart.Add(new CartItem { foodItem = foodItemList.Single(p => p.FoodItemId.Equals(id)), quantity = 1 });
                }
                Session["cart"] = myCart;
            }

            return RedirectToAction("Index", foodItemList);
        }

        private int isExist(int id)
        {
            List<CartItem> cart = (List<CartItem>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].foodItem.FoodItemId.Equals(id))
                    return i;
            return -1;
        }
    }
}