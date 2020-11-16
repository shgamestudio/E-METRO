﻿using System;
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

        public string Search_MAGAbyTENGA(string str)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT MAGA FROM GA WHERE TENGA =N'{0}' ", str);
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

        public string Search_MALTTbyTenLTT(string str)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT MALTT FROM LOAITUYENTAU WHERE TENLTT like '%{0}%' ", str);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return (String)dt.Rows[0][0];
        }

        public string Search_TenCTbyMACT(string str)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT TENCT FROM CONGTY WHERE MACT='{0}' ", str);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return (String)dt.Rows[0][0];
        }

        public string Search_MACTbyTenCT(string str)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT MACT FROM CONGTY WHERE TENCT like '%{0}%' ", str);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return (String)dt.Rows[0][0];
        }

        public DataTable gettuyentau()
        {
            //B1: Tạo câu lệnh Sql để lấy toàn bộ sân bay
            //string sql = "SELECT * FROM SANBAY";
            string sql = "SELECT TT.MATT[Mã tuyến tàu], TT.TENTT[Tên tuyến tàu], CT.TENCT[Tên công ty], G1.TENGA[Ga xuất phát], G2.TENGA[Ga kết thúc], LTT.TENLTT[Loại tuyến tàu], TT.GHICHU[Ghi chú], TT.GIAVE[Giá vé], TT.GIOBD[Giờ bắt đầu], TT.GIOKT[Giờ kết thúc], TT.THOIGIANCHO[Thời gian chờ], TT.TINHTRANG[Tình trạng] " +
                "FROM TUYENTAU TT " +
                "INNER JOIN GA G1 ON TT.MAGAXP = G1.MAGA " +
                "INNER JOIN GA G2 ON TT.MAGAKT = G2.MAGA " +
                "INNER JOIN CONGTY CT ON TT.MACT = CT.MACT " +
                "INNER JOIN LOAITUYENTAU LTT ON LTT.MALTT = TT.MALTT";
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

        public bool Check_Exist_Tuyentau_CT(string xp, string kt)
        {         
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT CASE WHEN EXISTS (SELECT TT.MATT FROM TUYENTAU TT JOIN GA G1 ON G1.MAGA = TT.MAGAXP JOIN GA G2 ON G2.MAGA = TT.MAGAKT  WHERE G1.TENGA=N'{0}' AND G2.TENGA=N'{1}') THEN '1' WHEN NOT EXISTS (SELECT TT.MATT FROM TUYENTAU TT JOIN GA G1 ON G1.MAGA = TT.MAGAXP JOIN GA G2 ON G2.MAGA = TT.MAGAKT WHERE G1.TENGA=N'{0}' AND G2.TENGA=N'{1}') THEN '0' END AS [ketqua]", xp,kt);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            if ((String)dt.Rows[0][0]=="1")
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }

        public bool InsertTuyenTau(DTO.Tuyentau tt)
        {

            //string sql = "INSERT INTO GA (maga, tenga, motavitri, bando, tinhtrang) VALUES (@MAGA, @TENGA, @MOTAVITRI, @BANDO, @TINHTRANG)", con;
            SqlConnection con = dc.GetConnect();
            try
            {
                //cmd = new SqlCommand(sql, con);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO TUYENTAU(matt, mact, tentt, magaxp, magakt, maltt, ghichu, giave, giobd, giokt, thoigiancho, tinhtrang) VALUES(@MATT, @MACT, @TENTT, @MAGAXP, @MAGAKT, @MALTT, @GHICHU, @GIAVE, @GIOBD, @GIOKT, @THOIGIANCHO, @TINHTRANG)", con);
                cmd.Parameters.AddWithValue("@MATT", TaoMaTT());
                cmd.Parameters.AddWithValue("@MACT", tt.tenct);
                cmd.Parameters.AddWithValue("@TENTT", tt.tentt);
                cmd.Parameters.AddWithValue("@MAGAXP", tt.tengaxp);
                cmd.Parameters.AddWithValue("@MAGAKT", tt.tengakt);
                cmd.Parameters.AddWithValue("@MALTT", tt.tenltt);
                cmd.Parameters.AddWithValue("@GHICHU", tt.ghichu);
                cmd.Parameters.AddWithValue("@GIAVE", tt.giave);
                cmd.Parameters.AddWithValue("@GIOBD", tt.giobd);
                cmd.Parameters.AddWithValue("@GIOKT", tt.giokt);
                cmd.Parameters.AddWithValue("@THOIGIANCHO", tt.thoigianchocb);
                cmd.Parameters.AddWithValue("@TINHTRANG", tt.tinhtrang);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public DataTable GetAndSortDesc()
        {
            SqlConnection con = dc.GetConnect();
            string sqlQuery = "SELECT matt, tentt FROM TUYENTAU ORDER BY matt DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private string TaoMaTT()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "TT0000" + dt.Rows.Count;
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
            return "TT" + strSoKhong + count;
        }

    }
}
