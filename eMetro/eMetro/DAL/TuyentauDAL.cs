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

        public bool Check_Tuyentau_CT()
        {
            return false;
        }

    }
}
