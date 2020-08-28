using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BLL
{
    public class OrderStatusInfo
    {
        private readonly DAL.OrderStatusInfo _db;

        #region "Constructors"
        public OrderStatusInfo(string strConnection)
        {
            _db = new DAL.OrderStatusInfo(strConnection);
        }
        #endregion

        public Model.OrderStatusInfo getOrderStatus(int orderId)
        {
            Model.OrderStatusInfo temp = null;

            DataRow dr = _db.getOrderStatus(orderId);

            if (dr != null)
            {
                temp = new Model.OrderStatusInfo(dr);
            }

            return temp;
        }
    }
}
