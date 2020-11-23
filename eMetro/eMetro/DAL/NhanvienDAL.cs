using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.DAL
{
    class NhanvienDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public NhanvienDAL()
        {
            dc = new DataConnection();
        }

        private static NhanvienDAL instance;

        public static NhanvienDAL Instance
        {
            get { if (instance == null)
                    instance = new NhanvienDAL();
                return instance;
            }
            private set { instance = value; }
        }

        

        public bool Login(string userName, string passWord)
        {
            string query = "USP_Login @username , @passWord";
            DataTable result = DataConnection.Instance.ExecuteQuery(query, new object[] { userName, passWord });

            return result.Rows.Count > 0;
        }

    }
}
