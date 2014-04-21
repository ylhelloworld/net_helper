namespace WinCode
{
    partial class FrmFixedUrlSet
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
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_find = new System.Windows.Forms.Button();
            this.txt_condition = new System.Windows.Forms.TextBox();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.txt_cell = new System.Windows.Forms.TextBox();
            this.btn_beautify = new System.Windows.Forms.Button();
            this.lb_row = new System.Windows.Forms.Label();
            this.lb_column = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.btn_find);
            this.groupBox1.Controls.Add(this.txt_condition);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(977, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find && Set Fixed Url";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(349, 17);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 2;
            this.btn_save.Text = "Save to DB";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(267, 17);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(75, 23);
            this.btn_find.TabIndex = 1;
            this.btn_find.Text = "Find";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // txt_condition
            // 
            this.txt_condition.Location = new System.Drawing.Point(6, 19);
            this.txt_condition.Name = "txt_condition";
            this.txt_condition.Size = new System.Drawing.Size(254, 20);
            this.txt_condition.TabIndex = 0;
            // 
            // dgv_result
            // 
            this.dgv_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Location = new System.Drawing.Point(6, 71);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.Size = new System.Drawing.Size(977, 305);
            this.dgv_result.TabIndex = 0;
            this.dgv_result.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_result_CellClick);
            this.dgv_result.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_result_DataBindingComplete);
            // 
            // txt_cell
            // 
            this.txt_cell.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_cell.Location = new System.Drawing.Point(6, 19);
            this.txt_cell.Multiline = true;
            this.txt_cell.Name = "txt_cell";
            this.txt_cell.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_cell.Size = new System.Drawing.Size(854, 153);
            this.txt_cell.TabIndex = 2;
            this.txt_cell.TextChanged += new System.EventHandler(this.txt_cell_TextChanged);
            // 
            // btn_beautify
            // 
            this.btn_beautify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_beautify.Location = new System.Drawing.Point(866, 19);
            this.btn_beautify.Name = "btn_beautify";
            this.btn_beautify.Size = new System.Drawing.Size(87, 23);
            this.btn_beautify.TabIndex = 3;
            this.btn_beautify.Text = "Beautify JSON";
            this.btn_beautify.UseVisualStyleBackColor = true;
            this.btn_beautify.Click += new System.EventHandler(this.btn_beautify_Click);
            // 
            // lb_row
            // 
            this.lb_row.AutoSize = true;
            this.lb_row.Location = new System.Drawing.Point(863, 105);
            this.lb_row.Name = "lb_row";
            this.lb_row.Size = new System.Drawing.Size(13, 13);
            this.lb_row.TabIndex = 5;
            this.lb_row.Text = "0";
            this.lb_row.Visible = false;
            // 
            // lb_column
            // 
            this.lb_column.AutoSize = true;
            this.lb_column.Location = new System.Drawing.Point(863, 122);
            this.lb_column.Name = "lb_column";
            this.lb_column.Size = new System.Drawing.Size(13, 13);
            this.lb_column.TabIndex = 6;
            this.lb_column.Text = "0";
            this.lb_column.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btn_check);
            this.groupBox2.Controls.Add(this.txt_cell);
            this.groupBox2.Controls.Add(this.lb_column);
            this.groupBox2.Controls.Add(this.btn_beautify);
            this.groupBox2.Controls.Add(this.lb_row);
            this.groupBox2.Location = new System.Drawing.Point(4, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(977, 182);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Operation";
            // 
            // btn_check
            // 
            this.btn_check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_check.Location = new System.Drawing.Point(866, 48);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(87, 23);
            this.btn_check.TabIndex = 7;
            this.btn_check.Text = "Check JSON";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // FrmFixedUrlSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgv_result);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmFixedUrlSet";
            this.Text = "Set Fixed Url";
            this.Load += new System.EventHandler(this.FrmUrlFixed_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.TextBox txt_condition;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.TextBox txt_cell;
        private System.Windows.Forms.Button btn_beautify;
        private System.Windows.Forms.Label lb_row;
        private System.Windows.Forms.Label lb_column;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_check;
    }
}