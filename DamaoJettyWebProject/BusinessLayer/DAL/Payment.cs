using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL
{
    public class Payment : DAL.BaseClass.DALBase
    {
        public Payment(string strConnString) : base(strConnString) { }

        public void Save(ref Model.Payment payment)
        {
            var cmd = new SqlCommand();

            cmd.Connection = Connection;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[SavePaymentDetails]";

            cmd.Parameters.Add("@OrderId", SqlDbType.Int).Value = payment.OrderId;
            cmd.Parameters.Add("@TotalAmount", SqlDbType.Float).Value = payment.TotalAmount;
            cmd.Parameters.Add("@PaymentType", SqlDbType.NVarChar, 50).Value = payment.PaymentType;
            cmd.Parameters.Add("@CardNumber", SqlDbType.NVarChar, 50).Value = payment.FourDigitCardNumber;

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
