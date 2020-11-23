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
                var menu = new Menu();
                menu.Closed += (s, args) => this.Close();
                menu.Show();


            }
            else
            {
                this.Alert("Tài khoản hoặc\r\nmật khẩu chưa đúng", Notification.Alert.enmType.Error);
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
    }
}
