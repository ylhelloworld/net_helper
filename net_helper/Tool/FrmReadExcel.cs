using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace WinCode
{
    public partial class FrmReadExcel : Form
    {
        public FrmReadExcel()
        {
            InitializeComponent();
        }
        SqlDbHelper helper = new SqlDbHelper("Password=tc_q210_file;Persist Security Info=True;User ID=mis;Initial Catalog=MIS;Data Source=192.168.1.221");
        StringBuilder builder = new StringBuilder();
        private void btn_read_Click(object sender, EventArgs e)
        {
            this.dgv_result.DataSource = ExcelToDataTable(@"C:/data.xls");
        }    
        /// <summary>
        /// 导入鞋柜类别
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_import_class_Click(object sender, EventArgs e)
        { 
            DataTable table =(DataTable)dgv_result.DataSource; 
            foreach (DataRow row in table.Rows)
            {
                string gaf002002 = row[0].ToString();
                string gaf002003 = row[1].ToString() ;
                string sql = string.Format("insert into gaf002 (gaf002002,gaf002003) values('{0}','{1}');", gaf002002, gaf002003);
                //helper.ExecuteNonQuery(sql);
                this.txt_sql.Text = this.txt_sql.Text + Environment.NewLine + sql;
            } 
        }
        /// <summary>
        /// 导入鞋柜柜号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_import_box_no_Click(object sender, EventArgs e)
        {  
            DataTable table = (DataTable)dgv_result.DataSource;
      
            foreach (DataRow row in table.Rows)
            {
                string gaf003002 = row[0].ToString().ToUpper();
                string gaf003003 = row[2].ToString().ToUpper();
                string user_no = row[3].ToString().ToUpper();
                string is_user = "";
                if (string.IsNullOrEmpty(user_no) == true)
                {
                    is_user = "0";
                }
                else
                {
                    is_user = "1";
                }
                string sql = string.Format("insert into gaf003 (gaf003002,gaf003003,gaf003005) values('{0}','{1}',{2});", gaf003002, gaf003003, is_user);
                helper.ExecuteNonQuery(sql);
                builder.Append(Environment.NewLine + sql);
                this.txt_sql.Text = builder.ToString() ;
                Application.DoEvents();
            } 
        }
        /// <summary>
        /// 导入员工工号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_import_employee_Click(object sender, EventArgs e)
        { 

            DataTable table = (DataTable)dgv_result.DataSource;
         
            foreach (DataRow row in table.Rows)
            {
                string gaf004002 = row[3].ToString().ToUpper();
                string gaf004003 = row[4].ToString().ToUpper();
                string gaf004004 = row[2].ToString().ToUpper();
                string gaf004007 = row[0].ToString().ToUpper();
                if (String.IsNullOrEmpty(gaf004002) == false)
                {
                    DateTime gaf004008 = DateTime.Now;
                    string sql = string.Format("insert into gaf004 (gaf004002,gaf004003,gaf004004,gaf004005,gaf004007,gaf004008) values ('{0}','{1}','{2}',{3},'{4}','{5}');", gaf004002, gaf004003, gaf004004, "1", gaf004007, gaf004008.ToString());
                    helper.ExecuteNonQuery(sql);
                    builder.Append(Environment.NewLine + sql);
                    this.txt_sql.Text = builder.ToString();
                    Application.DoEvents();

                }
            }
        }
        /// <summary>
        /// 读取时，SQL字符串自动滚动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_sql_TextChanged(object sender, EventArgs e)
        {
            this.txt_sql.SelectionStart = this.txt_sql.TextLength;
            this.txt_sql.ScrollToCaret();
        }
        
        /// <summary>
        /// 读取Excel电子档
        /// </summary>
        /// <param name="filename">Excel文件路径</param>
        /// <returns>DataTable</returns>
        public DataTable ExcelToDataTable(string filename)
        {
            DataSet ds;
            string strCon = "Provider=Microsoft.Jet.OLEDB.4.0;" +
                            "Extended Properties=Excel 8.0;" +
                            "data source=" + filename;
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = " SELECT * FROM [Sheet1$]";
            myConn.Open();
            OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);
            ds = new DataSet();
            myCommand.Fill(ds);
            myConn.Close();
            return ds.Tables[0];
        }

        private void btn_write_Click(object sender, EventArgs e)
        { 
            //测试FileStream在内存中分配的最大空间

            //this.txt_sql.Text = "";
            //FileStream stream = File.Open(@"c:/test1.txt", FileMode.Open);
            //StreamWriter writer = new StreamWriter(stream);
            //StringBuilder builer = new StringBuilder();
            //builer.Append("insert into gaf004 (gaf004002,gaf004003,gaf004004,gaf004005,gaf004007,gaf004008) values ");  
            //try
            //{
            //    for (int i = 1; i < float.MaxValue; i++)
            //    {
            //        writer.Write("insert into gaf004 (gaf004002,gaf004003,gaf004004,gaf004005,gaf004007,gaf004008)");
            //    }
            //}
            //catch (Exception error)
            //{
            //    writer.Close();
            //    MessageBox.Show(error.Message);
            //    return;
            //}
            //writer.Close();  
        } 
    }
}
    