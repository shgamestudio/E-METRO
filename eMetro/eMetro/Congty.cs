using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMetro
{
    public partial class Congty : Form
    {
        BLL.CongtyBLL bllCT;

        public Congty()
        {
            InitializeComponent();
            bllCT = new BLL.CongtyBLL();
        }

        private void Congty_Shown(object sender, EventArgs e)
        {
            //bunifuCustomDataGrid_congty.Rows.Add(
            //    new object[]
            //    {
            //        "Vincetn MArlone",
            //        31,
            //        "Developer",
            //        "wowy mood",
            //        "basket"
            //    }
            //    );

            //bunifuCustomDataGrid_congty.Rows.Add(
            //      new object[]
            //      {
            //        "John MArlone",
            //        31,
            //        "Developer",
            //        "wowy mood",
            //        "basket"
            //      }
            //      );

            //bunifuCustomDataGrid_congty.Rows.Add(
            //     new object[]
            //     {
            //        "Vincetn Hu",
            //        30,
            //        "Developer",
            //        "wowy mood",
            //        "basket"
            //     }
            //     );

            //bunifuCustomDataGrid_congty.Rows.Add(
            //     new object[]
            //     {
            //        "Poluinee Kyuree",
            //        29,
            //        "Developer",
            //        "wowy mood",
            //        "same"
            //     }
            //     );

            //bunifuCustomDataGrid_congty.Rows.Add(
            //     new object[]
            //     {
            //        "Balu Popipuy",
            //        32,
            //        "Developer",
            //        "koo mood",
            //        "basket"
            //     }
            //     );
        }

        private void BunifuTextbox_search_Enter(object sender, EventArgs e)
        {
            if (bunifuTextbox_search.text == "Tìm kiếm")
            {
                bunifuTextbox_search.text = "";
                
            }
        }

        private void BunifuTextbox_search_Leave(object sender, EventArgs e)
        {
            if (bunifuTextbox_search.text == "")
            {
                bunifuTextbox_search.text = "Tìm kiếm";

            }
        }

        public void ShowAllCongty()
        {
            DataTable dt = bllCT.getAllCongty();
            bunifuCustomDataGrid_congty.DataSource = dt;
        }

        private void Congty_Load(object sender, EventArgs e)
        {
            ShowAllCongty();
        }

        private void IconButton_them_Click(object sender, EventArgs e)
        {
            DTO.Congty ct = new DTO.Congty();         
            ct.tenct = textBox_tenct.Text;
            ct.sdtct = textBox_sdtct.Text;
            ct.diachitrusoct = textBox_diachitrusoct.Text;
            ct.diachiwebct = textBox_diachiwebct.Text;
            ct.tinhtrang = comboBox_tinhtrang.Text;
            

            if (bllCT.InsertCongty(ct))
            {
                ShowAllCongty();
                textBox_mact.Clear();    
                textBox_tenct.Clear();
                //comboBox_tinhtrang.Clear();
                textBox_sdtct.Clear();
                textBox_diachitrusoct.Clear();
                textBox_diachiwebct.Clear();
            }
            else
            {
                MessageBox.Show("Có lỗi xảy ra, xin hãy thử lại!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BunifuCustomDataGrid_congty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                //_ID = Int32.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
                textBox_mact.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Mã công ty"].Value.ToString();
                textBox_tenct.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Tên công ty"].Value.ToString();
                textBox_sdtct.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Số điện thoại"].Value.ToString();
                textBox_diachitrusoct.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Địa chỉ"].Value.ToString();
                textBox_diachiwebct.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Website"].Value.ToString();
                comboBox_tinhtrang.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Tình trạng"].Value.ToString();
            }
        }
    }
}
