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

        public string GetManv(string userName, string passWord)
        {
            //SqlConnection con = dc.GetConnect();

            //DataTable dt = new DataTable();
            //string sqlQuery = string.Format("SELECT MANV FROM NHANVIEN WHERE MALTT='{0}' ", str);
            //SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            //da.Fill(dt);
            //return (String)dt.Rows[0][0];
            string query = "USP_Login @username , @passWord";
            DataTable result = DataConnection.Instance.ExecuteQuery(query, new object[] { userName, passWord });

            return (String)result.Rows[0][0];
        }

        public string GetLoainv(string manv)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT LOAINV FROM NHANVIEN WHERE MANV='{0}' ", manv);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return (String)dt.Rows[0][0];
        }

        public string GetTennv(string manv)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT TENNV FROM NHANVIEN WHERE MANV='{0}' ", manv);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return (String)dt.Rows[0][0];
        }

        public string GetCongtynv(string manv)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT MACT FROM NHANVIEN WHERE MANV='{0}' ", manv);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return (String)dt.Rows[0][0];
        }

      

    }
}
