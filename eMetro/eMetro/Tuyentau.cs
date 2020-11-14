﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMetro
{
    public partial class Tuyentau : Form
    { //string u= "21:41:21";
        //bool check_click_combobox = false;
        DAL.DataConnection dc;
        SqlCommand cmd;
        SqlDataAdapter da;
        BLL.TuyentauBLL bllTT;
        BLL.CTTuyentauBLL bllCTTT;
        DataTable dty;
        bool check_num = false;
        DTO.CTTuyentau dtoCTTuyentau;
        public Tuyentau()
        {
            InitializeComponent();
            dc = new DAL.DataConnection();
            bllTT = new BLL.TuyentauBLL();
            bllCTTT = new BLL.CTTuyentauBLL();
            dty = new DataTable();
            dtoCTTuyentau = new DTO.CTTuyentau();
        }

        private void Tuyentau_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eMETRODataSet.TUYENTAU' table. You can move, or remove it, as needed.
            //this.tUYENTAUTableAdapter.Fill(this.eMETRODataSet.TUYENTAU); 
            //code chính


            //this.ShowAllGaxp();
            //this.ShowAllGakt();
            //advancedDataGridView_tuyentau.DataSource = dty;

            this.tUYENTAUBindingSource.DataSource = bllTT.gettuyentau();
            this.advancedDataGridView_tuyentau.DataSource = this.tUYENTAUBindingSource;

            
            //SqlConnection con = dc.GetConnect();
            //cmd = new SqlCommand("Select * from GA WHERE TINHTRANG=N'Hoạt động'", con);
            //da = new SqlDataAdapter();
            //da.SelectCommand = cmd;

           
        }

        //public DataTable gettuyentau()
        //{
        //    //B1: Tạo câu lệnh Sql để lấy toàn bộ sân bay
        //    //string sql = "SELECT * FROM SANBAY";
        //    string sql = "SELECT TT.MATT[Mã tuyến tàu], TT.TENTT[Tên tuyến tàu], CT.TENCT[Tên công ty], G1.TENGA[Ga xuất phát], G2.TENGA[Ga kết thúc], LTT.TENLTT[Loại tuyến tàu], TT.GHICHU[Ghi chú], TT.GIAVE[Giá vé], TT.GIOBD[Giờ bắt đầu], TT.GIOKT[Giờ kết thúc], TT.THOIGIANCHO[Thời gian chờ], TT.TINHTRANG[Tình trạng] " +
        //        "FROM TUYENTAU TT " +
        //        "INNER JOIN GA G1 ON TT.MAGAXP = G1.MAGA " +
        //        "INNER JOIN GA G2 ON TT.MAGAKT = G2.MAGA " +
        //        "INNER JOIN CONGTY CT ON TT.MACT = CT.MACT " +
        //        "INNER JOIN LOAITUYENTAU LTT ON LTT.MALTT = TT.MALTT";
        //    //B2: Tạo một kết nối đến Sql
        //    SqlConnection con = dc.GetConnect();
        //    //B3: Khởi tạo đối tượng của lớp SqlDataAdapter
        //    da = new SqlDataAdapter(sql, con);
        //    //B4: Mở kết nối
        //    con.Open();
        //    //B5: Đổ dữ liệu từ SqlDataAdapter vào DataTable
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    //B6: Đóng kết nối
        //    con.Close();
        //    return dt;
        //}

        private void ShowListField()
        {
            comboBox_fieldsearch.DataSource = Getlist_field();
            comboBox_fieldsearch.DisplayMember = "2";
            comboBox_fieldsearch.ValueMember = "1";
        }


        private void ShowAllGaxp()
        {
            SqlConnection con = dc.GetConnect();
            cmd = new SqlCommand("Select * from GA WHERE TINHTRANG=N'Hoạt động'", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);

            comboBox_gaxp.DataSource = table;
            comboBox_gaxp.DisplayMember = "TENGA";
            comboBox_gaxp.ValueMember = "MAGA";
        }

        private void ShowAllcongty()
        {
            SqlConnection con = dc.GetConnect();
            cmd = new SqlCommand("Select * from CONGTY WHERE TINHTRANG=N'Hoạt động'", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);

            comboBox_congty.DataSource = table;
            comboBox_congty.DisplayMember = "TENCT";
            comboBox_congty.ValueMember = "MACT";
        }

        private void ShowAllGakt()
        {
            SqlConnection con = dc.GetConnect();
            cmd = new SqlCommand("Select * from GA WHERE TINHTRANG=N'Hoạt động'", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);

            comboBox_gakt.DataSource = table;
            comboBox_gakt.DisplayMember = "TENGA";
            comboBox_gakt.ValueMember = "MAGA";
        }
        private void ShowAllLoaitt()
        {
            SqlConnection con = dc.GetConnect();
            cmd = new SqlCommand("Select * from LOAITUYENTAU WHERE TINHTRANG=N'Hoạt động'", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);

            comboBox_ltt.DataSource = table;
            comboBox_ltt.DisplayMember = "TENLTT";
            comboBox_ltt.ValueMember = "MALTT";
        }


        private DataTable getall_TENGA()
        {
            SqlConnection con = dc.GetConnect();
            cmd = new SqlCommand("Select TENGA[Tên ga] from GA WHERE TINHTRANG=N'Hoạt động'", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);
            return table;
        }

        private void AdvancedDataGridView_tuyentau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                //_ID = Int32.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
                textBox_matt.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Mã tuyến tàu"].Value.ToString();
                textBox_tentt.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Tên tuyến tàu"].Value.ToString();
                comboBox_congty.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Tên công ty"].Value.ToString();
                ////string t = advancedDataGridView_tuyentau.Rows[index].Cells["mAGAXPDataGridViewTextBoxColumn"].Value.ToString();
                comboBox_gaxp.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Ga xuất phát"].Value.ToString();
                comboBox_gakt.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Ga kết thúc"].Value.ToString();
                comboBox_ltt.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Loại tuyến tàu"].Value.ToString();

                textBox_ghichu.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Ghi chú"].Value.ToString();
                textBox_giave.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Giá vé"].Value.ToString();
                textBox_tgcho.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Thời gian chờ"].Value.ToString();
                dateTimePicker_giobd.Value = DateTime.ParseExact(advancedDataGridView_tuyentau.Rows[index].Cells["Giờ bắt đầu"].Value.ToString(), "HH:mm",
                                          System.Globalization.CultureInfo.InvariantCulture);
                dateTimePicker_giokt.Value = DateTime.ParseExact(advancedDataGridView_tuyentau.Rows[index].Cells["Giờ kết thúc"].Value.ToString(), "HH:mm",
                                         System.Globalization.CultureInfo.InvariantCulture);
                comboBox_tinhtrang.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Tình trạng"].Value.ToString();
                //bunifuCustomDataGrid_CTTUYENTAU.DataSource = bllCTTT.getAllCTTuyentau(advancedDataGridView_tuyentau.Rows[index].Cells["Mã tuyến tàu"].Value.ToString());   *tam cmd lại

                bunifuCustomDataGrid_CTTUYENTAU.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuCustomDataGrid_CTTUYENTAU.Rows.Clear();
                bunifuCustomDataGrid_CTTUYENTAU.Refresh();
                ArrayList StringList = new ArrayList();
                SqlConnection con = dc.GetConnect();
                DataTable dt = new DataTable();
                string sqlQuery = string.Format("SELECT CT.MATT[Mã tuyến tàu], G.TENGA[Tên ga], CT.STTGA[Thứ tự ga], CT.TGDUNG[Thời gian dừng], CT.GHICHU[Ghi chú] FROM CTTUYENTAU CT JOIN GA G ON CT.MAGATG = G.MAGA WHERE CT.MATT = '{0}' ORDER BY STTGA ASC", advancedDataGridView_tuyentau.Rows[index].Cells["Mã tuyến tàu"].Value.ToString());
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);


                DataTable table = new DataTable();
                da.Fill(table);

                
                foreach (DataRow item in getall_TENGA().Rows)
                {
                    StringList.Add(item["Tên ga"].ToString());
                }
                foreach (DataRow item in table.Rows)
                {
                    int n = bunifuCustomDataGrid_CTTUYENTAU.Rows.Add();
                    var CellSample = new DataGridViewComboBoxCell();
                    CellSample.DataSource = StringList;
                    bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[1].Value = item[0].ToString();
                    
                    bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[2] = CellSample;
                    bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[2].Value = item["Tên ga"].ToString();
                    bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[3].Value = item["Thứ tự ga"].ToString();
                    bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[4].Value = item["Thời gian dừng"].ToString();
                    bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[5].Value = item["Ghi chú"].ToString();
                }
            }
        }

        private void AdvancedDataGridView_tuyentau_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {
            this.tUYENTAUBindingSource.Sort = this.advancedDataGridView_tuyentau.SortString;
        }

        private void AdvancedDataGridView_tuyentau_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            this.tUYENTAUBindingSource.Filter = this.advancedDataGridView_tuyentau.FilterString;
        }

        //textBox9.Text = dateTimePicker3.Value.ToString("HH:mm:ss");
        //dateTimePicker3.Value = DateTime.ParseExact(u, "HH:mm:ss",
        //                           System.Globalization.CultureInfo.InvariantCulture);

        public void Alert(string msg, Notification.Alert.enmType type)
        {
            Notification.Alert frm = new Notification.Alert();
            frm.showAlert(msg, type);
        }


        public void ShowComboBoxGaxp(string gakt)
        {


            //SqlConnection con = dc.GetConnect();
            //cmd = new SqlCommand("Select * from GA WHERE TINHTRANG=N'Hoạt động' AND ", con);
            //da = new SqlDataAdapter();
            //da.SelectCommand = cmd;

            //DataTable table = new DataTable();

            SqlConnection con = dc.GetConnect();
            DataTable dt = new DataTable();
            string sqlQuery = string.Format("Select * from GA WHERE TINHTRANG=N'Hoạt động' AND MAGA != '{0}'", gakt);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);

            //comboBox_gaxp.DataSource = null;
            comboBox_gaxp.DataSource = dt;
            comboBox_gaxp.DisplayMember = "TENGA";
            comboBox_gaxp.ValueMember = "MAGA";

        }

        public void ShowComboBoxGakt(string gaxp)
        {


            //SqlConnection con = dc.GetConnect();
            //cmd = new SqlCommand("Select * from GA WHERE TINHTRANG=N'Hoạt động' AND ", con);
            //da = new SqlDataAdapter();
            //da.SelectCommand = cmd;

            //DataTable table = new DataTable();

            SqlConnection con = dc.GetConnect();
            DataTable dt = new DataTable();
            string sqlQuery = string.Format("Select * from GA WHERE TINHTRANG=N'Hoạt động' AND MAGA != '{0}'", gaxp);
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            da.Fill(dt);

            //comboBox_gakt.DataSource = null;
            comboBox_gakt.DataSource = dt;
            comboBox_gakt.DisplayMember = "TENGA";
            comboBox_gakt.ValueMember = "MAGA";

        }



        private void ComboBox_gakt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_gaxp.Text == comboBox_gakt.Text)
            {
                ShowComboBoxGaxp(comboBox_gakt.SelectedValue.ToString());
            }
        }



        private void Tuyentau_Shown(object sender, EventArgs e)
        {
            this.ShowAllGaxp();
            this.ShowAllGakt();
            this.ShowAllLoaitt();
            this.ShowAllcongty();
            this.ShowListField();
            comboBox_gakt.SelectedIndex = 2;
        }

        private void ComboBox_xpp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_gaxp.Text == comboBox_gakt.Text)
            {
                ShowComboBoxGakt(comboBox_gaxp.SelectedValue.ToString());

            }
        }

        private DataTable Getlist_field()
        {
            DataTable dts = new DataTable();
            dts.Columns.Add("1");
            dts.Columns.Add("2");
            DataRow dr = null;

            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "tatca";
            dr["2"] = "Tất cả";
            dts.Rows.Add(dr);

            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "matt";
            dr["2"] = "Mã tuyến tàu";
            dts.Rows.Add(dr);

            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "tentt";
            dr["2"] = "Tên tuyến tàu";
            dts.Rows.Add(dr);

            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "mact";
            dr["2"] = "Công ty";
            dts.Rows.Add(dr);

            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "gaxp";
            dr["2"] = "Ga xuất phát";
            dts.Rows.Add(dr);

            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "gakt";
            dr["2"] = "Ga kết thúc";
            dts.Rows.Add(dr);

            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "maltt";
            dr["2"] = "Loại tuyến tàu";
            dts.Rows.Add(dr);

            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "ghichu";
            dr["2"] = "Ghi chú";
            dts.Rows.Add(dr);

            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "giave";
            dr["2"] = "Giá vé";
            dts.Rows.Add(dr);


            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "giobd";
            dr["2"] = "Giờ bắt đầu";
            dts.Rows.Add(dr);

            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "giokt";
            dr["2"] = "Giờ kết thúc";
            dts.Rows.Add(dr);


            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "thoigiancho";
            dr["2"] = "Thời gian chờ";
            dts.Rows.Add(dr);

            dr = dts.NewRow(); // have new row on each iteration
            dr["1"] = "tinhtrang";
            dr["2"] = "Tình trạng";
            dts.Rows.Add(dr);


            return dts;
        }

        private void TextBox_search_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = advancedDataGridView_tuyentau.DataSource;
            if (comboBox_fieldsearch.Text == "Tất cả")
            {
                if (textBox_search.Text.All(char.IsDigit))
                {
                    if (textBox_search.Text != "")
                    {
                        bs.Filter = "[Mã tuyến tàu] like '%" + textBox_search.Text + "%'" +
                        "or [Tên tuyến tàu] like '%" + textBox_search.Text + "%'" +
                        "or [Tên công ty] like '%" + textBox_search.Text + "%'" +
                        "or [Loại tuyến tàu] like '%" + textBox_search.Text + "%'" +
                        "or [Ga xuất phát] like '%" + textBox_search.Text + "%'" +
                        "or [Ga kết thúc] like '%" + textBox_search.Text + "%'" +
                        "or [Ghi chú] like '%" + textBox_search.Text + "%'" +
                        "or [Giờ bắt đầu] like '%" + textBox_search.Text + "%'" +
                        "or [Giờ kết thúc] like '%" + textBox_search.Text + "%'" +
                        "or [Tình trạng] like '%" + textBox_search.Text + "%'" +
                        "or [Giá vé] = " + decimal.Parse(textBox_search.Text, CultureInfo.InvariantCulture) +
                        "or [Thời gian chờ] = " + decimal.Parse(textBox_search.Text, CultureInfo.InvariantCulture);
                        advancedDataGridView_tuyentau.DataSource = bs;
                    }
                    else
                    {
                        bs.Filter = "[Mã tuyến tàu] like '%" + textBox_search.Text + "%'";
                        advancedDataGridView_tuyentau.DataSource = bs;
                    }
                }
                else
                {
                    bs.Filter = "[Mã tuyến tàu] like '%" + textBox_search.Text + "%'" +
                        "or [Tên tuyến tàu] like '%" + textBox_search.Text + "%'" +
                        "or [Tên công ty] like '%" + textBox_search.Text + "%'" +
                        "or [Loại tuyến tàu] like '%" + textBox_search.Text + "%'" +
                        "or [Ga xuất phát] like '%" + textBox_search.Text + "%'" +
                        "or [Ga kết thúc] like '%" + textBox_search.Text + "%'" +
                        "or [Ghi chú] like '%" + textBox_search.Text + "%'" +
                        "or [Giờ bắt đầu] like '%" + textBox_search.Text + "%'" +
                        "or [Giờ kết thúc] like '%" + textBox_search.Text + "%'" +
                        "or [Tình trạng] like '%" + textBox_search.Text + "%'";

                    advancedDataGridView_tuyentau.DataSource = bs;
                }
            }
            else if (comboBox_fieldsearch.Text != "Giá vé" && comboBox_fieldsearch.Text != "Thời gian chờ")
            {
                bs.Filter = "[" + comboBox_fieldsearch.Text + "]" + " like '%" + textBox_search.Text + "%'";
                advancedDataGridView_tuyentau.DataSource = bs;
            }
            else if (comboBox_fieldsearch.Text == "Giá vé" || comboBox_fieldsearch.Text == "Thời gian chờ")
            {
                if (textBox_search.Text != "")
                {
                    bs.Filter = "[" + comboBox_fieldsearch.Text + "]" + " = " + decimal.Parse(textBox_search.Text, CultureInfo.InvariantCulture);
                    advancedDataGridView_tuyentau.DataSource = bs;
                }
                else
                {
                    bs.Filter = "[Mã tuyến tàu] like '%" + textBox_search.Text + "%'";
                    advancedDataGridView_tuyentau.DataSource = bs;
                }
            }
        }

        private void ComboBox_fieldsearch_TextChanged(object sender, EventArgs e)
        {
            if (comboBox_fieldsearch.Text == "Giá vé" || comboBox_fieldsearch.Text == "Thời gian chờ" )
            {
                check_num = true;
            }
            else
            {
                check_num = false;
            }
        }

        private void TextBox_search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (check_num == true)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

      

        private void IconButton_xoaCTTT_Click(object sender, EventArgs e)
        {
            int total = bunifuCustomDataGrid_CTTUYENTAU.Rows.Cast<DataGridViewRow>().Where(p => Convert.ToBoolean(p.Cells["select"].Value) == true).Count();
            if (total > 0)
            {
                for (int i = bunifuCustomDataGrid_CTTUYENTAU.RowCount - 1; i >= 0; i--)
                {
                    DataGridViewRow row = bunifuCustomDataGrid_CTTUYENTAU.Rows[i];
                    if (Convert.ToBoolean(row.Cells["select"].Value) == true)
                    {
                        bunifuCustomDataGrid_CTTUYENTAU.Rows.Remove(row);
                    }
                }
            }
        }

        private void IconButton_ThemCTTT_Click(object sender, EventArgs e)
        {
            ArrayList StringList = new ArrayList();

            foreach (DataRow item in getall_TENGA().Rows)
            {
                StringList.Add(item["Tên ga"].ToString());
            }
            int n = bunifuCustomDataGrid_CTTUYENTAU.Rows.Add();
            var CellSample = new DataGridViewComboBoxCell();
            CellSample.DataSource = StringList;


            bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[1].Value = textBox_matt.Text;
            bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[2] = CellSample;


            int k = bunifuCustomDataGrid_CTTUYENTAU.RowCount;
            bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[3].Value = (bunifuCustomDataGrid_CTTUYENTAU.RowCount ).ToString();
            
        }

        public bool checker_DatagridIsempty()
        {
            //for (int i = 0; i < bunifuCustomDataGrid_CTTUYENTAU.Rows.Count; i++)
            //{
            //    string value_stt = bunifuCustomDataGrid_CTTUYENTAU.Rows[i].Cells[4].Value.ToString();
            //    string value_ghichu = bunifuCustomDataGrid_CTTUYENTAU.Rows[i].Cells[5].Value.ToString();

            //    if (string.IsNullOrWhiteSpace(value_stt)|| string.IsNullOrWhiteSpace(value_ghichu))
            //    {

            //        return false;
            //    }
            //}

            //// If we have reached this far, then none of the cells were empty.
            //return true;

            bool flag = true;
            foreach (DataGridViewRow row in bunifuCustomDataGrid_CTTUYENTAU.Rows)
            {
                if (Convert.ToString(row.Cells["Column4"].Value) == string.Empty|| Convert.ToString(row.Cells["Column5"].Value) == string.Empty)
                    flag = false;
            }

            
            return flag;
           
        }

        private void IconButton_luuCTTT_Click(object sender, EventArgs e)
        {
            int check_count = 0;
            if(checker_DatagridIsempty())
            {
                if (bunifuCustomDataGrid_CTTUYENTAU.Rows.Count > 0)
                {
                    bllCTTT.Delete_CTTT(textBox_matt.Text);
                    foreach (DataGridViewRow row in bunifuCustomDataGrid_CTTUYENTAU.Rows)
                    {

                        dtoCTTuyentau = new DTO.CTTuyentau();
                        dtoCTTuyentau.matt = textBox_matt.Text;
                        //string test = row.Cells[2].Value.ToString();
                        dtoCTTuyentau.magatg = bllTT.Search_MAGAbyTENGA(row.Cells[2].Value.ToString());
                        dtoCTTuyentau.sttga = int.Parse(row.Cells[3].Value.ToString());
                        dtoCTTuyentau.tgdung = int.Parse(row.Cells[4].Value.ToString());
                        dtoCTTuyentau.ghichu = row.Cells[5].Value.ToString();
                        if (bllCTTT.Edit_CTTT(dtoCTTuyentau))
                        {
                            check_count++;
                        }
                        
                    }
                    if (check_count == bunifuCustomDataGrid_CTTUYENTAU.Rows.Count)
                    {
                        check_count = 0;
                        this.Alert("Lưu thành công", Notification.Alert.enmType.Success);
                    }
                    else
                    {
                        this.Alert("Lưu thất bại", Notification.Alert.enmType.Error);
                    }
                }
                else
                {
                    bllCTTT.Delete_CTTT(textBox_matt.Text);
                    this.Alert("Lưu thành công", Notification.Alert.enmType.Success);
                }
            }
            else
            {
                this.Alert("Thông tin bị thiếu", Notification.Alert.enmType.Error);
            }

        }





    }
}
