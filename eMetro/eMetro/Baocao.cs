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

        public void Alert(string msg, Notification.Alert.enmType type)
        {
            Notification.Alert frm = new Notification.Alert();
            frm.showAlert(msg, type);
        }

        private void IconButton_themTT_Click(object sender, EventArgs e)
        {
          
            this.tuyentauDataSetBindingSource.DataSource = bllVE.GetBaoCao(Int32.Parse(bunifuDropdown_thang.selectedValue), Int32.Parse(gunaNumeric_nam.Value.ToString()));
            this.advancedDataGridView_baocao.DataSource = this.tuyentauDataSetBindingSource;
            label_giatritong.Text = (String)bllVE.GetDoanhSo(Int32.Parse(bunifuDropdown_thang.selectedValue), Int32.Parse(gunaNumeric_nam.Value.ToString())).Rows[0][0].ToString();
            
        }

        private void IconButton_themNN_Click(object sender, EventArgs e)
        {
            this.tuyentauDataSetBindingSource.DataSource = bllVE.GetDoanhSoNam(Int32.Parse(gunaNumeric_nam.Value.ToString()));
            this.advancedDataGridView_baocao.DataSource = this.tuyentauDataSetBindingSource;
            label_giatritong.Text = (String)bllVE.GetTongDoanhSoNam( Int32.Parse(gunaNumeric_nam.Value.ToString())).Rows[0][0].ToString();
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
                    if (dt.Rows.Count > 13)
                    {
                        wb.Worksheet(1).Cell(33, 1).InsertTable(bllVE.GetDoanhSo(Int32.Parse(bunifuDropdown_thang.selectedValue), Int32.Parse(gunaNumeric_nam.Value.ToString())));
                    }
                    else
                    {
                        wb.Worksheet(1).Cell(15, 1).InsertTable(bllVE.GetTongDoanhSoNam(Int32.Parse(gunaNumeric_nam.Value.ToString())));
                    }
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

        public static DataTable MergeTables(DataTable baseTable, params DataTable[] additionalTables)
        {
            // Build combined table columns
            DataTable merged = baseTable;
            foreach (DataTable dt in additionalTables)
            {
                merged = AddTable(merged, dt);
            }
            return merged;
        }
        /// <summary>
        /// Merge two tables into a single table with more columns.
        /// </summary>
        /// <param name="baseTable"></param>
        /// <param name="additionalTable"></param>
        /// <returns></returns>
        public static DataTable AddTable(DataTable baseTable, DataTable additionalTable)
        {
            // Build combined table columns
            DataTable merged = baseTable.Clone();                  // Include all columns from base table in result.
            foreach (DataColumn col in additionalTable.Columns)
            {
                string newColumnName = col.ColumnName;
                merged.Columns.Add(newColumnName, col.DataType);
            }
            // Add all rows from both tables
            var bt = baseTable.AsEnumerable();
            var at = additionalTable.AsEnumerable();
            var mergedRows = bt.Zip(at, (r1, r2) => r1.ItemArray.Concat(r2.ItemArray).ToArray());
            foreach (object[] rowFields in mergedRows)
            {
                merged.Rows.Add(rowFields);
            }
            return merged;
        }
        public DataTable CombineTwoDataTables(DataTable dt1, DataTable dt2)
        {
            //dt3 is the combined dt1 and dt2
            //add all rows of dt2 to dt3 then add only rows of dt1 that don't match
            DataTable dt3 = dt2.Copy();
            Boolean addrow = false;
            Boolean rowMatched = false;
            //check for for rows in dt1 not matching dt2
            for (int i = dt1.Rows.Count - 1; i >= 0; i--)
            {
                addrow = true;
                //compare every row in dt2 with row i in dt1
                for (int j = dt2.Rows.Count - 1; j >= 0; j--)
                {
                    rowMatched = true;
                    for (int k = dt1.Columns.Count - 1; k >= 0; k--)
                    {
                        if (dt1.Columns[k].ToString() != dt2.Columns[k].ToString())
                        {
                            rowMatched = false;
                            break;
                        }
                    }
                    if (rowMatched == true)
                    {
                        //don't add dt1 row if it already exists in dt2
                        addrow = false;
                        break;
                    }
                }
                if (addrow == true)
                {
                    dt3.Rows.Add(dt1.Rows[i].ItemArray);
                }
            }
            return dt3;
        }

       

        private void Label_giatritong_TextChanged(object sender, EventArgs e)
        {
            if (label_giatritong.Text == "")
                return;
            string text = label_giatritong.Text.Replace(",", "");
            decimal value = Convert.ToDecimal(text);
            label_giatritong.Text = string.Format("{0:0,0}", value);
        }
    }
}
