namespace WinCode
{
    partial class FrmMixMatch
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_1_min_1_point = new System.Windows.Forms.Button();
            this.btn_1_min_1_total = new System.Windows.Forms.Button();
            this.btn_1_min_1_half = new System.Windows.Forms.Button();
            this.btn_1_min_1_spread = new System.Windows.Forms.Button();
            this.btn_1_min_1_wdl = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_load_match = new System.Windows.Forms.Button();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_match = new System.Windows.Forms.TextBox();
            this.dgv_match = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_compute_result = new System.Windows.Forms.TextBox();
            this.cb_over = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_match)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(317, 618);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_1_min_1_point);
            this.groupBox3.Controls.Add(this.btn_1_min_1_total);
            this.groupBox3.Controls.Add(this.btn_1_min_1_half);
            this.groupBox3.Controls.Add(this.btn_1_min_1_spread);
            this.groupBox3.Controls.Add(this.btn_1_min_1_wdl);
            this.groupBox3.Location = new System.Drawing.Point(6, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 532);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Compute Tool";
            // 
            // btn_1_min_1_point
            // 
            this.btn_1_min_1_point.Location = new System.Drawing.Point(9, 144);
            this.btn_1_min_1_point.Name = "btn_1_min_1_point";
            this.btn_1_min_1_point.Size = new System.Drawing.Size(93, 23);
            this.btn_1_min_1_point.TabIndex = 4;
            this.btn_1_min_1_point.Text = "1-min-1-point";
            this.btn_1_min_1_point.UseVisualStyleBackColor = true;
            this.btn_1_min_1_point.Click += new System.EventHandler(this.btn_1_min_1_point_Click);
            // 
            // btn_1_min_1_total
            // 
            this.btn_1_min_1_total.Location = new System.Drawing.Point(9, 115);
            this.btn_1_min_1_total.Name = "btn_1_min_1_total";
            this.btn_1_min_1_total.Size = new System.Drawing.Size(93, 23);
            this.btn_1_min_1_total.TabIndex = 3;
            this.btn_1_min_1_total.Text = "1-min-1-total";
            this.btn_1_min_1_total.UseVisualStyleBackColor = true;
            this.btn_1_min_1_total.Click += new System.EventHandler(this.btn_1_min_1_total_Click);
            // 
            // btn_1_min_1_half
            // 
            this.btn_1_min_1_half.Location = new System.Drawing.Point(9, 86);
            this.btn_1_min_1_half.Name = "btn_1_min_1_half";
            this.btn_1_min_1_half.Size = new System.Drawing.Size(93, 23);
            this.btn_1_min_1_half.TabIndex = 2;
            this.btn_1_min_1_half.Text = "1-min-1-half";
            this.btn_1_min_1_half.UseVisualStyleBackColor = true;
            this.btn_1_min_1_half.Click += new System.EventHandler(this.btn_1_min_1_half_Click);
            // 
            // btn_1_min_1_spread
            // 
            this.btn_1_min_1_spread.Location = new System.Drawing.Point(9, 57);
            this.btn_1_min_1_spread.Name = "btn_1_min_1_spread";
            this.btn_1_min_1_spread.Size = new System.Drawing.Size(93, 23);
            this.btn_1_min_1_spread.TabIndex = 1;
            this.btn_1_min_1_spread.Text = "1-min-1-spread";
            this.btn_1_min_1_spread.UseVisualStyleBackColor = true;
            this.btn_1_min_1_spread.Click += new System.EventHandler(this.btn_1_min_1_spread_Click);
            // 
            // btn_1_min_1_wdl
            // 
            this.btn_1_min_1_wdl.Location = new System.Drawing.Point(9, 28);
            this.btn_1_min_1_wdl.Name = "btn_1_min_1_wdl";
            this.btn_1_min_1_wdl.Size = new System.Drawing.Size(93, 23);
            this.btn_1_min_1_wdl.TabIndex = 0;
            this.btn_1_min_1_wdl.Text = "1-min-1-wdl";
            this.btn_1_min_1_wdl.UseVisualStyleBackColor = true;
            this.btn_1_min_1_wdl.Click += new System.EventHandler(this.btn_1_min_1_wdl_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_over);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btn_load_match);
            this.groupBox2.Location = new System.Drawing.Point(6, 17);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 54);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loading Data";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btn_load_match
            // 
            this.btn_load_match.Location = new System.Drawing.Point(221, 17);
            this.btn_load_match.Name = "btn_load_match";
            this.btn_load_match.Size = new System.Drawing.Size(68, 23);
            this.btn_load_match.TabIndex = 0;
            this.btn_load_match.Text = "Load";
            this.btn_load_match.UseVisualStyleBackColor = true;
            this.btn_load_match.Click += new System.EventHandler(this.btn_load_match_Click);
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Location = new System.Drawing.Point(327, 2);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(879, 618);
            this.tab.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_match);
            this.tabPage1.Controls.Add(this.dgv_match);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(871, 592);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Conditon";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_match
            // 
            this.txt_match.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_match.Font = new System.Drawing.Font("Lucida Console", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_match.Location = new System.Drawing.Point(3, 199);
            this.txt_match.Multiline = true;
            this.txt_match.Name = "txt_match";
            this.txt_match.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_match.Size = new System.Drawing.Size(863, 388);
            this.txt_match.TabIndex = 1;
            // 
            // dgv_match
            // 
            this.dgv_match.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_match.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_match.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_match.Location = new System.Drawing.Point(3, 3);
            this.dgv_match.Name = "dgv_match";
            this.dgv_match.Size = new System.Drawing.Size(863, 190);
            this.dgv_match.TabIndex = 0;
            this.dgv_match.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_match_RowEnter);
            this.dgv_match.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_match_CellMouseDown);
            this.dgv_match.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_match_DataBindingComplete);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_compute_result);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(871, 592);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compute Result";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_compute_result
            // 
            this.txt_compute_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_compute_result.Font = new System.Drawing.Font("Lucida Console", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_compute_result.Location = new System.Drawing.Point(3, 3);
            this.txt_compute_result.Multiline = true;
            this.txt_compute_result.Name = "txt_compute_result";
            this.txt_compute_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_compute_result.Size = new System.Drawing.Size(865, 586);
            this.txt_compute_result.TabIndex = 2;
            this.txt_compute_result.TextChanged += new System.EventHandler(this.txt_compute_result_TextChanged);
            // 
            // cb_over
            // 
            this.cb_over.AutoSize = true;
            this.cb_over.Location = new System.Drawing.Point(167, 21);
            this.cb_over.Name = "cb_over";
            this.cb_over.Size = new System.Drawing.Size(49, 17);
            this.cb_over.TabIndex = 5;
            this.cb_over.Text = "Over";
            this.cb_over.UseVisualStyleBackColor = true;
            // 
            // FrmMixMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 625);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMixMatch";
            this.Text = "Persent Compute";
            this.Load += new System.EventHandler(this.FrmMatch_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_match)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_match;
        private System.Windows.Forms.DataGridView dgv_match;
        private System.Windows.Forms.TextBox txt_compute_result;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_load_match;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_1_min_1_wdl;
        private System.Windows.Forms.Button btn_1_min_1_spread;
        private System.Windows.Forms.Button btn_1_min_1_half;
        private System.Windows.Forms.Button btn_1_min_1_total;
        private System.Windows.Forms.Button btn_1_min_1_point;
        private System.Windows.Forms.CheckBox cb_over;
    }
}