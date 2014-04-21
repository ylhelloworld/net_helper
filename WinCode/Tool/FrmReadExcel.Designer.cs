namespace WinCode
{
    partial class FrmReadExcel
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
            this.btn_read = new System.Windows.Forms.Button();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.tbn_import_class = new System.Windows.Forms.Button();
            this.btn_import_box_no = new System.Windows.Forms.Button();
            this.btn_import_employee = new System.Windows.Forms.Button();
            this.txt_sql = new System.Windows.Forms.TextBox();
            this.btn_write = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_read
            // 
            this.btn_read.Location = new System.Drawing.Point(12, 12);
            this.btn_read.Name = "btn_read";
            this.btn_read.Size = new System.Drawing.Size(75, 23);
            this.btn_read.TabIndex = 0;
            this.btn_read.Text = "Read Excel";
            this.btn_read.UseVisualStyleBackColor = true;
            this.btn_read.Click += new System.EventHandler(this.btn_read_Click);
            // 
            // dgv_result
            // 
            this.dgv_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Location = new System.Drawing.Point(3, 41);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.Size = new System.Drawing.Size(873, 271);
            this.dgv_result.TabIndex = 1;
            // 
            // tbn_import_class
            // 
            this.tbn_import_class.Location = new System.Drawing.Point(93, 12);
            this.tbn_import_class.Name = "tbn_import_class";
            this.tbn_import_class.Size = new System.Drawing.Size(75, 23);
            this.tbn_import_class.TabIndex = 2;
            this.tbn_import_class.Text = "Import Class";
            this.tbn_import_class.UseVisualStyleBackColor = true;
            this.tbn_import_class.Click += new System.EventHandler(this.btn_import_class_Click);
            // 
            // btn_import_box_no
            // 
            this.btn_import_box_no.Location = new System.Drawing.Point(174, 12);
            this.btn_import_box_no.Name = "btn_import_box_no";
            this.btn_import_box_no.Size = new System.Drawing.Size(75, 23);
            this.btn_import_box_no.TabIndex = 3;
            this.btn_import_box_no.Text = "Import Box";
            this.btn_import_box_no.UseVisualStyleBackColor = true;
            this.btn_import_box_no.Click += new System.EventHandler(this.btn_import_box_no_Click);
            // 
            // btn_import_employee
            // 
            this.btn_import_employee.Location = new System.Drawing.Point(256, 12);
            this.btn_import_employee.Name = "btn_import_employee";
            this.btn_import_employee.Size = new System.Drawing.Size(94, 23);
            this.btn_import_employee.TabIndex = 4;
            this.btn_import_employee.Text = "Import Employee";
            this.btn_import_employee.UseVisualStyleBackColor = true;
            this.btn_import_employee.Click += new System.EventHandler(this.btn_import_employee_Click);
            // 
            // txt_sql
            // 
            this.txt_sql.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_sql.Location = new System.Drawing.Point(3, 318);
            this.txt_sql.MaxLength = 0;
            this.txt_sql.Multiline = true;
            this.txt_sql.Name = "txt_sql";
            this.txt_sql.ReadOnly = true;
            this.txt_sql.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_sql.Size = new System.Drawing.Size(873, 165);
            this.txt_sql.TabIndex = 5;
            this.txt_sql.TextChanged += new System.EventHandler(this.txt_sql_TextChanged);
            // 
            // btn_write
            // 
            this.btn_write.Location = new System.Drawing.Point(357, 12);
            this.btn_write.Name = "btn_write";
            this.btn_write.Size = new System.Drawing.Size(89, 23);
            this.btn_write.TabIndex = 6;
            this.btn_write.Text = "Write Memory";
            this.btn_write.UseVisualStyleBackColor = true;
            this.btn_write.Click += new System.EventHandler(this.btn_write_Click);
            // 
            // FrmReadExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 486);
            this.Controls.Add(this.btn_write);
            this.Controls.Add(this.txt_sql);
            this.Controls.Add(this.btn_import_employee);
            this.Controls.Add(this.btn_import_box_no);
            this.Controls.Add(this.tbn_import_class);
            this.Controls.Add(this.dgv_result);
            this.Controls.Add(this.btn_read);
            this.Name = "FrmReadExcel";
            this.Text = "Read Excel";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_read;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.Button tbn_import_class;
        private System.Windows.Forms.Button btn_import_box_no;
        private System.Windows.Forms.Button btn_import_employee;
        private System.Windows.Forms.TextBox txt_sql;
        private System.Windows.Forms.Button btn_write;
    }
}