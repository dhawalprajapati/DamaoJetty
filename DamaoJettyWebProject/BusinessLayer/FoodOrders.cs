using BusinessLayer.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FoodOrders
    {
        public IEnumerable<OrderStatusInfo> FoodOrdersInfo
        {
            get
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DamaoJettyContext"].ConnectionString;

                List<OrderStatusInfo> foodOrdersList = new List<OrderStatusInfo>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetAllCustomerOrders", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Model.OrderStatusInfo orders = new Model.OrderStatusInfo();
                        orders.OrderId = Convert.ToInt32(rdr["OrderId"]);
                        orders.CustomerName = rdr["CustomerName"].ToString();
                        orders.OrderStatusId = Convert.ToInt32(rdr["OrderStatusId"]);
                        orders.OrderStatus = rdr["OrderStatus"].ToString();
                        orders.OrderDateTime = Convert.ToDateTime(rdr["OrderDateTime"]);


                        foodOrdersList.Add(orders);
                    }
                }

                return foodOrdersList;
            }

        }


        public void SaveOrder(OrderStatusInfo order)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DamaoJettyContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SaveFoodOrderStatus", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramOrderId = new SqlParameter();
                paramOrderId.ParameterName = "@OrderId";
                paramOrderId.Value = order.OrderId;
                cmd.Parameters.Add(paramOrderId);

                SqlParameter paramOrderStatusId = new SqlParameter();
                paramOrderStatusId.ParameterName = "@OrderStatusId";
                paramOrderStatusId.Value = order.OrderStatusId;
                cmd.Parameters.Add(paramOrderStatusId);                             

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}
