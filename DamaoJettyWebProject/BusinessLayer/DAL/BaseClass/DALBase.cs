using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DAL.BaseClass
{
    public abstract class DALBase
    {
        protected SqlConnection _cn = null;


        public SqlConnection Connection
        {
            get { return _cn; }
        }



        protected System.Data.DataRow DRReturn(SqlCommand command)
        {
            DataTable retDT = new DataTable();

            System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(command);

            DA.Fill(retDT);

            if (retDT.Rows.Count == 1)
            {
                return retDT.Rows[0];
            }

            return null;
        }

        protected System.Data.DataTable DTReturn(SqlCommand command, string DTName = "")
        {
            System.Data.DataTable retDT = new System.Data.DataTable(DTName);

            System.Data.SqlClient.SqlDataAdapter DA = new System.Data.SqlClient.SqlDataAdapter(command);

            DA.Fill(retDT);

            return retDT;
        }

        protected virtual void SafeOpen()
        {
            if (_cn.State == ConnectionState.Closed)
            {
                _cn.Open();
            }
        }

        protected virtual void FinallyClose()
        {
            if (_cn.State == ConnectionState.Open)
            {
                _cn.Close();
            }
        }

        #region "Constructors"
        public DALBase(string DBConnectionString)

        { _cn = new SqlConnection(DBConnectionString); }


        public DALBase(System.Data.SqlClient.SqlConnection TheCN)
        {
            _cn = TheCN;
        }

        #endregion
    }
}
