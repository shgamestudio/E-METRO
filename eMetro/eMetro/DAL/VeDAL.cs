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


        public DataTable Getdoanhthu()
        {
            //B1: Tạo câu lệnh Sql để lấy toàn bộ sân bay
            //string sql = "SELECT * FROM SANBAY";
            string sql = "select sum(GIAVE)[Doanh Thu], DS.ngay[Ngày] from VE V right outer join (SELECT CAST( GETDATE()-6 AS Date )[ngay] union SELECT CAST( GETDATE()-5 AS Date ) union SELECT CAST( GETDATE()-4 AS Date ) union SELECT CAST( GETDATE()-3 AS Date ) union SELECT CAST( GETDATE()-2 AS Date ) union SELECT CAST( GETDATE()-1 AS Date ) union SELECT CAST( GETDATE() AS Date )) DS ON DS.ngay = V.NGAYMUA group by V.GIAVE, DS.ngay";
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

        public DataTable Gettansuattt()
        {
            //B1: Tạo câu lệnh Sql để lấy toàn bộ sân bay
            //string sql = "SELECT * FROM SANBAY";
            string sql = "select count(V.matt)[Số vé], TT.TENTT[Tên tuyến tàu] from VE V join TUYENTAU TT on TT.MATT = V.MATT where NGAYMUA =  CAST( GETDATE() AS Date ) group by V.MATT, TT.TENTT";
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

        public DataTable Getdoanhthu_thang()
        {
            //B1: Tạo câu lệnh Sql để lấy toàn bộ sân bay
            //string sql = "SELECT * FROM SANBAY";
            string sql = "select sum(giave)[Doanh Thu], DS.thang[Tháng] from VE V right outer join ( SELECT MONTH(CAST( GETDATE() AS Date ))[thang] union SELECT MONTH(CAST( GETDATE() AS Date ))-1 union SELECT MONTH(CAST( GETDATE() AS Date ))-2 union SELECT MONTH(CAST( GETDATE() AS Date ))-3 union SELECT MONTH(CAST( GETDATE() AS Date ))-4 union SELECT MONTH(CAST( GETDATE() AS Date ))-5 union SELECT MONTH(CAST( GETDATE() AS Date ))-6 union SELECT MONTH(CAST( GETDATE() AS Date ))-7 union SELECT MONTH(CAST( GETDATE() AS Date ))-8 union SELECT MONTH(CAST( GETDATE() AS Date ))-9 union SELECT MONTH(CAST( GETDATE() AS Date ))-10 union SELECT MONTH(CAST( GETDATE() AS Date ))-11) DS ON DS.thang = MONTH(V.NGAYMUA) group by DS.thang";
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
        public string GetSLVe()
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT COUNT(MAVE) FROM VE WHERE NGAYMUA = CONVERT(date, getdate())");
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return (String)dt.Rows[0][0].ToString();
        }

        public DataTable GetBaoCao(int thang, int nam)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("DECLARE @Month INT = '{0}', @Year INT = '{1}' ;WITH MonthDays_CTE(DayNum) AS (SELECT DATEFROMPARTS(@Year, @Month, 1) AS DayNum UNION ALL SELECT DATEADD(DAY, 1, DayNum) FROM MonthDays_CTE WHERE DayNum < EOMONTH(DATEFROMPARTS(@Year, @Month, 1))) SELECT ROW_NUMBER()OVER(ORDER BY DayNum)[STT], DayNum[Ngày], COALESCE(sum(V.GIAVE),0)[Doanh Thu],COUNT(V.MAVE)[Số lượng vé],COUNT(case V.MALV when 'LV00002' then 1 else null end)[Số lượng vé tháng], COUNT(case V.MALV when 'LV00001' then 1 else null end)[Số lượng vé ngày] from VE V right outer join MonthDays_CTE DS ON DS.DayNum = V.NGAYMUA group by NGAYMUA,DayNum", thang, nam);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return dt;
        }


        public string GetTongDoanhSo(int thang, int nam)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("DECLARE @Month INT = 12, @Year INT = 2020 ;WITH MonthDays_CTE(DayNum) AS (SELECT DATEFROMPARTS(@Year, @Month, 1) AS DayNum UNION ALL SELECT DATEADD(DAY, 1, DayNum) FROM MonthDays_CTE WHERE DayNum < EOMONTH(DATEFROMPARTS(@Year, @Month, 1))) SELECT SUM(V.GIAVE) from VE V right outer join MonthDays_CTE DS ON DS.DayNum = V.NGAYMUA", thang, nam);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return (String)dt.Rows[0][0].ToString();
        }

        public DataTable GetDoanhSo(int thang, int nam )
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("DECLARE @Month INT = '{0}', @Year INT = '{1}' ;WITH MonthDays_CTE(DayNum) AS (SELECT DATEFROMPARTS(@Year, @Month, 1) AS DayNum UNION ALL SELECT DATEADD(DAY, 1, DayNum) FROM MonthDays_CTE WHERE DayNum < EOMONTH(DATEFROMPARTS(@Year, @Month, 1))) SELECT SUM(V.GIAVE)[Tổng doanh thu] from VE V right outer join MonthDays_CTE DS ON DS.DayNum = V.NGAYMUA", thang, nam);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetDoanhSoNam(int year)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format(";WITH months(MonthNumber) AS (SELECT 1 UNION ALL SELECT MonthNumber+1 FROM months WHERE MonthNumber < 12) select ROW_NUMBER()OVER(ORDER BY MonthNumber)[STT], m.MonthNumber[Tháng], COALESCE(sum(V.GIAVE),0)[Doanh Thu],COUNT(V.MAVE)[Số lượng vé],COUNT(case V.MALV when 'LV00002' then 1 else null end)[Số lượng vé tháng], COUNT(case V.MALV when 'LV00001' then 1 else null end)[Số lượng vé ngày] from months M left outer join (select * from ve where YEAR(NGAYMUA) = '{0}') as V on M.MonthNumber = Month(NGAYMUA) group by M.MonthNumber", year);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return dt;
        }

        public DataTable GetTongDoanhSoNam(int year)
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("select sum(GIAVE)[Tổng doanh thu năm] from ve where YEAR(NGAYMUA) = '{0}'", year);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return dt;
        }

    }
}
