namespace WinCode
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.mongoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mongoDBOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mongoDBWebDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webHelperMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.htmlAnalyseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.downAllFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestSocketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateOperateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setFixedUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFixedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tree_menu = new System.Windows.Forms.TreeView();
            this.panel_container = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_close_form = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MainMenu.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mongoDBToolStripMenuItem,
            this.webHelperMenuItem,
            this.templateToolStripMenuItem,
            this.toolToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(1257, 24);
            this.MainMenu.TabIndex = 3;
            this.MainMenu.Text = "menuStrip1";
            // 
            // mongoDBToolStripMenuItem
            // 
            this.mongoDBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mongoDBOperationToolStripMenuItem,
            this.mongoDBWebDocumentToolStripMenuItem});
            this.mongoDBToolStripMenuItem.Name = "mongoDBToolStripMenuItem";
            this.mongoDBToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.mongoDBToolStripMenuItem.Text = "MongoDB";
            // 
            // mongoDBOperationToolStripMenuItem
            // 
            this.mongoDBOperationToolStripMenuItem.Name = "mongoDBOperationToolStripMenuItem";
            this.mongoDBOperationToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.mongoDBOperationToolStripMenuItem.Text = "MongoDB Operation";
            this.mongoDBOperationToolStripMenuItem.Click += new System.EventHandler(this.mongoDBOperationToolStripMenuItem_Click);
            // 
            // mongoDBWebDocumentToolStripMenuItem
            // 
            this.mongoDBWebDocumentToolStripMenuItem.Name = "mongoDBWebDocumentToolStripMenuItem";
            this.mongoDBWebDocumentToolStripMenuItem.Size = new System.Drawing.Size(220, 22);
            this.mongoDBWebDocumentToolStripMenuItem.Text = "MongoDB Web Document View";
            this.mongoDBWebDocumentToolStripMenuItem.Click += new System.EventHandler(this.mongoDBWebDocumentToolStripMenuItem_Click);
            // 
            // webHelperMenuItem
            // 
            this.webHelperMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.htmlAnalyseToolStripMenuItem1,
            this.downAllFileToolStripMenuItem,
            this.requestSocketToolStripMenuItem});
            this.webHelperMenuItem.Name = "webHelperMenuItem";
            this.webHelperMenuItem.Size = new System.Drawing.Size(77, 20);
            this.webHelperMenuItem.Text = "Web Helper";
            // 
            // htmlAnalyseToolStripMenuItem1
            // 
            this.htmlAnalyseToolStripMenuItem1.Name = "htmlAnalyseToolStripMenuItem1";
            this.htmlAnalyseToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.htmlAnalyseToolStripMenuItem1.Text = "Html Analyse";
            this.htmlAnalyseToolStripMenuItem1.Click += new System.EventHandler(this.htmlAnalyseToolStripMenuItem1_Click);
            // 
            // downAllFileToolStripMenuItem
            // 
            this.downAllFileToolStripMenuItem.Name = "downAllFileToolStripMenuItem";
            this.downAllFileToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.downAllFileToolStripMenuItem.Text = "Html Download";
            this.downAllFileToolStripMenuItem.Click += new System.EventHandler(this.downAllFileToolStripMenuItem_Click);
            // 
            // requestSocketToolStripMenuItem
            // 
            this.requestSocketToolStripMenuItem.Name = "requestSocketToolStripMenuItem";
            this.requestSocketToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.requestSocketToolStripMenuItem.Text = "Request Socket";
            this.requestSocketToolStripMenuItem.Click += new System.EventHandler(this.requestSocketToolStripMenuItem_Click);
            // 
            // templateToolStripMenuItem
            // 
            this.templateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.templateManageToolStripMenuItem,
            this.templateOperateToolStripMenuItem,
            this.setFixedUrlToolStripMenuItem,
            this.selectFixedToolStripMenuItem});
            this.templateToolStripMenuItem.Name = "templateToolStripMenuItem";
            this.templateToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.templateToolStripMenuItem.Text = "Template";
            // 
            // templateManageToolStripMenuItem
            // 
            this.templateManageToolStripMenuItem.Name = "templateManageToolStripMenuItem";
            this.templateManageToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.templateManageToolStripMenuItem.Text = "Template Manage";
            this.templateManageToolStripMenuItem.Click += new System.EventHandler(this.templateManageToolStripMenuItem_Click);
            // 
            // templateOperateToolStripMenuItem
            // 
            this.templateOperateToolStripMenuItem.Name = "templateOperateToolStripMenuItem";
            this.templateOperateToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.templateOperateToolStripMenuItem.Text = "Template Add";
            this.templateOperateToolStripMenuItem.Click += new System.EventHandler(this.templateOperateToolStripMenuItem_Click);
            // 
            // setFixedUrlToolStripMenuItem
            // 
            this.setFixedUrlToolStripMenuItem.Name = "setFixedUrlToolStripMenuItem";
            this.setFixedUrlToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.setFixedUrlToolStripMenuItem.Text = "Fixed URL Set";
            this.setFixedUrlToolStripMenuItem.Click += new System.EventHandler(this.setFixedUrlToolStripMenuItem_Click);
            // 
            // selectFixedToolStripMenuItem
            // 
            this.selectFixedToolStripMenuItem.Name = "selectFixedToolStripMenuItem";
            this.selectFixedToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.selectFixedToolStripMenuItem.Text = "Fixed URL Pick";
            this.selectFixedToolStripMenuItem.Click += new System.EventHandler(this.selectFixedToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logMonitorToolStripMenuItem,
            this.codeConsoleToolStripMenuItem,
            this.viewHexToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolToolStripMenuItem.Text = "Tools";
            // 
            // logMonitorToolStripMenuItem
            // 
            this.logMonitorToolStripMenuItem.Name = "logMonitorToolStripMenuItem";
            this.logMonitorToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.logMonitorToolStripMenuItem.Text = "Log Monitor";
            this.logMonitorToolStripMenuItem.Click += new System.EventHandler(this.logMonitorToolStripMenuItem_Click);
            // 
            // codeConsoleToolStripMenuItem
            // 
            this.codeConsoleToolStripMenuItem.Name = "codeConsoleToolStripMenuItem";
            this.codeConsoleToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.codeConsoleToolStripMenuItem.Text = "Code Console";
            this.codeConsoleToolStripMenuItem.Click += new System.EventHandler(this.codeConsoleToolStripMenuItem_Click);
            // 
            // viewHexToolStripMenuItem
            // 
            this.viewHexToolStripMenuItem.Name = "viewHexToolStripMenuItem";
            this.viewHexToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.viewHexToolStripMenuItem.Text = "Hex Convert";
            this.viewHexToolStripMenuItem.Click += new System.EventHandler(this.viewHexToolStripMenuItem_Click);
            // 
            // tree_menu
            // 
            this.tree_menu.AllowDrop = true;
            this.tree_menu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tree_menu.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tree_menu.FullRowSelect = true;
            this.tree_menu.ItemHeight = 20;
            this.tree_menu.Location = new System.Drawing.Point(3, 57);
            this.tree_menu.Name = "tree_menu";
            this.tree_menu.ShowLines = false;
            this.tree_menu.ShowRootLines = false;
            this.tree_menu.Size = new System.Drawing.Size(187, 541);
            this.tree_menu.TabIndex = 5;
            this.tree_menu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_menu_AfterSelect);
            // 
            // panel_container
            // 
            this.panel_container.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_container.AutoSize = true;
            this.panel_container.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel_container.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_container.Location = new System.Drawing.Point(193, 57);
            this.panel_container.Name = "panel_container";
            this.panel_container.Size = new System.Drawing.Size(1064, 541);
            this.panel_container.TabIndex = 6;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_close_form,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1257, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_close_form
            // 
            this.tool_close_form.Image = ((System.Drawing.Image)(resources.GetObject("tool_close_form.Image")));
            this.tool_close_form.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_close_form.Name = "tool_close_form";
            this.tool_close_form.Size = new System.Drawing.Size(85, 22);
            this.tool_close_form.Text = "Close Form";
            this.tool_close_form.Click += new System.EventHandler(this.tool_close_form_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1257, 601);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel_container);
            this.Controls.Add(this.tree_menu);
            this.Controls.Add(this.MainMenu);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Send Mail Main Menu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmTest_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem mongoDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mongoDBOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webHelperMenuItem;
        private System.Windows.Forms.ToolStripMenuItem htmlAnalyseToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem templateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templateManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem templateOperateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downAllFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setFixedUrlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectFixedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem codeConsoleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mongoDBWebDocumentToolStripMenuItem;
        private System.Windows.Forms.TreeView tree_menu;
        private System.Windows.Forms.Panel panel_container;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tool_close_form;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem requestSocketToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHexToolStripMenuItem;
    }
}