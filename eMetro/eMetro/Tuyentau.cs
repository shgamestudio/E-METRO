using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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


        public Tuyentau()
        {
            InitializeComponent();
            dc = new DAL.DataConnection();
            bllTT = new BLL.TuyentauBLL();
        }

        private void Tuyentau_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eMETRODataSet.TUYENTAU' table. You can move, or remove it, as needed.
            this.tUYENTAUTableAdapter.Fill(this.eMETRODataSet.TUYENTAU);
            //this.ShowAllGaxp();
            //this.ShowAllGakt();
        }

        private void ShowAllGaxp()
        {
            SqlConnection con = dc.GetConnect();
            cmd = new SqlCommand("Select * from GA WHERE TINHTRANG=N'Hoạt động'", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);

            comboBox_xpp.DataSource = table;
            comboBox_xpp.DisplayMember = "TENGA";
            comboBox_xpp.ValueMember = "MAGA";
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
                textBox_matt.Text = advancedDataGridView_tuyentau.Rows[index].Cells["mACTDataGridViewTextBoxColumn"].Value.ToString();
                textBox_tentt.Text = advancedDataGridView_tuyentau.Rows[index].Cells["tENTTDataGridViewTextBoxColumn"].Value.ToString();
                comboBox_congty.Text = bllTT.Search_TenCTbyMACT(advancedDataGridView_tuyentau.Rows[index].Cells["mACTDataGridViewTextBoxColumn"].Value.ToString());
                //string t = advancedDataGridView_tuyentau.Rows[index].Cells["mAGAXPDataGridViewTextBoxColumn"].Value.ToString();
                comboBox_xpp.Text = bllTT.Search_TengabyMAGA(advancedDataGridView_tuyentau.Rows[index].Cells["mAGAXPDataGridViewTextBoxColumn"].Value.ToString());
                comboBox_gakt.Text = bllTT.Search_TengabyMAGA(advancedDataGridView_tuyentau.Rows[index].Cells["mAGAKTDataGridViewTextBoxColumn"].Value.ToString());
                comboBox_ltt.Text = bllTT.Search_TenlttbyMALTT(advancedDataGridView_tuyentau.Rows[index].Cells["mALTTDataGridViewTextBoxColumn"].Value.ToString());

                textBox_ghichu.Text = advancedDataGridView_tuyentau.Rows[index].Cells["gHICHUDataGridViewTextBoxColumn"].Value.ToString();
                textBox_giave.Text = advancedDataGridView_tuyentau.Rows[index].Cells["gIAVEDataGridViewTextBoxColumn"].Value.ToString();
                textBox_tgcho.Text = advancedDataGridView_tuyentau.Rows[index].Cells["tHOIGIANCHODataGridViewTextBoxColumn"].Value.ToString();
                dateTimePicker_giobd.Value = DateTime.ParseExact(advancedDataGridView_tuyentau.Rows[index].Cells["gIOBDDataGridViewTextBoxColumn"].Value.ToString(), "HH:mm",
                                          System.Globalization.CultureInfo.InvariantCulture);
                dateTimePicker_giokt.Value = DateTime.ParseExact(advancedDataGridView_tuyentau.Rows[index].Cells["gIOKTDataGridViewTextBoxColumn"].Value.ToString(), "HH:mm",
                                          System.Globalization.CultureInfo.InvariantCulture);
                comboBox_tinhtrang.Text = advancedDataGridView_tuyentau.Rows[index].Cells["tINHTRANGDataGridViewTextBoxColumn"].Value.ToString();
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
            comboBox_xpp.DataSource = dt;
            comboBox_xpp.DisplayMember = "TENGA";
            comboBox_xpp.ValueMember = "MAGA";

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
            if (comboBox_xpp.Text == comboBox_gakt.Text)
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
            comboBox_gakt.SelectedIndex = 2;
        }

        private void ComboBox_xpp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_xpp.Text == comboBox_gakt.Text)
            {
                ShowComboBoxGakt(comboBox_xpp.SelectedValue.ToString());

            }
        }
    }
}
