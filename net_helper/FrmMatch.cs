using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Driver;


namespace WinCode
{
    public partial class FrmMatch : Form
    {

        string sql = "";
        public FrmMatch()
        {
            InitializeComponent();
        }
        private void FrmMatch_Load(object sender, EventArgs e)
        {
            bind_data();
        }
        private void txt_compute_result_TextChanged(object sender, EventArgs e)
        {
            this.txt_compute_result.SelectionStart = this.txt_compute_result.TextLength;
            this.txt_compute_result.ScrollToCaret();
        } 
        public void bind_data()
        {
           
            DataTable dt_match = new DataTable(); 
            DataColumn col = new DataColumn();
            col.DataType = Type.GetType("System.Boolean");
            col.ColumnName = "selected";
            col.DefaultValue = false;
            dt_match.Columns.Add(col);
            dt_match.Columns.Add("start_time");
            dt_match.Columns.Add("host");
            dt_match.Columns.Add("client");  


            sql = " select *" +
                   " from win" +
                   " where start_time>'{0}'" +
                   " order by start_time,host,client,timespan";
            sql = string.Format(sql, DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd HH:mm:ss")); 
            DataTable dt = SQLServerHelper.get_table(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row_new = dt_match.NewRow();
                row_new["start_time"] = dt.Rows[i]["start_time"].ToString();
                row_new["host"] = dt.Rows[i]["host"].ToString();
                row_new["client"] = dt.Rows[i]["client"].ToString();
                dt_match.Rows.Add(row_new); 
            }
            this.dgv_match.DataSource = dt_match;
        }

    

    }
}
