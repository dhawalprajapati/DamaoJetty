using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class OrderedFoodItems
    {
        private int orderDetailsId;
        private string foodTitle;
        private int quantity;
        private string foodImg;

        public int OrderDetailsId { get => orderDetailsId; set => orderDetailsId = value; }
        public string FoodTitle { get => foodTitle; set => foodTitle = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string FoodImg { get => foodImg; set => foodImg = value; }

        #region "Constructors"
        public OrderedFoodItems() { }

        public OrderedFoodItems(DataRow dr)
            : base()
        {
            InitFromDB(dr);
        }
        #endregion

        public void InitFromDB(DataRow dr)
        {
            if (dr == null)
            {
                throw new ArgumentNullException("dr");
            }

            if ((dr["OrderDetailsId"]) != DBNull.Value) { OrderDetailsId = (System.Int32)(dr["OrderDetailsId"]); }
            if ((dr["FoodTitle"]) != DBNull.Value) { FoodTitle = (System.String)(dr["FoodTitle"]); }
            if ((dr["Quantity"]) != DBNull.Value) { Quantity = (System.Int32)(dr["Quantity"]); }
            if ((dr["FoodImg"]) != DBNull.Value) { FoodImg = (System.String)(dr["FoodImg"]); }
        }
    }
}
