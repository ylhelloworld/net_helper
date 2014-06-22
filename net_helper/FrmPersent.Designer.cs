namespace WinCode
{
    partial class FrmPersent
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
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_find_condition = new System.Windows.Forms.TextBox();
            this.btn_find_result = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_create_group = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_count_end = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_compute = new System.Windows.Forms.Button();
            this.txt_count_start = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_load = new System.Windows.Forms.Button();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_condition = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_compute = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.btn_compute_second = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_condition)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(8, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 541);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_find_condition);
            this.groupBox5.Controls.Add(this.btn_find_result);
            this.groupBox5.Location = new System.Drawing.Point(6, 169);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(284, 179);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Find Result";
            // 
            // txt_find_condition
            // 
            this.txt_find_condition.Location = new System.Drawing.Point(10, 20);
            this.txt_find_condition.Multiline = true;
            this.txt_find_condition.Name = "txt_find_condition";
            this.txt_find_condition.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_find_condition.Size = new System.Drawing.Size(268, 119);
            this.txt_find_condition.TabIndex = 4;
            this.txt_find_condition.Text = "{\r\n  \'host1\':\'#\',\r\n  \'host2\':\'#\', \r\n}";
            // 
            // btn_find_result
            // 
            this.btn_find_result.Location = new System.Drawing.Point(6, 145);
            this.btn_find_result.Name = "btn_find_result";
            this.btn_find_result.Size = new System.Drawing.Size(97, 21);
            this.btn_find_result.TabIndex = 3;
            this.btn_find_result.Text = "Find Result";
            this.btn_find_result.UseVisualStyleBackColor = true;
            this.btn_find_result.Click += new System.EventHandler(this.btn_find_result_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_create_group);
            this.groupBox4.Location = new System.Drawing.Point(6, 354);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(284, 46);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Help Tool";
            // 
            // btn_create_group
            // 
            this.btn_create_group.Location = new System.Drawing.Point(6, 19);
            this.btn_create_group.Name = "btn_create_group";
            this.btn_create_group.Size = new System.Drawing.Size(97, 21);
            this.btn_create_group.TabIndex = 3;
            this.btn_create_group.Text = "Create Group";
            this.btn_create_group.UseVisualStyleBackColor = true;
            this.btn_create_group.Click += new System.EventHandler(this.btn_create_group_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_compute_second);
            this.groupBox3.Controls.Add(this.txt_count_end);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btn_compute);
            this.groupBox3.Controls.Add(this.txt_count_start);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(6, 86);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(284, 77);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Compute Tool";
            // 
            // txt_count_end
            // 
            this.txt_count_end.Location = new System.Drawing.Point(148, 15);
            this.txt_count_end.Name = "txt_count_end";
            this.txt_count_end.Size = new System.Drawing.Size(48, 21);
            this.txt_count_end.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "~";
            // 
            // btn_compute
            // 
            this.btn_compute.Location = new System.Drawing.Point(6, 46);
            this.btn_compute.Name = "btn_compute";
            this.btn_compute.Size = new System.Drawing.Size(97, 21);
            this.btn_compute.TabIndex = 0;
            this.btn_compute.Text = "Compute";
            this.btn_compute.UseVisualStyleBackColor = true;
            this.btn_compute.Click += new System.EventHandler(this.btn_compute_Click);
            // 
            // txt_count_start
            // 
            this.txt_count_start.Location = new System.Drawing.Point(79, 16);
            this.txt_count_start.Name = "txt_count_start";
            this.txt_count_start.Size = new System.Drawing.Size(48, 21);
            this.txt_count_start.TabIndex = 1;
            this.txt_count_start.Text = "10";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Bid Count:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_load);
            this.groupBox2.Location = new System.Drawing.Point(6, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(284, 46);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Load Match";
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(6, 17);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(97, 21);
            this.btn_load.TabIndex = 2;
            this.btn_load.Text = "Load";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // tab
            // 
            this.tab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tab.Controls.Add(this.tabPage1);
            this.tab.Controls.Add(this.tabPage2);
            this.tab.Controls.Add(this.tabPage3);
            this.tab.Location = new System.Drawing.Point(310, 4);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(824, 542);
            this.tab.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_condition);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(816, 516);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Match";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgv_condition
            // 
            this.dgv_condition.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_condition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_condition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_condition.Location = new System.Drawing.Point(3, 3);
            this.dgv_condition.Name = "dgv_condition";
            this.dgv_condition.Size = new System.Drawing.Size(810, 510);
            this.dgv_condition.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_compute);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(816, 516);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Compute Result";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_compute
            // 
            this.txt_compute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_compute.Font = new System.Drawing.Font("Lucida Console", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_compute.Location = new System.Drawing.Point(3, 3);
            this.txt_compute.Multiline = true;
            this.txt_compute.Name = "txt_compute";
            this.txt_compute.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_compute.Size = new System.Drawing.Size(810, 510);
            this.txt_compute.TabIndex = 0;
            this.txt_compute.TextChanged += new System.EventHandler(this.txt_compute_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgv_result);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(816, 516);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Compute Result[Table]";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgv_result
            // 
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_result.Location = new System.Drawing.Point(0, 0);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.Size = new System.Drawing.Size(816, 516);
            this.dgv_result.TabIndex = 0;
            // 
            // btn_compute_second
            // 
            this.btn_compute_second.Location = new System.Drawing.Point(109, 46);
            this.btn_compute_second.Name = "btn_compute_second";
            this.btn_compute_second.Size = new System.Drawing.Size(97, 21);
            this.btn_compute_second.TabIndex = 8;
            this.btn_compute_second.Text = "Compute Second";
            this.btn_compute_second.UseVisualStyleBackColor = true;
            this.btn_compute_second.Click += new System.EventHandler(this.btn_compute_second_Click);
            // 
            // FrmPersent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 557);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmPersent";
            this.Text = "FrmPersent";
            this.Load += new System.EventHandler(this.FrmPersent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tab.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_condition)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tab;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_compute;
        private System.Windows.Forms.TextBox txt_compute;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.DataGridView dgv_condition;
        private System.Windows.Forms.TextBox txt_count_start;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.Button btn_create_group;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txt_find_condition;
        private System.Windows.Forms.Button btn_find_result;
        private System.Windows.Forms.TextBox txt_count_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_compute_second;
    }
}