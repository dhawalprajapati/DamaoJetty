using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BLL
{
    public class Customer
    {
        private readonly DAL.Customer _db;

        #region "Constructors"
        public Customer(string strConnection)
        {
            _db = new DAL.Customer(strConnection);
        }
#endregion

        public int Save(Model.Customer customer)
        {
           return _db.Save(ref customer);
        }
        
    }
}
