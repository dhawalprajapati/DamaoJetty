using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BusinessLayer
{
    public class FoodItems
    {

        public int FoodItemId { get; set; }
        
        [DisplayName("Food Title")]
        public String FoodTitle { get; set; }

        public string Description { get; set; }
      
        public decimal Price { get; set; }

        [DisplayName("Picture")]
        public string FoodImg { get; set; }

        public HttpPostedFileBase ImageFile { get; set; }

        [DisplayName("Food Serverd")]
        public string FoodServed { get; set; }

    }
}

