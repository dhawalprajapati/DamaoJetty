using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BLL
{
    public class OrderDetails
    {
        private readonly DAL.OrderDetails _db;

        #region "Constructors"
        public OrderDetails(string strConnection)
        {
            _db = new DAL.OrderDetails(strConnection);
        }
        #endregion

        public void Save(Model.OrderDetails orderDetails)
        {
            _db.Save(ref orderDetails);
        }

    }
}
