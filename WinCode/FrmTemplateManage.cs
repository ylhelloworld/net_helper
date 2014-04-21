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
    public partial class FrmTemplateManage : Form
    {
        public FrmTemplateManage()
        {
            InitializeComponent();
        }

        public FrmMain frm_main;
        private void btn_find_Click(object sender, EventArgs e)
        {
            DataTable dt = SQLServerHelper.get_table("select * from template_main;");
            this.dgv_result.DataSource = dt;
        }

        private void dgv_result_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string template_id = dgv_result.Rows[e.RowIndex].Cells["template_id"].Value.ToString();
            if (!string.IsNullOrEmpty(template_id))
            {
                frm_main.open_frm_template_list(template_id);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            FrmTemplateOperate frm = new FrmTemplateOperate();
            frm.type = "add";
            frm.Show();
        }
    }
}
