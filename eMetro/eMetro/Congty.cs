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
        public Congty()
        {
            InitializeComponent();
        }

        private void Congty_Shown(object sender, EventArgs e)
        {
            bunifuCustomDataGrid_congty.Rows.Add(
                new object[]
                {
                    "Vincetn MArlone",
                    31,
                    "Developer",
                    "wowy mood",
                    "basket"
                }
                );

            bunifuCustomDataGrid_congty.Rows.Add(
                  new object[]
                  {
                    "John MArlone",
                    31,
                    "Developer",
                    "wowy mood",
                    "basket"
                  }
                  );

            bunifuCustomDataGrid_congty.Rows.Add(
                 new object[]
                 {
                    "Vincetn Hu",
                    30,
                    "Developer",
                    "wowy mood",
                    "basket"
                 }
                 );

            bunifuCustomDataGrid_congty.Rows.Add(
                 new object[]
                 {
                    "Poluinee Kyuree",
                    29,
                    "Developer",
                    "wowy mood",
                    "same"
                 }
                 );

            bunifuCustomDataGrid_congty.Rows.Add(
                 new object[]
                 {
                    "Balu Popipuy",
                    32,
                    "Developer",
                    "koo mood",
                    "basket"
                 }
                 );

        }
    }
}
