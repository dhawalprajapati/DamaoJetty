using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Payment
    {
        private int orderId;
        private decimal totalAmount;
        private string paymentType;
        private string fourDigitCardNumber;

        public int OrderId { get => orderId; set => orderId = value; }
        public decimal TotalAmount { get => totalAmount; set => totalAmount = value; }
        public string PaymentType { get => paymentType; set => paymentType = value; }
        public string FourDigitCardNumber { get => fourDigitCardNumber; set => fourDigitCardNumber = value; }

        #region "Constructors"
        public Payment() { }

        public Payment(DataRow dr)
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
            if ((dr["TotalAmount"]) != DBNull.Value) { TotalAmount = (System.Int32)(dr["TotalAmount"]); }
            if ((dr["PaymentType"]) != DBNull.Value) { PaymentType = (System.String)(dr["PaymentType"]); }
            if ((dr["FourDigitCardNumber"]) != DBNull.Value) { FourDigitCardNumber = (System.String)(dr["FourDigitCardNumber"]); }
        }
    }
}
