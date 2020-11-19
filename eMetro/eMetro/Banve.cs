using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMetro
{
    public partial class Banve : Form
    {
        BLL.TuyentauBLL bllTT;
        public Banve()
        {
            InitializeComponent();
            bllTT = new BLL.TuyentauBLL();
        }

        private void Banve_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tuyentauDataSet.TUYENTAU' table. You can move, or remove it, as needed.
            this.tUYENTAUTableAdapter.Fill(this.tuyentauDataSet.TUYENTAU);

            this.tUYENTAUBindingSource.DataSource = bllTT.gettuyentau_banve();
            this.advancedDataGridView_tuyentau.DataSource = this.tUYENTAUBindingSource;
            DataGridViewColumn column = advancedDataGridView_tuyentau.Columns[4];
            column.Width = 200;
        }

        private void TextBox_search_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = advancedDataGridView_tuyentau.DataSource;
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
                "or [Tình trạng] like '%" + textBox_search.Text + "%'" ;
                advancedDataGridView_tuyentau.DataSource = bs;
            }
            else
            {
                bs.Filter = "[Mã tuyến tàu] like '%" + textBox_search.Text + "%'";
                advancedDataGridView_tuyentau.DataSource = bs;
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
    }
}
