namespace WinCode
{
    partial class FrmEFFinish
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
            this.btn_finish = new System.Windows.Forms.Button();
            this.txt_form_no = new System.Windows.Forms.TextBox();
            this.dgv_resda = new System.Windows.Forms.DataGridView();
            this.txt_form_type = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv_resdb = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgv_resdc = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.dgv_resdd = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_find = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resda)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resdb)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resdc)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resdd)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_finish
            // 
            this.btn_finish.Location = new System.Drawing.Point(363, 17);
            this.btn_finish.Name = "btn_finish";
            this.btn_finish.Size = new System.Drawing.Size(75, 23);
            this.btn_finish.TabIndex = 0;
            this.btn_finish.Text = "Finish";
            this.btn_finish.UseVisualStyleBackColor = true;
            this.btn_finish.Click += new System.EventHandler(this.btn_finish_Click);
            // 
            // txt_form_no
            // 
            this.txt_form_no.Location = new System.Drawing.Point(132, 19);
            this.txt_form_no.Name = "txt_form_no";
            this.txt_form_no.Size = new System.Drawing.Size(123, 20);
            this.txt_form_no.TabIndex = 1;
            this.txt_form_no.Text = "0000000010";
            // 
            // dgv_resda
            // 
            this.dgv_resda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_resda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_resda.Location = new System.Drawing.Point(3, 3);
            this.dgv_resda.Name = "dgv_resda";
            this.dgv_resda.Size = new System.Drawing.Size(964, 523);
            this.dgv_resda.TabIndex = 2;
            // 
            // txt_form_type
            // 
            this.txt_form_type.Location = new System.Drawing.Point(6, 19);
            this.txt_form_type.Name = "txt_form_type";
            this.txt_form_type.Size = new System.Drawing.Size(120, 20);
            this.txt_form_type.TabIndex = 3;
            this.txt_form_type.Text = "ESH002";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(2, 75);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(978, 515);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_resda);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(970, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "RESDA";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgv_resdb);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(970, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "RESDB";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv_resdb
            // 
            this.dgv_resdb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_resdb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_resdb.Location = new System.Drawing.Point(3, 3);
            this.dgv_resdb.Name = "dgv_resdb";
            this.dgv_resdb.Size = new System.Drawing.Size(964, 523);
            this.dgv_resdb.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgv_resdc);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(970, 529);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "RESDC";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgv_resdc
            // 
            this.dgv_resdc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_resdc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_resdc.Location = new System.Drawing.Point(0, 0);
            this.dgv_resdc.Name = "dgv_resdc";
            this.dgv_resdc.Size = new System.Drawing.Size(970, 529);
            this.dgv_resdc.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.dgv_resdd);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(970, 489);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "RESDD";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgv_resdd
            // 
            this.dgv_resdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_resdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_resdd.Location = new System.Drawing.Point(0, 0);
            this.dgv_resdd.Name = "dgv_resdd";
            this.dgv_resdd.Size = new System.Drawing.Size(970, 489);
            this.dgv_resdd.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_find);
            this.groupBox1.Controls.Add(this.txt_form_type);
            this.groupBox1.Controls.Add(this.txt_form_no);
            this.groupBox1.Controls.Add(this.btn_finish);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(958, 57);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(270, 16);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(75, 23);
            this.btn_find.TabIndex = 4;
            this.btn_find.Text = "Find";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.btn_find_Click);
            // 
            // FrmEFFinish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 592);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmEFFinish";
            this.Text = "FrmEFFinish";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resda)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resdb)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resdc)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resdd)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_finish;
        private System.Windows.Forms.TextBox txt_form_no;
        private System.Windows.Forms.DataGridView dgv_resda;
        private System.Windows.Forms.TextBox txt_form_type;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGridView dgv_resdb;
        private System.Windows.Forms.DataGridView dgv_resdc;
        private System.Windows.Forms.DataGridView dgv_resdd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_find;
    }
}