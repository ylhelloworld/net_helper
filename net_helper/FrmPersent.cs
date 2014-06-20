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
    public partial class FrmPersent : Form
    {
        DataTable dt_condition = new DataTable();
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
        private void txt_compute_TextChanged(object sender, EventArgs e)
        {
            this.txt_compute.SelectionStart = this.txt_compute.TextLength;
            this.txt_compute.ScrollToCaret();
        }

        public void bind_data()
        {

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



            string sql = " select *" +
                        " from win" +
                        " where start_time>'{0}'" +
                        " order by start_time,website,host,client,timespan";
            sql = string.Format(sql, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

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

        private void btn_compute_Click(object sender, EventArgs e)
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

            if (dt.Rows.Count == 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {
                    this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine + Environment.NewLine +
                                            "-------------------------------------------------------------------------------" + Environment.NewLine +
                                            str_compute(Convert.ToInt32(txt_count.Text),
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
                    Application.DoEvents();

                }
            }
            this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine +
                                    "-------------------------------------------------------------------------------";
            MessageBox.Show("bingo!!!complete!!!");
        }

        private void btn_compute_group_Click(object sender, EventArgs e)
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

            if (dt.Rows.Count == 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {
                    this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine + Environment.NewLine +
                                            "-------------------------------------------------------------------------------" + Environment.NewLine +
                                            str_compute_into_group(Convert.ToInt32(txt_count.Text),
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
                    Application.DoEvents();

                }
            }
            this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine +
                                    "-------------------------------------------------------------------------------";
            MessageBox.Show("bingo!!!complete!!!");
        }


        private void btn_create_group_Click(object sender, EventArgs e)
        {

            //All Group
            int group1 = 0;
            StringBuilder sb = new StringBuilder();
            for (int i = 9; i <= 99; i++)
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

        public string str_compute_into_group(int count,
                                             string start_time1, string host1, string client1, double three1, double one1, double zero1,
                                             string start_time2, string host2, string client2, double three2, double one2, double zero2)
        {


            StringBuilder builder = new StringBuilder();

            DateTime dt_start = DateTime.Now;
            Int64 step = 0;


            string sql = "select * from temp_group2";
            DataTable dt_group = SQLServerHelper.get_table(sql);

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
                                                            if(bid_group>0)
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
                                                step = step + 1; 

                                            }


                                        }

                                    }

                                }

                            }

                        }

                    }


                }

            }

            string group_info = "";
            for (int i = 1; i < dt_group.Columns.Count; i++)
            {
                if (!string.IsNullOrEmpty(dt_group.Rows[result_group_index][i].ToString()))
                {
                    group_info = group_info + "Group " + i.ToString() + ":" + dt_group.Rows[result_group_index][i].ToString() + "  ";
                }

            }

            DateTime dt_end = DateTime.Now;
            return start_time1 + "      " + host1.PadRight(10, ' ') + client1.PadRight(10, ' ') +
                   three1.ToString("f2").PadRight(10, ' ') +
                   one1.ToString("f2").PadRight(10, ' ') +
                   zero1.ToString("f2").PadRight(10, ' ') + Environment.NewLine +
                   start_time2 + "      " + host2.PadRight(10, ' ') + client2.PadRight(10, ' ') +
                   three2.ToString("f2").PadRight(10, ' ') +
                   one2.ToString("f2").PadRight(10, ' ') +
                   zero2.ToString("f2").PadRight(10, ' ') + Environment.NewLine +
                  "bit count:" + count.ToString() + Environment.NewLine +
                  "total count: " + step.ToString() + Environment.NewLine +
                  "use seconds: " + (dt_end - dt_start).TotalSeconds.ToString() + Environment.NewLine +
                  "return value: " + result_min.ToString("f4") + "~" + result_max.ToString("f4") + Environment.NewLine +
                  "return persent: " + (result_min / count * 100).ToString("f6") + "%" + Environment.NewLine +
                  "group information: " + group_info + Environment.NewLine +
                  "detail infomation:" + Environment.NewLine +
                  "B33: " + result_b33.ToString().PadRight(15, ' ') +
                  "B31: " + result_b31.ToString().PadRight(15, ' ') +
                  "B30: " + result_b30.ToString().PadRight(15, ' ') + Environment.NewLine +
                  "B13: " + result_b13.ToString().PadRight(15, ' ') +
                  "B11: " + result_b11.ToString().PadRight(15, ' ') +
                  "B10: " + result_b10.ToString().PadRight(15, ' ') + Environment.NewLine +
                  "B03: " + result_b03.ToString().PadRight(15, ' ') +
                  "B01: " + result_b01.ToString().PadRight(15, ' ') +
                  "B00: " + result_b00.ToString().PadRight(15, ' ') + Environment.NewLine +
                  "R33: " + result_r33.ToString("f4").PadRight(15, ' ') +
                  "R31: " + result_r31.ToString("f4").PadRight(15, ' ') +
                  "R30: " + result_r30.ToString("f4").PadRight(15, ' ') + Environment.NewLine +
                  "R13: " + result_r13.ToString("f4").PadRight(15, ' ') +
                  "R11: " + result_r11.ToString("f4").PadRight(15, ' ') +
                  "R10: " + result_r10.ToString("f4").PadRight(15, ' ') + Environment.NewLine +
                  "R03: " + result_r03.ToString("f4").PadRight(15, ' ') +
                  "R01: " + result_r01.ToString("f4").PadRight(15, ' ') +
                  "R00: " + result_r00.ToString("f4").PadRight(15, ' ');

        }
        public string str_compute(int count,
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

            return start_time1 + "      " + host1.PadRight(10, ' ') + client1.PadRight(10, ' ') +
                   three1.ToString("f2").PadRight(10, ' ') +
                   one1.ToString("f2").PadRight(10, ' ') +
                   zero1.ToString("f2").PadRight(10, ' ') + Environment.NewLine +
                   start_time2 + "      " + host2.PadRight(10, ' ') + client2.PadRight(10, ' ') +
                   three2.ToString("f2").PadRight(10, ' ') +
                   one2.ToString("f2").PadRight(10, ' ') +
                   zero2.ToString("f2").PadRight(10, ' ') + Environment.NewLine +
                  "bit count:" + count.ToString() + Environment.NewLine +
                  "total count: " + step.ToString() + Environment.NewLine +
                  "use seconds: " + (dt_end - dt_start).TotalSeconds.ToString() + Environment.NewLine +
                  "return value: " + result_min.ToString("f4") + "~" + result_max.ToString("f4") + Environment.NewLine +
                  "return persent: " + (result_min / count * 100).ToString("f6") + "%" + Environment.NewLine +
                  "detail infomation:" + Environment.NewLine +
                  "B33: " + result_b33.ToString().PadRight(15, ' ') +
                  "B31: " + result_b31.ToString().PadRight(15, ' ') +
                  "B30: " + result_b30.ToString().PadRight(15, ' ') + Environment.NewLine +
                  "B13: " + result_b13.ToString().PadRight(15, ' ') +
                  "B11: " + result_b11.ToString().PadRight(15, ' ') +
                  "B10: " + result_b10.ToString().PadRight(15, ' ') + Environment.NewLine +
                  "B03: " + result_b03.ToString().PadRight(15, ' ') +
                  "B01: " + result_b01.ToString().PadRight(15, ' ') +
                  "B00: " + result_b00.ToString().PadRight(15, ' ') + Environment.NewLine +
                  "R33: " + result_r33.ToString("f4").PadRight(15, ' ') +
                  "R31: " + result_r31.ToString("f4").PadRight(15, ' ') +
                  "R30: " + result_r30.ToString("f4").PadRight(15, ' ') + Environment.NewLine +
                  "R13: " + result_r13.ToString("f4").PadRight(15, ' ') +
                  "R11: " + result_r11.ToString("f4").PadRight(15, ' ') +
                  "R10: " + result_r10.ToString("f4").PadRight(15, ' ') + Environment.NewLine +
                  "R03: " + result_r03.ToString("f4").PadRight(15, ' ') +
                  "R01: " + result_r01.ToString("f4").PadRight(15, ' ') +
                  "R00: " + result_r00.ToString("f4").PadRight(15, ' ');

        }
        public double get_max_profit(string type, int count, int total, double offer_a, double offer_b)
        {
            double temp = 0;
            double profit = -99999999;

            temp = count * offer_a * offer_b - total;
            if (temp > profit) profit = temp;

            //temp = count * offer_a * offer_b * 1.206 - total;
            //if (temp > profit) profit = temp;

            //if (offer_a * offer_b * 1 >= 1.88) temp = count * offer_a * offer_b + (count * 0.5) - total;
            //if (temp > profit) profit = temp;

            return profit;
        } 



    }
}
