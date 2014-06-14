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

    public partial class FrmMain : Form
    {
        Form current_form = new Form();
        public FrmMain()
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

        public void set_window(Form frm)
        {
            foreach (Control control in panel_container.Controls)
            {
                if (control.Text == frm.Text)
                {
                    control.BringToFront();
                    current_form = (Form)frm;
                    frm.Dispose();
                    return;
                }
            }

            frm.TopLevel = false;
            frm.Dock = System.Windows.Forms.DockStyle.Fill;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopMost = true;
            this.panel_container.Controls.Add(frm);
            frm.Show();
            frm.BringToFront();
            current_form = (Form)frm;

            TreeNode node = new TreeNode();
            node.Text = frm.Text; 
            tree_menu.Nodes.Add(node);
        }

        private void mongoDBOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMongoDBOperate frm = new FrmMongoDBOperate();
            set_window((Form)frm);
        }
        private void mongoDBWebDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDocFind frm = new FrmDocFind();
            frm.frm_main = this;
            set_window((Form)frm); 
        }
        private void htmlAnalyseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmHtmlAnalyse frm = new FrmHtmlAnalyse();
            set_window((Form)frm);
        }
        private void templateManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTemplateManage frm = new FrmTemplateManage();
            frm.frm_main = this;
            set_window((Form)frm);
        }
        private void templateOperateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTemplateOperate frm = new FrmTemplateOperate();
            set_window((Form)frm);
        }
        private void downAllFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHtmlDownload frm = new FrmHtmlDownload();
            set_window((Form)frm); 
        }
        private void logMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLogMonitor frm = new FrmLogMonitor();
            set_window((Form)frm);
        }
        private void setFixedUrlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFixedUrlSet frm = new FrmFixedUrlSet();
            set_window((Form)frm); 
        }
        private void selectFixedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFixedUrlAutoPick frm = new FrmFixedUrlAutoPick();
            set_window((Form)frm);
        }
        private void codeConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCodeConsole frm = new FrmCodeConsole();
            set_window((Form)frm);
        }
        private void tree_menu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string name = e.Node.Text;

            foreach (Control control in panel_container.Controls)
            {
                if (control.Text == name)
                {
                    control.BringToFront();
                    current_form = (Form)control;
                }
            }
        }

        private void tool_close_form_Click(object sender, EventArgs e)
        {
            if (tree_menu.Nodes.Count > 0)
            {
                TreeNode node_delete = new TreeNode();
                foreach (TreeNode node in tree_menu.Nodes)
                {
                    if (node.Text == current_form.Text)
                    {
                        node_delete = node;
                    }
                }

                Control control_delete = new Control();
                foreach (Control control in panel_container.Controls)
                {
                    if (control.Text == node_delete.Text)
                    {
                        control_delete = control;
                    }
                }

                tree_menu.Nodes.Remove(node_delete);
                panel_container.Controls.Remove(control_delete);
            }
        }

        public void open_frm_template_list(string template_id)
        {
            FrmTemplateOperate frm = new FrmTemplateOperate();
            frm.type = "update";
            frm.template_id = template_id;
            frm.Text = "[T]" + template_id + "";
            
            set_window(frm);
        }
        public void open_frm_doc_find_view(string doc_id)
        {
            FrmDocFindView frm = new FrmDocFindView();
            frm.doc_id = doc_id;
            frm.Text = "[D]" + doc_id + "";
            set_window(frm);
        }

        private void requestSocketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmRequest_Socket frm = new FrmRequest_Socket();
            set_window((Form)frm);
        } 
        private void viewHexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHexConvert frm = new FrmHexConvert();
            set_window((Form)frm);
        }

        private void autoFiexeURLPickToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFixedUrlAutoPick frm = new FrmFixedUrlAutoPick();
            set_window((Form)frm);
        } 
    }

}
