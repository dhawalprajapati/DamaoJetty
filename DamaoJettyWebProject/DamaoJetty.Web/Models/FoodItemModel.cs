using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DamaoJetty.Web.Models
{
    public class FoodItemModel
    {
        private List<FoodItem> FoodItems;
        public List<FoodItem> FoodItemList { get; set; }

        public FoodItem find(string id)
        {
            return this.FoodItems.Single(p => p.FoodItemId.Equals(id));
        }
    }
}