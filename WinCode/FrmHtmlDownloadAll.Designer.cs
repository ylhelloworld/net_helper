namespace WinCode
{
    partial class FrmHtmlDownloadAll
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
            this.btn_upload = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_file_path = new System.Windows.Forms.TextBox();
            this.txt_url = new System.Windows.Forms.TextBox();
            this.btn_down = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Data = new System.Windows.Forms.TabPage();
            this.txt_data = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Data.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_upload);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txt_file_path);
            this.groupBox1.Controls.Add(this.txt_url);
            this.groupBox1.Controls.Add(this.btn_down);
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(975, 87);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(707, 33);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(75, 23);
            this.btn_upload.TabIndex = 5;
            this.btn_upload.Text = "Upload";
            this.btn_upload.UseVisualStyleBackColor = true;
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "File Path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL:";
            // 
            // txt_file_path
            // 
            this.txt_file_path.Location = new System.Drawing.Point(59, 47);
            this.txt_file_path.Name = "txt_file_path";
            this.txt_file_path.Size = new System.Drawing.Size(541, 20);
            this.txt_file_path.TabIndex = 2;
            this.txt_file_path.Text = "c:\\test.txt";
            // 
            // txt_url
            // 
            this.txt_url.Location = new System.Drawing.Point(59, 21);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(541, 20);
            this.txt_url.TabIndex = 1;
            this.txt_url.Text = "http://192.168.1.221/huanan/Tool.ashx?type=1&param=\\tool.txt";
            // 
            // btn_down
            // 
            this.btn_down.Location = new System.Drawing.Point(617, 33);
            this.btn_down.Name = "btn_down";
            this.btn_down.Size = new System.Drawing.Size(75, 23);
            this.btn_down.TabIndex = 0;
            this.btn_down.Text = "Down";
            this.btn_down.UseVisualStyleBackColor = true;
            this.btn_down.Click += new System.EventHandler(this.btn_down_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Data);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(5, 96);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(975, 458);
            this.tabControl1.TabIndex = 1;
            // 
            // Data
            // 
            this.Data.Controls.Add(this.txt_data);
            this.Data.Location = new System.Drawing.Point(4, 22);
            this.Data.Name = "Data";
            this.Data.Padding = new System.Windows.Forms.Padding(3);
            this.Data.Size = new System.Drawing.Size(967, 432);
            this.Data.TabIndex = 0;
            this.Data.Text = "Data";
            this.Data.UseVisualStyleBackColor = true;
            // 
            // txt_data
            // 
            this.txt_data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_data.Location = new System.Drawing.Point(3, 3);
            this.txt_data.Multiline = true;
            this.txt_data.Name = "txt_data";
            this.txt_data.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_data.Size = new System.Drawing.Size(961, 426);
            this.txt_data.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txt_result);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(967, 432);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Result";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txt_result
            // 
            this.txt_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_result.Location = new System.Drawing.Point(3, 3);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_result.Size = new System.Drawing.Size(961, 426);
            this.txt_result.TabIndex = 1;
            this.txt_result.TextChanged += new System.EventHandler(this.txt_result_TextChanged);
            this.txt_result.TextAlignChanged += new System.EventHandler(this.txt_result_TextAlignChanged);
            // 
            // FrmHtmlDownloadAll
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmHtmlDownloadAll";
            this.Text = "Down All File";
            this.Load += new System.EventHandler(this.FrmHtmlDownloadAll_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Data.ResumeLayout(false);
            this.Data.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Data;
        private System.Windows.Forms.TextBox txt_data;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.Button btn_down;
        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.TextBox txt_file_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_upload;
    }
}