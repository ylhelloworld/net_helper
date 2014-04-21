namespace WinCode
{
    partial class FrmTest
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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.mongoDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mongoDBOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mongoDBWebDocumentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.htmlAnalyseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.htmlAnalyseToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.downAllFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.templateOperateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setFixedUrlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectFixedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codeConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mongoDBToolStripMenuItem,
            this.htmlAnalyseToolStripMenuItem,
            this.templateToolStripMenuItem,
            this.toolToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(373, 25);
            this.MainMenu.TabIndex = 3;
            this.MainMenu.Text = "menuStrip1";
            // 
            // mongoDBToolStripMenuItem
            // 
            this.mongoDBToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mongoDBOperationToolStripMenuItem,
            this.mongoDBWebDocumentToolStripMenuItem});
            this.mongoDBToolStripMenuItem.Name = "mongoDBToolStripMenuItem";
            this.mongoDBToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.mongoDBToolStripMenuItem.Text = "MongoDB";
            // 
            // mongoDBOperationToolStripMenuItem
            // 
            this.mongoDBOperationToolStripMenuItem.Name = "mongoDBOperationToolStripMenuItem";
            this.mongoDBOperationToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.mongoDBOperationToolStripMenuItem.Text = "MongoDB Operation";
            this.mongoDBOperationToolStripMenuItem.Click += new System.EventHandler(this.mongoDBOperationToolStripMenuItem_Click);
            // 
            // mongoDBWebDocumentToolStripMenuItem
            // 
            this.mongoDBWebDocumentToolStripMenuItem.Name = "mongoDBWebDocumentToolStripMenuItem";
            this.mongoDBWebDocumentToolStripMenuItem.Size = new System.Drawing.Size(261, 22);
            this.mongoDBWebDocumentToolStripMenuItem.Text = "MongoDB Web Document View";
            this.mongoDBWebDocumentToolStripMenuItem.Click += new System.EventHandler(this.mongoDBWebDocumentToolStripMenuItem_Click);
            // 
            // htmlAnalyseToolStripMenuItem
            // 
            this.htmlAnalyseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.htmlAnalyseToolStripMenuItem1,
            this.downAllFileToolStripMenuItem});
            this.htmlAnalyseToolStripMenuItem.Name = "htmlAnalyseToolStripMenuItem";
            this.htmlAnalyseToolStripMenuItem.Size = new System.Drawing.Size(95, 21);
            this.htmlAnalyseToolStripMenuItem.Text = "Html Analyse";
            // 
            // htmlAnalyseToolStripMenuItem1
            // 
            this.htmlAnalyseToolStripMenuItem1.Name = "htmlAnalyseToolStripMenuItem1";
            this.htmlAnalyseToolStripMenuItem1.Size = new System.Drawing.Size(166, 22);
            this.htmlAnalyseToolStripMenuItem1.Text = "Html Analyse";
            this.htmlAnalyseToolStripMenuItem1.Click += new System.EventHandler(this.htmlAnalyseToolStripMenuItem1_Click);
            // 
            // downAllFileToolStripMenuItem
            // 
            this.downAllFileToolStripMenuItem.Name = "downAllFileToolStripMenuItem";
            this.downAllFileToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.downAllFileToolStripMenuItem.Text = "Html Download";
            this.downAllFileToolStripMenuItem.Click += new System.EventHandler(this.downAllFileToolStripMenuItem_Click);
            // 
            // templateToolStripMenuItem
            // 
            this.templateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.templateManageToolStripMenuItem,
            this.templateOperateToolStripMenuItem,
            this.setFixedUrlToolStripMenuItem,
            this.selectFixedToolStripMenuItem});
            this.templateToolStripMenuItem.Name = "templateToolStripMenuItem";
            this.templateToolStripMenuItem.Size = new System.Drawing.Size(74, 21);
            this.templateToolStripMenuItem.Text = "Template";
            // 
            // templateManageToolStripMenuItem
            // 
            this.templateManageToolStripMenuItem.Name = "templateManageToolStripMenuItem";
            this.templateManageToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.templateManageToolStripMenuItem.Text = "Template Manage";
            this.templateManageToolStripMenuItem.Click += new System.EventHandler(this.templateManageToolStripMenuItem_Click);
            // 
            // templateOperateToolStripMenuItem
            // 
            this.templateOperateToolStripMenuItem.Name = "templateOperateToolStripMenuItem";
            this.templateOperateToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.templateOperateToolStripMenuItem.Text = "Template Operate";
            this.templateOperateToolStripMenuItem.Click += new System.EventHandler(this.templateOperateToolStripMenuItem_Click);
            // 
            // setFixedUrlToolStripMenuItem
            // 
            this.setFixedUrlToolStripMenuItem.Name = "setFixedUrlToolStripMenuItem";
            this.setFixedUrlToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.setFixedUrlToolStripMenuItem.Text = "Fixed URL Set";
            this.setFixedUrlToolStripMenuItem.Click += new System.EventHandler(this.setFixedUrlToolStripMenuItem_Click);
            // 
            // selectFixedToolStripMenuItem
            // 
            this.selectFixedToolStripMenuItem.Name = "selectFixedToolStripMenuItem";
            this.selectFixedToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.selectFixedToolStripMenuItem.Text = "Fixed URL Pick";
            this.selectFixedToolStripMenuItem.Click += new System.EventHandler(this.selectFixedToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logMonitorToolStripMenuItem,
            this.codeConsoleToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(52, 21);
            this.toolToolStripMenuItem.Text = "Tools";
            // 
            // logMonitorToolStripMenuItem
            // 
            this.logMonitorToolStripMenuItem.Name = "logMonitorToolStripMenuItem";
            this.logMonitorToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.logMonitorToolStripMenuItem.Text = "Log Monitor";
            this.logMonitorToolStripMenuItem.Click += new System.EventHandler(this.logMonitorToolStripMenuItem_Click);
            // 
            // codeConsoleToolStripMenuItem
            // 
            this.codeConsoleToolStripMenuItem.Name = "codeConsoleToolStripMenuItem";
            this.codeConsoleToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.codeConsoleToolStripMenuItem.Text = "Code Console";
            this.codeConsoleToolStripMenuItem.Click += new System.EventHandler(this.codeConsoleToolStripMenuItem_Click);
            // 
            // FrmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 24);
            this.Controls.Add(this.MainMenu);
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MainMenu;
            this.Name = "FrmTest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Send Mail Main Menu";
            this.Load += new System.EventHandler(this.FrmTest_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem mongoDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mongoDBOperationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem htmlAnalyseToolStripMenuItem;
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
    }
}