namespace WinCode
{
    partial class FrmEFCheckInfo
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_check = new System.Windows.Forms.Button();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.btn_user_check = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgv_result_user = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result_user)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_check
            // 
            this.btn_check.Location = new System.Drawing.Point(12, 12);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(75, 23);
            this.btn_check.TabIndex = 0;
            this.btn_check.Text = "Check";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // dgv_result
            // 
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_result.Location = new System.Drawing.Point(3, 3);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.Size = new System.Drawing.Size(1041, 392);
            this.dgv_result.TabIndex = 1;
            // 
            // btn_user_check
            // 
            this.btn_user_check.Location = new System.Drawing.Point(94, 12);
            this.btn_user_check.Name = "btn_user_check";
            this.btn_user_check.Size = new System.Drawing.Size(75, 23);
            this.btn_user_check.TabIndex = 2;
            this.btn_user_check.Text = "User Check";
            this.btn_user_check.UseVisualStyleBackColor = true;
            this.btn_user_check.Click += new System.EventHandler(this.btn_user_check_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 41);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1055, 424);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgv_result);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1047, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Flow";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgv_result_user);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1047, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgv_result_user
            // 
            this.dgv_result_user.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result_user.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_result_user.Location = new System.Drawing.Point(3, 3);
            this.dgv_result_user.Name = "dgv_result_user";
            this.dgv_result_user.Size = new System.Drawing.Size(1041, 392);
            this.dgv_result_user.TabIndex = 2;
            // 
            // FrmEFCheckInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 477);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btn_user_check);
            this.Controls.Add(this.btn_check);
            this.Name = "FrmEFCheckInfo";
            this.Text = "Check EasyFlow Information";
            this.Load += new System.EventHandler(this.FrmCheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result_user)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.Button btn_user_check;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgv_result_user;
    }
}

