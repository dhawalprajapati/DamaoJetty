using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class FoodItems
    {

        public int FoodItemId { get; set; }
        public String FoodTitle { get; set; }

        public string Description { get; set; }
      
        public float Price { get; set; }
        
        public string FoodImg { get; set; }
       
        public string FoodServed { get; set; }

        //internal void Add(FoodItems foodItems)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

