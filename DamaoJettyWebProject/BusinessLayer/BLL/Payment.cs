using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BLL
{
    public class Payment
    {
        private readonly DAL.Payment _db;

        #region "Constructors"
        public Payment(string strConnection)
        {
            _db = new DAL.Payment(strConnection);
        }
        #endregion

        public void Save(Model.Payment payment)
        {
            _db.Save(ref payment);
        }
    }
}
