using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class OrderDetails
    {
        private int orderID;
        private int foodItemId;
        private int quantity;

        public int OrderID { get => orderID; set => orderID = value; }
        public int FoodItemId { get => foodItemId; set => foodItemId = value; }
        public int Quantity { get => quantity; set => quantity = value; }

        #region "Constructors"
        public OrderDetails() { }

        public OrderDetails(DataRow dr)
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

            if ((dr["OrderId"]) != DBNull.Value) { OrderID = (System.Int32)(dr["OrderId"]); }
            if ((dr["FoodItemId"]) != DBNull.Value) { FoodItemId = (System.Int32)(dr["FoodItemId"]); }
            if ((dr["Quantity"]) != DBNull.Value) { Quantity = (System.Int32)(dr["Quantity"]); }
        }
    }
}
