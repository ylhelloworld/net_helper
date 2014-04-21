
partial class FrmTemplateOperate
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
            this.dgv_html_element = new System.Windows.Forms.DataGridView();
            this.txt_template_id = new System.Windows.Forms.TextBox();
            this.txt_template_url = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_reload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_save = new System.Windows.Forms.Button();
            this.txt_template_description = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_column = new System.Windows.Forms.Label();
            this.lb_row = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.btn_beautify = new System.Windows.Forms.Button();
            this.txt_cell = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_html_element)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_html_element
            // 
            this.dgv_html_element.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_html_element.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_html_element.Location = new System.Drawing.Point(3, 108);
            this.dgv_html_element.Name = "dgv_html_element";
            this.dgv_html_element.Size = new System.Drawing.Size(983, 223);
            this.dgv_html_element.TabIndex = 0;
            this.dgv_html_element.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_html_element_CellClick);
            this.dgv_html_element.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_html_element_DataBindingComplete);
            // 
            // txt_template_id
            // 
            this.txt_template_id.Location = new System.Drawing.Point(145, 20);
            this.txt_template_id.Name = "txt_template_id";
            this.txt_template_id.Size = new System.Drawing.Size(719, 20);
            this.txt_template_id.TabIndex = 2;
            // 
            // txt_template_url
            // 
            this.txt_template_url.Location = new System.Drawing.Point(145, 46);
            this.txt_template_url.Name = "txt_template_url";
            this.txt_template_url.Size = new System.Drawing.Size(719, 20);
            this.txt_template_url.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Template ID:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.btn_reload);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btn_save);
            this.groupBox2.Controls.Add(this.txt_template_description);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txt_template_url);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_template_id);
            this.groupBox2.Location = new System.Drawing.Point(3, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(977, 101);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Template Main Info";
            // 
            // btn_reload
            // 
            this.btn_reload.Location = new System.Drawing.Point(872, 51);
            this.btn_reload.Name = "btn_reload";
            this.btn_reload.Size = new System.Drawing.Size(75, 23);
            this.btn_reload.TabIndex = 10;
            this.btn_reload.Text = "Reload";
            this.btn_reload.UseVisualStyleBackColor = true;
            this.btn_reload.Click += new System.EventHandler(this.btn_reload_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Template Description:";
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(870, 22);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 5;
            this.btn_save.Text = "Save To DB";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // txt_template_description
            // 
            this.txt_template_description.Location = new System.Drawing.Point(145, 72);
            this.txt_template_description.Name = "txt_template_description";
            this.txt_template_description.Size = new System.Drawing.Size(719, 20);
            this.txt_template_description.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Template Url:";
            // 
            // lb_column
            // 
            this.lb_column.AutoSize = true;
            this.lb_column.Location = new System.Drawing.Point(908, 144);
            this.lb_column.Name = "lb_column";
            this.lb_column.Size = new System.Drawing.Size(13, 13);
            this.lb_column.TabIndex = 11;
            this.lb_column.Text = "0";
            this.lb_column.Visible = false;
            // 
            // lb_row
            // 
            this.lb_row.AutoSize = true;
            this.lb_row.Location = new System.Drawing.Point(876, 144);
            this.lb_row.Name = "lb_row";
            this.lb_row.Size = new System.Drawing.Size(13, 13);
            this.lb_row.TabIndex = 10;
            this.lb_row.Text = "0";
            this.lb_row.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_check);
            this.groupBox1.Controls.Add(this.lb_column);
            this.groupBox1.Controls.Add(this.btn_beautify);
            this.groupBox1.Controls.Add(this.lb_row);
            this.groupBox1.Controls.Add(this.txt_cell);
            this.groupBox1.Location = new System.Drawing.Point(3, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(977, 222);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // btn_check
            // 
            this.btn_check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_check.Location = new System.Drawing.Point(870, 66);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(92, 23);
            this.btn_check.TabIndex = 12;
            this.btn_check.Text = "Check JSON";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // btn_beautify
            // 
            this.btn_beautify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_beautify.Location = new System.Drawing.Point(871, 35);
            this.btn_beautify.Name = "btn_beautify";
            this.btn_beautify.Size = new System.Drawing.Size(92, 23);
            this.btn_beautify.TabIndex = 4;
            this.btn_beautify.Text = "Beautify JSON";
            this.btn_beautify.UseVisualStyleBackColor = true;
            this.btn_beautify.Click += new System.EventHandler(this.btn_beautify_Click);
            // 
            // txt_cell
            // 
            this.txt_cell.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_cell.Location = new System.Drawing.Point(6, 20);
            this.txt_cell.Multiline = true;
            this.txt_cell.Name = "txt_cell";
            this.txt_cell.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_cell.Size = new System.Drawing.Size(858, 197);
            this.txt_cell.TabIndex = 3;
            this.txt_cell.TextChanged += new System.EventHandler(this.txt_cell_TextChanged);
            // 
            // FrmTemplateOperate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgv_html_element);
            this.Name = "FrmTemplateOperate";
            this.Text = "Template Add";
            this.Load += new System.EventHandler(this.FrmHtmlStorage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_html_element)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_html_element;
        private System.Windows.Forms.TextBox txt_template_id;
        private System.Windows.Forms.TextBox txt_template_url;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_template_description;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_cell;
        private System.Windows.Forms.Button btn_beautify;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lb_row;
        private System.Windows.Forms.Label lb_column;
        private System.Windows.Forms.Button btn_reload;
        private System.Windows.Forms.Button btn_check;

    }
 