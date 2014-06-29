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
            this.btn_1_point_min = new System.Windows.Forms.Button();
            this.btn_1_total_min = new System.Windows.Forms.Button();
            this.btn_1_half_min = new System.Windows.Forms.Button();
            this.btn_1_spread_min = new System.Windows.Forms.Button();
            this.btn_1_wld_min = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_load_match = new System.Windows.Forms.Button();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_match = new System.Windows.Forms.TextBox();
            this.dgv_match = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_compute_result = new System.Windows.Forms.TextBox();
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
            this.groupBox1.Size = new System.Drawing.Size(317, 570);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_1_point_min);
            this.groupBox3.Controls.Add(this.btn_1_total_min);
            this.groupBox3.Controls.Add(this.btn_1_half_min);
            this.groupBox3.Controls.Add(this.btn_1_spread_min);
            this.groupBox3.Controls.Add(this.btn_1_wld_min);
            this.groupBox3.Location = new System.Drawing.Point(6, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(305, 290);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Compute Tool";
            // 
            // btn_1_point_min
            // 
            this.btn_1_point_min.Location = new System.Drawing.Point(9, 133);
            this.btn_1_point_min.Name = "btn_1_point_min";
            this.btn_1_point_min.Size = new System.Drawing.Size(87, 21);
            this.btn_1_point_min.TabIndex = 4;
            this.btn_1_point_min.Text = "1-point-min";
            this.btn_1_point_min.UseVisualStyleBackColor = true;
            this.btn_1_point_min.Click += new System.EventHandler(this.btn_1_point_min_Click);
            // 
            // btn_1_total_min
            // 
            this.btn_1_total_min.Location = new System.Drawing.Point(9, 106);
            this.btn_1_total_min.Name = "btn_1_total_min";
            this.btn_1_total_min.Size = new System.Drawing.Size(87, 21);
            this.btn_1_total_min.TabIndex = 3;
            this.btn_1_total_min.Text = "1-total-min";
            this.btn_1_total_min.UseVisualStyleBackColor = true;
            this.btn_1_total_min.Click += new System.EventHandler(this.btn_1_total_min_Click);
            // 
            // btn_1_half_min
            // 
            this.btn_1_half_min.Location = new System.Drawing.Point(9, 79);
            this.btn_1_half_min.Name = "btn_1_half_min";
            this.btn_1_half_min.Size = new System.Drawing.Size(87, 21);
            this.btn_1_half_min.TabIndex = 2;
            this.btn_1_half_min.Text = "1-half-min";
            this.btn_1_half_min.UseVisualStyleBackColor = true;
            this.btn_1_half_min.Click += new System.EventHandler(this.btn_1_half_min_Click);
            // 
            // btn_1_spread_min
            // 
            this.btn_1_spread_min.Location = new System.Drawing.Point(9, 53);
            this.btn_1_spread_min.Name = "btn_1_spread_min";
            this.btn_1_spread_min.Size = new System.Drawing.Size(87, 21);
            this.btn_1_spread_min.TabIndex = 1;
            this.btn_1_spread_min.Text = "1-spread-min";
            this.btn_1_spread_min.UseVisualStyleBackColor = true;
            this.btn_1_spread_min.Click += new System.EventHandler(this.btn_1_spread_min_Click);
            // 
            // btn_1_wld_min
            // 
            this.btn_1_wld_min.Location = new System.Drawing.Point(9, 26);
            this.btn_1_wld_min.Name = "btn_1_wld_min";
            this.btn_1_wld_min.Size = new System.Drawing.Size(87, 21);
            this.btn_1_wld_min.TabIndex = 0;
            this.btn_1_wld_min.Text = "1-wld-min";
            this.btn_1_wld_min.UseVisualStyleBackColor = true;
            this.btn_1_wld_min.Click += new System.EventHandler(this.btn_1_wld_min_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btn_load_match);
            this.groupBox2.Location = new System.Drawing.Point(6, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(305, 50);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Loading Data";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 21);
            this.textBox1.TabIndex = 1;
            // 
            // btn_load_match
            // 
            this.btn_load_match.Location = new System.Drawing.Point(201, 16);
            this.btn_load_match.Name = "btn_load_match";
            this.btn_load_match.Size = new System.Drawing.Size(79, 21);
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
            this.tab.Size = new System.Drawing.Size(879, 570);
            this.tab.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_match);
            this.tabPage1.Controls.Add(this.dgv_match);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(871, 544);
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
            this.txt_match.Location = new System.Drawing.Point(3, 184);
            this.txt_match.Multiline = true;
            this.txt_match.Name = "txt_match";
            this.txt_match.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_match.Size = new System.Drawing.Size(863, 358);
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
            this.dgv_match.Size = new System.Drawing.Size(863, 175);
            this.dgv_match.TabIndex = 0;
            this.dgv_match.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_match_CellMouseDown);
            this.dgv_match.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_match_DataBindingComplete);
            this.dgv_match.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_match_RowEnter);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_compute_result);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(871, 544);
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
            this.txt_compute_result.Size = new System.Drawing.Size(865, 538);
            this.txt_compute_result.TabIndex = 2;
            this.txt_compute_result.TextChanged += new System.EventHandler(this.txt_compute_result_TextChanged);
            // 
            // FrmMixMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1209, 577);
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
        private System.Windows.Forms.Button btn_1_wld_min;
        private System.Windows.Forms.Button btn_1_spread_min;
        private System.Windows.Forms.Button btn_1_half_min;
        private System.Windows.Forms.Button btn_1_total_min;
        private System.Windows.Forms.Button btn_1_point_min;
    }
}