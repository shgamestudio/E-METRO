using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.DAL
{
    class CongtyDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public CongtyDAL()
        {
            dc = new DataConnection();
        }

        public DataTable getAllCongty()
        {
            //B1: Tạo câu lệnh Sql để lấy toàn bộ sân bay
            //string sql = "SELECT * FROM SANBAY";
            string sql = "SELECT mact[Mã công ty], tenct[Tên công ty], sdtct[Số ĐT], diachitrusoct[Địa chỉ], diachiwebct[Website], tinhtrang[Tình trạng] FROM CONGTY";
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

        public DataTable GetAndSortDesc()
        {
            SqlConnection con = dc.GetConnect();
            string sqlQuery = "SELECT mact, tenct FROM CONGTY ORDER BY mact DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private string TaoMaCongTy()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "CT0000" + dt.Rows.Count;
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
            return "CT" + strSoKhong + count;
        }

        public bool InsertCongty(DTO.Congty ct)
        {
            string sql = "INSERT INTO CONGTY(mact, tenct, sdtct, diachitrusoct, diachiwebct, tinhtrang) " +
                "VALUES(@MACT, @TENCT, @SDTCT, @DIACHITRUSOCT, @DIACHIWEBCT, @TINHTRANG)";
            SqlConnection con = dc.GetConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MACT", SqlDbType.VarChar).Value = TaoMaCongTy();
                cmd.Parameters.Add("@TENCT", SqlDbType.NVarChar).Value = ct.tenct;
                cmd.Parameters.Add("@SDTCT", SqlDbType.VarChar).Value = ct.sdtct;
                cmd.Parameters.Add("@DIACHITRUSOCT", SqlDbType.NVarChar).Value = ct.diachitrusoct;
                cmd.Parameters.Add("@DIACHIWEBCT", SqlDbType.NVarChar).Value = ct.diachiwebct;
                cmd.Parameters.Add("@TINHTRANG", SqlDbType.NVarChar).Value = ct.tinhtrang;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool UpdateCongty(DTO.Congty ct)
        {
            string sql = "UPDATE CONGTY SET tenct=@TENCT, sdtct=@SDTCT, diachitrusoct=@DIACHITRUSOCT, diachiwebct=@DIACHIWEBCT,tinhtrang=@TINHTRANG WHERE mact=@MACT";
            SqlConnection con = dc.GetConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();                                                                                                                    
                cmd.Parameters.Add("@MACT", SqlDbType.VarChar).Value = ct.mact;
                cmd.Parameters.Add("@TENCT", SqlDbType.NVarChar).Value = ct.tenct;
                cmd.Parameters.Add("@SDTCT", SqlDbType.VarChar).Value = ct.sdtct;
                cmd.Parameters.Add("@DIACHITRUSOCT", SqlDbType.NVarChar).Value = ct.diachitrusoct;
                cmd.Parameters.Add("@DIACHIWEBCT", SqlDbType.NVarChar).Value = ct.diachiwebct;
                cmd.Parameters.Add("@TINHTRANG", SqlDbType.NVarChar).Value = ct.tinhtrang;
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
