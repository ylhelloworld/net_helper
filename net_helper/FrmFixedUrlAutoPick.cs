using System;
using System.Collections;
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
using MongoDB.Driver.Builders;
using MongoDB.Bson.Serialization;

namespace WinCode
{
    public partial class FrmFixedUrlAutoPick : Form
    {
        public FrmFixedUrlAutoPick()
        {
            InitializeComponent();
        }
        private void FrmFixedUrlAutoPick_Load(object sender, EventArgs e)
        {
            bind_data("");
        }
        private void btn_find_Click(object sender, EventArgs e)
        {
            bind_data(this.txt_condition.Text);
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
            pick_data();
        } 

        private void btn_start_Click(object sender, EventArgs e)
        { 
                int interval = (int)num_interval.Value;
                this.timer.Enabled = true;
                this.timer.Interval = interval;
                this.timer.Start(); 
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.timer.Enabled = false;
            this.timer.Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        { 
            Thread thread = new Thread(new ThreadStart(pick_data_random)); 
            thread.Start();
        }

        public void pick_data()
        {
            foreach (DataGridViewRow row in dgv_find_result.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true && String.IsNullOrEmpty(row.Cells["id"].Value.ToString()) == false)
                {
                    string template_id = row.Cells["template_id"].Value.ToString();
                    ArrayList list = UrlSelectHelper.get_fixed_urls(row.Cells["id"].Value.ToString());
                    foreach (string item in list)
                    {
                        this.txt_pick_result.Text += item + Environment.NewLine; 
                        string doc_id=TemplateHelper_Match.save_html_to_db(item, template_id);
                        select_new_data_to_sqlserver(doc_id);
                    }
                }
            }
        }
        public void pick_data_random()
        {
            //加入随机时间，进行混淆 
            Random random = new Random();
            Thread.Sleep(random.Next( 2000)); 

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
        }
        public void select_new_data_to_sqlserver(string doc_id)
        {
            QueryDocument doc_query = new QueryDocument();
            doc_query.Add("doc_id", doc_id);
            BsonDocument doc = MongoHelper.query_bson_from_bson(doc_query);


        } 
 
    }
}
