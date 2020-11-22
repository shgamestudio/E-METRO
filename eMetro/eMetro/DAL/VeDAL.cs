using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.DAL
{
    class VeDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public VeDAL()
        {
            dc = new DataConnection();
        }

        public DataTable GetAndSortDesc()
        {
            SqlConnection con = dc.GetConnect();
            string sqlQuery = "SELECT mave FROM VE ORDER BY mave DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private string TaoMaVe()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "VE0000" + dt.Rows.Count;
            DataRow row = dt.Rows[0];
            string maTuyenBay = row[0].ToString().Substring(2);
            int count = int.Parse(maTuyenBay) + 1;
            int temp = count;
            string strSoKhong = "";
            int dem = 0;
            while (temp > 0)
            {
                temp /= 10;
                dem++;
            }
            for (int i = 0; i < 5 - dem; i++)
            {
                strSoKhong += "0";
            }
            return "VE" + strSoKhong + count;
        }
        public bool InsertVe(DTO.Ve ga)
        {

            //string sql = "INSERT INTO GA (maga, tenga, motavitri, bando, tinhtrang) VALUES (@MAGA, @TENGA, @MOTAVITRI, @BANDO, @TINHTRANG)", con;
            SqlConnection con = dc.GetConnect();
            try
            {
                //cmd = new SqlCommand(sql, con);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO VE(mave, malv, matt, giave, ngaymua, tinhtrang) VALUES(@MAVE, @MALV, @MATT, @GIAVE, @NGAYMUA,@TINHTRANG)", con);
                string a = TaoMaVe();
                cmd.Parameters.AddWithValue("@MAVE", TaoMaVe());
               
                cmd.Parameters.AddWithValue("@MALV", ga.malv);
                cmd.Parameters.AddWithValue("@MATT", ga.matt);
                cmd.Parameters.AddWithValue("@GIAVE", ga.giave);
                cmd.Parameters.AddWithValue("@NGAYMUA", ga.ngaymua);
                cmd.Parameters.AddWithValue("@TINHTRANG", ga.tinhtrang);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }




    }
}
