using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WinCode
{
    public partial class FrmLogMonitor : Form
    {
        public FrmLogMonitor()
        {
            InitializeComponent();
        }
        int max = 0;
        DataTable dt = new DataTable();

        private void FrmLogMonitor_Load(object sender, EventArgs e)
        {
            time.Start();
            bind_data();
        }

        private void time_Tick(object sender, EventArgs e)
        {
            this.lb_time.Text = DateTime.Now.ToString("hh:mm:ss");
            DataTable dt_temp = new DataTable();
            string sql = "select top 2 * from log where id > {0} order by id ";
            sql = string.Format(sql, max.ToString());
            dt_temp = SQLServerHelper.get_table(sql);
            foreach (DataRow row in dt_temp.Rows)
            {
                DataRow row_new = dt.NewRow();
                row_new[0] = row[0];
                row_new[1] = row[1];
                row_new[2] = row[2];
                row_new[3] = row[3];
                row_new[4] = row[4];
                dt.Rows.InsertAt(row_new, 0);

                //set current row  
                this.dgv_result.CurrentCell = this.dgv_result.Rows[0].Cells[0];
                dgv_result.Rows[0].Selected = true;

                max = int.Parse(row[0].ToString());
            }
        }
        public void bind_data()
        { 
            string sql = "select top 100 * from log order by id desc";
            dt = SQLServerHelper.get_table(sql);
            max = int.Parse(dt.Rows[0]["id"].ToString());
            this.dgv_result.DataSource = dt; 
        }

        private void dgv_result_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgv_result.Columns[0].Width = 50;
            this.dgv_result.Columns[1].Width = 100;
            this.dgv_result.Columns[2].Width = 100;
            this.dgv_result.Columns[3].Width = 100;
        }

        private void FrmLogMonitor_SizeChanged(object sender, EventArgs e)
        {
            //this.dgv_result.Columns[0].Width = 50;
            //this.dgv_result.Columns[1].Width = 100;
            //this.dgv_result.Columns[2].Width = 100;
            //this.dgv_result.Columns[3].Width = 100;
        }

        private void dgv_result_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e != null && e.RowIndex > -1 && e.RowIndex < dgv_result.Rows.Count - 1)
                {
                    if (e.RowIndex >= 0 && e.RowIndex <= dgv_result.Rows.Count - 1)
                    {
                        this.txt_result.Text = dgv_result.Rows[e.RowIndex].Cells["detail"].Value.ToString();
                    }
                }
            }
            catch(Exception error)
            {
                Log.error("cell mouse down", error);
            }

            
        }

        private void dgv_result_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e != null && e.RowIndex > -1 && e.RowIndex < dgv_result.Rows.Count - 1)
                { 
                    if (e.RowIndex >= 0 && e.RowIndex <= dgv_result.Rows.Count - 1)
                    {
                        this.txt_result.Text = dgv_result.Rows[e.RowIndex].Cells["detail"].Value.ToString();
                    }
                }
            }
            catch (Exception error)
            {
                Log.error("row enter", error);
            }

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            time.Start();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            time.Stop();
        }

        private void dgv_result_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            { 
                if (e != null && e.RowIndex > -1 && e.RowIndex<dgv_result.Rows.Count-1)
                {
                    if (this.dgv_result.Rows[e.RowIndex].Cells["type"].Value.ToString() == "error")
                    {
                        this.dgv_result.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
            }
            catch (Exception error)
            {
                Log.error("cell formatting", error);
            }
        }

    }
}
