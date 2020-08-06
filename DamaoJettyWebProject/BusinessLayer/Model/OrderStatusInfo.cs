using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class OrderStatusInfo
    {
        private int orderId;
        private string customerName;
        private int orderStatusId;
        private string orderStatus;
        private DateTime orderDateTime;

        public int OrderId { get => orderId; set => orderId = value; }
        public string CustomerName { get => customerName; set => customerName = value; }
        public int OrderStatusId { get => orderStatusId; set => orderStatusId = value; }
        public string OrderStatus { get => orderStatus; set => orderStatus = value; }
        public DateTime OrderDateTime { get => orderDateTime; set => orderDateTime = value; }

        #region "Constructors"
        public OrderStatusInfo() { }

        public OrderStatusInfo(DataRow dr)
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

            if ((dr["OrderId"]) != DBNull.Value) { OrderId = (System.Int32)(dr["OrderId"]); }            
            if ((dr["CustomerName"]) != DBNull.Value) { CustomerName = (System.String)(dr["CustomerName"]); }
            if ((dr["OrderStatusId"]) != DBNull.Value) { OrderStatusId = (System.Int32)(dr["OrderStatusId"]); }
            if ((dr["OrderStatus"]) != DBNull.Value) { OrderStatus = (System.String)(dr["OrderStatus"]); }
            if ((dr["OrderDateTime"]) != DBNull.Value) { OrderDateTime = (System.DateTime)(dr["OrderDateTime"]); }
        }
    }
}
