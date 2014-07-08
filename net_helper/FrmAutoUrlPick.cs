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
    public partial class FrmAutoUrlPick : Form
    {
        public FrmAutoUrlPick()
        {
            InitializeComponent();
        }

        private void btn_pick_Click(object sender, EventArgs e)
        {
            this.txt_result.Text = AutoPickHelper.select_data_from_url(this.txt_url.Text);
        }

        private void txt_result_TextChanged(object sender, EventArgs e)
        {
            this.txt_result.SelectionStart = this.txt_result.TextLength;
            this.txt_result.ScrollToCaret();
        }
    }
}
