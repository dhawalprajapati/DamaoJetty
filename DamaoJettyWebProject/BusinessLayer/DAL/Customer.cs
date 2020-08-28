using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL
{
    public class Customer : DAL.BaseClass.DALBase
    {
        public Customer(string strConnString) : base(strConnString) { }

        public int Save(ref Model.Customer customer)
        {
            var cmd = new SqlCommand();           

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[SaveCustomer]";

            cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.Output;

            cmd.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50).Value = customer.FirstName;
            cmd.Parameters.Add("@LastName", SqlDbType.NVarChar, 50).Value = customer.LastName;
            cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = customer.Email;
            cmd.Parameters.Add("@Phone", SqlDbType.NVarChar, 50).Value = customer.PhoneNumber;

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

           return (int)cmd.Parameters["@RETURN_VALUE"].Value;
           
        }
    }
}
