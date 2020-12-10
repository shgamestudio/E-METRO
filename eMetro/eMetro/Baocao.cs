using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eMetro
{
    public partial class Baocao : Form
    {
        BLL.TuyentauBLL bllTT;
        BLL.VeBLL bllVE;
        public Baocao()
        {
            InitializeComponent();
            bllTT = new BLL.TuyentauBLL();
            bllVE = new BLL.VeBLL();

        }

        private void Baocao_Load(object sender, EventArgs e)
        {
           
        }

        public void Alert(string msg, Notification.Alert.enmType type)
        {
            Notification.Alert frm = new Notification.Alert();
            frm.showAlert(msg, type);
        }

        private void IconButton_themTT_Click(object sender, EventArgs e)
        {
          
            this.tuyentauDataSetBindingSource.DataSource = bllVE.GetBaoCao(Int32.Parse(bunifuDropdown_thang.selectedValue), Int32.Parse(gunaNumeric_nam.Value.ToString()));
            this.advancedDataGridView_baocao.DataSource = this.tuyentauDataSetBindingSource;
        }

        private void IconButton_xuatbc_Click(object sender, EventArgs e)
        {
            if (textBox_path.Text != "" && advancedDataGridView_baocao.RowCount != 0)
            {
                //creating data table
                DataTable dt = new DataTable();
                //adding the columns
                foreach (DataGridViewColumn column in advancedDataGridView_baocao.Columns)
                {
                    dt.Columns.Add(column.HeaderText, column.ValueType);
                }
                //adding the rows
                foreach (DataGridViewRow row in advancedDataGridView_baocao.Rows)
                {
                    dt.Rows.Add();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dt.Rows[dt.Rows.Count - 1][cell.ColumnIndex] = cell.Value.ToString();
                    }

                    //DataRow dr = dt.NewRow();

                    //dr[0] = "Tổng doanh thu tháng "+ Int32.Parse(bunifuDropdown_thang.selectedValue)+" ";
                    //dr[1] = ;
                    
                }
                //exporting to excel
                string folderpath = textBox_path.Text;
                if (!Directory.Exists(folderpath))
                {
                    Directory.CreateDirectory(folderpath);
                }
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Report");
                    string excelfilename = "_Bao_Cao_Doanh_Thu.xlsx";
                    string destfilename = DateTime.Now.ToString("dd-mm-yyyy", CultureInfo.InvariantCulture) + excelfilename;
                    string pathexp = textBox_path.Text;
                    destfilename = Path.Combine(pathexp, destfilename);
                    wb.SaveAs(destfilename);
                    this.Alert("Xuất file báo cáo thành công", Notification.Alert.enmType.Success);
                }
            }
            else
            {
                if (advancedDataGridView_baocao.RowCount == 0)
                {
                    this.Alert("Chưa tra cứu báo cáo", Notification.Alert.enmType.Error);
                }
                if (textBox_path.Text=="")
                {
                    this.Alert("Chưa chọn đường dẫn", Notification.Alert.enmType.Error);
                }
            }
        }

      
        private void IconButton_filepath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog_filepath.ShowDialog() == DialogResult.OK)
            {
                textBox_path.Text = folderBrowserDialog_filepath.SelectedPath.ToString();
            }
        }
    }
}
