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


    public partial class FrmMixMatch : Form
    {

        string sql = "";

        public FrmMixMatch()
        {
            InitializeComponent();
        }
        private void FrmMatch_Load(object sender, EventArgs e)
        {
            bind_data();
        }
        private void btn_load_match_Click(object sender, EventArgs e)
        {
            bind_data();
        }
        private void btn_1_min_1_wdl_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv_match.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {

                    string id = row.Cells["id"].Value.ToString();
                    BsonDocument match = MixMatchHelper.get_mix_doc_from_db(id) ;

                    for (int i = 1; i <= 50; i++)
                    {
                        BsonDocument doc = MixMatchHelper.get_1_min_from_1_wdl_with_circle(match, i);

                        sb.Append("--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                        sb.Append(MixMatchHelper.get_info_from_doc(doc));
                        this.txt_compute_result.Text = sb.ToString();
                        Application.DoEvents();
                    }

                    sb.Append("--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                    this.txt_compute_result.Text = sb.ToString();
                    Application.DoEvents();

                }
            }
            this.tab.SelectTab(1);
            MessageBox.Show("bingo!!!complete!!!");
        }
        private void btn_1_min_1_spread_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv_match.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {

                    string id = row.Cells["id"].Value.ToString();
                    BsonDocument match = MixMatchHelper.get_mix_doc_from_db(id);

                    for (int i = 1; i <= 50; i++)
                    {
                        BsonDocument doc = MixMatchHelper.get_1_min_from_1_spread_with_circle(match, i);

                        sb.Append("--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                        sb.Append(MixMatchHelper.get_info_from_doc(doc));
                        this.txt_compute_result.Text = sb.ToString();
                        Application.DoEvents();
                    }

                    sb.Append("--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                    this.txt_compute_result.Text = sb.ToString();
                    Application.DoEvents();

                }
            }
            this.tab.SelectTab(1);
            MessageBox.Show("bingo!!!complete!!!");
        }
        private void btn_1_min_1_half_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv_match.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {

                    string id = row.Cells["id"].Value.ToString();
                    BsonDocument match = MixMatchHelper.get_mix_doc_from_db(id);

                    for (int i = 1; i <= 50; i++)
                    {
                        BsonDocument doc = MixMatchHelper.get_1_min_from_1_half_with_circle(match, i);

                        sb.Append("--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                        sb.Append(MixMatchHelper.get_info_from_doc(doc));
                        this.txt_compute_result.Text = sb.ToString();
                        Application.DoEvents();
                    }

                    sb.Append("--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                    this.txt_compute_result.Text = sb.ToString();
                    Application.DoEvents();

                }
            }
            this.tab.SelectTab(1);
            MessageBox.Show("bingo!!!complete!!!");
        } 
        private void btn_1_min_1_total_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv_match.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {

                    string id = row.Cells["id"].Value.ToString();
                    BsonDocument match = MixMatchHelper.get_mix_doc_from_db(id);

                    for (int i = 1; i <= 50; i++)
                    {
                        BsonDocument doc = MixMatchHelper.get_1_min_from_1_total_with_circle(match, i);

                        sb.Append("--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                        sb.Append(MixMatchHelper.get_info_from_doc(doc));
                        this.txt_compute_result.Text = sb.ToString();
                        Application.DoEvents();
                    }

                    sb.Append("--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                    this.txt_compute_result.Text = sb.ToString();
                    Application.DoEvents();

                }
            }
            this.tab.SelectTab(1);
            MessageBox.Show("bingo!!!complete!!!");
        }
        private void btn_1_min_1_point_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv_match.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {

                    string id = row.Cells["id"].Value.ToString();
                    BsonDocument match = MixMatchHelper.get_mix_doc_from_db(id);

                    for (int i = 1; i <= 50; i++)
                    {
                        BsonDocument doc = MixMatchHelper.get_1_min_from_1_point_with_circle(match, i);

                        sb.Append("--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                        sb.Append(MixMatchHelper.get_info_from_doc(doc));
                        this.txt_compute_result.Text = sb.ToString();
                        Application.DoEvents();
                    }

                    sb.Append("--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine);
                    this.txt_compute_result.Text = sb.ToString();
                    Application.DoEvents();

                }
            }
            this.tab.SelectTab(1);
            MessageBox.Show("bingo!!!complete!!!");
        }


        private void txt_compute_result_TextChanged(object sender, EventArgs e)
        {
            this.txt_compute_result.SelectionStart = this.txt_compute_result.TextLength;
            this.txt_compute_result.ScrollToCaret();
        }
        private void dgv_match_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e != null && e.RowIndex > -1 && e.RowIndex < dgv_match.Rows.Count - 1)
                {
                    if (e.RowIndex >= 0 && e.RowIndex <= dgv_match.Rows.Count - 1)
                    {
                        string id = dgv_match.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        BsonDocument doc =    MixMatchHelper.get_mix_doc_from_db(id) ;
                        this.txt_match.Text = "--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine +
                                           MixMatchHelper.get_info_from_doc(doc)+
                                           "--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine;
                    }
                }
            }
            catch (Exception error)
            {
                Log.error("cell mouse down", error);
            }

        }
        private void dgv_match_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e != null && e.RowIndex > -1 && e.RowIndex < dgv_match.Rows.Count - 1)
                {
                    if (e.RowIndex >= 0 && e.RowIndex <= dgv_match.Rows.Count - 1)
                    {
                        string id = dgv_match.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        BsonDocument doc = MixMatchHelper.get_mix_doc_from_db(id);
                        this.txt_match.Text = "--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine +
                                            MixMatchHelper.get_info_from_doc(doc)+
                                             "--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine;
                    }
                }
            }
            catch (Exception error)
            {
                Log.error("cell mouse down", error);
            }

        }
        private void dgv_match_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgv_match.Columns[0].Width = 60;
            this.dgv_match.Columns[1].Width = 60;
        }


        public void bind_data()
        {
            DataTable dt_match = new DataTable();
            DataColumn col = new DataColumn();
            col.DataType = Type.GetType("System.Boolean");
            col.ColumnName = "selected";
            col.DefaultValue = false;
            dt_match.Columns.Add(col);
            dt_match.Columns.Add("id");
            dt_match.Columns.Add("timespan");
            dt_match.Columns.Add("start_time");
            dt_match.Columns.Add("host");
            dt_match.Columns.Add("client");


            sql = " select *" +
                   " from mix_match" +
                   " where start_time>'{0}'" +
                   " order by start_time,host,client,timespan";
            sql = string.Format(sql, DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd HH:mm:ss"));

            DataTable dt = SQLServerHelper.get_table(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row_new = dt_match.NewRow();
                row_new["id"] = dt.Rows[i]["id"].ToString();
                row_new["timespan"] = dt.Rows[i]["timespan"].ToString();
                row_new["start_time"] = dt.Rows[i]["start_time"].ToString();
                row_new["host"] = dt.Rows[i]["host"].ToString();
                row_new["client"] = dt.Rows[i]["client"].ToString();
                dt_match.Rows.Add(row_new);
            }
            this.dgv_match.DataSource = dt_match;
        }

  

    



 


    }


}
