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
    public partial class FrmPersent : Form
    {
        DataTable dt_condition = new DataTable();
        DataTable dt_group = new DataTable();
        public FrmPersent()
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
                        BsonDocument doc_normal = get_doc_compute_normal(count,
                                                                      dt.Rows[i]["start_time"].ToString(),
                                                                      dt.Rows[i]["host"].ToString(),
                                                                      dt.Rows[i]["client"].ToString(),
                                                                      Convert.ToDouble(dt.Rows[i]["three"].ToString()),
                                                                      Convert.ToDouble(dt.Rows[i]["one"].ToString()),
                                                                      Convert.ToDouble(dt.Rows[i]["zero"].ToString()),
                                                                      dt.Rows[j]["start_time"].ToString(),
                                                                      dt.Rows[j]["host"].ToString(),
                                                                      dt.Rows[j]["client"].ToString(),
                                                                      Convert.ToDouble(dt.Rows[j]["three"].ToString()),
                                                                      Convert.ToDouble(dt.Rows[j]["one"].ToString()),
                                                                      Convert.ToDouble(dt.Rows[j]["zero"].ToString()));
                        BsonDocument doc_group = get_doc_compute_group(doc_normal);
                        this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine + Environment.NewLine +
                                                "-------------------------------------------------------------------------------" + Environment.NewLine +
                                                get_info_from_doc(doc_normal) + Environment.NewLine + Environment.NewLine + get_info_from_doc(doc_group);
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
                            BsonDocument doc_normal = get_doc_compute_normal_next(doc_temp, count,
                                                                          dt.Rows[i]["start_time"].ToString(),
                                                                          dt.Rows[i]["host"].ToString(),
                                                                          dt.Rows[i]["client"].ToString(),
                                                                          Convert.ToDouble(dt.Rows[i]["three"].ToString()),
                                                                          Convert.ToDouble(dt.Rows[i]["one"].ToString()),
                                                                          Convert.ToDouble(dt.Rows[i]["zero"].ToString()),
                                                                          dt.Rows[j]["start_time"].ToString(),
                                                                          dt.Rows[j]["host"].ToString(),
                                                                          dt.Rows[j]["client"].ToString(),
                                                                          Convert.ToDouble(dt.Rows[j]["three"].ToString()),
                                                                          Convert.ToDouble(dt.Rows[j]["one"].ToString()),
                                                                          Convert.ToDouble(dt.Rows[j]["zero"].ToString()));

                            doc_temp = get_doc_compute_group_next(doc_temp, doc_normal);
                            doc_temp["bid_count"] = (Convert.ToInt16(doc_temp["bid_count"].ToString()) + count * more).ToString();
                            this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine + Environment.NewLine +
                                                    "-------------------------------------------------------------------------------" + Environment.NewLine +
                                                    get_info_from_doc(doc_normal) + Environment.NewLine + Environment.NewLine + get_info_from_doc(doc_temp);
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

                    BsonDocument doc_normal = get_doc_compute_range(range_min, range_max,
                                                                  dt.Rows[i]["start_time"].ToString(),
                                                                  dt.Rows[i]["host"].ToString(),
                                                                  dt.Rows[i]["client"].ToString(),
                                                                  Convert.ToDouble(dt.Rows[i]["three"].ToString()),
                                                                  Convert.ToDouble(dt.Rows[i]["one"].ToString()),
                                                                  Convert.ToDouble(dt.Rows[i]["zero"].ToString()),
                                                                  dt.Rows[j]["start_time"].ToString(),
                                                                  dt.Rows[j]["host"].ToString(),
                                                                  dt.Rows[j]["client"].ToString(),
                                                                  Convert.ToDouble(dt.Rows[j]["three"].ToString()),
                                                                  Convert.ToDouble(dt.Rows[j]["one"].ToString()),
                                                                  Convert.ToDouble(dt.Rows[j]["zero"].ToString()));
                    BsonDocument doc_group = get_doc_compute_group(doc_normal);
                    this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine + Environment.NewLine +
                                            "-------------------------------------------------------------------------------" + Environment.NewLine +
                                            get_info_from_doc(doc_normal) + Environment.NewLine + Environment.NewLine + get_info_from_doc(doc_group);
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
            //add layer method
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
            //add layer method
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
                    int[] bids_temp = new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 };

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

                    for (int k = 1; k <= 100; k++)
                    {
                        bids[0] = k;
                        bids[1] = (int)Math.Floor(profits[0] * bids[0] / profits[1]);
                        bids[2] = (int)Math.Floor(profits[0] * bids[0] / profits[2]);
                        bids[3] = (int)Math.Floor(profits[0] * bids[0] / profits[3]);
                        bids[4] = (int)Math.Floor(profits[0] * bids[0] / profits[4]);
                        bids[5] = (int)Math.Floor(profits[0] * bids[0] / profits[5]);
                        bids[6] = (int)Math.Floor(profits[0] * bids[0] / profits[6]);
                        bids[7] = (int)Math.Floor(profits[0] * bids[0] / profits[7]);
                        bids[8] = (int)Math.Floor(profits[0] * bids[0] / profits[8]);



                        bids_temp[0] = bids[0];
                        bids_temp[1] = bids[1];
                        bids_temp[2] = bids[2];
                        bids_temp[3] = bids[3];
                        bids_temp[4] = bids[4];
                        bids_temp[5] = bids[5];
                        bids_temp[6] = bids[6];
                        bids_temp[7] = bids[7];
                        bids_temp[8] = bids[8];
                        //上下调整1
                        double max_persent = -99999;
                        for (int ajust1 = 0; ajust1 < 2; ajust1++)
                        {
                            for (int ajust2 = 0; ajust2 < 2; ajust2++)
                            {
                                for (int ajust3 = 0; ajust3 < 2; ajust3++)
                                {
                                    for (int ajust4 = 0; ajust4 < 2; ajust4++)
                                    {
                                        for (int ajust5 = 0; ajust5 < 2; ajust5++)
                                        {
                                            for (int ajust6 = 0; ajust6 < 2; ajust6++)
                                            {
                                                for (int ajust7 = 0; ajust7 < 2; ajust7++)
                                                {
                                                    for (int ajust8 = 0; ajust8 < 2; ajust8++)
                                                    {
                                                        int bid0 = bids[0];
                                                        int bid1 = bids[1] + ajust1;
                                                        int bid2 = bids[2] + ajust2;
                                                        int bid3 = bids[3] + ajust3;
                                                        int bid4 = bids[4] + ajust4;
                                                        int bid5 = bids[5] + ajust5;
                                                        int bid6 = bids[6] + ajust6;
                                                        int bid7 = bids[7] + ajust7;
                                                        int bid8 = bids[8] + ajust8;
                                                        int total = bid0 + bid1 + bid2 + bid3 + bid4 + bid5 + bid6 + bid7 + bid8;
                                                        double min_temp = 999999999;
                                                        if (bid0 * profits[0] - total < min_temp) min_temp = bid0 * profits[0] - total;
                                                        if (bid1 * profits[1] - total < min_temp) min_temp = bid1 * profits[1] - total;
                                                        if (bid2 * profits[2] - total < min_temp) min_temp = bid2 * profits[2] - total;
                                                        if (bid3 * profits[3] - total < min_temp) min_temp = bid3 * profits[3] - total;
                                                        if (bid4 * profits[4] - total < min_temp) min_temp = bid4 * profits[4] - total;
                                                        if (bid5 * profits[5] - total < min_temp) min_temp = bid5 * profits[5] - total;
                                                        if (bid6 * profits[6] - total < min_temp) min_temp = bid6 * profits[6] - total;
                                                        if (bid7 * profits[7] - total < min_temp) min_temp = bid7 * profits[7] - total;
                                                        if (bid8 * profits[8] - total < min_temp) min_temp = bid8 * profits[8] - total;

                                                        if (min_temp / total > max_persent)
                                                        {
                                                            bids_temp[0] = bid0;
                                                            bids_temp[1] = bid1;
                                                            bids_temp[2] = bid2;
                                                            bids_temp[3] = bid3;
                                                            bids_temp[4] = bid4;
                                                            bids_temp[5] = bid5;
                                                            bids_temp[6] = bid6;
                                                            bids_temp[7] = bid7;
                                                            bids_temp[8] = bid8;
                                                        }
                                                    }
                                                }

                                            }
                                        }

                                    }
                                }

                            }
                        }

                        bids[0] = bids_temp[0];
                        bids[1] = bids_temp[1];
                        bids[2] = bids_temp[2];
                        bids[3] = bids_temp[3];
                        bids[4] = bids_temp[4];
                        bids[5] = bids_temp[5];
                        bids[6] = bids_temp[6];
                        bids[7] = bids_temp[7];
                        bids[8] = bids_temp[8];

                        int bid_total = bids[0] + bids[1] + bids[2] + bids[3] + bids[4] + bids[5] + bids[6] + bids[7] + bids[8];
                        double min = 999999999;
                        double max = -999999999;
                        if (bids[0] * profits[0] - bid_total < min) min = bids[0] * profits[0] - bid_total;
                        if (bids[1] * profits[1] - bid_total < min) min = bids[1] * profits[1] - bid_total;
                        if (bids[2] * profits[2] - bid_total < min) min = bids[2] * profits[2] - bid_total;
                        if (bids[3] * profits[3] - bid_total < min) min = bids[3] * profits[3] - bid_total;
                        if (bids[4] * profits[4] - bid_total < min) min = bids[4] * profits[4] - bid_total;
                        if (bids[5] * profits[5] - bid_total < min) min = bids[5] * profits[5] - bid_total;
                        if (bids[6] * profits[6] - bid_total < min) min = bids[6] * profits[6] - bid_total;
                        if (bids[7] * profits[7] - bid_total < min) min = bids[7] * profits[7] - bid_total;
                        if (bids[8] * profits[8] - bid_total < min) min = bids[8] * profits[8] - bid_total;
                        if (bids[0] * profits[0] - bid_total > max) max = bids[0] * profits[0] - bid_total;
                        if (bids[1] * profits[1] - bid_total > max) max = bids[1] * profits[1] - bid_total;
                        if (bids[2] * profits[2] - bid_total > max) max = bids[2] * profits[2] - bid_total;
                        if (bids[3] * profits[3] - bid_total > max) max = bids[3] * profits[3] - bid_total;
                        if (bids[4] * profits[4] - bid_total > max) max = bids[4] * profits[4] - bid_total;
                        if (bids[5] * profits[5] - bid_total > max) max = bids[5] * profits[5] - bid_total;
                        if (bids[6] * profits[6] - bid_total > max) max = bids[6] * profits[6] - bid_total;
                        if (bids[7] * profits[7] - bid_total > max) max = bids[7] * profits[7] - bid_total;
                        if (bids[8] * profits[8] - bid_total > max) max = bids[8] * profits[8] - bid_total;




                        sb.Append("------------------------------------------------------------------------------------------------" + Environment.NewLine);
                        sb.Append(dt.Rows[i]["start_time"].ToString() + "      " + dt.Rows[i]["host"].ToString().PadRight(10, ' ') + dt.Rows[i]["client"].ToString().PadRight(10, ' '));
                        sb.Append(three1.ToString().PadRight(10, ' ') + one1.ToString().PadRight(10, ' ') + zero1.ToString().PadRight(10, ' ') + Environment.NewLine);
                        sb.Append(dt.Rows[j]["start_time"].ToString() + "      " + dt.Rows[j]["host"].ToString().PadRight(10, ' ') + dt.Rows[j]["client"].ToString().PadRight(10, ' '));
                        sb.Append(three2.ToString().PadRight(10, ' ') + one2.ToString().PadRight(10, ' ') + zero2.ToString().PadRight(10, ' ') + Environment.NewLine);
                        sb.Append("total bids:" + bid_total.ToString() + Environment.NewLine);
                        sb.Append("profit range:" + min.ToString("f2") + "  ~  " + max.ToString("f2") + Environment.NewLine);
                        sb.Append("persent:" + (min / bid_total * 100).ToString("f4") + "%" + Environment.NewLine);
                        sb.Append("detail info:" + Environment.NewLine);
                        sb.Append(profits[0].ToString("f2").PadRight(10, ' ') + profits[1].ToString("f2").PadRight(10, ' ') + profits[2].ToString("f2").PadRight(10, ' ') +
                               profits[3].ToString("f2").PadRight(10, ' ') + profits[4].ToString("f2").PadRight(10, ' ') + profits[5].ToString("f2").PadRight(10, ' ') +
                               profits[6].ToString("f2").PadRight(10, ' ') + profits[7].ToString("f2").PadRight(10, ' ') + profits[8].ToString("f2").PadRight(10, ' ') + Environment.NewLine);
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

                    sb.Append("------------------------------------------------------------------------------------------------" + Environment.NewLine);
                    this.txt_compute.Text = sb.ToString();
                    Application.DoEvents();

                }
            }

            this.txt_compute.Text = sb.ToString();
            this.tab.SelectTab(1);

            MessageBox.Show("bingo!!!complete!!!");
        }
        public double get_min_profit(int[] bids, double[] profits, int total_bids)
        {
            double min = 999999999;
            for (int i = 0; i < 9; i++)
            {
                double profit = bids[i] * profits[i] - total_bids;
                if (profit < min)
                {
                    min = profit;
                }
            }
            return min;

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
                    sb.Append(get_info_from_doc(doc));
                }
                sb.Append(Environment.NewLine + "-------------------------------------------------------------------------------");
                this.txt_compute.Text = sb.ToString();
                this.tab.SelectTab(1);
            }
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
        public BsonDocument get_doc_compute_normal(int count,
                                   string start_time1, string host1, string client1, double three1, double one1, double zero1,
                                   string start_time2, string host2, string client2, double three2, double one2, double zero2)
        {

            StringBuilder builder = new StringBuilder();

            DateTime dt_start = DateTime.Now;
            Int64 step = 0;



            double result_min = -1000;
            double result_max = 0;
            double result_b33 = 0;
            double result_b31 = 0;
            double result_b30 = 0;
            double result_b13 = 0;
            double result_b11 = 0;
            double result_b10 = 0;
            double result_b03 = 0;
            double result_b01 = 0;
            double result_b00 = 0;
            double result_r33 = 0;
            double result_r31 = 0;
            double result_r30 = 0;
            double result_r13 = 0;
            double result_r11 = 0;
            double result_r10 = 0;
            double result_r03 = 0;
            double result_r01 = 0;
            double result_r00 = 0;




            for (int b33 = 0; b33 <= count; b33++)
            {
                for (int b31 = 0; b31 <= count - b33; b31++)
                {
                    for (int b30 = 0; b30 <= count - b33 - b31; b30++)
                    {
                        for (int b13 = 0; b13 <= count - b33 - b31 - b30; b13++)
                        {
                            for (int b11 = 0; b11 <= count - b33 - b31 - b30 - b13; b11++)
                            {
                                for (int b10 = 0; b10 <= count - b33 - b31 - b30 - b13 - b11; b10++)
                                {
                                    for (int b03 = 0; b03 <= count - b33 - b31 - b30 - b13 - b11 - b10; b03++)
                                    {
                                        for (int b01 = 0; b01 <= count - b33 - b31 - b30 - b13 - b11 - b10 - b03; b01++)
                                        {
                                            int b00 = count - b33 - b31 - b30 - b13 - b11 - b10 - b03 - b01;

                                            double r33 = 0;
                                            double r31 = 0;
                                            double r30 = 0;
                                            double r13 = 0;
                                            double r11 = 0;
                                            double r10 = 0;
                                            double r03 = 0;
                                            double r01 = 0;
                                            double r00 = 0;


                                            r33 = get_max_profit("33", b33, count, three1, three2);
                                            r31 = get_max_profit("31", b31, count, three1, one2);
                                            r30 = get_max_profit("30", b30, count, three1, zero2);
                                            r13 = get_max_profit("33", b13, count, one1, three2);
                                            r11 = get_max_profit("31", b11, count, one1, one2);
                                            r10 = get_max_profit("30", b10, count, one1, zero2);
                                            r03 = get_max_profit("03", b03, count, zero1, three2);
                                            r01 = get_max_profit("01", b01, count, zero1, one2);
                                            r00 = get_max_profit("00", b00, count, zero1, zero2);

                                            double max = 0;
                                            double min = 99999999;

                                            if (r33 > max) max = r33;
                                            if (r33 < min) min = r33;
                                            if (r31 > max) max = r31;
                                            if (r31 < min) min = r31;
                                            if (r30 > max) max = r30;
                                            if (r30 < min) min = r30;
                                            if (r13 > max) max = r13;
                                            if (r13 < min) min = r13;
                                            if (r11 > max) max = r11;
                                            if (r11 < min) min = r11;
                                            if (r10 > max) max = r10;
                                            if (r10 < min) min = r10;
                                            if (r03 > max) max = r03;
                                            if (r03 < min) min = r03;
                                            if (r01 > max) max = r01;
                                            if (r01 < min) min = r01;
                                            if (r00 > max) max = r00;
                                            if (r00 < min) min = r00;

                                            if (min > result_min)
                                            {
                                                result_min = min;
                                                result_max = max;
                                                result_b33 = b33;
                                                result_b31 = b31;
                                                result_b30 = b30;
                                                result_b13 = b13;
                                                result_b11 = b11;
                                                result_b10 = b10;
                                                result_b03 = b03;
                                                result_b01 = b01;
                                                result_b00 = b00;
                                                result_r33 = r33;
                                                result_r31 = r31;
                                                result_r30 = r30;
                                                result_r13 = r13;
                                                result_r11 = r11;
                                                result_r10 = r10;
                                                result_r03 = r03;
                                                result_r01 = r01;
                                                result_r00 = r00;
                                            }

                                            step = step + 1;
                                        }

                                    }

                                }

                            }

                        }

                    }


                }

            }
            DateTime dt_end = DateTime.Now;
            BsonDocument doc = new BsonDocument();
            doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
            doc.Add("type", "2-normal-min");
            doc.Add("loop_count", "1");
            doc.Add("start_time1", start_time1);
            doc.Add("host1", host1);
            doc.Add("client1", client1);
            doc.Add("three1", three1.ToString("f2"));
            doc.Add("one1", one1.ToString("f2"));
            doc.Add("zero1", zero1.ToString("f2"));
            doc.Add("start_time2", start_time1);
            doc.Add("host2", host2);
            doc.Add("client2", client2);
            doc.Add("three2", three2.ToString("f2"));
            doc.Add("one2", one2.ToString("f2"));
            doc.Add("zero2", zero2.ToString("f2"));
            doc.Add("bid_count", count.ToString());
            doc.Add("total_bid_count", count.ToString());
            doc.Add("compute_count", step.ToString());
            doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
            doc.Add("min_value", result_min.ToString("f4"));
            doc.Add("max_value", result_max.ToString("f4"));
            doc.Add("b33", result_b33.ToString());
            doc.Add("b31", result_b31.ToString());
            doc.Add("b30", result_b30.ToString());
            doc.Add("b13", result_b13.ToString());
            doc.Add("b11", result_b11.ToString());
            doc.Add("b10", result_b10.ToString());
            doc.Add("b03", result_b03.ToString());
            doc.Add("b01", result_b01.ToString());
            doc.Add("b00", result_b00.ToString());
            doc.Add("r33", result_r33.ToString("f4"));
            doc.Add("r31", result_r31.ToString("f4"));
            doc.Add("r30", result_r30.ToString("f4"));
            doc.Add("r13", result_r13.ToString("f4"));
            doc.Add("r11", result_r11.ToString("f4"));
            doc.Add("r10", result_r10.ToString("f4"));
            doc.Add("r03", result_r03.ToString("f4"));
            doc.Add("r01", result_r01.ToString("f4"));
            doc.Add("r00", result_r00.ToString("f4"));
            // MongoHelper.insert_bson("match", doc);
            return doc;
        }
        public BsonDocument get_doc_compute_group(BsonDocument doc_input)
        {
            int count = Convert.ToInt16(doc_input["bid_count"].ToString());
            string start_time1 = doc_input["start_time1"].ToString();
            string host1 = doc_input["host1"].ToString();
            string client1 = doc_input["client1"].ToString();
            double three1 = Convert.ToDouble(doc_input["three1"].ToString());
            double one1 = Convert.ToDouble(doc_input["one1"].ToString());
            double zero1 = Convert.ToDouble(doc_input["zero1"].ToString());
            string start_time2 = doc_input["start_time2"].ToString();
            string host2 = doc_input["host2"].ToString();
            string client2 = doc_input["client2"].ToString();
            double three2 = Convert.ToDouble(doc_input["three2"].ToString());
            double one2 = Convert.ToDouble(doc_input["one2"].ToString());
            double zero2 = Convert.ToDouble(doc_input["zero2"].ToString());
            int b33 = Convert.ToInt16(doc_input["b33"].ToString());
            int b31 = Convert.ToInt16(doc_input["b31"].ToString());
            int b30 = Convert.ToInt16(doc_input["b30"].ToString());
            int b13 = Convert.ToInt16(doc_input["b13"].ToString());
            int b11 = Convert.ToInt16(doc_input["b11"].ToString());
            int b10 = Convert.ToInt16(doc_input["b10"].ToString());
            int b03 = Convert.ToInt16(doc_input["b03"].ToString());
            int b01 = Convert.ToInt16(doc_input["b01"].ToString());
            int b00 = Convert.ToInt16(doc_input["b00"].ToString());


            StringBuilder builder = new StringBuilder();

            int result_group_index = 0;
            double result_min = -1000;
            double result_max = 0;
            double result_b33 = 0;
            double result_b31 = 0;
            double result_b30 = 0;
            double result_b13 = 0;
            double result_b11 = 0;
            double result_b10 = 0;
            double result_b03 = 0;
            double result_b01 = 0;
            double result_b00 = 0;
            double result_r33 = 0;
            double result_r31 = 0;
            double result_r30 = 0;
            double result_r13 = 0;
            double result_r11 = 0;
            double result_r10 = 0;
            double result_r03 = 0;
            double result_r01 = 0;
            double result_r00 = 0;

            double r33 = 0;
            double r31 = 0;
            double r30 = 0;
            double r13 = 0;
            double r11 = 0;
            double r10 = 0;
            double r03 = 0;
            double r01 = 0;
            double r00 = 0;

            r33 = b33 * three1 * three2;
            r31 = b31 * three1 * one2;
            r30 = b30 * three1 * zero2;
            r13 = b13 * one1 * three2;
            r11 = b11 * one1 * one2;
            r10 = b10 * one1 * zero2;
            r03 = b03 * zero1 * three2;
            r01 = b01 * zero1 * one2;
            r00 = b00 * zero1 * zero2;

            int[] bits = new int[] { b33, b31, b30, b13, b11, b10, b03, b01, b00 };
            double[] profits = new double[] { r33, r31, r30, r13, r11, r10, r03, r01, r00 };

            DateTime dt_start = DateTime.Now;
            for (int i = 0; i < dt_group.Rows.Count; i++)
            {
                double[] profits_group = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                for (int j = 1; j < dt_group.Columns.Count; j++)
                {
                    string group = dt_group.Rows[i][j].ToString();
                    if (!string.IsNullOrEmpty(group))
                    {
                        int bid_group = 0;
                        for (int k = 0; k < group.Length; k++)
                        {
                            int index = Convert.ToInt32(group.Substring(k, 1));
                            bid_group = bid_group + bits[index - 1];
                        }
                        for (int k = 0; k < group.Length; k++)
                        {
                            int index = Convert.ToInt32(group.Substring(k, 1));
                            profits_group[index - 1] = profits[index - 1] - count;
                            if (bid_group > 0)
                            {
                                if ((profits[index - 1] - bid_group) / bid_group >= 1.88) profits_group[index - 1] = profits[index - 1] + bid_group / 2.0 - count;
                            }
                        }
                    }
                }

                double max = 0;
                double min = 99999999;
                for (int l = 0; l < profits_group.Length; l++)
                {
                    if (profits_group[l] < min) min = profits_group[l];
                    if (profits_group[l] > max) max = profits_group[l];
                }

                if (min > result_min)
                {

                    result_group_index = i;
                    result_min = min;
                    result_max = max;
                    result_b33 = b33;
                    result_b31 = b31;
                    result_b30 = b30;
                    result_b13 = b13;
                    result_b11 = b11;
                    result_b10 = b10;
                    result_b03 = b03;
                    result_b01 = b01;
                    result_b00 = b00;
                    result_r33 = profits_group[0];
                    result_r31 = profits_group[1];
                    result_r30 = profits_group[2];
                    result_r13 = profits_group[3];
                    result_r11 = profits_group[4];
                    result_r10 = profits_group[5];
                    result_r03 = profits_group[6];
                    result_r01 = profits_group[7];
                    result_r00 = profits_group[8];
                }
            }
            DateTime dt_end = DateTime.Now;



            string group_info = "";
            for (int i = 1; i < dt_group.Columns.Count; i++)
            {
                if (!string.IsNullOrEmpty(dt_group.Rows[result_group_index][i].ToString()))
                {
                    group_info = group_info + "Group-" + i.ToString() + ":" + dt_group.Rows[result_group_index][i].ToString() + "  ";
                }

            }


            BsonDocument doc = new BsonDocument();
            doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
            doc.Add("type", "2-group-min");
            doc.Add("loop_count", "1");
            doc.Add("start_time1", start_time1);
            doc.Add("host1", host1);
            doc.Add("client1", client1);
            doc.Add("three1", three1.ToString("f2"));
            doc.Add("one1", one1.ToString("f2"));
            doc.Add("zero1", zero1.ToString("f2"));
            doc.Add("start_time2", start_time1);
            doc.Add("host2", host2);
            doc.Add("client2", client2);
            doc.Add("three2", three2.ToString("f2"));
            doc.Add("one2", one2.ToString("f2"));
            doc.Add("zero2", zero2.ToString("f2"));
            doc.Add("bid_count", count.ToString());
            doc.Add("total_bid_count", count.ToString());
            doc.Add("compute_count", "256");
            doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
            doc.Add("min_value", result_min.ToString("f4"));
            doc.Add("max_value", result_max.ToString("f4"));
            doc.Add("group_info", group_info);
            doc.Add("b33", result_b33.ToString());
            doc.Add("b31", result_b31.ToString());
            doc.Add("b30", result_b30.ToString());
            doc.Add("b13", result_b13.ToString());
            doc.Add("b11", result_b11.ToString());
            doc.Add("b10", result_b10.ToString());
            doc.Add("b03", result_b03.ToString());
            doc.Add("b01", result_b01.ToString());
            doc.Add("b00", result_b00.ToString());
            doc.Add("r33", result_r33.ToString("f4"));
            doc.Add("r31", result_r31.ToString("f4"));
            doc.Add("r30", result_r30.ToString("f4"));
            doc.Add("r13", result_r13.ToString("f4"));
            doc.Add("r11", result_r11.ToString("f4"));
            doc.Add("r10", result_r10.ToString("f4"));
            doc.Add("r03", result_r03.ToString("f4"));
            doc.Add("r01", result_r01.ToString("f4"));
            doc.Add("r00", result_r00.ToString("f4"));
            //MongoHelper.insert_bson("match", doc);
            return doc;

        }
        public BsonDocument get_doc_compute_normal_next(BsonDocument doc_last, int count,
                                  string start_time1, string host1, string client1, double three1, double one1, double zero1,
                                  string start_time2, string host2, string client2, double three2, double one2, double zero2)
        {

            StringBuilder builder = new StringBuilder();

            DateTime dt_start = DateTime.Now;
            Int64 step = 0;

            int last_result_count = Convert.ToInt16(doc_last["bid_count"].ToString());
            double last_result_r33 = Convert.ToDouble(doc_last["r33"].ToString());
            double last_result_r31 = Convert.ToDouble(doc_last["r31"].ToString());
            double last_result_r30 = Convert.ToDouble(doc_last["r30"].ToString());
            double last_result_r13 = Convert.ToDouble(doc_last["r13"].ToString());
            double last_result_r11 = Convert.ToDouble(doc_last["r11"].ToString());
            double last_result_r10 = Convert.ToDouble(doc_last["r10"].ToString());
            double last_result_r03 = Convert.ToDouble(doc_last["r03"].ToString());
            double last_result_r01 = Convert.ToDouble(doc_last["r01"].ToString());
            double last_result_r00 = Convert.ToDouble(doc_last["r00"].ToString());


            double result_min = -1000;
            double result_max = 0;
            double result_b33 = 0;
            double result_b31 = 0;
            double result_b30 = 0;
            double result_b13 = 0;
            double result_b11 = 0;
            double result_b10 = 0;
            double result_b03 = 0;
            double result_b01 = 0;
            double result_b00 = 0;
            double result_r33 = 0;
            double result_r31 = 0;
            double result_r30 = 0;
            double result_r13 = 0;
            double result_r11 = 0;
            double result_r10 = 0;
            double result_r03 = 0;
            double result_r01 = 0;
            double result_r00 = 0;




            for (int b33 = 0; b33 <= count; b33++)
            {
                for (int b31 = 0; b31 <= count - b33; b31++)
                {
                    for (int b30 = 0; b30 <= count - b33 - b31; b30++)
                    {
                        for (int b13 = 0; b13 <= count - b33 - b31 - b30; b13++)
                        {
                            for (int b11 = 0; b11 <= count - b33 - b31 - b30 - b13; b11++)
                            {
                                for (int b10 = 0; b10 <= count - b33 - b31 - b30 - b13 - b11; b10++)
                                {
                                    for (int b03 = 0; b03 <= count - b33 - b31 - b30 - b13 - b11 - b10; b03++)
                                    {
                                        for (int b01 = 0; b01 <= count - b33 - b31 - b30 - b13 - b11 - b10 - b03; b01++)
                                        {
                                            int b00 = count - b33 - b31 - b30 - b13 - b11 - b10 - b03 - b01;

                                            double r33 = 0;
                                            double r31 = 0;
                                            double r30 = 0;
                                            double r13 = 0;
                                            double r11 = 0;
                                            double r10 = 0;
                                            double r03 = 0;
                                            double r01 = 0;
                                            double r00 = 0;


                                            r33 = get_max_profit("33", b33, count, three1, three2) + last_result_r33;
                                            r31 = get_max_profit("31", b31, count, three1, one2) + last_result_r31;
                                            r30 = get_max_profit("30", b30, count, three1, zero2) + last_result_r30;
                                            r13 = get_max_profit("33", b13, count, one1, three2) + last_result_r13;
                                            r11 = get_max_profit("31", b11, count, one1, one2) + last_result_r11;
                                            r10 = get_max_profit("30", b10, count, one1, zero2) + last_result_r10;
                                            r03 = get_max_profit("03", b03, count, zero1, three2) + last_result_r03;
                                            r01 = get_max_profit("01", b01, count, zero1, one2) + last_result_r01;
                                            r00 = get_max_profit("00", b00, count, zero1, zero2) + last_result_r00;

                                            double max = 0;
                                            double min = 99999999;

                                            if (r33 > max) max = r33;
                                            if (r33 < min) min = r33;
                                            if (r31 > max) max = r31;
                                            if (r31 < min) min = r31;
                                            if (r30 > max) max = r30;
                                            if (r30 < min) min = r30;
                                            if (r13 > max) max = r13;
                                            if (r13 < min) min = r13;
                                            if (r11 > max) max = r11;
                                            if (r11 < min) min = r11;
                                            if (r10 > max) max = r10;
                                            if (r10 < min) min = r10;
                                            if (r03 > max) max = r03;
                                            if (r03 < min) min = r03;
                                            if (r01 > max) max = r01;
                                            if (r01 < min) min = r01;
                                            if (r00 > max) max = r00;
                                            if (r00 < min) min = r00;

                                            if (min > result_min)
                                            {
                                                result_min = min;
                                                result_max = max;
                                                result_b33 = b33;
                                                result_b31 = b31;
                                                result_b30 = b30;
                                                result_b13 = b13;
                                                result_b11 = b11;
                                                result_b10 = b10;
                                                result_b03 = b03;
                                                result_b01 = b01;
                                                result_b00 = b00;
                                                result_r33 = r33;
                                                result_r31 = r31;
                                                result_r30 = r30;
                                                result_r13 = r13;
                                                result_r11 = r11;
                                                result_r10 = r10;
                                                result_r03 = r03;
                                                result_r01 = r01;
                                                result_r00 = r00;
                                            }

                                            step = step + 1;
                                        }

                                    }

                                }

                            }

                        }

                    }


                }

            }
            DateTime dt_end = DateTime.Now;
            BsonDocument doc = new BsonDocument();
            doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
            doc.Add("type", "2-normal-next-min");
            doc.Add("loop_count", (doc_last["loop_count"].ToInt32() + 1).ToString());
            doc.Add("last_doc_id", doc_last["doc_id"].ToString());
            doc.Add("start_time1", start_time1);
            doc.Add("host1", host1);
            doc.Add("client1", client1);
            doc.Add("three1", three1.ToString("f2"));
            doc.Add("one1", one1.ToString("f2"));
            doc.Add("zero1", zero1.ToString("f2"));
            doc.Add("start_time2", start_time1);
            doc.Add("host2", host2);
            doc.Add("client2", client2);
            doc.Add("three2", three2.ToString("f2"));
            doc.Add("one2", one2.ToString("f2"));
            doc.Add("zero2", zero2.ToString("f2"));
            doc.Add("bid_count", count.ToString());
            doc.Add("total_bid_count", (Convert.ToInt32(doc_last["total_bid_count"].ToString()) + count).ToString());
            doc.Add("compute_count", step.ToString());
            doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
            doc.Add("min_value", result_min.ToString("f4"));
            doc.Add("max_value", result_max.ToString("f4"));
            doc.Add("b33", result_b33.ToString());
            doc.Add("b31", result_b31.ToString());
            doc.Add("b30", result_b30.ToString());
            doc.Add("b13", result_b13.ToString());
            doc.Add("b11", result_b11.ToString());
            doc.Add("b10", result_b10.ToString());
            doc.Add("b03", result_b03.ToString());
            doc.Add("b01", result_b01.ToString());
            doc.Add("b00", result_b00.ToString());
            doc.Add("r33", result_r33.ToString("f4"));
            doc.Add("r31", result_r31.ToString("f4"));
            doc.Add("r30", result_r30.ToString("f4"));
            doc.Add("r13", result_r13.ToString("f4"));
            doc.Add("r11", result_r11.ToString("f4"));
            doc.Add("r10", result_r10.ToString("f4"));
            doc.Add("r03", result_r03.ToString("f4"));
            doc.Add("r01", result_r01.ToString("f4"));
            doc.Add("r00", result_r00.ToString("f4"));
            // MongoHelper.insert_bson("match", doc);
            return doc;
        }
        public BsonDocument get_doc_compute_group_next(BsonDocument doc_last, BsonDocument doc_input)
        {

            int last_result_count = Convert.ToInt16(doc_last["bid_count"].ToString());
            double last_result_r33 = Convert.ToDouble(doc_last["r33"].ToString());
            double last_result_r31 = Convert.ToDouble(doc_last["r31"].ToString());
            double last_result_r30 = Convert.ToDouble(doc_last["r30"].ToString());
            double last_result_r13 = Convert.ToDouble(doc_last["r13"].ToString());
            double last_result_r11 = Convert.ToDouble(doc_last["r11"].ToString());
            double last_result_r10 = Convert.ToDouble(doc_last["r10"].ToString());
            double last_result_r03 = Convert.ToDouble(doc_last["r03"].ToString());
            double last_result_r01 = Convert.ToDouble(doc_last["r01"].ToString());
            double last_result_r00 = Convert.ToDouble(doc_last["r00"].ToString());


            int count = Convert.ToInt16(doc_input["bid_count"].ToString());
            string start_time1 = doc_input["start_time1"].ToString();
            string host1 = doc_input["host1"].ToString();
            string client1 = doc_input["client1"].ToString();
            double three1 = Convert.ToDouble(doc_input["three1"].ToString());
            double one1 = Convert.ToDouble(doc_input["one1"].ToString());
            double zero1 = Convert.ToDouble(doc_input["zero1"].ToString());
            string start_time2 = doc_input["start_time2"].ToString();
            string host2 = doc_input["host2"].ToString();
            string client2 = doc_input["client2"].ToString();
            double three2 = Convert.ToDouble(doc_input["three2"].ToString());
            double one2 = Convert.ToDouble(doc_input["one2"].ToString());
            double zero2 = Convert.ToDouble(doc_input["zero2"].ToString());
            int b33 = Convert.ToInt16(doc_input["b33"].ToString());
            int b31 = Convert.ToInt16(doc_input["b31"].ToString());
            int b30 = Convert.ToInt16(doc_input["b30"].ToString());
            int b13 = Convert.ToInt16(doc_input["b13"].ToString());
            int b11 = Convert.ToInt16(doc_input["b11"].ToString());
            int b10 = Convert.ToInt16(doc_input["b10"].ToString());
            int b03 = Convert.ToInt16(doc_input["b03"].ToString());
            int b01 = Convert.ToInt16(doc_input["b01"].ToString());
            int b00 = Convert.ToInt16(doc_input["b00"].ToString());


            StringBuilder builder = new StringBuilder();

            int result_group_index = 0;
            double result_min = -1000;
            double result_max = 0;
            double result_b33 = 0;
            double result_b31 = 0;
            double result_b30 = 0;
            double result_b13 = 0;
            double result_b11 = 0;
            double result_b10 = 0;
            double result_b03 = 0;
            double result_b01 = 0;
            double result_b00 = 0;
            double result_r33 = 0;
            double result_r31 = 0;
            double result_r30 = 0;
            double result_r13 = 0;
            double result_r11 = 0;
            double result_r10 = 0;
            double result_r03 = 0;
            double result_r01 = 0;
            double result_r00 = 0;

            double r33 = 0;
            double r31 = 0;
            double r30 = 0;
            double r13 = 0;
            double r11 = 0;
            double r10 = 0;
            double r03 = 0;
            double r01 = 0;
            double r00 = 0;

            r33 = b33 * three1 * three2;
            r31 = b31 * three1 * one2;
            r30 = b30 * three1 * zero2;
            r13 = b13 * one1 * three2;
            r11 = b11 * one1 * one2;
            r10 = b10 * one1 * zero2;
            r03 = b03 * zero1 * three2;
            r01 = b01 * zero1 * one2;
            r00 = b00 * zero1 * zero2;

            int[] bits = new int[] { b33, b31, b30, b13, b11, b10, b03, b01, b00 };
            double[] profits = new double[] { r33, r31, r30, r13, r11, r10, r03, r01, r00 };

            DateTime dt_start = DateTime.Now;
            for (int i = 0; i < dt_group.Rows.Count; i++)
            {
                double[] profits_group = new double[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                double[] last_profits_group = new double[]{last_result_r33,last_result_r31,last_result_r30,
                                                          last_result_r13,last_result_r11,last_result_r10,
                                                          last_result_r03,last_result_r01,last_result_r00};
                for (int j = 1; j < dt_group.Columns.Count; j++)
                {
                    string group = dt_group.Rows[i][j].ToString();
                    if (!string.IsNullOrEmpty(group))
                    {
                        int bid_group = 0;
                        for (int k = 0; k < group.Length; k++)
                        {
                            int index = Convert.ToInt32(group.Substring(k, 1));
                            bid_group = bid_group + bits[index - 1];
                        }
                        for (int k = 0; k < group.Length; k++)
                        {
                            int index = Convert.ToInt32(group.Substring(k, 1));
                            profits_group[index - 1] = profits[index - 1] - count + last_profits_group[index - 1];
                            if (bid_group > 0)
                            {
                                if ((profits[index - 1] - bid_group) / bid_group >= 1.88) profits_group[index - 1] = profits[index - 1] + bid_group / 2.0 - count + last_profits_group[index - 1];
                            }
                        }
                    }
                }

                double max = 0;
                double min = 99999999;
                for (int l = 0; l < profits_group.Length; l++)
                {
                    if (profits_group[l] < min) min = profits_group[l];
                    if (profits_group[l] > max) max = profits_group[l];
                }

                if (min > result_min)
                {

                    result_group_index = i;
                    result_min = min;
                    result_max = max;
                    result_b33 = b33;
                    result_b31 = b31;
                    result_b30 = b30;
                    result_b13 = b13;
                    result_b11 = b11;
                    result_b10 = b10;
                    result_b03 = b03;
                    result_b01 = b01;
                    result_b00 = b00;
                    result_r33 = profits_group[0];
                    result_r31 = profits_group[1];
                    result_r30 = profits_group[2];
                    result_r13 = profits_group[3];
                    result_r11 = profits_group[4];
                    result_r10 = profits_group[5];
                    result_r03 = profits_group[6];
                    result_r01 = profits_group[7];
                    result_r00 = profits_group[8];
                }
            }
            DateTime dt_end = DateTime.Now;



            string group_info = "";
            for (int i = 1; i < dt_group.Columns.Count; i++)
            {
                if (!string.IsNullOrEmpty(dt_group.Rows[result_group_index][i].ToString()))
                {
                    group_info = group_info + "Group-" + i.ToString() + ":" + dt_group.Rows[result_group_index][i].ToString() + "  ";
                }

            }


            BsonDocument doc = new BsonDocument();
            doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
            doc.Add("type", "2-group-next-min");
            doc.Add("loop_count", (doc_last["loop_count"].ToInt32() + 1).ToString());
            doc.Add("last_doc_id", doc_last["doc_id"].ToString());
            doc.Add("start_time1", start_time1);
            doc.Add("host1", host1);
            doc.Add("client1", client1);
            doc.Add("three1", three1.ToString("f2"));
            doc.Add("one1", one1.ToString("f2"));
            doc.Add("zero1", zero1.ToString("f2"));
            doc.Add("start_time2", start_time1);
            doc.Add("host2", host2);
            doc.Add("client2", client2);
            doc.Add("three2", three2.ToString("f2"));
            doc.Add("one2", one2.ToString("f2"));
            doc.Add("zero2", zero2.ToString("f2"));
            doc.Add("bid_count", count.ToString());
            doc.Add("total_bid_count", (Convert.ToInt32(doc_last["total_bid_count"].ToString()) + count).ToString());
            doc.Add("compute_count", "256");
            doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
            doc.Add("min_value", result_min.ToString("f4"));
            doc.Add("max_value", result_max.ToString("f4"));
            doc.Add("group_info", group_info);
            doc.Add("b33", result_b33.ToString());
            doc.Add("b31", result_b31.ToString());
            doc.Add("b30", result_b30.ToString());
            doc.Add("b13", result_b13.ToString());
            doc.Add("b11", result_b11.ToString());
            doc.Add("b10", result_b10.ToString());
            doc.Add("b03", result_b03.ToString());
            doc.Add("b01", result_b01.ToString());
            doc.Add("b00", result_b00.ToString());
            doc.Add("r33", result_r33.ToString("f4"));
            doc.Add("r31", result_r31.ToString("f4"));
            doc.Add("r30", result_r30.ToString("f4"));
            doc.Add("r13", result_r13.ToString("f4"));
            doc.Add("r11", result_r11.ToString("f4"));
            doc.Add("r10", result_r10.ToString("f4"));
            doc.Add("r03", result_r03.ToString("f4"));
            doc.Add("r01", result_r01.ToString("f4"));
            doc.Add("r00", result_r00.ToString("f4"));
            //MongoHelper.insert_bson("match", doc);
            return doc;

        }


        public BsonDocument get_doc_compute_range(Int64 range_min, Int64 range_max,
                           string start_time1, string host1, string client1, double three1, double one1, double zero1,
                           string start_time2, string host2, string client2, double three2, double one2, double zero2)
        {



            StringBuilder builder = new StringBuilder();
            DateTime dt_start = DateTime.Now;
            Int64 step = 0;

            double result_min = -99999999;
            double result_persent = -99999999;
            double result_max = 0;
            double result_b33 = 0;
            double result_b31 = 0;
            double result_b30 = 0;
            double result_b13 = 0;
            double result_b11 = 0;
            double result_b10 = 0;
            double result_b03 = 0;
            double result_b01 = 0;
            double result_b00 = 0;
            double result_r33 = 0;
            double result_r31 = 0;
            double result_r30 = 0;
            double result_r13 = 0;
            double result_r11 = 0;
            double result_r10 = 0;
            double result_r03 = 0;
            double result_r01 = 0;
            double result_r00 = 0;

            int count = 0;

            for (Int64 range = range_min; range <= range_max; range++)
            {

                string str_range = range.ToString();

                int b33 = Convert.ToInt32(str_range.Substring(0, 1));
                int b31 = Convert.ToInt32(str_range.Substring(1, 1));
                int b30 = Convert.ToInt32(str_range.Substring(2, 1));
                int b13 = Convert.ToInt32(str_range.Substring(3, 1));
                int b11 = Convert.ToInt32(str_range.Substring(4, 1));
                int b10 = Convert.ToInt32(str_range.Substring(5, 1));
                int b03 = Convert.ToInt32(str_range.Substring(6, 1));
                int b01 = Convert.ToInt32(str_range.Substring(7, 1));
                int b00 = Convert.ToInt32(str_range.Substring(8, 1));
                count = b33 + b31 + b30 + b13 + b11 + b10 + b03 + b01 + b00;

                double r33 = 0;
                double r31 = 0;
                double r30 = 0;
                double r13 = 0;
                double r11 = 0;
                double r10 = 0;
                double r03 = 0;
                double r01 = 0;
                double r00 = 0;


                r33 = b33 * three1 * three2 - count;
                r31 = b31 * three1 * one2 - count;
                r30 = b30 * three1 * zero2 - count;
                r13 = b13 * one1 * three2 - count;
                r11 = b11 * one1 * one2 - count;
                r10 = b10 * one1 * zero2 - count;
                r03 = b03 * zero1 * three2 - count;
                r01 = b01 * zero1 * one2 - count;
                r00 = b01 * zero1 * zero2 - count;

                //r33 = get_max_profit("33", b33, count, three1, three2);
                //r31 = get_max_profit("31", b31, count, three1, one2);
                //r30 = get_max_profit("30", b30, count, three1, zero2);
                //r13 = get_max_profit("33", b13, count, one1, three2);
                //r11 = get_max_profit("31", b11, count, one1, one2);
                //r10 = get_max_profit("30", b10, count, one1, zero2);
                //r03 = get_max_profit("03", b03, count, zero1, three2);
                //r01 = get_max_profit("01", b01, count, zero1, one2);
                //r00 = get_max_profit("00", b00, count, zero1, zero2);

                double max = -9999999;
                double min = 99999999;


                if (r33 > max) max = r33;
                if (r33 < min) min = r33;
                if (r31 > max) max = r31;
                if (r31 < min) min = r31;
                if (r30 > max) max = r30;
                if (r30 < min) min = r30;
                if (r13 > max) max = r13;
                if (r13 < min) min = r13;
                if (r11 > max) max = r11;
                if (r11 < min) min = r11;
                if (r10 > max) max = r10;
                if (r10 < min) min = r10;
                if (r03 > max) max = r03;
                if (r03 < min) min = r03;
                if (r01 > max) max = r01;
                if (r01 < min) min = r01;
                if (r00 > max) max = r00;
                if (r00 < min) min = r00;

                double persent = min / count;

                if (persent > result_persent)
                {
                    result_persent = persent;
                    result_min = min;
                    result_max = max;
                    result_b33 = b33;
                    result_b31 = b31;
                    result_b30 = b30;
                    result_b13 = b13;
                    result_b11 = b11;
                    result_b10 = b10;
                    result_b03 = b03;
                    result_b01 = b01;
                    result_b00 = b00;
                    result_r33 = r33;
                    result_r31 = r31;
                    result_r30 = r30;
                    result_r13 = r13;
                    result_r11 = r11;
                    result_r10 = r10;
                    result_r03 = r03;
                    result_r01 = r01;
                    result_r00 = r00;
                }
                step = step + 1;
            }


            DateTime dt_end = DateTime.Now;
            BsonDocument doc = new BsonDocument();
            doc.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
            doc.Add("type", "2-normal-min");
            doc.Add("loop_count", "1");
            doc.Add("start_time1", start_time1);
            doc.Add("host1", host1);
            doc.Add("client1", client1);
            doc.Add("three1", three1.ToString("f2"));
            doc.Add("one1", one1.ToString("f2"));
            doc.Add("zero1", zero1.ToString("f2"));
            doc.Add("start_time2", start_time1);
            doc.Add("host2", host2);
            doc.Add("client2", client2);
            doc.Add("three2", three2.ToString("f2"));
            doc.Add("one2", one2.ToString("f2"));
            doc.Add("zero2", zero2.ToString("f2"));
            doc.Add("bid_count", count.ToString());
            doc.Add("total_bid_count", count.ToString());
            doc.Add("compute_count", step.ToString());
            doc.Add("use_second", (dt_end - dt_start).TotalSeconds.ToString());
            doc.Add("min_value", result_min.ToString("f4"));
            doc.Add("max_value", result_max.ToString("f4"));
            doc.Add("b33", result_b33.ToString());
            doc.Add("b31", result_b31.ToString());
            doc.Add("b30", result_b30.ToString());
            doc.Add("b13", result_b13.ToString());
            doc.Add("b11", result_b11.ToString());
            doc.Add("b10", result_b10.ToString());
            doc.Add("b03", result_b03.ToString());
            doc.Add("b01", result_b01.ToString());
            doc.Add("b00", result_b00.ToString());
            doc.Add("r33", result_r33.ToString("f4"));
            doc.Add("r31", result_r31.ToString("f4"));
            doc.Add("r30", result_r30.ToString("f4"));
            doc.Add("r13", result_r13.ToString("f4"));
            doc.Add("r11", result_r11.ToString("f4"));
            doc.Add("r10", result_r10.ToString("f4"));
            doc.Add("r03", result_r03.ToString("f4"));
            doc.Add("r01", result_r01.ToString("f4"));
            doc.Add("r00", result_r00.ToString("f4"));
            // MongoHelper.insert_bson("match", doc);
            return doc;
        }

        public double get_max_profit(string type, int count, int total, double offer_a, double offer_b)
        {
            double temp = 0;
            double profit = -99999999;

            temp = count * offer_a * offer_b - total;
            if (temp > profit) profit = temp;

            //temp = count * offer_a * offer_b * 1.208 - total;
            //if (temp > profit) profit = temp;

            //if (offer_a * offer_b * 1 >= 1.88) temp = count * offer_a * offer_b + (count * 0.5) - total;
            //if (temp > profit) profit = temp;

            return profit;
        }
        public string get_info_from_doc(BsonDocument doc)
        {
            string result = "";
            switch (doc["type"].ToString())
            {
                case "2-normal-min":
                    result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine + "loop_count:" + doc["loop_count"].ToInt32() + Environment.NewLine +
                     doc["start_time1"].ToString() + "      " + doc["host1"].ToString().PadRight(10, ' ') + doc["client1"].ToString().PadRight(10, ' ') +
                     doc["three1"].ToString().PadRight(10, ' ') +
                     doc["one1"].ToString().PadRight(10, ' ') +
                     doc["zero1"].ToString().PadRight(10, ' ') + Environment.NewLine +
                     doc["start_time1"].ToString() + "      " + doc["host2"].ToString().PadRight(10, ' ') + doc["client2"].ToString().PadRight(10, ' ') +
                     doc["three2"].ToString().PadRight(10, ' ') +
                     doc["one2"].ToString().PadRight(10, ' ') +
                     doc["zero2"].ToString().PadRight(10, ' ') + Environment.NewLine +
                    "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
                    "total bid count:" + doc["total_bid_count"].ToString() + Environment.NewLine +
                    "compute count: " + doc["compute_count"].ToString() + Environment.NewLine +
                    "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
                    "return value: " + doc["min_value"].ToString() + "~" + doc["max_value"].ToString() + Environment.NewLine +
                    "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["total_bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
                    "detail infomation:" + Environment.NewLine +
                    "B33: " + doc["b33"].ToString().PadRight(15, ' ') +
                    "B31: " + doc["b31"].ToString().PadRight(15, ' ') +
                    "B30: " + doc["b30"].ToString().PadRight(15, ' ') + Environment.NewLine +
                    "B13: " + doc["b13"].ToString().PadRight(15, ' ') +
                    "B11: " + doc["b11"].ToString().PadRight(15, ' ') +
                    "B10: " + doc["b10"].ToString().PadRight(15, ' ') + Environment.NewLine +
                    "B03: " + doc["b03"].ToString().PadRight(15, ' ') +
                    "B01: " + doc["b01"].ToString().PadRight(15, ' ') +
                    "B00: " + doc["b00"].ToString().PadRight(15, ' ') + Environment.NewLine +
                    "R33: " + doc["r33"].ToString().PadRight(15, ' ') +
                    "R31: " + doc["r31"].ToString().PadRight(15, ' ') +
                    "R30: " + doc["r30"].ToString().PadRight(15, ' ') + Environment.NewLine +
                    "R13: " + doc["r13"].ToString().PadRight(15, ' ') +
                    "R11: " + doc["r11"].ToString().PadRight(15, ' ') +
                    "R10: " + doc["r10"].ToString().PadRight(15, ' ') + Environment.NewLine +
                    "R03: " + doc["r03"].ToString().PadRight(15, ' ') +
                    "R01: " + doc["r01"].ToString().PadRight(15, ' ') +
                    "R00: " + doc["r00"].ToString().PadRight(15, ' ') + Environment.NewLine + Environment.NewLine;
                    break;
                case "2-group-min":
                    result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine + "loop_count:" + doc["loop_count"].ToInt32() + Environment.NewLine +
                doc["start_time1"].ToString() + "      " + doc["host1"].ToString().PadRight(10, ' ') + doc["client1"].ToString().PadRight(10, ' ') +
                doc["three1"].ToString().PadRight(10, ' ') +
                doc["one1"].ToString().PadRight(10, ' ') +
                doc["zero1"].ToString().PadRight(10, ' ') + Environment.NewLine +
                doc["start_time1"].ToString() + "      " + doc["host2"].ToString().PadRight(10, ' ') + doc["client2"].ToString().PadRight(10, ' ') +
                doc["three2"].ToString().PadRight(10, ' ') +
                doc["one2"].ToString().PadRight(10, ' ') +
                doc["zero2"].ToString().PadRight(10, ' ') + Environment.NewLine +
               "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
               "total bid count:" + doc["total_bid_count"].ToString() + Environment.NewLine +
               "compute count: " + doc["compute_count"].ToString() + Environment.NewLine +
               "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
               "return value: " + doc["min_value"].ToString() + "~" + doc["max_value"].ToString() + Environment.NewLine +
               "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["total_bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
               "group information: " + doc["group_info"].ToString() + Environment.NewLine +
               "detail infomation:" + Environment.NewLine +
               "B33: " + doc["b33"].ToString().PadRight(15, ' ') +
               "B31: " + doc["b31"].ToString().PadRight(15, ' ') +
               "B30: " + doc["b30"].ToString().PadRight(15, ' ') + Environment.NewLine +
               "B13: " + doc["b13"].ToString().PadRight(15, ' ') +
               "B11: " + doc["b11"].ToString().PadRight(15, ' ') +
               "B10: " + doc["b10"].ToString().PadRight(15, ' ') + Environment.NewLine +
               "B03: " + doc["b03"].ToString().PadRight(15, ' ') +
               "B01: " + doc["b01"].ToString().PadRight(15, ' ') +
               "B00: " + doc["b00"].ToString().PadRight(15, ' ') + Environment.NewLine +
               "R33: " + doc["r33"].ToString().PadRight(15, ' ') +
               "R31: " + doc["r31"].ToString().PadRight(15, ' ') +
               "R30: " + doc["r30"].ToString().PadRight(15, ' ') + Environment.NewLine +
               "R13: " + doc["r13"].ToString().PadRight(15, ' ') +
               "R11: " + doc["r11"].ToString().PadRight(15, ' ') +
               "R10: " + doc["r10"].ToString().PadRight(15, ' ') + Environment.NewLine +
               "R03: " + doc["r03"].ToString().PadRight(15, ' ') +
               "R01: " + doc["r01"].ToString().PadRight(15, ' ') +
               "R00: " + doc["r00"].ToString().PadRight(15, ' ') + Environment.NewLine + Environment.NewLine;
                    break;
                case "2-normal-next-min":
                    result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine + "loop_count:" + doc["loop_count"].ToInt32() + Environment.NewLine +
                   doc["start_time1"].ToString() + "      " + doc["host1"].ToString().PadRight(10, ' ') + doc["client1"].ToString().PadRight(10, ' ') +
                   doc["three1"].ToString().PadRight(10, ' ') +
                   doc["one1"].ToString().PadRight(10, ' ') +
                   doc["zero1"].ToString().PadRight(10, ' ') + Environment.NewLine +
                   doc["start_time1"].ToString() + "      " + doc["host2"].ToString().PadRight(10, ' ') + doc["client2"].ToString().PadRight(10, ' ') +
                   doc["three2"].ToString().PadRight(10, ' ') +
                   doc["one2"].ToString().PadRight(10, ' ') +
                   doc["zero2"].ToString().PadRight(10, ' ') + Environment.NewLine +
                  "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
                  "total bid count:" + doc["total_bid_count"].ToString() + Environment.NewLine +
                  "compute count: " + doc["compute_count"].ToString() + Environment.NewLine +
                  "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
                  "return value: " + doc["min_value"].ToString() + "~" + doc["max_value"].ToString() + Environment.NewLine +
                  "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["total_bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
                    "detail infomation:" + Environment.NewLine +
                     "B33: " + doc["b33"].ToString().PadRight(15, ' ') +
                     "B31: " + doc["b31"].ToString().PadRight(15, ' ') +
                     "B30: " + doc["b30"].ToString().PadRight(15, ' ') + Environment.NewLine +
                     "B13: " + doc["b13"].ToString().PadRight(15, ' ') +
                     "B11: " + doc["b11"].ToString().PadRight(15, ' ') +
                     "B10: " + doc["b10"].ToString().PadRight(15, ' ') + Environment.NewLine +
                     "B03: " + doc["b03"].ToString().PadRight(15, ' ') +
                     "B01: " + doc["b01"].ToString().PadRight(15, ' ') +
                     "B00: " + doc["b00"].ToString().PadRight(15, ' ') + Environment.NewLine +
                     "R33: " + doc["r33"].ToString().PadRight(15, ' ') +
                     "R31: " + doc["r31"].ToString().PadRight(15, ' ') +
                     "R30: " + doc["r30"].ToString().PadRight(15, ' ') + Environment.NewLine +
                     "R13: " + doc["r13"].ToString().PadRight(15, ' ') +
                     "R11: " + doc["r11"].ToString().PadRight(15, ' ') +
                     "R10: " + doc["r10"].ToString().PadRight(15, ' ') + Environment.NewLine +
                     "R03: " + doc["r03"].ToString().PadRight(15, ' ') +
                     "R01: " + doc["r01"].ToString().PadRight(15, ' ') +
                     "R00: " + doc["r00"].ToString().PadRight(15, ' ') + Environment.NewLine + Environment.NewLine;
                    break;
                case "2-group-second-min":
                    result = "type:" + doc["type"].ToString() + "  doc id:" + doc["doc_id"].ToString() + Environment.NewLine + "loop_count:" + doc["loop_count"].ToInt32() + Environment.NewLine +
                doc["start_time1"].ToString() + "      " + doc["host1"].ToString().PadRight(10, ' ') + doc["client1"].ToString().PadRight(10, ' ') +
                doc["three1"].ToString().PadRight(10, ' ') +
                doc["one1"].ToString().PadRight(10, ' ') +
                doc["zero1"].ToString().PadRight(10, ' ') + Environment.NewLine +
                doc["start_time1"].ToString() + "      " + doc["host2"].ToString().PadRight(10, ' ') + doc["client2"].ToString().PadRight(10, ' ') +
                doc["three2"].ToString().PadRight(10, ' ') +
                doc["one2"].ToString().PadRight(10, ' ') +
                doc["zero2"].ToString().PadRight(10, ' ') + Environment.NewLine +
               "bid count:" + doc["bid_count"].ToString() + Environment.NewLine +
                  "total bid count:" + doc["total_bid_count"].ToString() + Environment.NewLine +
                  "compute count: " + doc["compute_count"].ToString() + Environment.NewLine +
               "use seconds: " + doc["use_second"].ToString() + Environment.NewLine +
               "return value: " + doc["min_value"].ToString() + "~" + doc["max_value"].ToString() + Environment.NewLine +
              "return persent: " + (Convert.ToDouble(doc["min_value"].ToString()) / Convert.ToDouble(doc["total_bid_count"].ToString()) * 100).ToString("f6") + "%" + Environment.NewLine +
               "group information: " + doc["group_info"].ToString() + Environment.NewLine +
               "detail infomation:" + Environment.NewLine +
               "B33: " + doc["b33"].ToString().PadRight(15, ' ') +
               "B31: " + doc["b31"].ToString().PadRight(15, ' ') +
               "B30: " + doc["b30"].ToString().PadRight(15, ' ') + Environment.NewLine +
               "B13: " + doc["b13"].ToString().PadRight(15, ' ') +
               "B11: " + doc["b11"].ToString().PadRight(15, ' ') +
               "B10: " + doc["b10"].ToString().PadRight(15, ' ') + Environment.NewLine +
               "B03: " + doc["b03"].ToString().PadRight(15, ' ') +
               "B01: " + doc["b01"].ToString().PadRight(15, ' ') +
               "B00: " + doc["b00"].ToString().PadRight(15, ' ') + Environment.NewLine +
               "R33: " + doc["r33"].ToString().PadRight(15, ' ') +
               "R31: " + doc["r31"].ToString().PadRight(15, ' ') +
               "R30: " + doc["r30"].ToString().PadRight(15, ' ') + Environment.NewLine +
               "R13: " + doc["r13"].ToString().PadRight(15, ' ') +
               "R11: " + doc["r11"].ToString().PadRight(15, ' ') +
               "R10: " + doc["r10"].ToString().PadRight(15, ' ') + Environment.NewLine +
               "R03: " + doc["r03"].ToString().PadRight(15, ' ') +
               "R01: " + doc["r01"].ToString().PadRight(15, ' ') +
               "R00: " + doc["r00"].ToString().PadRight(15, ' ') + Environment.NewLine + Environment.NewLine;
                    break;
                default:
                    break;
            }
            return result;
        }










    }
}
