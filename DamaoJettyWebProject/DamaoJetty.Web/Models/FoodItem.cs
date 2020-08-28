using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DamaoJetty.Web.Models
{
    [Table("FoodItem")]
    public class FoodItem
    {
        public int FoodItemId { get; set; }
        public string FoodTitle { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsTopFood { get; set; }
        public string FoodImg { get; set; }
        public string FoodServed { get; set; }

    }
}