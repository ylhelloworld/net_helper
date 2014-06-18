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
                    row_new["zero"] =row.Cells["zero"].Value.ToString();
                    dt.Rows.Add(row_new);
                } 
            }

            if (dt.Rows.Count == 0) return;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = i + 1; j < dt.Rows.Count; j++)
                {
                    this.txt_compute.Text = this.txt_compute.Text + Environment.NewLine   +Environment.NewLine +
                                            "-------------------------------------------------------------------------------"+Environment.NewLine+
                                            compute_into_txt(Convert.ToInt32(txt_count.Text),
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
            this.txt_compute.Text = this.txt_compute.Text +Environment.NewLine+
                                    "-------------------------------------------------------------------------------";
            MessageBox.Show("bingo!!!complete!!!");
        }
        public string compute_into_txt(int count,
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

          return start_time1+"      "+host1.PadRight(10, ' ')+client1.PadRight(10, ' ')+
                 three1.ToString("f2").PadRight(10, ' ')+
                 one1.ToString("f2").PadRight(10, ' ') +
                 zero1.ToString("f2").PadRight(10, ' ') +Environment.NewLine+
                 start_time2 + "      " + host2.PadRight(10, ' ') + client2.PadRight(10, ' ') +
                 three2.ToString("f2").PadRight(10, ' ') +
                 one2.ToString("f2").PadRight(10, ' ') +
                 zero2.ToString("f2").PadRight(10, ' ') + Environment.NewLine +
                "bit count:"+count.ToString()+Environment.NewLine+
                "total count: " + step.ToString() + Environment.NewLine +
                "use seconds: " + (dt_end - dt_start).TotalSeconds.ToString() + Environment.NewLine +
                "return value: " + result_min.ToString("f4") + "~" + result_max.ToString("f4")+Environment.NewLine +
                "return persent: " + (result_min/count*100).ToString("f6") +"%"+ Environment.NewLine +
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
        public double get_max_profit(string type,int count,int total,double offer_a,double offer_b)
        {
            double temp=0;
            double profit=-99999999;

            temp = count * offer_a * offer_b - total;
            if (temp > profit) profit = temp;

            temp = count * offer_a * offer_b * 1.206 - total;
            if (temp > profit) profit = temp;

            //if (offer_a * offer_b * 1 >= 1.88) temp = count * offer_a * offer_b + (count * 0.5) - total;
            //if (temp > profit) profit = temp;

            return profit; 
        }
        public void compute_into_table()
        {

            StringBuilder builder = new StringBuilder();
            DataTable dt = new DataTable();
            dt.Columns.Add("B33");
            dt.Columns.Add("B31");
            dt.Columns.Add("B30");
            dt.Columns.Add("B13");
            dt.Columns.Add("B11");
            dt.Columns.Add("B10");
            dt.Columns.Add("B03");
            dt.Columns.Add("B01");
            dt.Columns.Add("B00");
            dt.Columns.Add("R33");
            dt.Columns.Add("R31");
            dt.Columns.Add("R30");
            dt.Columns.Add("R13");
            dt.Columns.Add("R11");
            dt.Columns.Add("R10");
            dt.Columns.Add("R03");
            dt.Columns.Add("R01");
            dt.Columns.Add("R00");
            dt.Columns.Add("min", typeof(double));
            dt.Columns.Add("max", typeof(double));

            //10 43758 1
            //12 125970 3
            //13 203490 6
            //14 319770 10
            //15 490314 15
            //16 735471 22
            //17 1081575 33
            //18 Out of Memory
            DateTime dt_start = DateTime.Now;
            int count = 17;
            int step = 0;

            double three1 = Convert.ToDouble(dt_condition.Rows[0]["three"].ToString());
            double one1 = Convert.ToDouble(dt_condition.Rows[0]["one"].ToString());
            double zero1 = Convert.ToDouble(dt_condition.Rows[0]["zero"].ToString());

            double three2 = Convert.ToDouble(dt_condition.Rows[1]["three"].ToString());
            double one2 = Convert.ToDouble(dt_condition.Rows[1]["one"].ToString());
            double zero2 = Convert.ToDouble(dt_condition.Rows[1]["zero"].ToString());
            double all_min = 999999999;
            double all_min_max = 999999999;

            for (int i1 = 0; i1 <= count; i1++)
            {
                for (int i2 = 0; i2 <= count - i1; i2++)
                {
                    for (int i3 = 0; i3 <= count - i1 - i2; i3++)
                    {
                        for (int i4 = 0; i4 <= count - i1 - i2 - i3; i4++)
                        {
                            for (int i5 = 0; i5 <= count - i1 - i2 - i3 - i4; i5++)
                            {
                                for (int i6 = 0; i6 <= count - i1 - i2 - i3 - i4 - i5; i6++)
                                {
                                    for (int i7 = 0; i7 <= count - i1 - i2 - i3 - i4 - i5 - i6; i7++)
                                    {
                                        for (int i8 = 0; i8 <= count - i1 - i2 - i3 - i4 - i5 - i6 - i7; i8++)
                                        {
                                            int i9 = count - i1 - i2 - i3 - i4 - i5 - i6 - i7 - i8;
                                            DataRow row_new = dt.NewRow();

                                            row_new["B33"] = i1;
                                            row_new["B31"] = i2;
                                            row_new["B30"] = i3;
                                            row_new["B13"] = i4;
                                            row_new["B11"] = i5;
                                            row_new["B10"] = i6;
                                            row_new["B03"] = i7;
                                            row_new["B01"] = i8;
                                            row_new["B00"] = i9;

                                            if (three1 * three2 >= 1.88)
                                            {
                                                row_new["R33"] = i1 * three1 * three2 - count / 2;
                                            }
                                            else
                                            {
                                                row_new["R33"] = i1 * three1 * three2 - count;
                                            }
                                            if (three1 * one2 >= 1.88)
                                            {
                                                row_new["R31"] = i2 * three1 * one2 - count / 2;
                                            }
                                            else
                                            {
                                                row_new["R31"] = i2 * three1 * one2 - count;
                                            }
                                            if (three1 * zero2 >= 1.88)
                                            {
                                                row_new["R30"] = i3 * three1 * zero2 - count / 2;
                                            }
                                            else
                                            {
                                                row_new["R30"] = i3 * three1 * zero2 - count;
                                            }
                                            if (one1 * three2 > 1.88)
                                            {
                                                row_new["R13"] = i4 * one1 * three2 - count / 2;
                                            }
                                            else
                                            {
                                                row_new["R13"] = i4 * one1 * three2 - count;
                                            }
                                            if (one1 * one2 > 1.88)
                                            {
                                                row_new["R11"] = i5 * one1 * one2 - count / 2;
                                            }
                                            else
                                            {
                                                row_new["R11"] = i5 * one1 * one2 - count;
                                            }
                                            if (one1 * zero2 > 1.88)
                                            {
                                                row_new["R10"] = i6 * one1 * zero2 - count / 2;
                                            }
                                            else
                                            {
                                                row_new["R10"] = i6 * one1 * zero2 - count;
                                            }
                                            if (zero1 * three2 > 1.88)
                                            {
                                                row_new["R03"] = i7 * zero1 * three2 - count / 2;
                                            }
                                            else
                                            {
                                                row_new["R03"] = i7 * zero1 * three2 - count;
                                            }
                                            if (zero1 * one2 > 1.88)
                                            {
                                                row_new["R01"] = i8 * zero1 * one2 - count / 2;
                                            }
                                            else
                                            {
                                                row_new["R01"] = i8 * zero1 * one2 - count;
                                            }
                                            if (zero1 * zero2 > 1.88)
                                            {
                                                row_new["R00"] = i9 * zero1 * zero2 - count / 2;
                                            }
                                            else
                                            {
                                                row_new["R00"] = i9 * zero1 * zero2 - count;

                                            }


                                            double max = 0;
                                            double min = 99999999;
                                            string[] str_result = new string[] { "R33", "R31", "R30", "R13", "R11", "R10", "R03", "R01", "R00" };
                                            foreach (string result in str_result)
                                            {
                                                double value = Convert.ToDouble(row_new[result].ToString());
                                                if (value > max)
                                                {
                                                    max = value;
                                                }
                                                if (value < min)
                                                {
                                                    min = value;
                                                }
                                            }
                                            row_new["max"] = max;
                                            row_new["min"] = min;

                                            dt.Rows.Add(row_new);
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

            this.txt_compute.Text = "total count: " + dt.Rows.Count + Environment.NewLine +
                                    "total seconds: " + (dt_end - dt_start).Seconds.ToString() + Environment.NewLine +
                                    "min value: " + all_min.ToString() + "~" + all_min_max.ToString();
            this.dgv_result.DataSource = dt;
            MessageBox.Show(step.ToString());
        }
    }
}
