﻿using System;
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
                SqlCommand cmd = new SqlCommand("INSERT INTO GA(maga, tenga, motavitri, tinhtrang, bandoga) VALUES(@MAGA, @TENGA, @MOTAVITRI, @TINHTRANG, @BANDOGA)", con);
                cmd.Parameters.AddWithValue("@MAGA", TaoMaGa());
                cmd.Parameters.AddWithValue("@TENGA",  ga.tenga);
                cmd.Parameters.AddWithValue("@MOTAVITRI", ga.motavitri);
              
                cmd.Parameters.AddWithValue("@BANDOGA", TaoMaGa()+"_bdo.jpg");
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
                SqlCommand cmd = new SqlCommand("UPDATE GA SET tenga=@TENGA, motavitri=@MOTAVITRI, tinhtrang=@TINHTRANG, bandoga=@BANDOGA WHERE maga=@MAGA", con);
                cmd.Parameters.AddWithValue("@MAGA", ga.maga);
                cmd.Parameters.AddWithValue("@TENGA", ga.tenga);
                cmd.Parameters.AddWithValue("@MOTAVITRI", ga.motavitri);
    
                cmd.Parameters.AddWithValue("@BANDOGA", ga.maga + "_bdo.jpg");
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
            string sql = "SELECT maga[Mã ga], tenga[Tên ga], motavitri[Mô tả vị trí], bandoga[Bản đồ], tinhtrang[Tình trạng] FROM GA";
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

        public DataTable FindGa(string g, string field_search)
        {


            string sql;


            if (field_search == "       Tất cả")
            {
                if (g == "Tìm kiếm")
                {
                    g = "";
                }
                sql = "SELECT maga[Mã ga], tenga[Tên ga], motavitri[Mô tả vị trí], bandoga[Bản đồ], tinhtrang[Tình trạng] FROM GA WHERE MAGA like N'%" + g + "%' OR TENGA like N'%" + g + "%' OR MOTAVITRI like N'%" + g + "%' " +
                    "OR tinhtrang like N'%" + g + "%'";
            }
            else
            {
                sql = "SELECT maga[Mã ga], tenga[Tên ga],  motavitri[Mô tả vị trí], bandoga[Bản đồ], tinhtrang[Tình trạng] FROM GA WHERE " + field_search + " like N'%" + g + "%' ";
            }


            //string sql = "SELECT * FROM FOOD WHERE PRICE = " + int.Parse(fd);          //tìm kiếm theo giá

            SqlConnection con = dc.GetConnect();
            //B3: khởi tạo đối tượng của lớp sql data adapter
            da = new SqlDataAdapter(sql, con);
            //B4: mở kết nối
            con.Open();
            //B5: đổ dữ liệu từ sql data adapter vào data table
            DataTable dt = new DataTable();
            da.Fill(dt);
            //B6: đóng kết nối
            con.Close();
            return dt;
        }
        public string GetSLGa()
        {
            SqlConnection con = dc.GetConnect();

            DataTable dt = new DataTable();
            string sqlQuery = string.Format("SELECT COUNT(MAGA) FROM GA WHERE TINHTRANG=N'Hoạt động'");
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);
            return (String)dt.Rows[0][0].ToString();
        }
    }
}
