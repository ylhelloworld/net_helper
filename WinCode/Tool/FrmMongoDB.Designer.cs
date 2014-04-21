namespace WinCode
{
    partial class FrmMongoDB
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
            this.btn_insert = new System.Windows.Forms.Button();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.btn_find = new System.Windows.Forms.Button();
            this.txt_conditon = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_insert
            // 
            this.btn_insert.Location = new System.Drawing.Point(12, 9);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(75, 23);
            this.btn_insert.TabIndex = 0;
            this.btn_insert.Text = "Insert";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // txt_result
            // 
            this.txt_result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_result.Location = new System.Drawing.Point(2, 125);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_result.Size = new System.Drawing.Size(852, 277);
            this.txt_result.TabIndex = 1;
            // 
            // dgv_result
            // 
            this.dgv_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Location = new System.Drawing.Point(2, 408);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.Size = new System.Drawing.Size(852, 137);
            this.dgv_result.TabIndex = 2;
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(93, 9);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(75, 23);
            this.btn_find.TabIndex = 3;
            this.btn_find.Text = "Find";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // txt_conditon
            // 
            this.txt_conditon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_conditon.Location = new System.Drawing.Point(2, 32);
            this.txt_conditon.Multiline = true;
            this.txt_conditon.Name = "txt_conditon";
            this.txt_conditon.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_conditon.Size = new System.Drawing.Size(852, 87);
            this.txt_conditon.TabIndex = 4;
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(174, 9);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 5;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // FrmMongoDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 548);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.txt_conditon);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.dgv_result);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.btn_insert);
            this.Name = "FrmMongoDB";
            this.Text = "Mongodb DB";
            this.Load += new System.EventHandler(this.FrmMongoDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_conditon;
        private System.Windows.Forms.Button btn_delete;
    }
}