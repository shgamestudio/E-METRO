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
    public partial class Dangnhap : Form
    {
        private int quick = 1800;
        private int count_fail=0;
        bool check = false;
        BLL.NhanvienBLL bllNV;
       
        public Dangnhap()
        {
            InitializeComponent();
            bllNV = new BLL.NhanvienBLL();
            check = new bool();
        }

      

   
        private void Dangnhap_Load(object sender, EventArgs e)
        {
      
        }

     

        public void Alert(string msg, Notification.Alert.enmType type)
        {
            Notification.Alert frm = new Notification.Alert();
            frm.showAlert(msg, type);
        }

        private void GunaGradientButton_dangnhap_Click(object sender, EventArgs e)
        {

            if(bllNV.Login(bunifuMaterialTextbox_username.Text,textBox_password.Text))
            {


                this.Alert("Đăng nhập thành công", Notification.Alert.enmType.Success);
                this.Hide();
                var menu = new Menu(bllNV.GetManv(bunifuMaterialTextbox_username.Text, textBox_password.Text));
                menu.Closed += (s, args) => this.Close();
                menu.Show();


            }
            else
            {
                count_fail++;
                this.Alert("Tài khoản hoặc\r\nmật khẩu chưa đúng", Notification.Alert.enmType.Error);
            }
            if(count_fail==3)
            {
                label_fail_count.Visible = true;
                gunaGradientButton_dangnhap.Enabled = false;
                timer_checkSignin = new System.Windows.Forms.Timer();
                timer_checkSignin.Interval = 1;
                timer_checkSignin.Tick += new EventHandler(Timer_checkSignin_Tick);
                timer_checkSignin.Enabled = true;
            }
        }

       

        private void TextBox_password_Click(object sender, EventArgs e)
        {
            if (check == false)
            {
                textBox_password.Text = "";
                check = true;

            }
        }

        private void GunaImageButton_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BunifuSeparator2_MouseEnter(object sender, EventArgs e)
        {
            bunifuSeparator2.LineColor = Color.PaleVioletRed;
        }

        private void BunifuSeparator2_MouseLeave(object sender, EventArgs e)
        {
            bunifuSeparator2.LineColor = Color.FromArgb(128,128,128);
        }

        private void TextBox_password_MouseEnter(object sender, EventArgs e)
        {
            bunifuSeparator2.LineColor = Color.PaleVioletRed;
        }

        private void TextBox_password_MouseLeave(object sender, EventArgs e)
        {
            bunifuSeparator2.LineColor = Color.FromArgb(128, 128, 128);
        }

        private void Timer_checkSignin_Tick(object sender, EventArgs e)
        {
            quick--;
            //label_fail_count.Text = quick / 60 + ":" + ((quick % 60) >= 10 ? (quick % 60).ToString() : "0" + (quick % 60));
            label_fail_count.Text = (quick / 60 > 0) ? "Vui lòng đăng nhập lại sau "+(quick / 60).ToString()+ " giây." : "Xin mời đăng nhập lại";
            if (label_fail_count.Text == "Xin mời đăng nhập lại")
            {
                timer_checkSignin.Stop();
                gunaGradientButton_dangnhap.Enabled = true;
                quick = 1800;
                count_fail = 0;
                label_fail_count.Visible = false;
            }
        }
    }
}
