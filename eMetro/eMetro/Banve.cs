using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QRCoder;

namespace eMetro
{
    public partial class Banve : Form
    {
        DAL.DataConnection dc;
        SqlCommand cmd;
        SqlDataAdapter da;
        BLL.TuyentauBLL bllTT;
        int index;
        BLL.VeBLL bllVE;
        string mave_tmp;
        public Banve()
        {
            InitializeComponent();
            bllTT = new BLL.TuyentauBLL();
            bllVE = new BLL.VeBLL();
            dc = new DAL.DataConnection();
            index = new int();
           
        }


        //
        #region Mã hóa 
        static readonly string PasswordHash = "P@@Sw0rd";
        static readonly string SaltKey = "S@LT&KEY";
        static readonly string VIKey = "@1B2c3D4e5F6g7H8";





        public static string Encrypt(string plainText)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }


        public static string Decrypt(string encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }
        #endregion 
        //


        private void Banve_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eMETRODataSet_TT.TUYENTAU' table. You can move, or remove it, as needed.
            this.tUYENTAUTableAdapter2.Fill(this.eMETRODataSet_TT.TUYENTAU);
            ShowAllLoaive();



            this.tUYENTAUBindingSource2.DataSource = bllTT.gettuyentau_banve();
            this.advancedDataGridView_tuyentau.DataSource = this.tUYENTAUBindingSource2;
            DataGridViewColumn column = advancedDataGridView_tuyentau.Columns[4];
            column.Width = 200;
            advancedDataGridView_tuyentau.Rows[0].Selected = true;
            
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
                "or [Giá vé thường] = " + decimal.Parse(textBox_search.Text, CultureInfo.InvariantCulture) +
                "or [Giá vé tháng] = " + decimal.Parse(textBox_search.Text, CultureInfo.InvariantCulture) +
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
            this.tUYENTAUBindingSource2.Sort = this.advancedDataGridView_tuyentau.SortString;
        }

        private void AdvancedDataGridView_tuyentau_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {
            this.tUYENTAUBindingSource2.Filter = this.advancedDataGridView_tuyentau.FilterString;
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

        private void ShowAllLoaive()
        {
            SqlConnection con = dc.GetConnect();
            cmd = new SqlCommand("Select * from LOAIVE WHERE TINHTRANG=N'Hoạt động'", con);
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;

            DataTable table = new DataTable();
            da.Fill(table);

            comboBox_lv.DataSource = table;
            comboBox_lv.DisplayMember = "TENLV";
            comboBox_lv.ValueMember = "MALV";
        }


        private void AdvancedDataGridView_tuyentau_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //int index = e.RowIndex;
            index = e.RowIndex;
            if (index >= 0)
            {
                //_ID = Int32.Parse(dataGridView1.Rows[index].Cells[0].Value.ToString());
               
                ////string t = advancedDataGridView_tuyentau.Rows[index].Cells["mAGAXPDataGridViewTextBoxColumn"].Value.ToString();
                textBox_tentt.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Tên tuyến tàu"].Value.ToString();
                textBox_gaxp.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Ga xuất phát"].Value.ToString();
                textBox_gakt.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Ga kết thúc"].Value.ToString();
                textBox_ltt.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Loại tuyến tàu"].Value.ToString();

                if(comboBox_lv.Text == "Vé thường")
                {
                    textBox_giave.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Giá vé thường"].Value.ToString();
                }
                else
                {
                    textBox_giave.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Giá vé tháng"].Value.ToString();
                }
                //bunifuCustomDataGrid_CTTUYENTAU.DataSource = bllCTTT.getAllCTTuyentau(advancedDataGridView_tuyentau.Rows[index].Cells["Mã tuyến tàu"].Value.ToString());   *tam cmd lại

                bunifuCustomDataGrid_CTTUYENTAU.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                bunifuCustomDataGrid_CTTUYENTAU.Rows.Clear();
                bunifuCustomDataGrid_CTTUYENTAU.Refresh();

                SqlConnection con = dc.GetConnect();
                DataTable dt = new DataTable();
                string sqlQuery = string.Format("SELECT CT.MATT[Mã tuyến tàu], G.TENGA[Tên ga], CT.STTGA[Thứ tự ga], CT.TGDUNG[Thời gian dừng], CT.GHICHU[Ghi chú] FROM CTTUYENTAU CT JOIN GA G ON CT.MAGATG = G.MAGA WHERE CT.MATT = '{0}' ORDER BY STTGA ASC", advancedDataGridView_tuyentau.Rows[index].Cells["Mã tuyến tàu"].Value.ToString());
                SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);


                DataTable table = new DataTable();
                da.Fill(table);


                foreach (DataRow item in table.Rows)
                {
                    int n = bunifuCustomDataGrid_CTTUYENTAU.Rows.Add();
           
                    bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[0].Value = item[0].ToString();

                    
                    bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[1].Value = item["Tên ga"].ToString();
                    bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[2].Value = item["Thứ tự ga"].ToString();
                    bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[3].Value = item["Thời gian dừng"].ToString();
                    bunifuCustomDataGrid_CTTUYENTAU.Rows[n].Cells[4].Value = item["Ghi chú"].ToString();
                }
            }
        }

        private void ComboBox_lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox_lv.Text == "Vé thường")
            //{
            //    textBox_giave.Text = advancedDataGridView_tuyentau.Rows[6].Cells["Giá vé thường"].Value.ToString();
            //}
            //else
            //{
            //    textBox_giave.Text = advancedDataGridView_tuyentau.Rows[7].Cells["Giá vé tháng"].Value.ToString();
            //}
        }

        private void ComboBox_lv_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox_lv.Text == "Vé thường")
            {
                textBox_giave.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Giá vé thường"].Value.ToString();
            }
            else
            {
                textBox_giave.Text = advancedDataGridView_tuyentau.Rows[index].Cells["Giá vé tháng"].Value.ToString();
            }
        }

        public void Alert(string msg, Notification.Alert.enmType type)
        {
            Notification.Alert frm = new Notification.Alert();
            frm.showAlert(msg, type);
        }

        private bool CheckData()
        {
            //if (string.IsNullOrEmpty(textBox_masb.Text) || string.IsNullOrEmpty(textBox_tensb.Text))
            if (string.IsNullOrEmpty(textBox_tentt.Text) ||  string.IsNullOrEmpty(textBox_gaxp.Text)|| string.IsNullOrEmpty(textBox_gakt.Text)|| string.IsNullOrEmpty(textBox_ltt.Text))
            {
                this.Alert("Chưa chọn tuyến tàu", Notification.Alert.enmType.Warning);
                textBox_tentt.Focus(); //để con trỏ vào đây
                return false;
            }
            return true;
        }


        public DataTable GetAndSortDesc()
        {
            SqlConnection con = dc.GetConnect();
            string sqlQuery = "SELECT mave FROM VE ORDER BY mave DESC";
            SqlDataAdapter da = new SqlDataAdapter(sqlQuery, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private string TaoMaVe()
        {
            DataTable dt = this.GetAndSortDesc();
            if (dt.Rows.Count == 0)
                return "VE0000" + dt.Rows.Count;
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
            return "VE" + strSoKhong + count;
        }

        private void IconButton_inve_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                DTO.Ve ve = new DTO.Ve();
                ve.malv = comboBox_lv.SelectedValue.ToString();
                ve.matt = advancedDataGridView_tuyentau.Rows[index].Cells["Mã tuyến tàu"].Value.ToString();
                ve.giave = decimal.Parse(textBox_giave.Text);     
                ve.ngaymua = DateTime.Today;
                ve.tinhtrang = "Hoạt động";
                mave_tmp = Encrypt(TaoMaVe());
                if (bllVE.InsertVe(ve))
                {
                    this.tUYENTAUTableAdapter2.Fill(this.eMETRODataSet_TT.TUYENTAU);
                    this.tUYENTAUBindingSource2.DataSource = bllTT.gettuyentau_banve();
                    this.advancedDataGridView_tuyentau.DataSource = this.tUYENTAUBindingSource2;

                
                    //comboBox_tinhtrang.Clear();

                    this.Alert("Bán vé thành công", Notification.Alert.enmType.Success);

                    //in ve
                    printDocument_ve.DefaultPageSettings.PaperSize = new PaperSize("", 800, 350);
                    PrintPreviewDialog ppvw = new PrintPreviewDialog();
                    ppvw.Document = printDocument_ve;
                    ppvw.Show(this);

                   
                }
                else
                {
                    this.Alert("Bán vé thất bại", Notification.Alert.enmType.Error);
                }

            }
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        private void PrintDocument_ve_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            

            e.Graphics.DrawString("e-Metro Subway Ticket", new Font("Times New Roman", 32, FontStyle.Bold), new SolidBrush(Color.Black), new Point(225, 45));
            e.Graphics.DrawString("Tuyến: " + textBox_tentt.Text, new Font("Times New Roman", 13, FontStyle.Regular), new SolidBrush(Color.Black), new Point(240, 145));
            e.Graphics.DrawString("Ga xuất phát: " + textBox_gaxp.Text + " →  Ga kết thúc: " + textBox_gakt.Text, new Font("Times New Roman", 13, FontStyle.Regular), new SolidBrush(Color.Black), new Point(240, 175));
            e.Graphics.DrawString("Ngày mua: " + DateTime.Today.ToString("dd/MM/yyyy"), new Font("Times New Roman", 13, FontStyle.Regular), new SolidBrush(Color.Black), new Point(240, 205));
            e.Graphics.DrawString("Loại vé: " + comboBox_lv.Text + "      -      Loại tuyến: " + textBox_ltt.Text, new Font("Times New Roman", 13, FontStyle.Regular), new SolidBrush(Color.Black), new Point(240, 235));
            e.Graphics.DrawString("Giá: " + textBox_giave.Text +" VNĐ", new Font("Times New Roman", 13, FontStyle.Regular), new SolidBrush(Color.Black), new Point(240, 265));
          


            // Create pen.
            Pen blackPen = new Pen(Color.Black, 4);
            Pen blackPen_light = new Pen(Color.Black, 2);
            // Create rectangle.
            Rectangle rect = new Rectangle(20, 20, 760, 310);
            Rectangle rect_hk = new Rectangle(225, 123, 520, 180);   //285 //450
            //Rectangle rect_ve = new Rectangle(170, k_offset - 20, 510, 692);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, rect);
            e.Graphics.DrawRectangle(blackPen_light, rect_hk);
            //e.Graphics.DrawRectangle(blackPen_light, rect_ve);

            //Bitmap bitmap = Properties.Resources.plane;
            QRCodeGenerator qr = new QRCodeGenerator();
            QRCodeData data = qr.CreateQrCode(mave_tmp, QRCodeGenerator.ECCLevel.Q);
            QRCode code = new QRCode(data);
            Bitmap _bit = ResizeImage(code.GetGraphic(5), 170, 170);

            e.Graphics.DrawImage(_bit, 35, 135);

            Bitmap _bit2 = ResizeImage(Properties.Resources._50471, 110, 110);

            e.Graphics.DrawImage(_bit2, 65, 30);
        }

        private void TextBox_giave_TextChanged(object sender, EventArgs e)
        {
            if (textBox_giave.Text == "")
                return;
            string text = textBox_giave.Text.Replace(",", "");
            decimal value = Convert.ToDecimal(text);
            textBox_giave.Text = string.Format("{0:0,0}", value);
        }

      
    }
}
