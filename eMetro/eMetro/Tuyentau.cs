using System;
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
        DataTable dty;
        bool check_num = false;
        public Tuyentau()
        {
            InitializeComponent();
            dc = new DAL.DataConnection();
            bllTT = new BLL.TuyentauBLL();
            dty = new DataTable();
        }

        private void Tuyentau_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eMETRODataSet.TUYENTAU' table. You can move, or remove it, as needed.
            //this.tUYENTAUTableAdapter.Fill(this.eMETRODataSet.TUYENTAU); 
            //code chính


            //this.ShowAllGaxp();
            //this.ShowAllGakt();
            //advancedDataGridView_tuyentau.DataSource = dty;

            this.tUYENTAUBindingSource.DataSource = gettuyentau();
            this.advancedDataGridView_tuyentau.DataSource = this.tUYENTAUBindingSource;

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
    }
}
