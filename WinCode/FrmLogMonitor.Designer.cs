namespace WinCode
{
    partial class FrmLogMonitor
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
            this.components = new System.ComponentModel.Container();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_time = new System.Windows.Forms.Label();
            this.btn_stop = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.time = new System.Windows.Forms.Timer(this.components);
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
            this.dgv_result.Location = new System.Drawing.Point(6, 61);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.Size = new System.Drawing.Size(974, 306);
            this.dgv_result.TabIndex = 0;
            this.dgv_result.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_result_CellFormatting);
            this.dgv_result.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_result_CellMouseDown);
            this.dgv_result.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_result_DataBindingComplete);
            this.dgv_result.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_result_RowEnter);
            // 
            // txt_result
            // 
            this.txt_result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_result.Location = new System.Drawing.Point(6, 373);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_result.Size = new System.Drawing.Size(974, 139);
            this.txt_result.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lb_time);
            this.groupBox1.Controls.Add(this.btn_stop);
            this.groupBox1.Controls.Add(this.btn_start);
            this.groupBox1.Location = new System.Drawing.Point(6, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(974, 54);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Operation";
            // 
            // lb_time
            // 
            this.lb_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_time.AutoSize = true;
            this.lb_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_time.Location = new System.Drawing.Point(823, 18);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(92, 29);
            this.lb_time.TabIndex = 2;
            this.lb_time.Text = "lb_time";
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(101, 18);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(75, 21);
            this.btn_stop.TabIndex = 1;
            this.btn_stop.Text = "Stop";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(20, 18);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 21);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // time
            // 
            this.time.Enabled = true;
            this.time.Interval = 200;
            this.time.Tick += new System.EventHandler(this.time_Tick);
            // 
            // FrmLogMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 522);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.dgv_result);
            this.Name = "FrmLogMonitor";
            this.Text = "Log Monitor";
            this.Load += new System.EventHandler(this.FrmLogMonitor_Load);
            this.SizeChanged += new System.EventHandler(this.FrmLogMonitor_SizeChanged);
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
        private System.Windows.Forms.Timer time;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Label lb_time;
    }
}