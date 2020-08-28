using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL
{
    public class OrderDetails : DAL.BaseClass.DALBase
    {
        public OrderDetails(string strConnString) : base(strConnString) { }

        public void Save(ref Model.OrderDetails orderDetails)
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[SaveOrderDetails]";

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = orderDetails.OrderID;
            cmd.Parameters.Add("@FoodItemId", SqlDbType.Int).Value = orderDetails.FoodItemId;
            cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = orderDetails.Quantity;

            try
            {
                SafeOpen();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                FinallyClose();
            }
        }
    }
}
