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
            Session["Login"] = null;
            if (username != null && password != null)
            {
                if (username.ToLower() == "admin" && password == "pass")
                {
                    Session["Login"] = "Successfull Login";
                    return RedirectToAction("AdminView");
                }
                else
                    ViewBag.LoginMessage = "Invalid Login.";
            }

            return View();
        }

        public ActionResult AdminView()
        {
            if (Session["Login"] != null)
            {
                List<BusinessLayer.FoodItems> foodItems = foodItemLayer.FoodItems.ToList();
                return View(foodItems);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            if (Session["Login"] != null)
                return View();
            else
                return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Session["Login"] != null)
            {
                BusinessLayer.FoodItems foodItem = foodItemLayer.FoodItems.Single(food => food.FoodItemId == id);
                return View(foodItem);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        
        public ActionResult Orders()
        {
            if (Session["Login"] != null)
            {
                List<BusinessLayer.Model.OrderStatusInfo> foodOrders = foodOrdersLayer.FoodOrdersInfo.ToList();
                return View(foodOrders);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult OrderUpdate(int id)
        {
            if (Session["Login"] != null)
            {
                BusinessLayer.Model.OrderStatusInfo orderStatusInfo = foodOrdersLayer.FoodOrdersInfo.Single(order => order.OrderId == id);
            return View(orderStatusInfo);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        [ActionName("EditOrder")]
        public ActionResult Edit_Post([Bind(Include = "OrderId, OrderStatusId")] BusinessLayer.Model.OrderStatusInfo order)
        {
            if (Session["Login"] != null)
            {
                foodOrdersLayer.SaveOrder(order);
            List<BusinessLayer.Model.OrderStatusInfo> foodOrders = foodOrdersLayer.FoodOrdersInfo.ToList();
            return RedirectToAction("Orders", foodOrders);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }



        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(BusinessLayer.FoodItems model)
        {
            if (Session["Login"] != null)
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
                    return RedirectToAction("AdminView", foodItems);
                }

                return View();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post([Bind(Include = "FoodItemId, FoodTitle, Description, Price, FoodImg, ImageFile, FoodServed")] BusinessLayer.FoodItems foodItem)
        {
            if (Session["Login"] != null)
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
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id)
        {
            if (Session["Login"] != null)
            {
                FoodItemLayer foodItemLayer = new FoodItemLayer();
                foodItemLayer.DeleteFoodItems(id);
                return RedirectToAction("AdminView");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}