using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.DAL
{
    class GaDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public GaDAL()
        {
            dc = new DataConnection();
        }

        public DataTable GetAndSortDesc()
        {
            SqlConnection con = dc.GetConnect();
            string sqlQuery = "SELECT maga, tenga FROM GA ORDER BY maga DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private string TaoMaGa()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "GA0000" + dt.Rows.Count;
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
            return "GA" + strSoKhong + count;
        }
        public bool InsertGa(DTO.Ga ga)
        {
            
            //string sql = "INSERT INTO GA (maga, tenga, motavitri, bando, tinhtrang) VALUES (@MAGA, @TENGA, @MOTAVITRI, @BANDO, @TINHTRANG)", con;
            SqlConnection con = dc.GetConnect();
            try
            {
                //cmd = new SqlCommand(sql, con);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO GA(maga, tenga, motavitri, bando, tinhtrang) VALUES(@MAGA, @TENGA, @MOTAVITRI, @BANDO, @TINHTRANG)", con);
                cmd.Parameters.AddWithValue("@MAGA", TaoMaGa());
                cmd.Parameters.AddWithValue("@TENGA",  ga.tenga);
                cmd.Parameters.AddWithValue("@MOTAVITRI", ga.motavitri);
                cmd.Parameters.AddWithValue("@BANDO",ga.bando);
                cmd.Parameters.AddWithValue("@TINHTRANG",  ga.tinhtrang);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool UpdateGa(DTO.Ga ga)
        {

            //string sql = "INSERT INTO GA (maga, tenga, motavitri, bando, tinhtrang) VALUES (@MAGA, @TENGA, @MOTAVITRI, @BANDO, @TINHTRANG)", con;
            SqlConnection con = dc.GetConnect();
            try
            {
                //cmd = new SqlCommand(sql, con);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE GA SET tenga=@TENGA, motavitri=@MOTAVITRI, bando=@BANDO, tinhtrang=@TINHTRANG WHERE maga=@MAGA", con);
                cmd.Parameters.AddWithValue("@MAGA", ga.maga);
                cmd.Parameters.AddWithValue("@TENGA", ga.tenga);
                cmd.Parameters.AddWithValue("@MOTAVITRI", ga.motavitri);
                cmd.Parameters.AddWithValue("@BANDO", ga.bando);
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

        public DataTable getAllGa()
        {
            //B1: Tạo câu lệnh Sql để lấy toàn bộ sân bay
            //string sql = "SELECT * FROM SANBAY";
            string sql = "SELECT maga[Mã ga], tenga[Tên ga], motavitri[Mô tả vị trí], bando[Bản đồ], tinhtrang[Tình trạng] FROM GA";
            //B2: Tạo một kết nối đến Sql
            SqlConnection con = dc.GetConnect();
            //B3: Khởi tạo đối tượng của lớp SqlDataAdapter
            da = new SqlDataAdapter(sql, con);
            //B4: Mở kết nối
            con.Open();
            //B5: Đổ dữ liệu từ SqlDataAdapter vào DataTable
            DataTable dt = new DataTable();
            da.Fill(dt);
            //B6: Đóng kết nối
            con.Close();
            return dt;
        }

    }
}
