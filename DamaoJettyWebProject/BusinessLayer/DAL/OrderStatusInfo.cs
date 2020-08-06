using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL
{
    public class OrderStatusInfo : DAL.BaseClass.DALBase
    {
        public OrderStatusInfo(string strConnString) : base(strConnString) { }

        public DataRow getOrderStatus(int orderID)
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[GetOrderStatusInfo]";

            cmd.Parameters.Add("@OrderId", SqlDbType.NVarChar, 50).Value = orderID;
            try
            {
                return DRReturn(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
