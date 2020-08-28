using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Model
{
    public class Customer
    {
        private string firstName;
        private string lastName;
        private string email;
        private string phoneNumber;

        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        #region "Constructors"
        public Customer() { }

        public Customer(DataRow dr)
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
            
            if ((dr["FirstName"]) != DBNull.Value) { firstName = (System.String)(dr["FirstName"]); }
            if ((dr["LastName"]) != DBNull.Value) { lastName = (System.String)(dr["LastName"]); }
            if ((dr["Phone"]) != DBNull.Value) { phoneNumber = (System.String)(dr["Phone"]); }
            if ((dr["Email"]) != DBNull.Value) { email = (System.String)(dr["Email"]); }
        }
    }
}
