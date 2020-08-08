using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace BusinessLayer
{
    public class FoodItemLayer
    {
        public IEnumerable<FoodItems> FoodItems
        {
            get
            {

                string connectionString = ConfigurationManager.ConnectionStrings["DamaoJettyContext"].ConnectionString;

                List<FoodItems> fooditemsList = new List<FoodItems>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("GetFoodItems", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        FoodItems foodItems = new FoodItems();
                        foodItems.FoodItemId = Convert.ToInt32(rdr["FoodItemId"]);
                        foodItems.FoodTitle = rdr["FoodTitle"].ToString();
                        foodItems.Description = rdr["Description"].ToString();
                        foodItems.Price = Convert.ToInt32(rdr["Price"]);
                        foodItems.FoodServed = rdr["FoodServed"].ToString();

                        fooditemsList.Add(foodItems);
                    }
                }

                return fooditemsList;
            }

        }

        public void AddFoodItems(FoodItems foodItems)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DamaoJettyContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("AddFoodItems", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramFoodTitle = new SqlParameter();
                paramFoodTitle.ParameterName = "@FoodTitle";
                paramFoodTitle.Value = foodItems.FoodTitle;
                cmd.Parameters.Add(paramFoodTitle);

                SqlParameter paramDescription = new SqlParameter();
                paramDescription.ParameterName = "@Description";
                paramDescription.Value = foodItems.Description;
                cmd.Parameters.Add(paramDescription);

                SqlParameter paramPrice = new SqlParameter();
                paramPrice.ParameterName = "@Price";
                paramPrice.Value = foodItems.Price;
                cmd.Parameters.Add(paramPrice);

                SqlParameter paramFoodServed = new SqlParameter();
                paramFoodServed.ParameterName = "@FoodServed";
                paramFoodServed.Value = foodItems.FoodServed;
                cmd.Parameters.Add(paramFoodServed);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SaveFoodItems(FoodItems foodItems)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DamaoJettyContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SaveFoodItems", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramFoodTitle = new SqlParameter();
                paramFoodTitle.ParameterName = "@FoodTitle";
                paramFoodTitle.Value = foodItems.FoodTitle;
                cmd.Parameters.Add(paramFoodTitle);

                SqlParameter paramDescription = new SqlParameter();
                paramDescription.ParameterName = "@Description";
                paramDescription.Value = foodItems.Description;
                cmd.Parameters.Add(paramDescription);

                SqlParameter paramPrice = new SqlParameter();
                paramPrice.ParameterName = "@Price";
                paramPrice.Value = foodItems.Price;
                cmd.Parameters.Add(paramPrice);

                SqlParameter paramFoodServed = new SqlParameter();
                paramFoodServed.ParameterName = "@FoodServed";
                paramFoodServed.Value = foodItems.FoodServed;
                cmd.Parameters.Add(paramFoodServed);

                con.Open();
                cmd.ExecuteNonQuery();
            }

        }
    }
}

