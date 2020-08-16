using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DamaoJetty.Web.ViewModels
{
    public class OrderedStatus
    {
        [Required(ErrorMessage = "Order Number must be number or cannot be blank")]
        public int OrderNumber { get; set; }
        public BusinessLayer.Model.OrderStatusInfo OrderStatus { get; set; }
        public List<BusinessLayer.Model.OrderedFoodItems> ListOfOrderedFoodItems { get; set; }
    }
}