using FontAwesome.Sharp;
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
    public partial class Menu : Form
    {
        //Fields
        private IconButton currentBtn;
        private IconButton clickedBtn;
        private Panel leftBorderBtn;

        //Struct
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);

            public static Color color44 = Color.FromArgb(255, 255, 255);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

        private void activehover(object senderbtn)
        {
            if(senderbtn !=null)
            {
                deactivehover();
                currentBtn = (IconButton)senderbtn;               
                currentBtn.BackColor = Color.FromArgb(165, 21, 80);
            }
        }

        private void deactivehover()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.Transparent;
            }
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
               
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.Font = new Font("Calibri", 12);
                //currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                //currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }



        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.Font = new Font("Calibri", 11);
                //currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                //currentBtn.BackColor = Color.Transparent;
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        public Menu()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            leftBorderBtn.Visible = false;
            bunifuGradientPanel_menu.Controls.Add(leftBorderBtn);

            //BDK
            iconButton_BDK.FlatAppearance.MouseOverBackColor = iconButton_BDK.BackColor;
            iconButton_BDK.BackColorChanged += (s, e) =>
            {
                iconButton_BDK.FlatAppearance.MouseOverBackColor = iconButton_BDK.BackColor;

            };

            iconButton_BDK.FlatAppearance.MouseDownBackColor = iconButton_BDK.BackColor;
            iconButton_BDK.BackColorChanged += (s, e) =>
            {
                iconButton_BDK.FlatAppearance.MouseDownBackColor = iconButton_BDK.BackColor;
            };
            //QLCT
            iconButton_QLCT.FlatAppearance.MouseOverBackColor = iconButton_QLCT.BackColor;
            iconButton_QLCT.BackColorChanged += (s, e) =>
            {
                iconButton_QLCT.FlatAppearance.MouseOverBackColor = iconButton_QLCT.BackColor;

            };

            iconButton_QLCT.FlatAppearance.MouseDownBackColor = iconButton_QLCT.BackColor;
            iconButton_QLCT.BackColorChanged += (s, e) =>
            {
                iconButton_QLCT.FlatAppearance.MouseDownBackColor = iconButton_QLCT.BackColor;
            };
            //QLG
            iconButton_QLG.FlatAppearance.MouseOverBackColor = iconButton_QLG.BackColor;
            iconButton_QLG.BackColorChanged += (s5, e5) =>
            {
                iconButton_QLG.FlatAppearance.MouseOverBackColor = iconButton_QLG.BackColor;

            };

            iconButton_QLG.FlatAppearance.MouseDownBackColor = iconButton_QLG.BackColor;
            iconButton_QLG.BackColorChanged += (s6, e6) =>
            {
                iconButton_QLG.FlatAppearance.MouseDownBackColor = iconButton_QLG.BackColor;
            };
            //QLTT
            iconButton_QLTT.FlatAppearance.MouseOverBackColor = iconButton_QLTT.BackColor;
            iconButton_QLTT.BackColorChanged += (s7, e7) =>
            {
                iconButton_QLTT.FlatAppearance.MouseOverBackColor = iconButton_QLTT.BackColor;

            };

            iconButton_QLTT.FlatAppearance.MouseDownBackColor = iconButton_QLTT.BackColor;
            iconButton_QLTT.BackColorChanged += (s8, e8) =>
            {
                iconButton_QLTT.FlatAppearance.MouseDownBackColor = iconButton_QLTT.BackColor;
            };
        }

        private void PictureBox_hide_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void PictureBox_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void PictureBox_restore_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            pictureBox_maximize.Visible = true;
            pictureBox_restore.Visible = false;
        }

        private void PictureBox_maximize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            pictureBox_maximize.Visible = false;
            pictureBox_restore.Visible = true;
        }

        //Chỉnh nút menu
        private void IconButton_BDK_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, RGBColors.color1);
            if (clickedBtn != (IconButton)sender)                         //thêm dòng if là oke
            {
                setColor();
                IconButton theBtn = (IconButton)sender;
                clickedBtn = theBtn;
            }
        }

        private void IconButton_QLCT_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, RGBColors.color2);
            setColor();
            IconButton theBtn = (IconButton)sender;
            clickedBtn = theBtn;
        }

        private void IconButton_QLG_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, RGBColors.color3);
            setColor();
            IconButton theBtn = (IconButton)sender;
            clickedBtn = theBtn;
        }

        private void IconButton_QLTT_Click(object sender, EventArgs e)
        {
            //ActivateButton(sender, RGBColors.color44);
            setColor();
            IconButton theBtn = (IconButton)sender;
            clickedBtn = theBtn;
        }

        //Mouse hover event
        private void IconButton_BDK_MouseHover(object sender, EventArgs e)
        {
            //this.iconButton_BDK.BackColor = Color.FromArgb(165, 21, 80);
            //activehover(sender);
        }

        private void IconButton_BDK_MouseLeave(object sender, EventArgs e)
        {
            //this.iconButton_BDK.BackColor = Color.Transparent;
            IconButton theBtn = (IconButton)sender;
            if(theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.Transparent;
            }
        }

        public void setColor()
        {
            if (clickedBtn != default(IconButton))
                clickedBtn.BackColor = Color.Transparent;
            //Resetting clicked label because another (or the same) was just clicked.
        }

        private void IconButton_QLCT_MouseHover(object sender, EventArgs e)
        {
            //iconButton_QLCT.BackColor = Color.FromArgb(165, 21, 80);
        }

        private void IconButton_QLCT_MouseLeave(object sender, EventArgs e)
        {
            //iconButton_QLCT.BackColor = Color.Transparent;
            IconButton theBtn = (IconButton)sender;
            if (theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.Transparent;
            }
        }

        private void IconButton_QLG_MouseHover(object sender, EventArgs e)
        {
            //iconButton_QLG.BackColor = Color.FromArgb(165, 21, 80);
        }

        private void IconButton_QLG_MouseLeave(object sender, EventArgs e)
        {
            //iconButton_QLG.BackColor = Color.Transparent;
            IconButton theBtn = (IconButton)sender;
            if (theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.Transparent;
            }
        }

        private void IconButton_QLTT_MouseHover(object sender, EventArgs e)
        {
            //iconButton_QLTT.BackColor = Color.FromArgb(165, 21, 80);
        }

        private void IconButton_QLTT_MouseLeave(object sender, EventArgs e)
        {
            IconButton theBtn = (IconButton)sender;
            if (theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.Transparent;
            }
            //iconButton_QLTT.BackColor = Color.Transparent;
        }

        private void IconButton_BDK_MouseEnter(object sender, EventArgs e)
        {
            IconButton theBtn = (IconButton)sender;
            if(theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.Red;
            }
        }

        private void IconButton_QLCT_MouseEnter(object sender, EventArgs e)
        {
            IconButton theBtn = (IconButton)sender;
            if (theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.Red;
            }
        }

        private void IconButton_QLG_MouseEnter(object sender, EventArgs e)
        {
            IconButton theBtn = (IconButton)sender;
            if (theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.Red;
            }
        }

        private void IconButton_QLTT_MouseEnter(object sender, EventArgs e)
        {
            IconButton theBtn = (IconButton)sender;
            if (theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.Red;
            }
        }
    }
}
