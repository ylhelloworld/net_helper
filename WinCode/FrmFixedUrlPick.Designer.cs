namespace WinCode
{
    partial class FrmFixedUrlPick
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_pick = new System.Windows.Forms.Button();
            this.btn_find = new System.Windows.Forms.Button();
            this.txt_condition = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_find_result = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_pick_result = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_find_result)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_pick);
            this.groupBox1.Controls.Add(this.btn_find);
            this.groupBox1.Controls.Add(this.txt_condition);
            this.groupBox1.Location = new System.Drawing.Point(3, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(986, 51);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find && Pick Html Value To DB";
            // 
            // btn_pick
            // 
            this.btn_pick.Location = new System.Drawing.Point(401, 17);
            this.btn_pick.Name = "btn_pick";
            this.btn_pick.Size = new System.Drawing.Size(75, 21);
            this.btn_pick.TabIndex = 2;
            this.btn_pick.Text = "Pick";
            this.btn_pick.UseVisualStyleBackColor = true;
            this.btn_pick.Click += new System.EventHandler(this.btn_pick_Click);
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(320, 17);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(75, 21);
            this.btn_find.TabIndex = 1;
            this.btn_find.Text = "Find";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // txt_condition
            // 
            this.txt_condition.Location = new System.Drawing.Point(6, 18);
            this.txt_condition.Name = "txt_condition";
            this.txt_condition.Size = new System.Drawing.Size(308, 21);
            this.txt_condition.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 63);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(986, 458);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_find_result);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(978, 432);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Find Result";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv_find_result
            // 
            this.dgv_find_result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_find_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_find_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_find_result.Location = new System.Drawing.Point(3, 3);
            this.dgv_find_result.Name = "dgv_find_result";
            this.dgv_find_result.Size = new System.Drawing.Size(972, 426);
            this.dgv_find_result.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_pick_result);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(978, 423);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Pick Result";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_pick_result
            // 
            this.txt_pick_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_pick_result.Location = new System.Drawing.Point(3, 3);
            this.txt_pick_result.Multiline = true;
            this.txt_pick_result.Name = "txt_pick_result";
            this.txt_pick_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_pick_result.Size = new System.Drawing.Size(972, 419);
            this.txt_pick_result.TabIndex = 0;
            this.txt_pick_result.TextChanged += new System.EventHandler(this.txt_pick_result_TextChanged);
            // 
            // FrmFixedUrlPick
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 522);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmFixedUrlPick";
            this.Text = "Pick Fixed Url";
            this.Load += new System.EventHandler(this.FrmFixedUrlPick_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_find_result)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_pick;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_condition;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView dgv_find_result;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_pick_result;
    }
}