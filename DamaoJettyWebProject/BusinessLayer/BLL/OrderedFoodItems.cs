using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.BLL
{
    public class OrderedFoodItems
    {
        private readonly DAL.OrderedFoodItems _db;

        #region "Constructors"
        public OrderedFoodItems(string strConnection)
        {
            _db = new DAL.OrderedFoodItems(strConnection);
        }
        #endregion


        public IEnumerable<Model.OrderedFoodItems> GetAllOrderedFoodItems(int OrderId)
        {
            var outList = new List<Model.OrderedFoodItems>();

            DataTable dt = _db.GetAllOrderedFoodItems(OrderId);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    outList.Add(new Model.OrderedFoodItems(dr));
                }
            }

            return outList;
        }
    }
}
