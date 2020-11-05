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

     

        public void ShowAllCongty()
        {
            DataTable dt = bllCT.getAllCongty();
            bunifuCustomDataGrid_congty.DataSource = dt;
           
            bunifuCustomDataGrid_congty.Columns[0].Width = 125;
            bunifuCustomDataGrid_congty.Columns[2].Width = 120;
            bunifuCustomDataGrid_congty.Columns[3].Width = 250;
            bunifuCustomDataGrid_congty.Columns[5].Width = 160;
        }

        private void Congty_Load(object sender, EventArgs e)
        {
            ShowAllCongty();
        }

        private bool CheckData()
        {
            //if (string.IsNullOrEmpty(textBox_masb.Text) || string.IsNullOrEmpty(textBox_tensb.Text))
            if (string.IsNullOrEmpty(textBox_tenct.Text) || string.IsNullOrEmpty(textBox_sdtct.Text) 
                || string.IsNullOrEmpty(textBox_diachitrusoct.Text) || string.IsNullOrEmpty(textBox_diachiwebct.Text) )
            {
                this.Alert("Thông tin nhập bị thiếu", Notification.Alert.enmType.Warning);
                textBox_tenct.Focus(); //để con trỏ vào đây
                return false;
            }
            return true;
        }

        private void IconButton_them_Click(object sender, EventArgs e)
        {
            

            if (CheckData())
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
                    this.Alert("Thêm thành công", Notification.Alert.enmType.Success);
                }
                else
                {
                    this.Alert("Thêm thất bại", Notification.Alert.enmType.Error);
                }
            }
           
           
        }

        public void Alert(string msg, Notification.Alert.enmType type)
        {
            Notification.Alert frm = new Notification.Alert();
            frm.showAlert(msg, type);
        }

        private void BunifuCustomDataGrid_congty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                //_ID = Int32.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
                textBox_mact.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Mã công ty"].Value.ToString();
                textBox_tenct.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Tên công ty"].Value.ToString();
                textBox_sdtct.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Số ĐT"].Value.ToString();
                textBox_diachitrusoct.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Địa chỉ"].Value.ToString();
                textBox_diachiwebct.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Website"].Value.ToString();
                comboBox_tinhtrang.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Tình trạng"].Value.ToString();
            }
        }

        private void TextBox_search_Enter(object sender, EventArgs e)
        {
            if (textBox_search.Text == "Tìm kiếm")
            {
                textBox_search.Text = "";
                textBox_search.ForeColor = Color.Black;


            }
        }

        private void TextBox_search_Leave(object sender, EventArgs e)
        {
            if (textBox_search.Text == "")
            {
                textBox_search.ForeColor = Color.DarkGray;
                textBox_search.Text = "Tìm kiếm";

            }
        }

        private void IconButton_capnhat_Click(object sender, EventArgs e)
        {
            DTO.Congty ct = new DTO.Congty();

            ct.mact = textBox_mact.Text;
            ct.tenct = textBox_tenct.Text;
            ct.tinhtrang = comboBox_tinhtrang.Text;
            ct.sdtct = textBox_sdtct.Text;
            ct.diachitrusoct = textBox_diachitrusoct.Text;
            ct.diachiwebct = textBox_diachiwebct.Text;

            if (bllCT.UpdateCongty(ct))
            {
                ShowAllCongty();
                textBox_mact.Clear();    
                textBox_tenct.Clear();
                textBox_sdtct.Clear();
                textBox_diachitrusoct.Clear();
                textBox_diachiwebct.Clear();
                this.Alert("Thêm thành công", Notification.Alert.enmType.Success);
            }
            else
            {
                this.Alert("Thêm thất bại", Notification.Alert.enmType.Error);
            }
        }

        private void IconButton_tracuu_Click(object sender, EventArgs e)
        {
            string value = textBox_search.Text;
            string field_search="";

            switch (bunifuDropdown_filter.selectedIndex)
            {
                case 0:
                    field_search = "Tất cả";
                    break;
                case 1:
                    field_search = "mact";
                    break;
                case 2:
                   field_search = "tenct";
                    break;
                case 3:
                    field_search = "sdtct";
                    break;
                case 4:
                    field_search = "diachitrusoct";
                    break;
                case 5:
                    field_search = "diachiwebct";
                    break;
                case 6:
                    field_search = "tinhtrang";
                    break;
            }

            if (!string.IsNullOrEmpty(value)) //không rỗng
            {
                DataTable dt = bllCT.FindCongty(value, field_search);
                bunifuCustomDataGrid_congty.DataSource = dt;
            }
            else
            ShowAllCongty();
            

        }

        private void TextBox_search_TextChanged(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox_search.Text))
            {
                ShowAllCongty();

            }
        }

       
    }
}
