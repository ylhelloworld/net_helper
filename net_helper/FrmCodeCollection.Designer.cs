namespace WinCode
{
    partial class FrmCodeCollection
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
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_use = new System.Windows.Forms.Button();
            this.btn_find = new System.Windows.Forms.Button();
            this.txt_condition = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_result
            // 
            this.dgv_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Location = new System.Drawing.Point(6, 56);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.Size = new System.Drawing.Size(974, 342);
            this.dgv_result.TabIndex = 0;
            this.dgv_result.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_result_RowEnter);
            this.dgv_result.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_result_CellMouseDown);
            this.dgv_result.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_result_DataBindingComplete);
            // 
            // txt_result
            // 
            this.txt_result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_result.Location = new System.Drawing.Point(6, 404);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_result.Size = new System.Drawing.Size(974, 150);
            this.txt_result.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_use);
            this.groupBox1.Controls.Add(this.btn_find);
            this.groupBox1.Controls.Add(this.txt_condition);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(974, 48);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // btn_use
            // 
            this.btn_use.Location = new System.Drawing.Point(382, 16);
            this.btn_use.Name = "btn_use";
            this.btn_use.Size = new System.Drawing.Size(75, 23);
            this.btn_use.TabIndex = 2;
            this.btn_use.Text = "Use";
            this.btn_use.UseVisualStyleBackColor = true;
            this.btn_use.Click += new System.EventHandler(this.btn_use_Click);
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(289, 16);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(75, 23);
            this.btn_find.TabIndex = 1;
            this.btn_find.Text = "Find";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // txt_condition
            // 
            this.txt_condition.Location = new System.Drawing.Point(27, 19);
            this.txt_condition.Name = "txt_condition";
            this.txt_condition.Size = new System.Drawing.Size(241, 20);
            this.txt_condition.TabIndex = 0;
            // 
            // FrmCodeCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.dgv_result);
            this.Name = "FrmCodeCollection";
            this.Text = "Code Collection";
            this.Load += new System.EventHandler(this.FrmCodeCollection_Load);
            this.SizeChanged += new System.EventHandler(this.FrmCodeCollection_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_condition;
        private System.Windows.Forms.Button btn_use;
    }
}