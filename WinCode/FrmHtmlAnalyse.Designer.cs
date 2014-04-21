  partial class FrmHtmlAnalyse
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
            this.btn_fuzzy_find = new System.Windows.Forms.Button();
            this.txt_condition = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_load_from_html_source = new System.Windows.Forms.CheckBox();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_load = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_html_source = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_fuzzy_find);
            this.groupBox1.Controls.Add(this.txt_condition);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cb_load_from_html_source);
            this.groupBox1.Controls.Add(this.btn_select);
            this.groupBox1.Controls.Add(this.btn_load);
            this.groupBox1.Controls.Add(this.txt_path);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_url);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(984, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // btn_fuzzy_find
            // 
            this.btn_fuzzy_find.Location = new System.Drawing.Point(276, 90);
            this.btn_fuzzy_find.Name = "btn_fuzzy_find";
            this.btn_fuzzy_find.Size = new System.Drawing.Size(93, 21);
            this.btn_fuzzy_find.TabIndex = 9;
            this.btn_fuzzy_find.Text = "Fuzzy Select";
            this.btn_fuzzy_find.UseVisualStyleBackColor = true;
            this.btn_fuzzy_find.Click += new System.EventHandler(this.btn_fuzzy_find_Click);
            // 
            // txt_condition
            // 
            this.txt_condition.Location = new System.Drawing.Point(114, 39);
            this.txt_condition.Name = "txt_condition";
            this.txt_condition.Size = new System.Drawing.Size(830, 21);
            this.txt_condition.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fuzzy Conditon:";
            // 
            // cb_load_from_html_source
            // 
            this.cb_load_from_html_source.AutoSize = true;
            this.cb_load_from_html_source.Location = new System.Drawing.Point(114, 93);
            this.cb_load_from_html_source.Name = "cb_load_from_html_source";
            this.cb_load_from_html_source.Size = new System.Drawing.Size(150, 16);
            this.cb_load_from_html_source.TabIndex = 6;
            this.cb_load_from_html_source.Text = "Load From Html Source";
            this.cb_load_from_html_source.UseVisualStyleBackColor = true;
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(375, 90);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(93, 21);
            this.btn_select.TabIndex = 5;
            this.btn_select.Text = "Select Element";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // btn_load
            // 
            this.btn_load.Location = new System.Drawing.Point(12, 90);
            this.btn_load.Name = "btn_load";
            this.btn_load.Size = new System.Drawing.Size(96, 21);
            this.btn_load.TabIndex = 4;
            this.btn_load.Text = "Load Doc";
            this.btn_load.UseVisualStyleBackColor = true;
            this.btn_load.Click += new System.EventHandler(this.btn_load_Click);
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(114, 64);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(830, 21);
            this.txt_path.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Element Path:";
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(114, 12);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(830, 21);
            this.txt_url.TabIndex = 1;
            this.txt_url.Text = "http://192.168.1.221/efnet_test/src/_Common/AppUtil/FrameSet/EFDBLogin.aspx";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Web Url:";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(5, 128);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 389);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_html_source);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(976, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Html Source";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_html_source
            // 
            this.txt_html_source.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_html_source.Location = new System.Drawing.Point(3, 3);
            this.txt_html_source.Multiline = true;
            this.txt_html_source.Name = "txt_html_source";
            this.txt_html_source.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_html_source.Size = new System.Drawing.Size(970, 357);
            this.txt_html_source.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txt_result);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(967, 363);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Elements Text";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_result
            // 
            this.txt_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_result.Location = new System.Drawing.Point(0, 0);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_result.Size = new System.Drawing.Size(967, 365);
            this.txt_result.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgv_result);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(967, 363);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Element DataTable";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgv_result
            // 
            this.dgv_result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_result.Location = new System.Drawing.Point(0, 0);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.Size = new System.Drawing.Size(967, 365);
            this.dgv_result.TabIndex = 0;
            // 
            // FrmHtmlAnalyse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 522);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmHtmlAnalyse";
            this.Text = "Html Analyse";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_load;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TextBox txt_html_source;
        private System.Windows.Forms.CheckBox cb_load_from_html_source;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.TextBox txt_condition;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_fuzzy_find;
    } 