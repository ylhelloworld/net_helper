namespace WinCode
{
    partial class FrmHook
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
            this.btn_run = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_key = new System.Windows.Forms.Button();
            this.btn_file = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(327, 15);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 23);
            this.btn_run.TabIndex = 0;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(13, 15);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(295, 20);
            this.txt_path.TabIndex = 1;
            this.txt_path.Text = "C:\\Program Files\\Internet Explorer\\iexplore.exe";
            // 
            // btn_key
            // 
            this.btn_key.Location = new System.Drawing.Point(13, 42);
            this.btn_key.Name = "btn_key";
            this.btn_key.Size = new System.Drawing.Size(75, 23);
            this.btn_key.TabIndex = 2;
            this.btn_key.Text = "Key";
            this.btn_key.UseVisualStyleBackColor = true;
            this.btn_key.Click += new System.EventHandler(this.btn_key_Click);
            // 
            // btn_file
            // 
            this.btn_file.Location = new System.Drawing.Point(94, 42);
            this.btn_file.Name = "btn_file";
            this.btn_file.Size = new System.Drawing.Size(75, 23);
            this.btn_file.TabIndex = 3;
            this.btn_file.Text = "File";
            this.btn_file.UseVisualStyleBackColor = true;
            this.btn_file.Click += new System.EventHandler(this.btn_file_Click);
            // 
            // FrmHook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 131);
            this.Controls.Add(this.btn_file);
            this.Controls.Add(this.btn_key);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.btn_run);
            this.Name = "FrmHook";
            this.Text = "FrmHook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_key;
        private System.Windows.Forms.Button btn_file;
    }
}