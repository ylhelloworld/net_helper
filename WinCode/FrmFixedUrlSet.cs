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
    public partial class FrmFixedUrlSet : Form
    {
        public FrmFixedUrlSet()
        {
            InitializeComponent();
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            bind_data(this.txt_condition.Text);
        }

        
        private void FrmUrlFixed_Load(object sender, EventArgs e)
        {
            bind_data("");
        }

        public void bind_data(string condition)
        {
             
            if (string.IsNullOrEmpty(condition)) 
            {
                condition = "%";
            }
            else
            {
                condition="%"+condition +"%";
            } 

            string sql="select * from url_fixed where url like '{0}' or remark like '{0}'";
            sql=string.Format(sql,condition);
            DataTable dt= SQLServerHelper.get_table(sql);


            this.dgv_result.DataSource = dt; 
        }

        private void dgv_result_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            try
            { 
                this.lb_row.Text = e.RowIndex.ToString();
                this.lb_column.Text = e.ColumnIndex.ToString();
                string content = this.dgv_result.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                this.txt_cell.Text = content;
            }
            catch (Exception error)
            {
                this.lb_row.Text = "";
                this.lb_column.Text = "";
                this.txt_cell.Text = ""; 
            }
        }   
        private void dgv_result_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgv_result.Columns["id"].ReadOnly = true;  
        }
 
        private void btn_beautify_Click(object sender, EventArgs e)
        {
            this.txt_cell.Text = JsonBeautify.beautify(this.txt_cell.Text);
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            string sql = "";
            for (int i = 0; i < dgv_result.Rows.Count-1; i++)
            {
                string id = dgv_result.Rows[i].Cells["id"].Value==null? "":dgv_result.Rows[i].Cells["id"].Value.ToString();
                string url =dgv_result.Rows[i].Cells["url"].Value==null? "": dgv_result.Rows[i].Cells["url"].Value.ToString();
                string url_value =dgv_result.Rows[i].Cells["url_value"].Value==null?"": dgv_result.Rows[i].Cells["url_value"].Value.ToString();
                string remark = dgv_result.Rows[i].Cells["remark"].Value==null? "":dgv_result.Rows[i].Cells["remark"].Value.ToString();
                string type =dgv_result.Rows[i].Cells["type"].Value==null?"": dgv_result.Rows[i].Cells["type"].Value.ToString();
                string template_id =dgv_result.Rows[i].Cells["template_id"].Value==null?"": dgv_result.Rows[i].Cells["template_id"].Value.ToString();
                if (string.IsNullOrEmpty((id + url + url_value + remark + type + template_id).Trim())) continue;
                url=SQLServerHelper.format_sql_str(url);
                url_value=SQLServerHelper.format_sql_str(url_value);
                remark=SQLServerHelper.format_sql_str(remark);
                string create_time = DateTime.Now.ToString();
                string update_time = DateTime.Now.ToString();

                if (string.IsNullOrEmpty(type))
                {
                    type = "P0";
                }

                if (string.IsNullOrEmpty(id))
                {
                    sql = "insert into url_fixed (url,url_value,remark,type,create_time,template_id) values ('{0}','{1}','{2}','{3}','{4}','{5}')";
                    sql = string.Format(sql, url, url_value, remark, type, create_time,template_id);
                }
                else
                {
                    sql = "update url_fixed set url='{0}',url_value='{1}',remark='{2}',type='{3}',update_time='{4}',template_id='{5}' where id={6}";
                    sql = string.Format(sql, url, url_value, remark, type, update_time,template_id, id);
                }
                SQLServerHelper.exe_sql(sql); 
            }
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            string msg = MongoHelper.check_is_doc_str(this.txt_cell.Text);
            if (msg == "right")
            {
                MessageBox.Show(" Bingo! Right JSON String!");
            }
            else
            {
                MessageBox.Show(msg);
            }
        }

        private void txt_cell_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.lb_column.Text) || string.IsNullOrEmpty(this.lb_row.Text)||this.dgv_result.Rows.Count==0) return;
            this.dgv_result.Rows[Int16.Parse(this.lb_row.Text)].Cells[Int16.Parse(this.lb_column.Text)].Value = this.txt_cell.Text;
        }

        
    }
}
