namespace WinCode
{
    partial class FrmHtmlAgiligtyPack
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
            this.btn_html_load = new System.Windows.Forms.Button();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.txt_html_result = new System.Windows.Forms.TextBox();
            this.txt_condition = new System.Windows.Forms.TextBox();
            this.txt_html = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txt_db_result = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.browser = new System.Windows.Forms.WebBrowser();
            this.btn_html_select = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_update = new System.Windows.Forms.TextBox();
            this.txt_id = new System.Windows.Forms.TextBox();
            this.btn_insert = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_insert = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_select = new System.Windows.Forms.TextBox();
            this.btn_test = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_html_load
            // 
            this.btn_html_load.Location = new System.Drawing.Point(6, 72);
            this.btn_html_load.Name = "btn_html_load";
            this.btn_html_load.Size = new System.Drawing.Size(75, 23);
            this.btn_html_load.TabIndex = 0;
            this.btn_html_load.Text = "Load";
            this.btn_html_load.UseVisualStyleBackColor = true;
            this.btn_html_load.Click += new System.EventHandler(this.btn_html_load_Click);
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(6, 20);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(412, 20);
            this.txt_url.TabIndex = 1;
            this.txt_url.Text = "http://192.168.1.221/efnet_test/src/_Common/AppUtil/FrameSet/EFDBLogin.aspx";
            // 
            // txt_html_result
            // 
            this.txt_html_result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_html_result.Location = new System.Drawing.Point(6, 235);
            this.txt_html_result.Multiline = true;
            this.txt_html_result.Name = "txt_html_result";
            this.txt_html_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_html_result.Size = new System.Drawing.Size(564, 247);
            this.txt_html_result.TabIndex = 2;
            // 
            // txt_condition
            // 
            this.txt_condition.Location = new System.Drawing.Point(6, 46);
            this.txt_condition.Name = "txt_condition";
            this.txt_condition.Size = new System.Drawing.Size(414, 20);
            this.txt_condition.TabIndex = 3;
            // 
            // txt_html
            // 
            this.txt_html.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_html.Location = new System.Drawing.Point(6, 6);
            this.txt_html.Multiline = true;
            this.txt_html.Name = "txt_html";
            this.txt_html.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_html.Size = new System.Drawing.Size(564, 223);
            this.txt_html.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(450, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(594, 522);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_html);
            this.tabPage1.Controls.Add(this.txt_html_result);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(586, 496);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "HTML";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txt_db_result);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(586, 496);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "DB";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txt_db_result
            // 
            this.txt_db_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_db_result.Location = new System.Drawing.Point(0, 0);
            this.txt_db_result.Multiline = true;
            this.txt_db_result.Name = "txt_db_result";
            this.txt_db_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_db_result.Size = new System.Drawing.Size(586, 496);
            this.txt_db_result.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.browser);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(586, 496);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Web";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // browser
            // 
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.Location = new System.Drawing.Point(3, 3);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(580, 490);
            this.browser.TabIndex = 0;
            // 
            // btn_html_select
            // 
            this.btn_html_select.Location = new System.Drawing.Point(87, 72);
            this.btn_html_select.Name = "btn_html_select";
            this.btn_html_select.Size = new System.Drawing.Size(75, 23);
            this.btn_html_select.TabIndex = 6;
            this.btn_html_select.Text = "Select";
            this.btn_html_select.UseVisualStyleBackColor = true;
            this.btn_html_select.Click += new System.EventHandler(this.btn_html_select_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txt_url);
            this.groupBox1.Controls.Add(this.btn_html_select);
            this.groupBox1.Controls.Add(this.txt_condition);
            this.groupBox1.Controls.Add(this.btn_html_load);
            this.groupBox1.Location = new System.Drawing.Point(16, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(428, 109);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Html";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_test);
            this.groupBox2.Controls.Add(this.btn_update);
            this.groupBox2.Controls.Add(this.btn_select);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_update);
            this.groupBox2.Controls.Add(this.txt_id);
            this.groupBox2.Controls.Add(this.btn_insert);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txt_insert);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_select);
            this.groupBox2.Location = new System.Drawing.Point(16, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(428, 297);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mongo DB";
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(87, 248);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 10;
            this.btn_update.Text = "Update";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(9, 248);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(75, 23);
            this.btn_select.TabIndex = 9;
            this.btn_select.Text = "Select";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "UPDATE";
            // 
            // txt_update
            // 
            this.txt_update.Location = new System.Drawing.Point(6, 197);
            this.txt_update.Multiline = true;
            this.txt_update.Name = "txt_update";
            this.txt_update.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_update.Size = new System.Drawing.Size(412, 45);
            this.txt_update.TabIndex = 7;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(6, 24);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(412, 20);
            this.txt_id.TabIndex = 6;
            this.txt_id.Text = "EFDBLogin.aspx";
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(166, 248);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(75, 23);
            this.btn_insert.TabIndex = 4;
            this.btn_insert.Text = "Insert";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "INSERT";
            // 
            // txt_insert
            // 
            this.txt_insert.Location = new System.Drawing.Point(6, 133);
            this.txt_insert.Multiline = true;
            this.txt_insert.Name = "txt_insert";
            this.txt_insert.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_insert.Size = new System.Drawing.Size(412, 45);
            this.txt_insert.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SELECT";
            // 
            // txt_select
            // 
            this.txt_select.Location = new System.Drawing.Point(6, 69);
            this.txt_select.Multiline = true;
            this.txt_select.Name = "txt_select";
            this.txt_select.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_select.Size = new System.Drawing.Size(412, 43);
            this.txt_select.TabIndex = 0;
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(247, 248);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(75, 23);
            this.btn_test.TabIndex = 11;
            this.btn_test.Text = "Test";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // FrmHtmlAgiligtyPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 537);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmHtmlAgiligtyPack";
            this.Text = "HtmlAgiligty & MongoDB";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_html_load;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.TextBox txt_html_result;
        private System.Windows.Forms.TextBox txt_condition;
        private System.Windows.Forms.TextBox txt_html;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.Button btn_html_select;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_insert;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_select;
        private System.Windows.Forms.TextBox txt_id;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_update;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox txt_db_result;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_test;
    }
}