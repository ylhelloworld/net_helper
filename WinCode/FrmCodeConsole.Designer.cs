namespace WinCode
{
    partial class FrmCodeConsole
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
            this.txt_code = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_clear_result = new System.Windows.Forms.Button();
            this.btn_clear_code = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.txt_tag = new System.Windows.Forms.TextBox();
            this.btn_save_code = new System.Windows.Forms.Button();
            this.btn_get_code = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_code
            // 
            this.txt_code.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_code.Font = new System.Drawing.Font("新宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_code.Location = new System.Drawing.Point(3, 2);
            this.txt_code.Multiline = true;
            this.txt_code.Name = "txt_code";
            this.txt_code.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_code.Size = new System.Drawing.Size(986, 333);
            this.txt_code.TabIndex = 0;
            this.txt_code.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_code_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_get_code);
            this.groupBox1.Controls.Add(this.btn_save_code);
            this.groupBox1.Controls.Add(this.txt_tag);
            this.groupBox1.Controls.Add(this.btn_clear_result);
            this.groupBox1.Controls.Add(this.btn_clear_code);
            this.groupBox1.Controls.Add(this.btn_run);
            this.groupBox1.Controls.Add(this.txt_result);
            this.groupBox1.Location = new System.Drawing.Point(3, 341);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(986, 213);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // btn_clear_result
            // 
            this.btn_clear_result.Location = new System.Drawing.Point(210, 16);
            this.btn_clear_result.Name = "btn_clear_result";
            this.btn_clear_result.Size = new System.Drawing.Size(75, 23);
            this.btn_clear_result.TabIndex = 3;
            this.btn_clear_result.Text = "Clear Result";
            this.btn_clear_result.UseVisualStyleBackColor = true;
            this.btn_clear_result.Click += new System.EventHandler(this.btn_clear_result_Click);
            // 
            // btn_clear_code
            // 
            this.btn_clear_code.Location = new System.Drawing.Point(129, 16);
            this.btn_clear_code.Name = "btn_clear_code";
            this.btn_clear_code.Size = new System.Drawing.Size(75, 23);
            this.btn_clear_code.TabIndex = 2;
            this.btn_clear_code.Text = "Clear Code";
            this.btn_clear_code.UseVisualStyleBackColor = true;
            this.btn_clear_code.Click += new System.EventHandler(this.btn_clear_code_Click);
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(48, 16);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 23);
            this.btn_run.TabIndex = 1;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // txt_result
            // 
            this.txt_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_result.BackColor = System.Drawing.Color.White;
            this.txt_result.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_result.ForeColor = System.Drawing.Color.Black;
            this.txt_result.Location = new System.Drawing.Point(6, 45);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_result.Size = new System.Drawing.Size(974, 162);
            this.txt_result.TabIndex = 0;
            // 
            // txt_tag
            // 
            this.txt_tag.Location = new System.Drawing.Point(333, 16);
            this.txt_tag.Name = "txt_tag";
            this.txt_tag.Size = new System.Drawing.Size(152, 20);
            this.txt_tag.TabIndex = 4;
            // 
            // btn_save_code
            // 
            this.btn_save_code.Location = new System.Drawing.Point(492, 15);
            this.btn_save_code.Name = "btn_save_code";
            this.btn_save_code.Size = new System.Drawing.Size(75, 23);
            this.btn_save_code.TabIndex = 5;
            this.btn_save_code.Text = "Save Code";
            this.btn_save_code.UseVisualStyleBackColor = true;
            this.btn_save_code.Click += new System.EventHandler(this.btn_save_code_Click);
            // 
            // btn_get_code
            // 
            this.btn_get_code.Location = new System.Drawing.Point(574, 15);
            this.btn_get_code.Name = "btn_get_code";
            this.btn_get_code.Size = new System.Drawing.Size(75, 23);
            this.btn_get_code.TabIndex = 6;
            this.btn_get_code.Text = "Get Code";
            this.btn_get_code.UseVisualStyleBackColor = true;
            this.btn_get_code.Click += new System.EventHandler(this.btn_get_code_Click);
            // 
            // FrmCodeConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_code);
            this.Name = "FrmCodeConsole";
            this.Text = "C# Code Console";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.Button btn_clear_result;
        private System.Windows.Forms.Button btn_clear_code;
        private System.Windows.Forms.Button btn_save_code;
        private System.Windows.Forms.TextBox txt_tag;
        private System.Windows.Forms.Button btn_get_code;
    }
}