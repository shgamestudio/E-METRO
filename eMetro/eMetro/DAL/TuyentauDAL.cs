using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.DAL
{
    class TuyentauDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public TuyentauDAL()
        {
            dc = new DataConnection();
        }

        public string Search_TengabyMAGA(string str)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT TENGA FROM GA WHERE MAGA='{0}' ", str);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return (String)dt.Rows[0][0];
        }

        public string Search_TenlttbyMALTT(string str)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT TENLTT FROM LOAITUYENTAU WHERE MALTT='{0}' ", str);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return (String)dt.Rows[0][0];
        }
    }
}
