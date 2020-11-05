using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMetro
{
    public partial class Ga : Form
    {
        BLL.GaBLL bllGA;
        string imageUrl = null;
        public Ga()
        {
            InitializeComponent();
            bllGA = new BLL.GaBLL();
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

        private void Ga_Load(object sender, EventArgs e)
        {
            ShowAllGa();
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

        private void IconButton_themga_Click(object sender, EventArgs e)
        {
            Image img = pictureBox_bando.Image;
            //byte[] arr;
            //ImageConverter converter = new ImageConverter();
            //arr = (byte[])converter.ConvertTo(img, typeof(byte[]));

            DTO.Ga ga = new DTO.Ga();
            ga.tenga = textBox_tenga.Text;
            ga.motavitri = richTextBox_motavitri.Text;
            ga.bando = ConvertImageToBytes(img);
            ga.tinhtrang = comboBox_tinhtrang.Text;


            if (bllGA.InsertGa(ga))
            {
                ShowAllGa();
                textBox_maga.Clear();
                textBox_tenga.Clear();
                //comboBox_tinhtrang.Clear();
                
                richTextBox_motavitri.Clear();
                
                this.Alert("Thêm thành công", Notification.Alert.enmType.Success);
            }
            else
            {
                this.Alert("Thêm thất bại", Notification.Alert.enmType.Error);
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
                pictureBox_bando.Image = ConvertByteArrayToImage((byte[])rowga["Bản đồ"]);
                comboBox_tinhtrang.Text = bunifuCustomDataGrid_ga.Rows[index].Cells["Tình trạng"].Value.ToString();
            }
        }

        private void IconButton_capnhat_Click(object sender, EventArgs e)
        {
            Image img = pictureBox_bando.Image;
            DTO.Ga ct = new DTO.Ga();

            ct.maga = textBox_maga.Text;
            ct.tenga = textBox_tenga.Text;
            ct.tinhtrang = comboBox_tinhtrang.Text;
            ct.motavitri = richTextBox_motavitri.Text;
            ct.bando = ConvertImageToBytes(img);


            if (bllGA.UpdateGa(ct))
            {
                ShowAllGa();
                textBox_maga.Clear();
                textBox_tenga.Clear();
                richTextBox_motavitri.Clear();
                pictureBox_bando.Image.Dispose();
                this.Alert("Thêm thành công", Notification.Alert.enmType.Success);

            }
            else
            {
                this.Alert("Thêm thất bại", Notification.Alert.enmType.Error);
            }
        }
    }
}
