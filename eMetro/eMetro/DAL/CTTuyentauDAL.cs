using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMetro.DAL
{
    class CTTuyentauDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public CTTuyentauDAL()
        {
            dc = new DataConnection();
        }

        public DataTable getAllCTTuyentau(string matt)
        {
            //B1: Tạo câu lệnh Sql để lấy toàn bộ sân bay
            //string sql = "SELECT * FROM SANBAY";

            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT CT.MATT[Mã tuyến tàu], G.TENGA[Tên ga], CT.STTGA[Số thự ga], CT.TGDUNG[Thời gian dừng], CT.GHICHU[Ghi chú] FROM CTTUYENTAU CT JOIN GA G ON CT.MAGATG = G.MAGA WHERE CT.MATT = '{0}' ORDER BY STTGA ASC", matt);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return dt;
        }

        public bool Edit_CTTT(DTO.CTTuyentau cttt)
        {

            //string sql = "INSERT INTO GA (maga, tenga, motavitri, bando, tinhtrang) VALUES (@MAGA, @TENGA, @MOTAVITRI, @BANDO, @TINHTRANG)", con;
            SqlConnection con = dc.GetConnect();
            try
            {
                //cmd = new SqlCommand(sql, con);
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO CTTUYENTAU(matt, magatg, sttga, tgdung, ghichu) VALUES(@MATT, @MAGATG, @STTGA, @TGDUNG, @GHICHU)", con);
                cmd.Parameters.AddWithValue("@MATT", cttt.matt);
                cmd.Parameters.AddWithValue("@MAGATG", cttt.magatg);
                cmd.Parameters.AddWithValue("@STTGA", cttt.sttga);
                cmd.Parameters.AddWithValue("@TGDUNG", cttt.tgdung);
                cmd.Parameters.AddWithValue("@GHICHU", cttt.ghichu);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool Delete_CTTT(string cttt)
        {

            //string sql = "INSERT INTO GA (maga, tenga, motavitri, bando, tinhtrang) VALUES (@MAGA, @TENGA, @MOTAVITRI, @BANDO, @TINHTRANG)", con;
            SqlConnection con = dc.GetConnect();
            try
            {
                //cmd = new SqlCommand(sql, con);
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM CTTUYENTAU WHERE MATT=@MATT", con);
                cmd.Parameters.AddWithValue("@MATT", cttt);
          
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
