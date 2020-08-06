using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamaoJetty.Web.ViewModels
{
    public class OrderedStatus
    {
        public BusinessLayer.Model.OrderStatusInfo OrderStatus { get; set; }
        public List<BusinessLayer.Model.OrderedFoodItems> ListOfOrderedFoodItems { get; set; }
    }
}