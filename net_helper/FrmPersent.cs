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
        DataTable dt = new DataTable();
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
           
            dt.Columns.Add("start_time");
            dt.Columns.Add("host");
            dt.Columns.Add("client");
            dt.Columns.Add("three");
            dt.Columns.Add("one");
            dt.Columns.Add("zero");

            DataRow row1 = dt.NewRow();
            row1["start_time"] = "2014-07-16";
            row1["host"] = "A1";
            row1["client"] = "A2";
            row1["three"] = "2.24";
            row1["one"] = "2.21";
            row1["zero"] = "2.23";
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["start_time"] = "2014-07-16";
            row2["host"] = "B1";
            row2["client"] = "B2";
            row2["three"] = "2.14";
            row2["one"] = "2.5";
            row2["zero"] = "2.53";
            dt.Rows.Add(row2);

            this.dgv_condition.DataSource = dt;


        }

        private void btn_compute_Click(object sender, EventArgs e)
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
            dt.Columns.Add("min");
            dt.Columns.Add("max");
            int count = 0;
            for (int i1 = 0; i1 <= 100; i1++)
            {
                for (int i2 = 0; i2 <= 10 - i1; i2++)
                {
                    for (int i3 = 0; i3 <= 10 - i1 - i2; i3++)
                    {
                        for (int i4 = 0; i4 <= 10 - i1 - i2 - i3; i4++)
                        {
                            for (int i5 = 0; i5 <= 10 - i1 - i2 - i3 - i4; i5++)
                            {
                                for (int i6 = 0; i6 <= 10 - i1 - i2 - i3 - i4 - i5; i6++)
                                {
                                    for (int i7 = 0; i7 <= 10 - i1 - i2 - i3 - i4 - i5 - i6; i7++)
                                    {
                                        for (int i8 = 0; i8 <= 10 - i1 - i2 - i3 - i4 - i5 - i6 - i7; i8++)
                                        { 
                                            int i9 = 10 - i1 - i2 - i3 - i4 - i5 - i6 - i7 - i8;
                                            DataRow row_new = dt.NewRow();
                                            row_new["B33"] = i1.ToString();
                                            row_new["B31"] = i2.ToString();
                                            row_new["B30"] = i3.ToString();
                                            row_new["B13"] = i4.ToString();
                                            row_new["B11"] = i5.ToString();
                                            row_new["B10"] = i6.ToString();
                                            row_new["B03"] = i7.ToString();
                                            row_new["B01"] = i8.ToString();
                                            row_new["B00"] = i9.ToString();
                                            count = count + 1; 
                                        }

                                    }

                                }

                            }

                        }

                    }


                }

            }
            this.txt_compute.Text = count.ToString();
            MessageBox.Show("hello");
            

        }
    }
}
