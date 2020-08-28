using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL
{
    public class OrderedFoodItems : DAL.BaseClass.DALBase
    {
        public OrderedFoodItems(string strConnString) : base(strConnString) { }

        public DataTable GetAllOrderedFoodItems(int OrderId)
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[GetOrderedFoodItems]";

            cmd.Parameters.Add("@OrderId", SqlDbType.NVarChar, 50).Value = OrderId;
            try
            {
                return DTReturn(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
