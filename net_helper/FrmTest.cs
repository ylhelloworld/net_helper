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
    public partial class FrmTest : Form
    {
        public FrmTest()
        {
            InitializeComponent();
        } 
        
        public void SetMdiBackColor()
        {
            MdiClient ctlMDI = new MdiClient();
            int i = 0;
            for (i = 0; i <= this.Controls.Count; i++)
            {
                try
                {
                    ctlMDI = (MdiClient)this.Controls[i];
                    ctlMDI.BackColor = this.BackColor;
                }
                catch (Exception error)
                {
                     
                }
            }
        }

        private void FrmTest_Load(object sender, EventArgs e)
        {
            SetMdiBackColor();
        }

        private void mongoDBOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMongoDBOperate frm = new FrmMongoDBOperate();
            frm.MdiParent = this;
            frm.Show();
        }

        private void htmlAnalyseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmHtmlAnalyse frm = new FrmHtmlAnalyse();
            frm.Show();
        }

        private void templateManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTemplateManage frm = new FrmTemplateManage();
            frm.Show();
        }

        private void templateOperateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTemplateOperate frm = new FrmTemplateOperate();
            frm.Show();
        } 

        private void downAllFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHtmlDownload frm = new FrmHtmlDownload();
            frm.Show();
        }

        private void logMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogMonitor frm = new FrmLogMonitor();
            frm.Show();
        }

        private void setFixedUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFixedUrlSet frm = new FrmFixedUrlSet();
            frm.Show();

        }

        private void selectFixedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFixedUrlAutoPick frm = new FrmFixedUrlAutoPick();
            frm.Show();
        }

        private void codeConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCodeConsole frm = new FrmCodeConsole();
            frm.Show();
        }

        private void mongoDBWebDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDocFind frm = new FrmDocFind();
            frm.Show();
        }

 
 
 
    }

}
