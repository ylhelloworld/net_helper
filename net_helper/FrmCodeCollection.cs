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
   
    public partial class FrmCodeCollection : Form
    {
        public FrmCodeConsole father = new FrmCodeConsole();
        public FrmCodeCollection()
        {
            InitializeComponent();
        }  

        private void FrmCodeCollection_Load(object sender, EventArgs e)
        { 
            bind_data();
        }

        private void btn_find_Click(object sender, EventArgs e)
        { 
            string condition=this.txt_condition.Text;
            if (string.IsNullOrEmpty(condition))
            {
                condition = "%";
            }
            else
            {
                condition = "%" + condition + "%";
            }
            string sql = "select date,tag,code from code where code like '{0}' or tag like '{0}' order by id desc";
            DataTable dt = SQLServerHelper.get_table(sql);
            this.dgv_result.DataSource = dt;  
        }
        public void bind_data()
        {
            string sql = "select top 100 date,tag,code from code order by id desc";
            DataTable dt = SQLServerHelper.get_table(sql); 
            this.dgv_result.DataSource = dt; 
        }

        private void dgv_result_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgv_result.Columns[0].Width = 150;
            this.dgv_result.Columns[1].Width = 150;
        }

        private void FrmCodeCollection_SizeChanged(object sender, EventArgs e)
        {
            this.dgv_result.Columns[0].Width = 150;
            this.dgv_result.Columns[1].Width = 150;
        }

        private void dgv_result_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e != null && e.RowIndex > -1 && e.RowIndex < dgv_result.Rows.Count - 1)
                {
                    if (e.RowIndex >= 0 && e.RowIndex <= dgv_result.Rows.Count - 1)
                    {
                        this.txt_result.Text = dgv_result.Rows[e.RowIndex].Cells["code"].Value.ToString();
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
                        this.txt_result.Text = dgv_result.Rows[e.RowIndex].Cells["code"].Value.ToString();
                    }
                }
            }
            catch (Exception error)
            {
                Log.error("row enter", error);
            } 
        }

        private void btn_use_Click(object sender, EventArgs e)
        {
            father.set_code(this.txt_result.Text);
            this.Close();
            this.Dispose();
        } 
    }
}
