using BusinessLayer;
using DamaoJetty.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DamaoJetty.Web.Controllers
{
    public class AdminController : Controller
    {
        BusinessLayer.FoodItemLayer foodItemLayer = new BusinessLayer.FoodItemLayer();
        BusinessLayer.FoodOrders foodOrdersLayer = new BusinessLayer.FoodOrders();
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
            
            List<BusinessLayer.FoodItems> foodItems = foodItemLayer.FoodItems.ToList();
            return View(foodItems);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            BusinessLayer.FoodItems foodItem = foodItemLayer.FoodItems.Single(food => food.FoodItemId == id);            
            return View(foodItem);
        }

        
        public ActionResult Orders()
        {
            List<BusinessLayer.Model.OrderStatusInfo> foodOrders = foodOrdersLayer.FoodOrdersInfo.ToList();
            return View(foodOrders);
        }

        [HttpGet]
        public ActionResult OrderUpdate(int id)
        {
            BusinessLayer.Model.OrderStatusInfo orderStatusInfo = foodOrdersLayer.FoodOrdersInfo.Single(order => order.OrderId == id);
            return View(orderStatusInfo);
        }


        [HttpPost]
        [ActionName("EditOrder")]
        public ActionResult Edit_Post([Bind(Include = "OrderId, OrderStatusId")] BusinessLayer.Model.OrderStatusInfo order)
        {

            foodOrdersLayer.SaveOrder(order);
            List<BusinessLayer.Model.OrderStatusInfo> foodOrders = foodOrdersLayer.FoodOrdersInfo.ToList();
            return RedirectToAction("Orders", foodOrders);            
        }



        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(BusinessLayer.FoodItems model)
        {
            BusinessLayer.FoodItems foodItem = new BusinessLayer.FoodItems();
            TryUpdateModel(foodItem);

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/img/FoodItems/"), fileName);
                        file.SaveAs(path);
                        foodItem.FoodImg = "/Content/img/FoodItems/" + fileName;
                    }                    
                }

                foodItemLayer.AddFoodItems(foodItem);

                List<BusinessLayer.FoodItems> foodItems = foodItemLayer.FoodItems.ToList();
                return RedirectToAction("AdminView",foodItems);
            }

            return View();
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post([Bind(Include = "FoodItemId, FoodTitle, Description, Price, FoodImg, ImageFile, FoodServed")] BusinessLayer.FoodItems foodItem)
        {            

            if (ModelState.IsValid)
            {

                if (Request.Files.Count > 0)
                {
                    var file = Request.Files[0];

                    if (file != null && file.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        var path = Path.Combine(Server.MapPath("~/Content/img/FoodItems/"), fileName);
                        file.SaveAs(path);
                        foodItem.FoodImg = "/Content/img/FoodItems/" + fileName;
                    }
                }

                foodItemLayer.SaveFoodItems(foodItem);

                List<BusinessLayer.FoodItems> foodItems = foodItemLayer.FoodItems.ToList();
                return RedirectToAction("AdminView", foodItems);
            }
            return View(foodItem);
        }

        public ActionResult Delete(int id)
        {
            FoodItemLayer foodItemLayer = new FoodItemLayer();
            foodItemLayer.DeleteFoodItems(id);
            return RedirectToAction("AdminView");
        }


    }
}