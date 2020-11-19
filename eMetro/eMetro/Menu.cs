using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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
        private Form currentChildForm;
        private bool minim = false;
        private bool hometrig = true;

        //Struct
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);

            public static Color color44 = Color.FromArgb(79, 224, 220);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
        }

       

        public Menu()
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            leftBorderBtn.Visible = false;
            bunifuGradientPanel_menu.Controls.Add(leftBorderBtn);
            //Form
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            ActivateButton(iconButton_homebtn, Color.FromArgb(165, 21, 80));
            IconButton theBtn = iconButton_homebtn;
            if (theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.FromArgb(165, 21, 80);
            }
            clickedBtn = theBtn;

            #region Ẩn hiệu ứng hover của button
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
            //home
            iconButton_homebtn.FlatAppearance.MouseOverBackColor = iconButton_homebtn.BackColor;
            iconButton_homebtn.BackColorChanged += (s7, e7) =>
            {
                iconButton_homebtn.FlatAppearance.MouseOverBackColor = iconButton_homebtn.BackColor;

            };

            iconButton_homebtn.FlatAppearance.MouseDownBackColor = iconButton_homebtn.BackColor;
            iconButton_homebtn.BackColorChanged += (s8, e8) =>
            {
                iconButton_homebtn.FlatAppearance.MouseDownBackColor = iconButton_homebtn.BackColor;
            };
            #endregion
        }

        #region Hàm hiệu ứng khi nhấn nút

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
                currentBtn.IconColor = color;
                //Iconshow
                iconPictureBox_showform.IconChar = currentBtn.IconChar;
                if (minim == false)
                {
                    currentBtn.TextAlign = ContentAlignment.MiddleCenter;

                    currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                    currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                }
                if (hometrig == true)
                {
                    currentBtn.Font = new Font("Calibri", 14);
                    currentBtn.TextAlign = ContentAlignment.MiddleCenter;

                    currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                    currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                    iconPictureBox_showform.IconChar = IconChar.Home;
                }
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
                iconButton_homebtn.Font = new Font("Calibri", 14);
                //currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                //currentBtn.BackColor = Color.Transparent;
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        #endregion

        #region Các nút tắt, mở rộng, thu nhỏ màn hình

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

        #endregion

        #region Event khi nhấn nút ở side bar
        //Chỉnh nút menu
        private void IconButton_BDK_Click(object sender, EventArgs e)
        {
            hometrig = false;
            ActivateButton(sender, RGBColors.color3);
            if (clickedBtn != (IconButton)sender)                         //thêm dòng if là oke
            {
                setColor();
                IconButton theBtn = (IconButton)sender;
                clickedBtn = theBtn;
            }
            OpenChildForm(new Banve(),iconButton_BDK.Text);
            label_showform.Text = "Bảng điều khiển";
        }

        private void IconButton_QLCT_Click(object sender, EventArgs e)
        {
            hometrig = false;
            ActivateButton(sender, RGBColors.color3);
            if (clickedBtn != (IconButton)sender)                         //thêm dòng if là oke
            {
                setColor();
                IconButton theBtn = (IconButton)sender;
                clickedBtn = theBtn;
            }
            OpenChildForm(new Congty(), iconButton_QLCT.Text);
            label_showform.Text = "Quản lý công ty";
        }

        private void IconButton_QLG_Click(object sender, EventArgs e)
        {
            hometrig = false;
            if (clickedBtn != (IconButton)sender)                         //thêm dòng if là oke
            {
                ActivateButton(sender, RGBColors.color3);
                setColor();
                IconButton theBtn = (IconButton)sender;
                clickedBtn = theBtn;
            }
            OpenChildForm(new Ga(), iconButton_QLG.Text);
            label_showform.Text = "Quản lý ga tàu";
        }

        private void IconButton_QLTT_Click(object sender, EventArgs e)
        {
            hometrig = false;
            if (clickedBtn != (IconButton)sender)                         //thêm dòng if là oke
            {
                ActivateButton(sender, RGBColors.color3);
                setColor();
                IconButton theBtn = (IconButton)sender;
                clickedBtn = theBtn;
            }
            OpenChildForm(new Tuyentau(), iconButton_QLTT.Text);
            label_showform.Text = "Quản lý tuyến tàu";
        }

        #endregion

        #region Hiệu ứng khi con trỏ khi ấn nút

        private void activehover(object senderbtn)
        {
            if (senderbtn != null)
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

        private void IconButton_BDK_MouseLeave(object sender, EventArgs e)
        {
            //this.iconButton_BDK.BackColor = Color.Transparent;
            IconButton theBtn = (IconButton)sender;
            if(theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.Transparent;
            }
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

      

        private void IconButton_QLG_MouseLeave(object sender, EventArgs e)
        {
            //iconButton_QLG.BackColor = Color.Transparent;
            IconButton theBtn = (IconButton)sender;
            if (theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.Transparent;
            }
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
                theBtn.BackColor = Color.FromArgb(165, 21, 80);
            }
        }

        private void IconButton_QLCT_MouseEnter(object sender, EventArgs e)
        {
            IconButton theBtn = (IconButton)sender;
            if (theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.FromArgb(165, 21, 80);
            }
        }

        private void IconButton_QLG_MouseEnter(object sender, EventArgs e)
        {
            IconButton theBtn = (IconButton)sender;
            if (theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.FromArgb(165, 21, 80);
            }
        }

        private void IconButton_QLTT_MouseEnter(object sender, EventArgs e)
        {
            IconButton theBtn = (IconButton)sender;
            if (theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.FromArgb(165, 21, 80);
            }
        }

        public void setColor()
        {
            if (clickedBtn != default(IconButton))
                clickedBtn.BackColor = Color.Transparent;
            //Resetting clicked label because another (or the same) was just clicked.
        }
        #endregion

        private void PictureBox_menusidebar_Click(object sender, EventArgs e)
        {
            minim = !minim;
            if(bunifuGradientPanel_menu.Width == 270)
            {
                //
                if (currentBtn != null)
                {
                    currentBtn.ForeColor = Color.Gainsboro;
                    currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                    currentBtn.IconColor = RGBColors.color3;
                    currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                    currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                }
                //
                bunifuSeparator_linesidebar.Width = 65;
                bunifuGradientPanel_menu.Width = 83;
                panel_sidebar.Width = 115; //104
                //animation
                bunifuGradientPanel_menu.Visible = false;
                bunifuTransition_sidebar.Show(bunifuGradientPanel_menu);
            }
            else
            {
                //
                if (currentBtn != null && hometrig !=true)
                {
                    currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                    currentBtn.IconColor = RGBColors.color3;
                    currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                    currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                }
                //
                bunifuSeparator_linesidebar.Width = 255;
                bunifuGradientPanel_menu.Width = 270;
                panel_sidebar.Width = 300;
                //animation
                bunifuGradientPanel_menu.Visible = false;
                bunifuTransition_sidebar_back.Show(bunifuGradientPanel_menu);
            }
        }


        //[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        //private extern static void ReleaseCapture();

        //[DllImport("user32.DLL", EntryPoint = "SendMessage")]
        //private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Panel_top_MouseDown(object sender, MouseEventArgs e)
        {
            //ReleaseCapture();
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void OpenChildForm(Form childForm, string title_name)
        {
            //if (iconCur)
            //bunifuGradientPanel_home.gr
            if(currentChildForm != null)
            {
                //open only form
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel_wrapperform.Controls.Add(childForm);
            panel_wrapperform.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            //label_showform.Text = title_name;
        }

     

        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            iconButton_homebtn.BackColor = Color.FromArgb(165, 21, 80);
        }


        private void Reset()
        {
            DisableButton();
            setColor();
            leftBorderBtn.Visible = false;
        }

        private void IconButton_homebtn_Click(object sender, EventArgs e)
        {
            hometrig = true;
            ActivateButton(sender, RGBColors.color3);

            leftBorderBtn.Visible = false;
            iconPictureBox_showform.IconChar = IconChar.Home;
            label_showform.Text = "Trang chủ";
            if (clickedBtn != (IconButton)sender)                         //thêm dòng if 
            {
                setColor();
                IconButton theBtn = (IconButton)sender;
                clickedBtn = theBtn;
            }
        }

        private void IconButton_homebtn_MouseEnter(object sender, EventArgs e)
        {
            iconButton_homebtn.BackColor = Color.FromArgb(165, 21, 80);
        }

        private void IconButton_homebtn_MouseLeave(object sender, EventArgs e)
        {
            IconButton theBtn = (IconButton)sender;
            if (theBtn != clickedBtn)
            {
                theBtn.BackColor = Color.Transparent;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            hometrig = true;
            ActivateButton(iconButton_homebtn, RGBColors.color3);

            leftBorderBtn.Visible = false;
            if (clickedBtn != iconButton_homebtn)                         //thêm dòng if 
            {
                setColor();
                IconButton theBtn = iconButton_homebtn;
                clickedBtn = theBtn;
            }
        }
    }
}
