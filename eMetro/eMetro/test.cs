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
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "admin")
            {
                MessageBox.Show("ssssss");
            }
            else
            {
                MessageBox.Show("aaaaaaaaaaaaaaaaa");
            }
        }
    }
}
