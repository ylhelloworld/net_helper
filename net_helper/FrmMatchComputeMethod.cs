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

namespace WinCode
{
    public partial class FrmMatchComputeMethod : Form
    {
        DataTable dt_condition = new DataTable();
        DataTable dt_group = new DataTable();
        public FrmMatchComputeMethod()
        {
            InitializeComponent();
        }

        private void FrmPersent_Load(object sender, EventArgs e)
        {
            bind_data();
        }
        private void btn_load_Click(object sender, EventArgs e)
        {
            bind_data();
        }
        private void btn_compute_Click(object sender, EventArgs e)
        {
            this.txt_compute.Text = "";
            int start_count = Convert.ToInt16(txt_count_start.Text);
            int end_count = Convert.ToInt16(txt_count_start.Text);
            if (!string.IsNullOrEmpty(txt_count_end.Text)) end_count = Convert.ToInt16(txt_count_end.Text);

            DataTable dt = new DataTable();
            dt.Columns.Add("start_time");
            dt.Columns.Add("host");
            dt.Columns.Add("client");
            dt.Columns.Add("three");
            dt.Columns.Add("one");
            dt.Columns.Add("zero");

            foreach (DataGridViewRow row in dgv_condition.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {
                    DataRow row_new = dt.NewRow();
                    row_new["start_time"] = row.Cells["start_time"].Value.ToString();
                    row_new["host"] = row.Cells["host"].Value.ToString();
                    row_new["client"] = row.Cells["client"].Value.ToString();
                    row_new["three"] = row.Cells["three"].Value.ToString();
                    row_new["one"] = row.Cells["one"].Value.ToString();
                    row_new["zero"] = row.Cells["zero"].Value.ToString();
                    dt.Rows.Add(row_new);
                }
            }

            if (dt.Rows.Count == 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {
                    for (int count = start_count; count <= end_count; count++)
                    {
                        BsonDocument match1 = new BsonDocument();
                        match1["start_time"] = dt.Rows[i]["start_time"].ToString();
                        match1["host"] = dt.Rows[i]["host"].ToString();
                        match1["client"] = dt.Rows[i]["client"].ToString();
                        match1["three"] = Convert.ToDouble(dt.Rows[i]["three"].ToString());
                        match1["one"] = Convert.ToDouble(dt.Rows[i]["one"].ToString());
                        match1["zero"] = Convert.ToDouble(dt.Rows[i]["zero"].ToString());

                        BsonDocument match2 = new BsonDocument();
                        match2["start_time"] = dt.Rows[j]["start_time"].ToString();
                        match2["host"] = dt.Rows[j]["host"].ToString();
                        match2["client"] = dt.Rows[j]["client"].ToString();
                        match2["three"] = Convert.ToDouble(dt.Rows[j]["three"].ToString());
                        match2["one"] = Convert.ToDouble(dt.Rows[j]["one"].ToString());
                        match2["zero"] = Convert.ToDouble(dt.Rows[j]["zero"].ToString());

                        BsonDocument doc_fix_bid = MatchHelper.get_doc_two_fix_bid(match1, match2, count);
                        BsonDocument doc_group = MatchHelper.get_doc_two_into_group(doc_fix_bid);
                        this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine + Environment.NewLine +
                                                "-------------------------------------------------------------------------------" + Environment.NewLine +
                                                MatchHelper.get_info_from_doc(doc_fix_bid) + Environment.NewLine + Environment.NewLine + MatchHelper.get_info_from_doc(doc_group);
                        Application.DoEvents();
                    }

                }
            }
            this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine +
                                    "-------------------------------------------------------------------------------";
            this.tab.SelectTab(1);

            MessageBox.Show("bingo!!!complete!!!");
        }
        private void btn_compute_next_Click(object sender, EventArgs e)
        {
            this.txt_compute.Text = "";
            int start_count = Convert.ToInt16(txt_count_start.Text);
            int end_count = Convert.ToInt16(txt_count_start.Text);
            if (!string.IsNullOrEmpty(txt_count_end.Text)) end_count = Convert.ToInt16(txt_count_end.Text);

            DataTable dt = new DataTable();
            dt.Columns.Add("start_time");
            dt.Columns.Add("host");
            dt.Columns.Add("client");
            dt.Columns.Add("three");
            dt.Columns.Add("one");
            dt.Columns.Add("zero");

            foreach (DataGridViewRow row in dgv_condition.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {
                    DataRow row_new = dt.NewRow();
                    row_new["start_time"] = row.Cells["start_time"].Value.ToString();
                    row_new["host"] = row.Cells["host"].Value.ToString();
                    row_new["client"] = row.Cells["client"].Value.ToString();
                    row_new["three"] = row.Cells["three"].Value.ToString();
                    row_new["one"] = row.Cells["one"].Value.ToString();
                    row_new["zero"] = row.Cells["zero"].Value.ToString();
                    dt.Rows.Add(row_new);
                }
            }

            if (dt.Rows.Count == 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {
                    for (int count = start_count; count <= end_count; count++)
                    {
                        BsonDocument doc_temp = MongoHelper.query_bson_from_string("match", "{'doc_id':'2014062312123230'}");
                        BsonDocument doc_temp_group = MongoHelper.query_bson_from_string("match", "{'doc_id':'2014062312123230'}");

                        for (int more = 1; more <= 100; more++)
                        {
                            BsonDocument match1 = new BsonDocument();
                            match1["start_time"] = dt.Rows[i]["start_time"].ToString();
                            match1["host"] = dt.Rows[i]["host"].ToString();
                            match1["client"] = dt.Rows[i]["client"].ToString();
                            match1["three"] = Convert.ToDouble(dt.Rows[i]["three"].ToString());
                            match1["one"] = Convert.ToDouble(dt.Rows[i]["one"].ToString());
                            match1["zero"] = Convert.ToDouble(dt.Rows[i]["zero"].ToString());

                            BsonDocument match2 = new BsonDocument();
                            match2["start_time"] = dt.Rows[j]["start_time"].ToString();
                            match2["host"] = dt.Rows[j]["host"].ToString();
                            match2["client"] = dt.Rows[j]["client"].ToString();
                            match2["three"] = Convert.ToDouble(dt.Rows[j]["three"].ToString());
                            match2["one"] = Convert.ToDouble(dt.Rows[j]["one"].ToString());
                            match2["zero"] = Convert.ToDouble(dt.Rows[j]["zero"].ToString());

                            BsonDocument doc_fix_bid_next = MatchHelper.get_doc_two_fix_bid_with_last_doc(doc_temp, match1, match2, count);
                            doc_temp = doc_fix_bid_next;

                            this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine + Environment.NewLine +
                                                    "-------------------------------------------------------------------------------" + Environment.NewLine +
                                                    MatchHelper.get_info_from_doc(doc_fix_bid_next) + Environment.NewLine;
                            Application.DoEvents();
                        }
                    }

                }
            }
            this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine +
                                    "-------------------------------------------------------------------------------";
            this.tab.SelectTab(1);

            MessageBox.Show("bingo!!!complete!!!");
        }
        private void btn_compute_range_Click(object sender, EventArgs e)
        {
            Int64 range_min = Convert.ToInt64(this.txt_range_min.Text);
            Int64 range_max = Convert.ToInt64(this.txt_range_max.Text);
            this.txt_compute.Text = "";


            DataTable dt = new DataTable();
            dt.Columns.Add("start_time");
            dt.Columns.Add("host");
            dt.Columns.Add("client");
            dt.Columns.Add("three");
            dt.Columns.Add("one");
            dt.Columns.Add("zero");

            foreach (DataGridViewRow row in dgv_condition.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {
                    DataRow row_new = dt.NewRow();
                    row_new["start_time"] = row.Cells["start_time"].Value.ToString();
                    row_new["host"] = row.Cells["host"].Value.ToString();
                    row_new["client"] = row.Cells["client"].Value.ToString();
                    row_new["three"] = row.Cells["three"].Value.ToString();
                    row_new["one"] = row.Cells["one"].Value.ToString();
                    row_new["zero"] = row.Cells["zero"].Value.ToString();
                    dt.Rows.Add(row_new);
                }
            }

            if (dt.Rows.Count == 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {


                    BsonDocument match1 = new BsonDocument();
                    match1["start_time"] = dt.Rows[i]["start_time"].ToString();
                    match1["host"] = dt.Rows[i]["host"].ToString();
                    match1["client"] = dt.Rows[i]["client"].ToString();
                    match1["three"] = Convert.ToDouble(dt.Rows[i]["three"].ToString());
                    match1["one"] = Convert.ToDouble(dt.Rows[i]["one"].ToString());
                    match1["zero"] = Convert.ToDouble(dt.Rows[i]["zero"].ToString());

                    BsonDocument match2 = new BsonDocument();
                    match2["start_time"] = dt.Rows[j]["start_time"].ToString();
                    match2["host"] = dt.Rows[j]["host"].ToString();
                    match2["client"] = dt.Rows[j]["client"].ToString();
                    match2["three"] = Convert.ToDouble(dt.Rows[j]["three"].ToString());
                    match2["one"] = Convert.ToDouble(dt.Rows[j]["one"].ToString());
                    match2["zero"] = Convert.ToDouble(dt.Rows[j]["zero"].ToString());

                    BsonDocument doc_range = MatchHelper.get_doc_two_add_range(match1, match2, range_min, range_max);
                    BsonDocument doc_group = MatchHelper.get_doc_two_into_group(doc_range);
                    this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine + Environment.NewLine +
                                            "-------------------------------------------------------------------------------" + Environment.NewLine +
                                            MatchHelper.get_info_from_doc(doc_range) + Environment.NewLine + Environment.NewLine + MatchHelper.get_info_from_doc(doc_group);
                    Application.DoEvents();

                }
            }
            this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine +
                                    "-------------------------------------------------------------------------------";
            this.tab.SelectTab(1);

            MessageBox.Show("bingo!!!complete!!!");

        }
        private void btn_compute_auto_Click(object sender, EventArgs e)
        {

            this.txt_compute.Text = "";

            DataTable dt = new DataTable();
            dt.Columns.Add("start_time");
            dt.Columns.Add("host");
            dt.Columns.Add("client");
            dt.Columns.Add("three");
            dt.Columns.Add("one");
            dt.Columns.Add("zero");

            foreach (DataGridViewRow row in dgv_condition.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {
                    DataRow row_new = dt.NewRow();
                    row_new["start_time"] = row.Cells["start_time"].Value.ToString();
                    row_new["host"] = row.Cells["host"].Value.ToString();
                    row_new["client"] = row.Cells["client"].Value.ToString();
                    row_new["three"] = row.Cells["three"].Value.ToString();
                    row_new["one"] = row.Cells["one"].Value.ToString();
                    row_new["zero"] = row.Cells["zero"].Value.ToString();
                    dt.Rows.Add(row_new);
                }
            }

            if (dt.Rows.Count == 0)
            {

                MessageBox.Show("not select data!");
                return;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {

                    double three1 = Convert.ToDouble(dt.Rows[i]["three"].ToString());
                    double one1 = Convert.ToDouble(dt.Rows[i]["one"].ToString());
                    double zero1 = Convert.ToDouble(dt.Rows[i]["zero"].ToString());
                    double three2 = Convert.ToDouble(dt.Rows[j]["three"].ToString());
                    double one2 = Convert.ToDouble(dt.Rows[j]["one"].ToString());
                    double zero2 = Convert.ToDouble(dt.Rows[j]["zero"].ToString());

                    int[] bids = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                    int[] steps = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                    int[] bids_temp = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                    int[] bids_result = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };
                    double[] profits = new double[] { three1 * three2, three1 * one2, three1 * zero2, one1 * three2, one1 * one2, one1 * zero2, zero1 * three2, zero1 * one2, zero1 * zero2 };
                    double[] profits_temp = new double[] { profits[0], profits[1], profits[2], profits[3], profits[4], profits[5], profits[6], profits[7], profits[8] };
                    for (int step1 = 0; step1 < 9; step1++)
                    {
                        int step_index = 0;
                        double step_max = -999999999;
                        for (int step2 = 0; step2 < 9; step2++)
                        {
                            if (profits_temp[step2] > step_max)
                            {
                                step_max = profits_temp[step2];
                                step_index = step2;
                            }
                        }
                        profits_temp[step_index] = 0;
                        profits[step1] = step_max;
                    }
                    //for (int step = 0; step < 9; step++)
                    //{
                    //    profits[step] = profits[step] * 1.208;
                    //}

                    int bid_total = 9;
                    int bid_total_temp = 0;

                    double best_persent = -99999999;
                    double best_persent_temp = -999999999;

                    double all_profit_min = 0;
                    double all_profit_max = 0;
                    ////按层轮流加1，取最大
                    //while (bid_total < 2000)
                    //{
                    //    //add 1
                    //    best_persent_temp = -999999999;
                    //    for (int k = 0; k < 9; k++)
                    //    {
                    //        bids_temp = new int[] { bids[0], bids[1], bids[2], bids[3], bids[4], bids[5], bids[6], bids[7], bids[8] };
                    //        bids_temp[k] = bids_temp[k] + 1;

                    //        bid_total_temp = bid_total + 1;
                    //        double profit_min = get_min_profit(bids_temp, profits, bid_total_temp);
                    //        if (profit_min / bid_total_temp > best_persent_temp)
                    //        {
                    //            bids_result = new int[] { bids_temp[0], bids_temp[1], bids_temp[2], bids_temp[3], bids_temp[4], bids_temp[5], bids_temp[6], bids_temp[7], bids_temp[8] };
                    //            best_persent_temp = profit_min / bid_total_temp;
                    //        }
                    //    }


                    //    best_persent = best_persent_temp;
                    //    bid_total = bids_result[0] + bids_result[1] + bids_result[2] + bids_result[3] + bids_result[4] + bids_result[5] + bids_result[6] + bids_result[7] + bids_result[8];
                    //    bids = new int[] { bids_result[0], bids_result[1], bids_result[2], bids_result[3], bids_result[4], bids_result[5], bids_result[6], bids_result[7], bids_result[8] };
                    //    sb.Append("------------------------------------------------------------------------------------------------" + Environment.NewLine);
                    //    sb.Append("B33:" + bids[0].ToString() + " B31:" + bids[1].ToString() + " B30:" + bids[2].ToString() +
                    //               " B13:" + bids[3].ToString() + " B11:" + bids[4].ToString() + " B10:" + bids[5].ToString() +
                    //               " B03:" + bids[6].ToString() + " B01:" + bids[7].ToString() + " B00:" + bids[8].ToString() + Environment.NewLine);
                    //    sb.Append("add count:1" + Environment.NewLine);
                    //    sb.Append("total bids:" + bid_total.ToString() + Environment.NewLine);
                    //    sb.Append("persent:" + (best_persent_temp * 100).ToString("f4") + "%" + Environment.NewLine);
                    //    continue;
                    //}


                    //Russi block
                    while (bid_total < 1000)
                    {
                        //add 1 

                        DateTime dt_start = DateTime.Now;
                        int[] add = new int[] { 9, 9, 9, 9, 9, 9, 9, 9, 9 };
                        for (int k0 = 0; k0 <= add[0]; k0++)
                        {
                            for (int k1 = 0; k1 <= add[1]; k1++)
                            {
                                for (int k2 = 0; k2 <= add[2]; k2++)
                                {
                                    for (int k3 = 0; k3 <= add[3]; k3++)
                                    {
                                        for (int k4 = 0; k4 <= add[4]; k4++)
                                        {
                                            for (int k5 = 0; k5 <= add[5]; k5++)
                                            {
                                                for (int k6 = 0; k6 <= add[6]; k6++)
                                                {
                                                    for (int k7 = 0; k7 <= add[7]; k7++)
                                                    {
                                                        for (int k8 = 0; k8 <= add[8]; k8++)
                                                        {
                                                            int bid0 = bids[0] + k0;
                                                            int bid1 = bids[1] + k1;
                                                            int bid2 = bids[2] + k2;
                                                            int bid3 = bids[3] + k3;
                                                            int bid4 = bids[4] + k4;
                                                            int bid5 = bids[5] + k5;
                                                            int bid6 = bids[6] + k6;
                                                            int bid7 = bids[7] + k7;
                                                            int bid8 = bids[8] + k8;
                                                            bid_total_temp = bid0 + bid1 + bid2 + bid3 + bid4 + bid5 + bid6 + bid7 + bid8;

                                                            double profit_min = 999999999;

                                                            if (bid0 * profits[0] - bid_total_temp < profit_min) profit_min = bid0 * profits[0] - bid_total_temp;
                                                            if (bid1 * profits[1] - bid_total_temp < profit_min) profit_min = bid1 * profits[1] - bid_total_temp;
                                                            if (bid2 * profits[2] - bid_total_temp < profit_min) profit_min = bid2 * profits[2] - bid_total_temp;
                                                            if (bid3 * profits[3] - bid_total_temp < profit_min) profit_min = bid3 * profits[3] - bid_total_temp;
                                                            if (bid4 * profits[4] - bid_total_temp < profit_min) profit_min = bid4 * profits[4] - bid_total_temp;
                                                            if (bid5 * profits[5] - bid_total_temp < profit_min) profit_min = bid5 * profits[5] - bid_total_temp;
                                                            if (bid6 * profits[6] - bid_total_temp < profit_min) profit_min = bid6 * profits[6] - bid_total_temp;
                                                            if (bid7 * profits[7] - bid_total_temp < profit_min) profit_min = bid7 * profits[7] - bid_total_temp;
                                                            if (bid8 * profits[8] - bid_total_temp < profit_min) profit_min = bid8 * profits[8] - bid_total_temp;



                                                            if (profit_min / bid_total_temp > best_persent)
                                                            {
                                                                double profit_max = -999999999;
                                                                if (bid0 * profits[0] - bid_total_temp > profit_max) profit_max = bid0 * profits[0] - bid_total_temp;
                                                                if (bid1 * profits[1] - bid_total_temp > profit_max) profit_max = bid1 * profits[1] - bid_total_temp;
                                                                if (bid2 * profits[2] - bid_total_temp > profit_max) profit_max = bid2 * profits[2] - bid_total_temp;
                                                                if (bid3 * profits[3] - bid_total_temp > profit_max) profit_max = bid3 * profits[3] - bid_total_temp;
                                                                if (bid4 * profits[4] - bid_total_temp > profit_max) profit_max = bid4 * profits[4] - bid_total_temp;
                                                                if (bid5 * profits[5] - bid_total_temp > profit_max) profit_max = bid5 * profits[5] - bid_total_temp;
                                                                if (bid6 * profits[6] - bid_total_temp > profit_max) profit_max = bid6 * profits[6] - bid_total_temp;
                                                                if (bid7 * profits[7] - bid_total_temp > profit_max) profit_max = bid7 * profits[7] - bid_total_temp;
                                                                if (bid8 * profits[8] - bid_total_temp > profit_max) profit_max = bid8 * profits[8] - bid_total_temp;

                                                                bids[0] = bid0;
                                                                bids[1] = bid1;
                                                                bids[2] = bid2;
                                                                bids[3] = bid3;
                                                                bids[4] = bid4;
                                                                bids[5] = bid5;
                                                                bids[6] = bid6;
                                                                bids[7] = bid7;
                                                                bids[8] = bid8;

                                                                steps[0] = k0;
                                                                steps[1] = k1;
                                                                steps[2] = k2;
                                                                steps[3] = k3;
                                                                steps[4] = k4;
                                                                steps[5] = k5;
                                                                steps[6] = k6;
                                                                steps[7] = k7;
                                                                steps[8] = k8;

                                                                bid_total = bid_total_temp;
                                                                best_persent = profit_min / bid_total;
                                                                all_profit_min = profit_min;
                                                                all_profit_max = profit_max;

                                                                goto step_next;
                                                            }
                                                            if (k0 == add[0] && k1 == add[1] && k2 == add[2] && k3 == add[3] && k4 == add[4] && k5 == add[5] && k6 == add[6] && k7 == add[7] && k8 == add[8])
                                                            {
                                                                goto step_quit;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                    step_next:
                        DateTime dt_end = DateTime.Now;
                        sb.Append("------------------------------------------------------------------------------------------------" + Environment.NewLine);
                        sb.Append(dt.Rows[i]["start_time"].ToString() + "      " + dt.Rows[i]["host"].ToString().PadRight(10, ' ') + dt.Rows[i]["client"].ToString().PadRight(10, ' '));
                        sb.Append(three1.ToString().PadRight(10, ' ') + one1.ToString().PadRight(10, ' ') + zero1.ToString().PadRight(10, ' ') + Environment.NewLine);
                        sb.Append(dt.Rows[j]["start_time"].ToString() + "      " + dt.Rows[j]["host"].ToString().PadRight(10, ' ') + dt.Rows[j]["client"].ToString().PadRight(10, ' '));
                        sb.Append(three2.ToString().PadRight(10, ' ') + one2.ToString().PadRight(10, ' ') + zero2.ToString().PadRight(10, ' ') + Environment.NewLine);
                        sb.Append("use seconds:" + (dt_end - dt_start).TotalSeconds.ToString() + Environment.NewLine);
                        sb.Append("total bids:" + bid_total.ToString() + Environment.NewLine);
                        sb.Append("profit range:" + all_profit_min.ToString("f2") + "  ~  " + all_profit_max.ToString("f2") + Environment.NewLine);
                        sb.Append("persent:" + (best_persent * 100).ToString("f4") + "%" + Environment.NewLine);
                        sb.Append("detail info:" + Environment.NewLine);
                        sb.Append(profits[0].ToString("f2").PadRight(10, ' ') + profits[1].ToString("f2").PadRight(10, ' ') + profits[2].ToString("f2").PadRight(10, ' ') +
                               profits[3].ToString("f2").PadRight(10, ' ') + profits[4].ToString("f2").PadRight(10, ' ') + profits[5].ToString("f2").PadRight(10, ' ') +
                               profits[6].ToString("f2").PadRight(10, ' ') + profits[7].ToString("f2").PadRight(10, ' ') + profits[8].ToString("f2").PadRight(10, ' ') + Environment.NewLine);
                        sb.Append(steps[0].ToString().PadRight(10, ' ') + steps[1].ToString().PadRight(10, ' ') + steps[2].ToString().PadRight(10, ' ') +
                                steps[3].ToString().PadRight(10, ' ') + steps[4].ToString().PadRight(10, ' ') + steps[5].ToString().PadRight(10, ' ') +
                                steps[6].ToString().PadRight(10, ' ') + steps[7].ToString().PadRight(10, ' ') + steps[8].ToString().PadRight(10, ' ') + Environment.NewLine);
                        sb.Append(bids[0].ToString().PadRight(10, ' ') + bids[1].ToString().PadRight(10, ' ') + bids[2].ToString().PadRight(10, ' ') +
                           bids[3].ToString().PadRight(10, ' ') + bids[4].ToString().PadRight(10, ' ') + bids[5].ToString().PadRight(10, ' ') +
                           bids[6].ToString().PadRight(10, ' ') + bids[7].ToString().PadRight(10, ' ') + bids[8].ToString().PadRight(10, ' ') + Environment.NewLine);
                        sb.Append((bids[0] * profits[0] - bid_total).ToString("f2").PadRight(10, ' ') +
                                  (bids[1] * profits[1] - bid_total).ToString("f2").PadRight(10, ' ') +
                                  (bids[2] * profits[2] - bid_total).ToString("f2").PadRight(10, ' ') +
                                  (bids[3] * profits[3] - bid_total).ToString("f2").PadRight(10, ' ') +
                                  (bids[4] * profits[4] - bid_total).ToString("f2").PadRight(10, ' ') +
                                  (bids[5] * profits[5] - bid_total).ToString("f2").PadRight(10, ' ') +
                                  (bids[6] * profits[6] - bid_total).ToString("f2").PadRight(10, ' ') +
                                  (bids[7] * profits[7] - bid_total).ToString("f2").PadRight(10, ' ') +
                                  (bids[8] * profits[8] - bid_total).ToString("f2").PadRight(10, ' ') + Environment.NewLine);
                        this.txt_compute.Text = sb.ToString();
                        Application.DoEvents();
                    }
                step_quit:
                    sb.Append("------------------------------------------------------------------------------------------------" + Environment.NewLine);
                    this.txt_compute.Text = sb.ToString();
                    Application.DoEvents();

                }
            }

            this.txt_compute.Text = sb.ToString();
            this.tab.SelectTab(1);

            MessageBox.Show("bingo!!!complete!!!");
        }
        private void btn_compute_circle_Click(object sender, EventArgs e)
        {

            this.txt_compute.Text = "";

            DataTable dt = new DataTable();
            dt.Columns.Add("start_time");
            dt.Columns.Add("host");
            dt.Columns.Add("client");
            dt.Columns.Add("three");
            dt.Columns.Add("one");
            dt.Columns.Add("zero");

            foreach (DataGridViewRow row in dgv_condition.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {
                    DataRow row_new = dt.NewRow();
                    row_new["start_time"] = row.Cells["start_time"].Value.ToString();
                    row_new["host"] = row.Cells["host"].Value.ToString();
                    row_new["client"] = row.Cells["client"].Value.ToString();
                    row_new["three"] = row.Cells["three"].Value.ToString();
                    row_new["one"] = row.Cells["one"].Value.ToString();
                    row_new["zero"] = row.Cells["zero"].Value.ToString();
                    dt.Rows.Add(row_new);
                }
            }

            if (dt.Rows.Count == 0)
            {

                MessageBox.Show("not select data!");
                return;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {


                    BsonDocument match1 = new BsonDocument();
                    match1["start_time"] = dt.Rows[i]["start_time"].ToString();
                    match1["host"] = dt.Rows[i]["host"].ToString();
                    match1["client"] = dt.Rows[i]["client"].ToString();
                    match1["three"] = Convert.ToDouble(dt.Rows[i]["three"].ToString());
                    match1["one"] = Convert.ToDouble(dt.Rows[i]["one"].ToString());
                    match1["zero"] = Convert.ToDouble(dt.Rows[i]["zero"].ToString());

                    BsonDocument match2 = new BsonDocument();
                    match2["start_time"] = dt.Rows[j]["start_time"].ToString();
                    match2["host"] = dt.Rows[j]["host"].ToString();
                    match2["client"] = dt.Rows[j]["client"].ToString();
                    match2["three"] = Convert.ToDouble(dt.Rows[j]["three"].ToString());
                    match2["one"] = Convert.ToDouble(dt.Rows[j]["one"].ToString());
                    match2["zero"] = Convert.ToDouble(dt.Rows[j]["zero"].ToString());

                    

                    for (int k=1;k<=100;k++)
                    {
                        BsonDocument doc = MatchHelper.get_doc_two_like_circle(match1, match2,k);

                        sb.Append("------------------------------------------------------------------------------------------------" + Environment.NewLine);
                        sb.Append(MatchHelper.get_info_from_doc(doc));
                        this.txt_compute.Text = sb.ToString();
                        Application.DoEvents();
                    }

                    sb.Append("------------------------------------------------------------------------------------------------" + Environment.NewLine);
                    this.txt_compute.Text = sb.ToString();
                    Application.DoEvents();

                }
            }

            this.txt_compute.Text = sb.ToString();
            this.tab.SelectTab(1);

            MessageBox.Show("bingo!!!complete!!!");
        }
        private void btn_compute_circle_one_Click(object sender, EventArgs e)
        {
            this.txt_compute.Text = "";

            DataTable dt = new DataTable();
            dt.Columns.Add("start_time");
            dt.Columns.Add("host");
            dt.Columns.Add("client");
            dt.Columns.Add("three");
            dt.Columns.Add("one");
            dt.Columns.Add("zero");

            foreach (DataGridViewRow row in dgv_condition.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {
                    DataRow row_new = dt.NewRow();
                    row_new["start_time"] = row.Cells["start_time"].Value.ToString();
                    row_new["host"] = row.Cells["host"].Value.ToString();
                    row_new["client"] = row.Cells["client"].Value.ToString();
                    row_new["three"] = row.Cells["three"].Value.ToString();
                    row_new["one"] = row.Cells["one"].Value.ToString();
                    row_new["zero"] = row.Cells["zero"].Value.ToString();
                    dt.Rows.Add(row_new);
                }
            }

            if (dt.Rows.Count == 0)
            {

                MessageBox.Show("not select data!");
                return;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
         
                    BsonDocument match1 = new BsonDocument();
                    match1["start_time"] = dt.Rows[i]["start_time"].ToString();
                    match1["host"] = dt.Rows[i]["host"].ToString();
                    match1["client"] = dt.Rows[i]["client"].ToString();
                    match1["three"] = Convert.ToDouble(dt.Rows[i]["three"].ToString());
                    match1["one"] = Convert.ToDouble(dt.Rows[i]["one"].ToString());
                    match1["zero"] = Convert.ToDouble(dt.Rows[i]["zero"].ToString()); 


                    for (int k = 1; k <= 100; k++)
                    {
                        BsonDocument doc = MatchHelper.get_doc_one_like_circle(match1,k);

                        sb.Append("------------------------------------------------------------------------------------------------" + Environment.NewLine);
                        sb.Append(MatchHelper.get_info_from_doc(doc));
                        this.txt_compute.Text = sb.ToString();
                        Application.DoEvents();
                    }

                    sb.Append("------------------------------------------------------------------------------------------------" + Environment.NewLine);
                    this.txt_compute.Text = sb.ToString();
                    Application.DoEvents();

                
            }

            this.txt_compute.Text = sb.ToString();
            this.tab.SelectTab(1);

            MessageBox.Show("bingo!!!complete!!!");
        }
        private void btn_find_result_Click(object sender, EventArgs e)
        {

            StringBuilder sb = new StringBuilder();
            MongoCursor<BsonDocument> cursor = MongoHelper.query_cursor_from_string("match", this.txt_find_condition.Text);
            if (cursor.Count() != 0)
            {
                foreach (BsonDocument doc in cursor)
                {
                    sb.Append(Environment.NewLine);
                    sb.Append("-------------------------------------------------------------------------------" + Environment.NewLine);
                    sb.Append(MatchHelper.get_info_from_doc(doc));
                    Application.DoEvents();
                }
                sb.Append(Environment.NewLine + "-------------------------------------------------------------------------------");
                this.txt_compute.Text = sb.ToString();
                this.tab.SelectTab(1);
            }
        }
        private void btn_compute_circle_three_Click(object sender, EventArgs e)
        {

            this.txt_compute.Text = "";

            DataTable dt = new DataTable();
            dt.Columns.Add("start_time");
            dt.Columns.Add("host");
            dt.Columns.Add("client");
            dt.Columns.Add("three");
            dt.Columns.Add("one");
            dt.Columns.Add("zero");

            foreach (DataGridViewRow row in dgv_condition.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true)
                {
                    DataRow row_new = dt.NewRow();
                    row_new["start_time"] = row.Cells["start_time"].Value.ToString();
                    row_new["host"] = row.Cells["host"].Value.ToString();
                    row_new["client"] = row.Cells["client"].Value.ToString();
                    row_new["three"] = row.Cells["three"].Value.ToString();
                    row_new["one"] = row.Cells["one"].Value.ToString();
                    row_new["zero"] = row.Cells["zero"].Value.ToString();
                    dt.Rows.Add(row_new);
                }
            }

            if (dt.Rows.Count == 0)
            {

                MessageBox.Show("not select data!");
                return;
            }

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {

                    for (int k = j + 1; k < dt.Rows.Count; k++)
                    {
                        BsonDocument match1 = new BsonDocument();
                        match1["start_time"] = dt.Rows[i]["start_time"].ToString();
                        match1["host"] = dt.Rows[i]["host"].ToString();
                        match1["client"] = dt.Rows[i]["client"].ToString();
                        match1["three"] = Convert.ToDouble(dt.Rows[i]["three"].ToString());
                        match1["one"] = Convert.ToDouble(dt.Rows[i]["one"].ToString());
                        match1["zero"] = Convert.ToDouble(dt.Rows[i]["zero"].ToString());

                        BsonDocument match2 = new BsonDocument();
                        match2["start_time"] = dt.Rows[j]["start_time"].ToString();
                        match2["host"] = dt.Rows[j]["host"].ToString();
                        match2["client"] = dt.Rows[j]["client"].ToString();
                        match2["three"] = Convert.ToDouble(dt.Rows[j]["three"].ToString());
                        match2["one"] = Convert.ToDouble(dt.Rows[j]["one"].ToString());
                        match2["zero"] = Convert.ToDouble(dt.Rows[j]["zero"].ToString());

                        BsonDocument match3 = new BsonDocument();
                        match3["start_time"] = dt.Rows[k]["start_time"].ToString();
                        match3["host"] = dt.Rows[k]["host"].ToString();
                        match3["client"] = dt.Rows[k]["client"].ToString();
                        match3["three"] = Convert.ToDouble(dt.Rows[k]["three"].ToString());
                        match3["one"] = Convert.ToDouble(dt.Rows[k]["one"].ToString());
                        match3["zero"] = Convert.ToDouble(dt.Rows[k]["zero"].ToString());



                        for (int l = 1; l <= 100; l++)
                        {
                            BsonDocument doc = MatchHelper.get_doc_three_like_circle(match1, match2, match3, l);

                            sb.Append("------------------------------------------------------------------------------------------------" + Environment.NewLine);
                            sb.Append(MatchHelper.get_info_from_doc(doc));
                            this.txt_compute.Text = sb.ToString();
                            Application.DoEvents();
                        }

                        sb.Append("------------------------------------------------------------------------------------------------" + Environment.NewLine);
                        this.txt_compute.Text = sb.ToString();
                        Application.DoEvents();
                    }

                }
            }

            this.txt_compute.Text = sb.ToString();
            this.tab.SelectTab(1);

            MessageBox.Show("bingo!!!complete!!!");
        }
        private void txt_compute_TextChanged(object sender, EventArgs e)
        {
            this.txt_compute.SelectionStart = this.txt_compute.TextLength;
            this.txt_compute.ScrollToCaret();
        }
        private void btn_create_group_Click(object sender, EventArgs e)
        {

            //All Group
            int group1 = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 9; i <= 111111111; i++)
            {
                string num = i.ToString();
                int total = 0;
                if (num.Contains("0") == false)
                {
                    for (int j = 0; j < num.Length; j++)
                    {
                        total = total + Convert.ToInt32(num.Substring(j, 1));
                    }
                    if (total == 9)
                    {

                        group1 = group1 + 1;
                        sb.Append(i.ToString() + Environment.NewLine);


                        string[] info = new string[] { "", "", "", "", "", "", "", "", "" };
                        //save all group 
                        int count = 0;
                        for (int j = 0; j < num.Length; j++)
                        {
                            string no = "";
                            for (int k = 1; k <= Convert.ToInt32(num.Substring(j, 1)); k++)
                            {
                                count = count + 1;
                                no = no + count.ToString();
                            }
                            info[j] = no;
                        }
                        string sql = "";
                        string sql_temp = " insert into temp_group2  (type,group1,group2,group3,group4,group5,group6,group7,group8,group9) " +
                                          " values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')";
                        sql = string.Format(sql_temp, i.ToString(), info[0].ToString(), info[1].ToString(), info[2].ToString(), info[3].ToString(), info[4].ToString(),
                                     info[5].ToString(), info[6].ToString(), info[7].ToString(), info[8].ToString());
                        SQLServerHelper.exe_sql(sql);
                    }
                }
            }
            this.txt_compute.Text = sb.ToString();



            MessageBox.Show(group1.ToString());
        }


        public void bind_data()
        {
            //bind group
            string sql = "select * from temp_group2";
            dt_group = SQLServerHelper.get_table(sql);

            DataTable dt_condition = new DataTable();

            DataColumn col = new DataColumn();
            col.DataType = Type.GetType("System.Boolean");
            col.ColumnName = "selected";
            col.DefaultValue = false;
            dt_condition.Columns.Add(col);
            dt_condition.Columns.Add("start_time");
            dt_condition.Columns.Add("host");
            dt_condition.Columns.Add("client");
            dt_condition.Columns.Add("three");
            dt_condition.Columns.Add("one");
            dt_condition.Columns.Add("zero");



            sql = " select *" +
                   " from win" +
                   " where start_time>'{0}'" +
                   " order by start_time,website,host,client,timespan";
            sql = string.Format(sql, DateTime.Now.AddDays(-10).ToString("yyyy-MM-dd HH:mm:ss"));

            DataTable dt = SQLServerHelper.get_table(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt_condition.NewRow();
                if (i == 0)
                {
                    row["start_time"] = dt.Rows[i]["start_time"].ToString();
                    row["host"] = dt.Rows[i]["host"].ToString();
                    row["client"] = dt.Rows[i]["client"].ToString();
                    row["three"] = dt.Rows[i]["three"].ToString();
                    row["one"] = dt.Rows[i]["one"].ToString();
                    row["zero"] = dt.Rows[i]["zero"].ToString();
                    dt_condition.Rows.Add(row);
                }
                else
                {
                    if (dt.Rows[i]["start_time"].ToString() != dt.Rows[i - 1]["start_time"].ToString() ||
                       dt.Rows[i]["host"].ToString() != dt.Rows[i - 1]["host"].ToString() ||
                       dt.Rows[i]["client"].ToString() != dt.Rows[i - 1]["client"].ToString())
                    {
                        row["start_time"] = dt.Rows[i]["start_time"].ToString();
                        row["host"] = dt.Rows[i]["host"].ToString();
                        row["client"] = dt.Rows[i]["client"].ToString();
                        row["three"] = dt.Rows[i]["three"].ToString();
                        row["one"] = dt.Rows[i]["one"].ToString();
                        row["zero"] = dt.Rows[i]["zero"].ToString();
                        dt_condition.Rows.Add(row);
                    }
                }
            }
            this.dgv_condition.DataSource = dt_condition;
        }

 












    }
}
