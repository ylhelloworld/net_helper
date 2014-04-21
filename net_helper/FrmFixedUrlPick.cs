using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinCode
{
    public partial class FrmFixedUrlPick : Form
    {
        public FrmFixedUrlPick()
        {
            InitializeComponent();
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            bind_data(this.txt_condition.Text);
        }

        private void FrmFixedUrlPick_Load(object sender, EventArgs e)
        {
            bind_data("");
        }

        private void txt_pick_result_TextChanged(object sender, EventArgs e)
        {
            this.txt_pick_result.SelectionStart = this.txt_pick_result.TextLength;
            this.txt_pick_result.ScrollToCaret();
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

            string sql = "select * from url_fixed where template_id like '{0}' or url like '{0}' or remark like '{0}'";
            sql = string.Format(sql, condition);
            DataTable dt = SQLServerHelper.get_table(sql);

            DataColumn col = new DataColumn();
            col.DataType = Type.GetType("System.Boolean");
            col.ColumnName = "selected";
            col.DefaultValue = false; 
            dt.Columns.Add(col);
            dt.Columns["selected"].SetOrdinal(0);

            this.dgv_find_result.DataSource = dt;
        }

        private void btn_pick_Click(object sender, EventArgs e)
        {
            //try
            //{
                foreach (DataGridViewRow row in dgv_find_result.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["selected"].Value) == true && String.IsNullOrEmpty(row.Cells["id"].Value.ToString()) == false)
                    {
                        string template_id = row.Cells["template_id"].Value.ToString();
                        ArrayList list = UrlSelectHelper.get_fixed_urls(row.Cells["id"].Value.ToString());
                        foreach (string item in list)
                        {
                            this.txt_pick_result.Text += item + Environment.NewLine;
                            TemplateHelper.save_html_to_db(item, template_id);
                        }
                    } 
                }
            //}
            //catch (Exception error)
            //{
            //    Log.error("pick_error", error);
            //}
        }

  


 
    }
}
