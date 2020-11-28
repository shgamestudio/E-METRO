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
    public partial class test2 : Form
    {
        public test2()
        {
            InitializeComponent();
        }

        private void Test2_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            notifyIcon1.Icon = SystemIcons.Application;
            notifyIcon1.BalloonTipText = "Ứng dụng đã thu nhỏ";
            notifyIcon1.ShowBalloonTip(1000);
            this.ShowInTaskbar = false;
            this.Hide();
            notifyIcon1.Visible = true;
        }

        private void NotifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
            notifyIcon1.Visible = false;
        }
    }
}
