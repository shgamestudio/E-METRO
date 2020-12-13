namespace eMetro
{
    partial class Baocao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.advancedDataGridView_baocao = new Zuby.ADGV.AdvancedDataGridView();
            this.tuyentauDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tuyentauDataSet = new eMetro.TuyentauDataSet();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.bunifuDropdown_thang = new Bunifu.Framework.UI.BunifuDropdown();
            this.label_mact = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gunaNumeric_nam = new Guna.UI.WinForms.GunaNumeric();
            this.iconButton_themTT = new FontAwesome.Sharp.IconButton();
            this.iconButton_filepath = new FontAwesome.Sharp.IconButton();
            this.iconButton_xuatbc = new FontAwesome.Sharp.IconButton();
            this.folderBrowserDialog_filepath = new System.Windows.Forms.FolderBrowserDialog();
            this.iconButton_themNN = new FontAwesome.Sharp.IconButton();
            this.label_tong = new System.Windows.Forms.Label();
            this.label_giatritong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_baocao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuyentauDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuyentauDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // advancedDataGridView_baocao
            // 
            this.advancedDataGridView_baocao.AllowUserToAddRows = false;
            this.advancedDataGridView_baocao.AllowUserToDeleteRows = false;
            this.advancedDataGridView_baocao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.advancedDataGridView_baocao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.advancedDataGridView_baocao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.advancedDataGridView_baocao.FilterAndSortEnabled = true;
            this.advancedDataGridView_baocao.Location = new System.Drawing.Point(38, 89);
            this.advancedDataGridView_baocao.Name = "advancedDataGridView_baocao";
            this.advancedDataGridView_baocao.ReadOnly = true;
            this.advancedDataGridView_baocao.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.advancedDataGridView_baocao.Size = new System.Drawing.Size(980, 508);
            this.advancedDataGridView_baocao.TabIndex = 5;
            // 
            // tuyentauDataSetBindingSource
            // 
            this.tuyentauDataSetBindingSource.DataSource = this.tuyentauDataSet;
            this.tuyentauDataSetBindingSource.Position = 0;
            // 
            // tuyentauDataSet
            // 
            this.tuyentauDataSet.DataSetName = "TuyentauDataSet";
            this.tuyentauDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // textBox_path
            // 
            this.textBox_path.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_path.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_path.Location = new System.Drawing.Point(225, 660);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.ReadOnly = true;
            this.textBox_path.Size = new System.Drawing.Size(604, 39);
            this.textBox_path.TabIndex = 45;
            // 
            // bunifuDropdown_thang
            // 
            this.bunifuDropdown_thang.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown_thang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bunifuDropdown_thang.BorderRadius = 3;
            this.bunifuDropdown_thang.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDropdown_thang.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDropdown_thang.ForeColor = System.Drawing.Color.White;
            this.bunifuDropdown_thang.Items = new string[] {
        "1",
        "2",
        "3",
        "4",
        "5",
        "6",
        "7",
        "8",
        "9",
        "10",
        "11",
        "12"};
            this.bunifuDropdown_thang.Location = new System.Drawing.Point(119, 33);
            this.bunifuDropdown_thang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuDropdown_thang.Name = "bunifuDropdown_thang";
            this.bunifuDropdown_thang.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
            this.bunifuDropdown_thang.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
            this.bunifuDropdown_thang.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuDropdown_thang.selectedIndex = 0;
            this.bunifuDropdown_thang.Size = new System.Drawing.Size(68, 30);
            this.bunifuDropdown_thang.TabIndex = 6;
            // 
            // label_mact
            // 
            this.label_mact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label_mact.AutoSize = true;
            this.label_mact.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_mact.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_mact.Location = new System.Drawing.Point(39, 33);
            this.label_mact.Name = "label_mact";
            this.label_mact.Size = new System.Drawing.Size(73, 25);
            this.label_mact.TabIndex = 48;
            this.label_mact.Text = "Tháng:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(238, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 25);
            this.label1.TabIndex = 50;
            this.label1.Text = "Năm:";
            // 
            // gunaNumeric_nam
            // 
            this.gunaNumeric_nam.BaseColor = System.Drawing.Color.White;
            this.gunaNumeric_nam.BorderColor = System.Drawing.Color.Silver;
            this.gunaNumeric_nam.ButtonColor = System.Drawing.Color.SeaGreen;
            this.gunaNumeric_nam.ButtonForeColor = System.Drawing.Color.White;
            this.gunaNumeric_nam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaNumeric_nam.ForeColor = System.Drawing.Color.Black;
            this.gunaNumeric_nam.Location = new System.Drawing.Point(314, 33);
            this.gunaNumeric_nam.Maximum = ((long)(9999999));
            this.gunaNumeric_nam.Minimum = ((long)(2000));
            this.gunaNumeric_nam.Name = "gunaNumeric_nam";
            this.gunaNumeric_nam.Size = new System.Drawing.Size(94, 30);
            this.gunaNumeric_nam.TabIndex = 51;
            this.gunaNumeric_nam.Text = "gunaNumeric1";
            this.gunaNumeric_nam.Value = ((long)(2020));
            // 
            // iconButton_themTT
            // 
            this.iconButton_themTT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_themTT.BackColor = System.Drawing.Color.SeaGreen;
            this.iconButton_themTT.FlatAppearance.BorderSize = 0;
            this.iconButton_themTT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_themTT.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_themTT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton_themTT.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton_themTT.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.iconButton_themTT.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton_themTT.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton_themTT.IconSize = 25;
            this.iconButton_themTT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_themTT.Location = new System.Drawing.Point(522, 26);
            this.iconButton_themTT.Name = "iconButton_themTT";
            this.iconButton_themTT.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton_themTT.Rotation = 0D;
            this.iconButton_themTT.Size = new System.Drawing.Size(233, 40);
            this.iconButton_themTT.TabIndex = 53;
            this.iconButton_themTT.Text = "      Tra cứu tháng";
            this.iconButton_themTT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_themTT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton_themTT.UseVisualStyleBackColor = false;
            this.iconButton_themTT.Click += new System.EventHandler(this.IconButton_themTT_Click);
            // 
            // iconButton_filepath
            // 
            this.iconButton_filepath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.iconButton_filepath.BackColor = System.Drawing.Color.SeaGreen;
            this.iconButton_filepath.FlatAppearance.BorderSize = 0;
            this.iconButton_filepath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_filepath.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_filepath.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton_filepath.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton_filepath.IconChar = FontAwesome.Sharp.IconChar.Link;
            this.iconButton_filepath.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton_filepath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton_filepath.IconSize = 25;
            this.iconButton_filepath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_filepath.Location = new System.Drawing.Point(38, 660);
            this.iconButton_filepath.Name = "iconButton_filepath";
            this.iconButton_filepath.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton_filepath.Rotation = 0D;
            this.iconButton_filepath.Size = new System.Drawing.Size(175, 39);
            this.iconButton_filepath.TabIndex = 54;
            this.iconButton_filepath.Text = "Đường dẫn";
            this.iconButton_filepath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_filepath.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton_filepath.UseVisualStyleBackColor = false;
            this.iconButton_filepath.Click += new System.EventHandler(this.IconButton_filepath_Click);
            // 
            // iconButton_xuatbc
            // 
            this.iconButton_xuatbc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_xuatbc.BackColor = System.Drawing.Color.SeaGreen;
            this.iconButton_xuatbc.FlatAppearance.BorderSize = 0;
            this.iconButton_xuatbc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_xuatbc.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_xuatbc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton_xuatbc.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton_xuatbc.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.iconButton_xuatbc.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton_xuatbc.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton_xuatbc.IconSize = 25;
            this.iconButton_xuatbc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_xuatbc.Location = new System.Drawing.Point(842, 660);
            this.iconButton_xuatbc.Name = "iconButton_xuatbc";
            this.iconButton_xuatbc.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton_xuatbc.Rotation = 0D;
            this.iconButton_xuatbc.Size = new System.Drawing.Size(176, 39);
            this.iconButton_xuatbc.TabIndex = 55;
            this.iconButton_xuatbc.Text = "      Xuất Excel";
            this.iconButton_xuatbc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_xuatbc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton_xuatbc.UseVisualStyleBackColor = false;
            this.iconButton_xuatbc.Click += new System.EventHandler(this.IconButton_xuatbc_Click);
            // 
            // iconButton_themNN
            // 
            this.iconButton_themNN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconButton_themNN.BackColor = System.Drawing.Color.SeaGreen;
            this.iconButton_themNN.FlatAppearance.BorderSize = 0;
            this.iconButton_themNN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton_themNN.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton_themNN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton_themNN.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconButton_themNN.IconChar = FontAwesome.Sharp.IconChar.PlusCircle;
            this.iconButton_themNN.IconColor = System.Drawing.Color.Gainsboro;
            this.iconButton_themNN.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton_themNN.IconSize = 25;
            this.iconButton_themNN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_themNN.Location = new System.Drawing.Point(785, 26);
            this.iconButton_themNN.Name = "iconButton_themNN";
            this.iconButton_themNN.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconButton_themNN.Rotation = 0D;
            this.iconButton_themNN.Size = new System.Drawing.Size(233, 40);
            this.iconButton_themNN.TabIndex = 56;
            this.iconButton_themNN.Text = "      Tra cứu năm";
            this.iconButton_themNN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton_themNN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton_themNN.UseVisualStyleBackColor = false;
            this.iconButton_themNN.Click += new System.EventHandler(this.IconButton_themNN_Click);
            // 
            // label_tong
            // 
            this.label_tong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_tong.AutoSize = true;
            this.label_tong.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tong.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_tong.Location = new System.Drawing.Point(428, 616);
            this.label_tong.Name = "label_tong";
            this.label_tong.Size = new System.Drawing.Size(125, 25);
            this.label_tong.TabIndex = 57;
            this.label_tong.Text = "Tổng (VNĐ):";
            // 
            // label_giatritong
            // 
            this.label_giatritong.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_giatritong.AutoSize = true;
            this.label_giatritong.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_giatritong.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label_giatritong.Location = new System.Drawing.Point(567, 616);
            this.label_giatritong.Name = "label_giatritong";
            this.label_giatritong.Size = new System.Drawing.Size(0, 25);
            this.label_giatritong.TabIndex = 79;
            this.label_giatritong.TextChanged += new System.EventHandler(this.Label_giatritong_TextChanged);
            // 
            // Baocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(1054, 735);
            this.Controls.Add(this.label_giatritong);
            this.Controls.Add(this.label_tong);
            this.Controls.Add(this.iconButton_themNN);
            this.Controls.Add(this.iconButton_xuatbc);
            this.Controls.Add(this.iconButton_filepath);
            this.Controls.Add(this.iconButton_themTT);
            this.Controls.Add(this.gunaNumeric_nam);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_mact);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.bunifuDropdown_thang);
            this.Controls.Add(this.advancedDataGridView_baocao);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Baocao";
            this.Text = "Baocao";
            ((System.ComponentModel.ISupportInitialize)(this.advancedDataGridView_baocao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuyentauDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tuyentauDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView_baocao;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.BindingSource tuyentauDataSetBindingSource;
        private TuyentauDataSet tuyentauDataSet;
        private Bunifu.Framework.UI.BunifuDropdown bunifuDropdown_thang;
        private System.Windows.Forms.Label label_mact;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaNumeric gunaNumeric_nam;
        private FontAwesome.Sharp.IconButton iconButton_themTT;
        private FontAwesome.Sharp.IconButton iconButton_filepath;
        private FontAwesome.Sharp.IconButton iconButton_xuatbc;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_filepath;
        private FontAwesome.Sharp.IconButton iconButton_themNN;
        private System.Windows.Forms.Label label_tong;
        private System.Windows.Forms.Label label_giatritong;
    }
}