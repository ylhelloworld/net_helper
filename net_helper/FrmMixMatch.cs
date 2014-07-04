using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using MongoDB.Bson;
using MongoDB.Driver;


namespace WinCode
{


    public partial class FrmMixMatch : Form
    {

        string sql = "";
        string id = "";
        BsonDocument match1;
        BsonDocument match2;

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
                    BsonDocument match = MixMatchHelper.get_mix_doc_from_db(id);

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

        }
        private void btn_1_min_1_free_Click(object sender, EventArgs e)
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
                        double[] profits = get_profits_from_select();
                        if (profits.Length == 0) return;
                        BsonDocument doc = MixMatchHelper.get_1_min_from_1_free_with_circle(match, profits, i);

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
        }


        private void btn_2_min_2_wld_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv_match.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {

                    string id = row.Cells["id"].Value.ToString();
                    list.Add(id);
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    BsonDocument match1 = MixMatchHelper.get_mix_doc_from_db(list[i].ToString());
                    BsonDocument match2 = MixMatchHelper.get_mix_doc_from_db(list[j].ToString());
                    for (int k = 1; k <= 50; k++)
                    {
                        BsonDocument doc = MixMatchHelper.get_2_min_from_2_wld_with_circle(match1, match2, k);
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
        }
        private void btn_2_min_2_spread_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv_match.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {

                    string id = row.Cells["id"].Value.ToString();
                    list.Add(id);
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    BsonDocument match1 = MixMatchHelper.get_mix_doc_from_db(list[i].ToString());
                    BsonDocument match2 = MixMatchHelper.get_mix_doc_from_db(list[j].ToString());
                    for (int k = 1; k <= 50; k++)
                    {
                        BsonDocument doc = MixMatchHelper.get_2_min_from_2_spread_with_circle(match1, match2, k);
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
        }
        private void btn_2_min_2_half_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv_match.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {

                    string id = row.Cells["id"].Value.ToString();
                    list.Add(id);
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    BsonDocument match1 = MixMatchHelper.get_mix_doc_from_db(list[i].ToString());
                    BsonDocument match2 = MixMatchHelper.get_mix_doc_from_db(list[j].ToString());
                    for (int k = 1; k <= 50; k++)
                    {
                        BsonDocument doc = MixMatchHelper.get_2_min_from_2_half_with_circle(match1, match2, k);
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
        }
        private void btn_min_2_total_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv_match.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {

                    string id = row.Cells["id"].Value.ToString();
                    list.Add(id);
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    BsonDocument match1 = MixMatchHelper.get_mix_doc_from_db(list[i].ToString());
                    BsonDocument match2 = MixMatchHelper.get_mix_doc_from_db(list[j].ToString());
                    for (int k = 1; k <= 50; k++)
                    {
                        BsonDocument doc = MixMatchHelper.get_2_min_from_2_total_with_circle(match1, match2, k);
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
        }
        private void btn_2_min_2_point_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in dgv_match.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {

                    string id = row.Cells["id"].Value.ToString();
                    list.Add(id);
                }
            }

            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    BsonDocument match1 = MixMatchHelper.get_mix_doc_from_db(list[i].ToString());
                    BsonDocument match2 = MixMatchHelper.get_mix_doc_from_db(list[j].ToString());
                    for (int k = 1; k <= 50; k++)
                    {
                        BsonDocument doc = MixMatchHelper.get_2_min_from_2_point_with_circle(match1, match2, k);
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
        }
        private void btn_2_min_2_free_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            if (match1 != null && match2 != null)
            { 
                for (int k = 1; k <= 50; k++)
                {
                    BsonDocument doc = MixMatchHelper.get_2_min_from_2_free_with_circle(match1, match2, k);
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

        private void btn_select_one_Click(object sender, EventArgs e)
        {
            BsonDocument doc = MixMatchHelper.get_mix_doc_from_db(id);
            match1 = new BsonDocument();
            match1.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
            match1.Add("type", "select-one");
            match1.Add("start_time", doc["start_time"].ToString());
            match1.Add("host", doc["host"].ToString());
            match1.Add("client", doc["client"].ToString());

            if (this.cb_wdl_w.Checked) match1.Add("wdl_w", this.cb_wdl_w.Text);
            if (this.cb_wdl_d.Checked) match1.Add("wdl_d", this.cb_wdl_d.Text);
            if (this.cb_wdl_l.Checked) match1.Add("wdl_l", this.cb_wdl_l.Text);
            if (this.cb_spread_w.Checked) match1.Add("spread_w", this.cb_spread_w.Text);
            if (this.cb_spread_d.Checked) match1.Add("spread_d", this.cb_spread_d.Text);
            if (this.cb_spread_l.Checked) match1.Add("spread_l", this.cb_spread_l.Text);

            if (this.cb_half_ww.Checked) match1.Add("half_ww", this.cb_half_ww.Text);
            if (this.cb_half_wd.Checked) match1.Add("half_wd", this.cb_half_wd.Text);
            if (this.cb_half_wl.Checked) match1.Add("half_wl", this.cb_half_wl.Text);
            if (this.cb_half_dw.Checked) match1.Add("half_dw", this.cb_half_dw.Text);
            if (this.cb_half_dd.Checked) match1.Add("half_dd", this.cb_half_dd.Text);
            if (this.cb_half_dl.Checked) match1.Add("half_dl", this.cb_half_dl.Text);
            if (this.cb_half_lw.Checked) match1.Add("half_lw", this.cb_half_lw.Text);
            if (this.cb_half_ld.Checked) match1.Add("half_ld", this.cb_half_ld.Text);
            if (this.cb_half_ll.Checked) match1.Add("half_ll", this.cb_half_ll.Text);

            if (this.cb_point_w_1_0.Checked) match1.Add("point_w_1_0", this.cb_point_w_1_0.Text);
            if (this.cb_point_w_2_0.Checked) match1.Add("point_w_2_0", this.cb_point_w_2_0.Text);
            if (this.cb_point_w_2_1.Checked) match1.Add("point_w_2_1", this.cb_point_w_2_1.Text);
            if (this.cb_point_w_3_0.Checked) match1.Add("point_w_3_0", this.cb_point_w_3_0.Text);
            if (this.cb_point_w_3_1.Checked) match1.Add("point_w_3_1", this.cb_point_w_3_1.Text);
            if (this.cb_point_w_3_2.Checked) match1.Add("point_w_3_2", this.cb_point_w_3_2.Text);
            if (this.cb_point_w_4_0.Checked) match1.Add("point_w_4_0", this.cb_point_w_4_0.Text);
            if (this.cb_point_w_4_1.Checked) match1.Add("point_w_4_1", this.cb_point_w_4_1.Text);
            if (this.cb_point_w_4_2.Checked) match1.Add("point_w_4_2", this.cb_point_w_4_2.Text);
            if (this.cb_point_w_5_0.Checked) match1.Add("point_w_5_0", this.cb_point_w_5_0.Text);
            if (this.cb_point_w_5_1.Checked) match1.Add("point_w_5_1", this.cb_point_w_5_1.Text);
            if (this.cb_point_w_5_2.Checked) match1.Add("point_w_5_2", this.cb_point_w_5_2.Text);
            if (this.cb_point_w_other.Checked) match1.Add("point_w_other", this.cb_point_w_other.Text);
            if (this.cb_point_d_0_0.Checked) match1.Add("point_d_0_0", this.cb_point_d_0_0.Text);
            if (this.cb_point_d_1_1.Checked) match1.Add("point_d_1_1", this.cb_point_d_1_1.Text);
            if (this.cb_point_d_2_2.Checked) match1.Add("point_d_2_2", this.cb_point_d_2_2.Text);
            if (this.cb_point_d_3_3.Checked) match1.Add("point_d_3_3", this.cb_point_d_3_3.Text);
            if (this.cb_point_d_other.Checked) match1.Add("point_d_other", this.cb_point_d_other.Text);
            if (this.cb_point_l_0_1.Checked) match1.Add("point_l_0_1", this.cb_point_l_0_1.Text);
            if (this.cb_point_l_0_2.Checked) match1.Add("point_l_0_2", this.cb_point_l_0_2.Text);
            if (this.cb_point_l_1_2.Checked) match1.Add("point_l_1_2", this.cb_point_l_1_2.Text);
            if (this.cb_point_l_0_3.Checked) match1.Add("point_l_0_3", this.cb_point_l_0_3.Text);
            if (this.cb_point_l_1_3.Checked) match1.Add("point_l_1_3", this.cb_point_l_1_3.Text);
            if (this.cb_point_l_2_3.Checked) match1.Add("point_l_2_3", this.cb_point_l_2_3.Text);
            if (this.cb_point_l_0_4.Checked) match1.Add("point_l_0_4", this.cb_point_l_0_4.Text);
            if (this.cb_point_l_1_4.Checked) match1.Add("point_l_1_4", this.cb_point_l_1_4.Text);
            if (this.cb_point_l_2_4.Checked) match1.Add("point_l_2_4", this.cb_point_l_2_4.Text);
            if (this.cb_point_l_0_5.Checked) match1.Add("point_l_0_5", this.cb_point_l_0_5.Text);
            if (this.cb_point_l_1_5.Checked) match1.Add("point_l_1_5", this.cb_point_l_1_5.Text);
            if (this.cb_point_l_2_5.Checked) match1.Add("point_l_2_5", this.cb_point_l_2_5.Text);
            if (this.cb_point_l_other.Checked) match1.Add("point_l_other", this.cb_point_l_other.Text);

            if (this.cb_total_0.Checked) match1.Add("total_0", this.cb_total_0.Text);
            if (this.cb_total_1.Checked) match1.Add("total_1", this.cb_total_1.Text);
            if (this.cb_total_2.Checked) match1.Add("total_2", this.cb_total_2.Text);
            if (this.cb_total_3.Checked) match1.Add("total_3", this.cb_total_3.Text);
            if (this.cb_total_4.Checked) match1.Add("total_4", this.cb_total_4.Text);
            if (this.cb_total_5.Checked) match1.Add("total_5", this.cb_total_5.Text);
            if (this.cb_total_6.Checked) match1.Add("total_6", this.cb_total_6.Text);
            if (this.cb_total_more.Checked) match1.Add("total_more", this.cb_total_more.Text);

            get_select_match_info();

        }
        private void btn_select_two_Click(object sender, EventArgs e)
        {
            BsonDocument doc = MixMatchHelper.get_mix_doc_from_db(id);
            match2 = new BsonDocument();
            match2.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
            match2.Add("type", "select-two");
            match2.Add("start_time", doc["start_time"].ToString());
            match2.Add("host", doc["host"].ToString());
            match2.Add("client", doc["client"].ToString());

            if (this.cb_wdl_w.Checked) match2.Add("wdl_w", this.cb_wdl_w.Text);
            if (this.cb_wdl_d.Checked) match2.Add("wdl_d", this.cb_wdl_d.Text);
            if (this.cb_wdl_l.Checked) match2.Add("wdl_l", this.cb_wdl_l.Text);
            if (this.cb_spread_w.Checked) match2.Add("spread_w", this.cb_spread_w.Text);
            if (this.cb_spread_d.Checked) match2.Add("spread_d", this.cb_spread_d.Text);
            if (this.cb_spread_l.Checked) match2.Add("spread_l", this.cb_spread_l.Text);

            if (this.cb_half_ww.Checked) match2.Add("half_ww", this.cb_half_ww.Text);
            if (this.cb_half_wd.Checked) match2.Add("half_wd", this.cb_half_wd.Text);
            if (this.cb_half_wl.Checked) match2.Add("half_wl", this.cb_half_wl.Text);
            if (this.cb_half_dw.Checked) match2.Add("half_dw", this.cb_half_dw.Text);
            if (this.cb_half_dd.Checked) match2.Add("half_dd", this.cb_half_dd.Text);
            if (this.cb_half_dl.Checked) match2.Add("half_dl", this.cb_half_dl.Text);
            if (this.cb_half_lw.Checked) match2.Add("half_lw", this.cb_half_lw.Text);
            if (this.cb_half_ld.Checked) match2.Add("half_ld", this.cb_half_ld.Text);
            if (this.cb_half_ll.Checked) match2.Add("half_ll", this.cb_half_ll.Text);

            if (this.cb_point_w_1_0.Checked) match2.Add("point_w_1_0", this.cb_point_w_1_0.Text);
            if (this.cb_point_w_2_0.Checked) match2.Add("point_w_2_0", this.cb_point_w_2_0.Text);
            if (this.cb_point_w_2_1.Checked) match2.Add("point_w_2_1", this.cb_point_w_2_1.Text);
            if (this.cb_point_w_3_0.Checked) match2.Add("point_w_3_0", this.cb_point_w_3_0.Text);
            if (this.cb_point_w_3_1.Checked) match2.Add("point_w_3_1", this.cb_point_w_3_1.Text);
            if (this.cb_point_w_3_2.Checked) match2.Add("point_w_3_2", this.cb_point_w_3_2.Text);
            if (this.cb_point_w_4_0.Checked) match2.Add("point_w_4_0", this.cb_point_w_4_0.Text);
            if (this.cb_point_w_4_1.Checked) match2.Add("point_w_4_1", this.cb_point_w_4_1.Text);
            if (this.cb_point_w_4_2.Checked) match2.Add("point_w_4_2", this.cb_point_w_4_2.Text);
            if (this.cb_point_w_5_0.Checked) match2.Add("point_w_5_0", this.cb_point_w_5_0.Text);
            if (this.cb_point_w_5_1.Checked) match2.Add("point_w_5_1", this.cb_point_w_5_1.Text);
            if (this.cb_point_w_5_2.Checked) match2.Add("point_w_5_2", this.cb_point_w_5_2.Text);
            if (this.cb_point_w_other.Checked) match2.Add("point_w_other", this.cb_point_w_other.Text);
            if (this.cb_point_d_0_0.Checked) match2.Add("point_d_0_0", this.cb_point_d_0_0.Text);
            if (this.cb_point_d_1_1.Checked) match2.Add("point_d_1_1", this.cb_point_d_1_1.Text);
            if (this.cb_point_d_2_2.Checked) match2.Add("point_d_2_2", this.cb_point_d_2_2.Text);
            if (this.cb_point_d_3_3.Checked) match2.Add("point_d_3_3", this.cb_point_d_3_3.Text);
            if (this.cb_point_d_other.Checked) match2.Add("point_d_other", this.cb_point_d_other.Text);
            if (this.cb_point_l_0_1.Checked) match2.Add("point_l_0_1", this.cb_point_l_0_1.Text);
            if (this.cb_point_l_0_2.Checked) match2.Add("point_l_0_2", this.cb_point_l_0_2.Text);
            if (this.cb_point_l_1_2.Checked) match2.Add("point_l_1_2", this.cb_point_l_1_2.Text);
            if (this.cb_point_l_0_3.Checked) match2.Add("point_l_0_3", this.cb_point_l_0_3.Text);
            if (this.cb_point_l_1_3.Checked) match2.Add("point_l_1_3", this.cb_point_l_1_3.Text);
            if (this.cb_point_l_2_3.Checked) match2.Add("point_l_2_3", this.cb_point_l_2_3.Text);
            if (this.cb_point_l_0_4.Checked) match2.Add("point_l_0_4", this.cb_point_l_0_4.Text);
            if (this.cb_point_l_1_4.Checked) match2.Add("point_l_1_4", this.cb_point_l_1_4.Text);
            if (this.cb_point_l_2_4.Checked) match2.Add("point_l_2_4", this.cb_point_l_2_4.Text);
            if (this.cb_point_l_0_5.Checked) match2.Add("point_l_0_5", this.cb_point_l_0_5.Text);
            if (this.cb_point_l_1_5.Checked) match2.Add("point_l_1_5", this.cb_point_l_1_5.Text);
            if (this.cb_point_l_2_5.Checked) match2.Add("point_l_2_5", this.cb_point_l_2_5.Text);
            if (this.cb_point_l_other.Checked) match2.Add("point_l_other", this.cb_point_l_other.Text);

            if (this.cb_total_0.Checked) match2.Add("total_0", this.cb_total_0.Text);
            if (this.cb_total_1.Checked) match2.Add("total_1", this.cb_total_1.Text);
            if (this.cb_total_2.Checked) match2.Add("total_2", this.cb_total_2.Text);
            if (this.cb_total_3.Checked) match2.Add("total_3", this.cb_total_3.Text);
            if (this.cb_total_4.Checked) match2.Add("total_4", this.cb_total_4.Text);
            if (this.cb_total_5.Checked) match2.Add("total_5", this.cb_total_5.Text);
            if (this.cb_total_6.Checked) match2.Add("total_6", this.cb_total_6.Text);
            if (this.cb_total_more.Checked) match2.Add("total_more", this.cb_total_more.Text);

            get_select_match_info();
        }
        private void btn_clear_one_Click(object sender, EventArgs e)
        {
            match1 = null;
            get_select_match_info();
        }
        private void btn_clear_two_Click(object sender, EventArgs e)
        {
            match2 = null;
            get_select_match_info();
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
                        id = dgv_match.Rows[e.RowIndex].Cells["id"].Value.ToString();
                        get_select_match_info();


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
            //try
            //{
            if (e != null && e.RowIndex > -1 && e.RowIndex < dgv_match.Rows.Count - 1)
            {
                if (e.RowIndex >= 0 && e.RowIndex <= dgv_match.Rows.Count - 1)
                {
                    id = dgv_match.Rows[e.RowIndex].Cells["id"].Value.ToString();
                    get_select_match_info();

                }
            }
            //}
            //catch (Exception error)
            //{
            //    Log.error("cell mouse down", error);
            //}

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
        public void get_select_match_info()
        {
            BsonDocument doc = MixMatchHelper.get_mix_doc_from_db(id);
            string result = "";
            result = "--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine +
                      MixMatchHelper.get_info_from_doc(doc) +
                      "--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine;
            if (match1 != null)
            {
                result = result +
                    MixMatchHelper.get_info_from_doc(match1) + Environment.NewLine +
                    "--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine;
            }
            if (match2 != null)
            {
                result = result +
                    MixMatchHelper.get_info_from_doc(match2) + Environment.NewLine +
                    "--------------------------------------------------------------------------------------------------------------------" + Environment.NewLine;
            }
            this.txt_match.Text = result;
            set_select(doc);
        }
        public void set_select(BsonDocument match)
        {

            this.lb_spread_count.Text = match["spread_count"].ToString();
            this.cb_wdl_w.Text = match["wdl_w"].ToString();
            this.cb_wdl_d.Text = match["wdl_d"].ToString();
            this.cb_wdl_l.Text = match["wdl_l"].ToString();
            this.cb_spread_w.Text = match["spread_w"].ToString();
            this.cb_spread_d.Text = match["spread_d"].ToString();
            this.cb_spread_l.Text = match["spread_l"].ToString();

            this.cb_half_ww.Text = match["half_w_w"].ToString();
            this.cb_half_wd.Text = match["half_w_d"].ToString();
            this.cb_half_wl.Text = match["half_w_l"].ToString();
            this.cb_half_dw.Text = match["half_d_w"].ToString();
            this.cb_half_dd.Text = match["half_d_d"].ToString();
            this.cb_half_dl.Text = match["half_d_l"].ToString();
            this.cb_half_lw.Text = match["half_l_w"].ToString();
            this.cb_half_ld.Text = match["half_l_d"].ToString();
            this.cb_half_ll.Text = match["half_l_l"].ToString();

            this.cb_point_w_1_0.Text = match["point_w_1_0"].ToString();
            this.cb_point_w_2_0.Text = match["point_w_2_0"].ToString();
            this.cb_point_w_2_1.Text = match["point_w_2_1"].ToString();
            this.cb_point_w_3_0.Text = match["point_w_3_0"].ToString();
            this.cb_point_w_3_1.Text = match["point_w_3_1"].ToString();
            this.cb_point_w_3_2.Text = match["point_w_3_2"].ToString();
            this.cb_point_w_4_0.Text = match["point_w_4_0"].ToString();
            this.cb_point_w_4_1.Text = match["point_w_4_1"].ToString();
            this.cb_point_w_4_2.Text = match["point_w_4_2"].ToString();
            this.cb_point_w_5_0.Text = match["point_w_5_0"].ToString();
            this.cb_point_w_5_1.Text = match["point_w_5_1"].ToString();
            this.cb_point_w_5_2.Text = match["point_w_5_2"].ToString();
            this.cb_point_w_other.Text = match["point_w_other"].ToString();
            this.cb_point_d_0_0.Text = match["point_d_0_0"].ToString();
            this.cb_point_d_1_1.Text = match["point_d_1_1"].ToString();
            this.cb_point_d_2_2.Text = match["point_d_2_2"].ToString();
            this.cb_point_d_3_3.Text = match["point_d_3_3"].ToString();
            this.cb_point_d_other.Text = match["point_d_other"].ToString();
            this.cb_point_l_0_1.Text = match["point_l_0_1"].ToString();
            this.cb_point_l_0_2.Text = match["point_l_0_2"].ToString();
            this.cb_point_l_1_2.Text = match["point_l_1_2"].ToString();
            this.cb_point_l_0_3.Text = match["point_l_0_3"].ToString();
            this.cb_point_l_1_3.Text = match["point_l_1_3"].ToString();
            this.cb_point_l_2_3.Text = match["point_l_2_3"].ToString();
            this.cb_point_l_0_4.Text = match["point_l_0_4"].ToString();
            this.cb_point_l_1_4.Text = match["point_l_1_4"].ToString();
            this.cb_point_l_2_4.Text = match["point_l_2_4"].ToString();
            this.cb_point_l_0_5.Text = match["point_l_0_5"].ToString();
            this.cb_point_l_1_5.Text = match["point_l_1_5"].ToString();
            this.cb_point_l_2_5.Text = match["point_l_2_5"].ToString();
            this.cb_point_l_other.Text = match["point_l_other"].ToString();

            this.cb_total_0.Text = match["total_0"].ToString();
            this.cb_total_1.Text = match["total_1"].ToString();
            this.cb_total_2.Text = match["total_2"].ToString();
            this.cb_total_3.Text = match["total_3"].ToString();
            this.cb_total_4.Text = match["total_4"].ToString();
            this.cb_total_5.Text = match["total_5"].ToString();
            this.cb_total_6.Text = match["total_6"].ToString();
            this.cb_total_more.Text = match["total_more"].ToString();

        }
        public double[] get_profits_from_select()
        {
            ArrayList list = new ArrayList();

            if (this.cb_wdl_w.Checked) list.Add(this.cb_wdl_w.Text);
            if (this.cb_wdl_d.Checked) list.Add(this.cb_wdl_d.Text);
            if (this.cb_wdl_l.Checked) list.Add(this.cb_wdl_l.Text);
            if (this.cb_spread_w.Checked) list.Add(this.cb_spread_w.Text);
            if (this.cb_spread_d.Checked) list.Add(this.cb_spread_d.Text);
            if (this.cb_spread_l.Checked) list.Add(this.cb_spread_l.Text);

            if (this.cb_half_ww.Checked) list.Add(this.cb_half_ww.Text);
            if (this.cb_half_wd.Checked) list.Add(this.cb_half_wd.Text);
            if (this.cb_half_wl.Checked) list.Add(this.cb_half_wl.Text);
            if (this.cb_half_dw.Checked) list.Add(this.cb_half_dw.Text);
            if (this.cb_half_dd.Checked) list.Add(this.cb_half_dd.Text);
            if (this.cb_half_dl.Checked) list.Add(this.cb_half_dl.Text);
            if (this.cb_half_lw.Checked) list.Add(this.cb_half_lw.Text);
            if (this.cb_half_ld.Checked) list.Add(this.cb_half_ld.Text);
            if (this.cb_half_ll.Checked) list.Add(this.cb_half_ll.Text);

            if (this.cb_point_w_1_0.Checked) list.Add(this.cb_point_w_1_0.Text);
            if (this.cb_point_w_2_0.Checked) list.Add(this.cb_point_w_2_0.Text);
            if (this.cb_point_w_2_1.Checked) list.Add(this.cb_point_w_2_1.Text);
            if (this.cb_point_w_3_0.Checked) list.Add(this.cb_point_w_3_0.Text);
            if (this.cb_point_w_3_1.Checked) list.Add(this.cb_point_w_3_1.Text);
            if (this.cb_point_w_3_2.Checked) list.Add(this.cb_point_w_3_2.Text);
            if (this.cb_point_w_4_0.Checked) list.Add(this.cb_point_w_4_0.Text);
            if (this.cb_point_w_4_1.Checked) list.Add(this.cb_point_w_4_1.Text);
            if (this.cb_point_w_4_2.Checked) list.Add(this.cb_point_w_4_2.Text);
            if (this.cb_point_w_5_0.Checked) list.Add(this.cb_point_w_5_0.Text);
            if (this.cb_point_w_5_1.Checked) list.Add(this.cb_point_w_5_1.Text);
            if (this.cb_point_w_5_2.Checked) list.Add(this.cb_point_w_5_2.Text);
            if (this.cb_point_w_other.Checked) list.Add(this.cb_point_w_other.Text);
            if (this.cb_point_d_0_0.Checked) list.Add(this.cb_point_d_0_0.Text);
            if (this.cb_point_d_1_1.Checked) list.Add(this.cb_point_d_1_1.Text);
            if (this.cb_point_d_2_2.Checked) list.Add(this.cb_point_d_2_2.Text);
            if (this.cb_point_d_3_3.Checked) list.Add(this.cb_point_d_3_3.Text);
            if (this.cb_point_d_other.Checked) list.Add(this.cb_point_d_other.Text);
            if (this.cb_point_l_0_1.Checked) list.Add(this.cb_point_l_0_1.Text);
            if (this.cb_point_l_0_2.Checked) list.Add(this.cb_point_l_0_2.Text);
            if (this.cb_point_l_1_2.Checked) list.Add(this.cb_point_l_1_2.Text);
            if (this.cb_point_l_0_3.Checked) list.Add(this.cb_point_l_0_3.Text);
            if (this.cb_point_l_1_3.Checked) list.Add(this.cb_point_l_1_3.Text);
            if (this.cb_point_l_2_3.Checked) list.Add(this.cb_point_l_2_3.Text);
            if (this.cb_point_l_0_4.Checked) list.Add(this.cb_point_l_0_4.Text);
            if (this.cb_point_l_1_4.Checked) list.Add(this.cb_point_l_1_4.Text);
            if (this.cb_point_l_2_4.Checked) list.Add(this.cb_point_l_2_4.Text);
            if (this.cb_point_l_0_5.Checked) list.Add(this.cb_point_l_0_5.Text);
            if (this.cb_point_l_1_5.Checked) list.Add(this.cb_point_l_1_5.Text);
            if (this.cb_point_l_2_5.Checked) list.Add(this.cb_point_l_2_5.Text);
            if (this.cb_point_l_other.Checked) list.Add(this.cb_point_l_other.Text);

            if (this.cb_total_0.Checked) list.Add(this.cb_total_0.Text);
            if (this.cb_total_1.Checked) list.Add(this.cb_total_1.Text);
            if (this.cb_total_2.Checked) list.Add(this.cb_total_2.Text);
            if (this.cb_total_3.Checked) list.Add(this.cb_total_3.Text);
            if (this.cb_total_4.Checked) list.Add(this.cb_total_4.Text);
            if (this.cb_total_5.Checked) list.Add(this.cb_total_5.Text);
            if (this.cb_total_6.Checked) list.Add(this.cb_total_6.Text);
            if (this.cb_total_more.Checked) list.Add(this.cb_total_more.Text);


            double[] profits = new double[list.Count];
            for (int i = 0; i < profits.Length; i++)
            {
                profits[i] = Convert.ToDouble(list[i].ToString());
            }
            return profits;
        } 

    }

}
