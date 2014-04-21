using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinCode
{
    public partial class FrmDocFind : Form
    {

        public FrmMain frm_main;
        public FrmDocFind()
        {
            InitializeComponent();
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            bind_data(this.txt_condition.Text);
        }

        public void bind_data(string condition)
        {

            if (string.IsNullOrEmpty(condition))
            {
                condition = "%";
            }
            else
            {
                condition = "%" + condition + "%";
            }

            string sql = "select * from data where doc_id like '{0}' or  description  like '{0}' ";
            sql = string.Format(sql, condition);
            DataTable dt = SQLServerHelper.get_table(sql);


            this.dgv_result.DataSource = dt;
        } 
        private void dgv_result_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e != null && e.RowIndex > -1 && e.RowIndex < dgv_result.Rows.Count - 1)
            {
                string doc_id = this.dgv_result.Rows[e.RowIndex].Cells["doc_id"].Value.ToString();
                frm_main.open_frm_doc_find_view(doc_id);
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.dgv_result.Rows.Count - 1; i++)
            {
                string id = this.dgv_result.Rows[i].Cells["id"].Value.ToString();
                string type = this.dgv_result.Rows[i].Cells["type"].Value.ToString();
                string doc_id = this.dgv_result.Rows[i].Cells["doc_id"].Value.ToString();
                string description=this.dgv_result.Rows[i].Cells["description"].Value.ToString();

                string tag0= SQLServerHelper.format_sql_str(this.dgv_result.Rows[i].Cells["tag0"].Value.ToString());
                string tag1 = SQLServerHelper.format_sql_str(this.dgv_result.Rows[i].Cells["tag1"].Value.ToString());
                string tag2 = SQLServerHelper.format_sql_str(this.dgv_result.Rows[i].Cells["tag2"].Value.ToString());
                string tag3 = SQLServerHelper.format_sql_str(this.dgv_result.Rows[i].Cells["tag3"].Value.ToString());
                string tag4 = SQLServerHelper.format_sql_str(this.dgv_result.Rows[i].Cells["tag4"].Value.ToString()); 
                string update_time = DateTime.Now.ToString(); 

               string sql = " update data set type='{0}',doc_id='{1}',description='{2}',tag0='{3}',tag1='{4}', tag2='{5}', tag3='{6}', tag4='{7}',update_time='{8}'"+
                          " where id={9}";


               sql = string.Format(sql,type,doc_id,description,tag0,tag1,tag2,tag3,tag4,update_time,id);
                
                SQLServerHelper.exe_sql(sql);
            }
        }

    }
}
