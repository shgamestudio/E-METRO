﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMetro
{
    public partial class Ga : Form
    {
        DAL.DataConnection dc;
        SqlDataAdapter da;
        BLL.GaBLL bllGA;
        string imageUrl = null;
        public Ga()
        {
            InitializeComponent();
            bllGA = new BLL.GaBLL();
            dc = new DAL.DataConnection();
        }

       
        private void IconButton_chonanh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg)|*.jpg;*.jpeg", Multiselect = false})
            {
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    imageUrl = ofd.FileName;
                    pictureBox_bando.Image = Image.FromFile(ofd.FileName);
                }
            }
        }

        public void ShowAllGa()
        {

            DataTable dt = bllGA.getAllGa();
            bunifuCustomDataGrid_ga.DataSource = dt;

            bunifuCustomDataGrid_ga.Columns[0].Width = 100;
         
            
            //DataTable dt = bllGA.getAllGa();
            //for (int i = 0; i <= dt.Rows.Count - 1; i++) //dt is datatable
            //{
            //    string k = dt.Rows[i]["Mã ga"].ToString();
            //    bunifuCustomDataGrid_ga.Rows.Add();
            //    bunifuCustomDataGrid_ga.Rows[i].Cells["Column_maga"].Value = k;
            //    bunifuCustomDataGrid_ga.Rows[i].Cells["Column_tenga"].Value = dt.Rows[i]["Tên ga"].ToString();
            //    bunifuCustomDataGrid_ga.Rows[i].Cells["Column_motavitri"].Value = dt.Rows[i]["motavitri"].ToString();
            //    bunifuCustomDataGrid_ga.Rows[i].Cells["Column_bando"].Value = dt.Rows[i]["Bản đồ"];
            //    bunifuCustomDataGrid_ga.Rows[i].Cells["Column_tinhtrang"].Value = dt.Rows[i]["Tình trạng"];
            //}



            //bunifuCustomDataGrid_congty.DataSource = dt;

            //imageCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
            //bunifuCustomDataGrid_congty.Columns[0].Width = 125;
            //bunifuCustomDataGrid_congty.Columns[2].Width = 120;
            //bunifuCustomDataGrid_congty.Columns[3].Width = 250;
            //bunifuCustomDataGrid_congty.Columns[5].Width = 160;
        }

        private bool CheckData()
        {
            //if (string.IsNullOrEmpty(textBox_masb.Text) || string.IsNullOrEmpty(textBox_tensb.Text))
            if (string.IsNullOrEmpty(textBox_tenga.Text) || string.IsNullOrEmpty(richTextBox_motavitri.Text)
                || pictureBox_bando.Image == null)
            {
                this.Alert("Thông tin nhập bị thiếu", Notification.Alert.enmType.Warning);
                textBox_tenga.Focus(); //để con trỏ vào đây
                return false;
            }
            return true;
        }

        private void Ga_Load(object sender, EventArgs e)
        {
            ShowAllGa();
            bunifuCustomDataGrid_ga.Visible = false;
            bunifuTransition_ga.Show(bunifuCustomDataGrid_ga);
            
        }

        public void Alert(string msg, Notification.Alert.enmType type)
        {
            Notification.Alert frm = new Notification.Alert();
            frm.showAlert(msg, type);
        }

        byte[] ConvertImageToBytes(Image img)
        {
            using(MemoryStream ms =new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }
        public Image ConvertByteArrayToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
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


        private void IconButton_themga_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {

                //Image img = pictureBox_bando.Image;
                //byte[] arr;
                //ImageConverter converter = new ImageConverter();
                //arr = (byte[])converter.ConvertTo(img, typeof(byte[]));


                DTO.Ga ga = new DTO.Ga();
                ga.tenga = textBox_tenga.Text;
                ga.motavitri = richTextBox_motavitri.Text;
                //ga.bando = ConvertImageToBytes(img);
                ga.tinhtrang = comboBox_tinhtrang.Text;
                string tmp_bdoname = TaoMaGa();

                if (bllGA.InsertGa(ga))
                {
                    ShowAllGa();
                    textBox_maga.Clear();
                    textBox_tenga.Clear();
                    //comboBox_tinhtrang.Clear();


                    //Copy hình
                    string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    string filePath = Path.Combine(projectPath, "StationMap");
                    pictureBox_bando.Image.Save(@"" + filePath + @"\" + tmp_bdoname+"_bdo.jpg", ImageFormat.Jpeg);
                    //
                    //pictureBox_bando.Dispose();
                    pictureBox_bando.Image = null;

                    richTextBox_motavitri.Clear();
                    //pictureBox_bando.Image.Dispose();
                    //pictureBox_bando.Image = null;
                    this.Alert("Thêm thành công", Notification.Alert.enmType.Success);
                }
                else
                {
                    this.Alert("Thêm thất bại", Notification.Alert.enmType.Error);
                }
            }
        }

      

        private void BunifuCustomDataGrid_congty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dtga = bunifuCustomDataGrid_ga.DataSource as DataTable;
            int index = e.RowIndex;
            if (index >= 0)
            {
                DataRow rowga = dtga.Rows[e.RowIndex];
                //_ID = Int32.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
                textBox_maga.Text = bunifuCustomDataGrid_ga.Rows[index].Cells["Mã ga"].Value.ToString();
                textBox_tenga.Text = bunifuCustomDataGrid_ga.Rows[index].Cells["Tên ga"].Value.ToString();
                richTextBox_motavitri.Text = bunifuCustomDataGrid_ga.Rows[index].Cells["Mô tả vị trí"].Value.ToString();
                //textBox_diachitrusoct.Text = bunifuCustomDataGrid_congty.Rows[index].Cells["Địa chỉ"].Value.ToString();
                //pictureBox_bando.Image = ConvertByteArrayToImage((byte[])rowga["Bản đồ"]);
                comboBox_tinhtrang.Text = bunifuCustomDataGrid_ga.Rows[index].Cells["Tình trạng"].Value.ToString();

                string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                string filePath = Path.Combine(projectPath, "StationMap");
                string path = @"" + filePath + @"\" + bunifuCustomDataGrid_ga.Rows[index].Cells["Mã ga"].Value.ToString() + "_bdo.jpg";

                if (File.Exists(path))
                {
                    //show ảnh
                    using (FileStream fs = new FileStream(@"" + filePath + @"\" + bunifuCustomDataGrid_ga.Rows[index].Cells["Mã ga"].Value.ToString() + "_bdo.jpg", FileMode.Open))
                    {
                        pictureBox_bando.Image = Image.FromStream(fs);
                        fs.Close();
                    }
                    //pictureBox_bando.Image = Image.FromFile(@"" + filePath + @"\" + bunifuCustomDataGrid_ga.Rows[index].Cells["Mã ga"].Value.ToString() + "_bdo.jpg");
                }
                else
                {

                    pictureBox_bando.Image = null;
                }

               
            }
        }

        private void IconButton_capnhat_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
               
                //Image img = pictureBox_bando.Image;
                DTO.Ga ct = new DTO.Ga();

                ct.maga = textBox_maga.Text;
                ct.tenga = textBox_tenga.Text;
                ct.tinhtrang = comboBox_tinhtrang.Text;
                ct.motavitri = richTextBox_motavitri.Text;
                //ct.bando = ConvertImageToBytes(img);
                string tmp_bdoname = ct.maga;

                if (bllGA.UpdateGa(ct))
                {
                    ShowAllGa();
                    textBox_maga.Clear();
                    textBox_tenga.Clear();
                    ////Copy hình
                    //string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    //string filePath = Path.Combine(projectPath, "StationMap");

                    //if (System.IO.File.Exists(@"" + filePath + @"\" + tmp_bdoname + "_bdo.jpg"))
                    //{
                    //    System.IO.File.Delete(@"" + filePath + @"\" + tmp_bdoname + "_bdo.jpg");
                    //}

                    //pictureBox_bando.Image.Save(@"" + filePath + @"\" + tmp_bdoname + "_bdo.jpg", ImageFormat.Jpeg);
                    //

                    //Lưu ảnh vào folder
                    string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                    string filePath = Path.Combine(projectPath, "StationMap");
                    pictureBox_bando.Image.Save(@"" + filePath + @"\" + tmp_bdoname + "_bdo.jpg", ImageFormat.Jpeg);



                    //pictureBox_bando.Dispose();
                    pictureBox_bando.Image = null;
                    richTextBox_motavitri.Clear();
                    

                    //pictureBox_bando.Image.Dispose();
                    //pictureBox_bando.Image = null;
                    this.Alert("Cập nhật thành công", Notification.Alert.enmType.Success);

                }
                else
                {
                    this.Alert("Cập nhật thất bại", Notification.Alert.enmType.Error);
                }
            }
        }



        private void TextBox_search_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_search.Text))
            {
                ShowAllGa();

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

        private void IconButton_tracuu_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_search.Text))
            {
                ShowAllGa();

            }
        }

        private void IconButton_tracuu_Click(object sender, EventArgs e)
        {
            string value = textBox_search.Text;
            string field_search = "";

            switch (bunifuDropdown_filter.selectedIndex)
            {
                case 0:
                    field_search = "       Tất cả";
                    break;
                case 1:
                    field_search = "maga";
                    break;
                case 2:
                    field_search = "tenga";
                    break;
                case 3:
                    field_search = "motavitri";
                    break;              
                case 4:
                    field_search = "tinhtrang";
                    break;
            }

            if (!string.IsNullOrEmpty(value)) //không rỗng
            {
                DataTable dt = bllGA.FindGa(value, field_search);
                bunifuCustomDataGrid_ga.DataSource = dt;
            }
            else
                ShowAllGa();
        }

        private void TextBox_search_Enter(object sender, EventArgs e)
        {
            if (textBox_search.Text == "Tìm kiếm")
            {
                textBox_search.Text = "";
                textBox_search.ForeColor = Color.Black;


            }
        }

        private void IconButton_image_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image files(*.jpg;*.jpeg)|*.jpg;*.jpeg", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageUrl = ofd.FileName;
                    pictureBox_bando.Image = Image.FromFile(ofd.FileName);
                }
            }
        }



    }
}
