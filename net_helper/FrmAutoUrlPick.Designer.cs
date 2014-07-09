namespace WinCode
{
    partial class FrmAutoUrlPick
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
            this.txt_url = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_pick_to_tree = new System.Windows.Forms.Button();
            this.cb_local = new System.Windows.Forms.CheckBox();
            this.btn_pick = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_page_0 = new System.Windows.Forms.TabPage();
            this.txt_local = new System.Windows.Forms.TextBox();
            this.tab_page_1 = new System.Windows.Forms.TabPage();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.tab_page_2 = new System.Windows.Forms.TabPage();
            this.tree_result = new System.Windows.Forms.TreeView();
            this.btn_pick_to_table = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_page_0.SuspendLayout();
            this.tab_page_1.SuspendLayout();
            this.tab_page_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(24, 19);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(584, 20);
            this.txt_url.TabIndex = 0;
            this.txt_url.Text = "http://v2.bootcss.com/base-css.html";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_pick_to_table);
            this.groupBox1.Controls.Add(this.btn_pick_to_tree);
            this.groupBox1.Controls.Add(this.cb_local);
            this.groupBox1.Controls.Add(this.btn_pick);
            this.groupBox1.Controls.Add(this.txt_url);
            this.groupBox1.Location = new System.Drawing.Point(5, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1082, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // btn_pick_to_tree
            // 
            this.btn_pick_to_tree.Location = new System.Drawing.Point(803, 16);
            this.btn_pick_to_tree.Name = "btn_pick_to_tree";
            this.btn_pick_to_tree.Size = new System.Drawing.Size(91, 23);
            this.btn_pick_to_tree.TabIndex = 3;
            this.btn_pick_to_tree.Text = "Pick To Tree";
            this.btn_pick_to_tree.UseVisualStyleBackColor = true;
            this.btn_pick_to_tree.Click += new System.EventHandler(this.btn_pick_to_tree_Click);
            // 
            // cb_local
            // 
            this.cb_local.AutoSize = true;
            this.cb_local.Location = new System.Drawing.Point(615, 21);
            this.cb_local.Name = "cb_local";
            this.cb_local.Size = new System.Drawing.Size(102, 17);
            this.cb_local.TabIndex = 2;
            this.cb_local.Text = "From Local Html";
            this.cb_local.UseVisualStyleBackColor = true;
            // 
            // btn_pick
            // 
            this.btn_pick.Location = new System.Drawing.Point(722, 16);
            this.btn_pick.Name = "btn_pick";
            this.btn_pick.Size = new System.Drawing.Size(75, 23);
            this.btn_pick.TabIndex = 1;
            this.btn_pick.Text = "Pick";
            this.btn_pick.UseVisualStyleBackColor = true;
            this.btn_pick.Click += new System.EventHandler(this.btn_pick_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab_page_0);
            this.tabControl1.Controls.Add(this.tab_page_1);
            this.tabControl1.Controls.Add(this.tab_page_2);
            this.tabControl1.Location = new System.Drawing.Point(5, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1082, 509);
            this.tabControl1.TabIndex = 2;
            // 
            // tab_page_0
            // 
            this.tab_page_0.Controls.Add(this.txt_local);
            this.tab_page_0.Location = new System.Drawing.Point(4, 22);
            this.tab_page_0.Name = "tab_page_0";
            this.tab_page_0.Size = new System.Drawing.Size(1074, 483);
            this.tab_page_0.TabIndex = 1;
            this.tab_page_0.Text = "Local Html Source";
            this.tab_page_0.UseVisualStyleBackColor = true;
            // 
            // txt_local
            // 
            this.txt_local.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_local.Location = new System.Drawing.Point(0, 0);
            this.txt_local.Multiline = true;
            this.txt_local.Name = "txt_local";
            this.txt_local.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_local.Size = new System.Drawing.Size(1074, 483);
            this.txt_local.TabIndex = 0;
            // 
            // tab_page_1
            // 
            this.tab_page_1.Controls.Add(this.txt_result);
            this.tab_page_1.Location = new System.Drawing.Point(4, 22);
            this.tab_page_1.Name = "tab_page_1";
            this.tab_page_1.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_1.Size = new System.Drawing.Size(1074, 483);
            this.tab_page_1.TabIndex = 0;
            this.tab_page_1.Text = "Result Text";
            this.tab_page_1.UseVisualStyleBackColor = true;
            // 
            // txt_result
            // 
            this.txt_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_result.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_result.Location = new System.Drawing.Point(3, 3);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_result.Size = new System.Drawing.Size(1068, 477);
            this.txt_result.TabIndex = 0;
            this.txt_result.TextChanged += new System.EventHandler(this.txt_result_TextChanged);
            // 
            // tab_page_2
            // 
            this.tab_page_2.Controls.Add(this.tree_result);
            this.tab_page_2.Location = new System.Drawing.Point(4, 22);
            this.tab_page_2.Name = "tab_page_2";
            this.tab_page_2.Size = new System.Drawing.Size(1074, 483);
            this.tab_page_2.TabIndex = 2;
            this.tab_page_2.Text = "Result Tree";
            this.tab_page_2.UseVisualStyleBackColor = true;
            // 
            // tree_result
            // 
            this.tree_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_result.Location = new System.Drawing.Point(0, 0);
            this.tree_result.Name = "tree_result";
            this.tree_result.Size = new System.Drawing.Size(1074, 483);
            this.tree_result.TabIndex = 0;
            // 
            // btn_pick_to_table
            // 
            this.btn_pick_to_table.Location = new System.Drawing.Point(900, 16);
            this.btn_pick_to_table.Name = "btn_pick_to_table";
            this.btn_pick_to_table.Size = new System.Drawing.Size(89, 23);
            this.btn_pick_to_table.TabIndex = 4;
            this.btn_pick_to_table.Text = "Pick To Table";
            this.btn_pick_to_table.UseVisualStyleBackColor = true;
            this.btn_pick_to_table.Click += new System.EventHandler(this.btn_pick_to_table_Click);
            // 
            // FrmAutoUrlPick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 584);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmAutoUrlPick";
            this.Text = "Auto Url Pick";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab_page_0.ResumeLayout(false);
            this.tab_page_0.PerformLayout();
            this.tab_page_1.ResumeLayout(false);
            this.tab_page_1.PerformLayout();
            this.tab_page_2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_pick;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_page_1;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.TabPage tab_page_0;
        private System.Windows.Forms.CheckBox cb_local;
        private System.Windows.Forms.TextBox txt_local;
        private System.Windows.Forms.Button btn_pick_to_tree;
        private System.Windows.Forms.TabPage tab_page_2;
        private System.Windows.Forms.TreeView tree_result;
        private System.Windows.Forms.Button btn_pick_to_table;
    }
}