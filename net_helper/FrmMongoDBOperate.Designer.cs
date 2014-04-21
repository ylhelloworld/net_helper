
partial class FrmMongoDBOperate
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
            this.lab_beautify = new System.Windows.Forms.Label();
            this.btn_beautify = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_insert = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_operate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_select = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tv_result = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.lab_beautify);
            this.groupBox1.Controls.Add(this.btn_beautify);
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Controls.Add(this.btn_update);
            this.groupBox1.Controls.Add(this.btn_insert);
            this.groupBox1.Controls.Add(this.btn_select);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_operate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_select);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(982, 233);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // lab_beautify
            // 
            this.lab_beautify.AutoSize = true;
            this.lab_beautify.Location = new System.Drawing.Point(782, 25);
            this.lab_beautify.Name = "lab_beautify";
            this.lab_beautify.Size = new System.Drawing.Size(0, 13);
            this.lab_beautify.TabIndex = 14;
            // 
            // btn_beautify
            // 
            this.btn_beautify.AutoSize = true;
            this.btn_beautify.Location = new System.Drawing.Point(376, 20);
            this.btn_beautify.Name = "btn_beautify";
            this.btn_beautify.Size = new System.Drawing.Size(75, 25);
            this.btn_beautify.TabIndex = 13;
            this.btn_beautify.Text = "Beautify";
            this.btn_beautify.UseVisualStyleBackColor = true;
            this.btn_beautify.Click += new System.EventHandler(this.btn_beautify_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.AutoSize = true;
            this.btn_delete.Location = new System.Drawing.Point(294, 20);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 25);
            this.btn_delete.TabIndex = 12;
            this.btn_delete.Text = "DELETE";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // btn_update
            // 
            this.btn_update.AutoSize = true;
            this.btn_update.Location = new System.Drawing.Point(213, 20);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 25);
            this.btn_update.TabIndex = 11;
            this.btn_update.Text = "UPDATE";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_insert
            // 
            this.btn_insert.AutoSize = true;
            this.btn_insert.Location = new System.Drawing.Point(132, 20);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(75, 25);
            this.btn_insert.TabIndex = 10;
            this.btn_insert.Text = "INSERT";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // btn_select
            // 
            this.btn_select.AutoSize = true;
            this.btn_select.Location = new System.Drawing.Point(51, 20);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(75, 25);
            this.btn_select.TabIndex = 9;
            this.btn_select.Text = "SELECT";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(369, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "OPERATE";
            // 
            // txt_operate
            // 
            this.txt_operate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_operate.Location = new System.Drawing.Point(428, 54);
            this.txt_operate.Multiline = true;
            this.txt_operate.Name = "txt_operate";
            this.txt_operate.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_operate.Size = new System.Drawing.Size(547, 157);
            this.txt_operate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "SELECT";
            // 
            // txt_select
            // 
            this.txt_select.Location = new System.Drawing.Point(52, 54);
            this.txt_select.Multiline = true;
            this.txt_select.Name = "txt_select";
            this.txt_select.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_select.Size = new System.Drawing.Size(317, 157);
            this.txt_select.TabIndex = 3;
            this.txt_select.Text = "{}";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 243);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(982, 312);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txt_result);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(974, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "JSON View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txt_result
            // 
            this.txt_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_result.Location = new System.Drawing.Point(3, 3);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_result.Size = new System.Drawing.Size(968, 280);
            this.txt_result.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tv_result);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(974, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tree View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tv_result
            // 
            this.tv_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tv_result.Location = new System.Drawing.Point(3, 3);
            this.tv_result.Name = "tv_result";
            this.tv_result.Size = new System.Drawing.Size(968, 280);
            this.tv_result.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgv_result);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(974, 286);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Table View";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgv_result
            // 
            this.dgv_result.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_result.Location = new System.Drawing.Point(0, 0);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.Size = new System.Drawing.Size(974, 286);
            this.dgv_result.TabIndex = 0;
            // 
            // FrmMongoDBOperate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmMongoDBOperate";
            this.Text = "MongoDB Operation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_operate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_select;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.TreeView tv_result;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.Button btn_beautify;
        private System.Windows.Forms.Label lab_beautify;
    } 