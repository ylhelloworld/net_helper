 
    partial class FrmRequest_WebHttpRequest
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
            this.txt_url = new System.Windows.Forms.TextBox();
            this.btn_request = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rb_post = new System.Windows.Forms.RadioButton();
            this.rb_get = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_cookie = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_cookie_add = new System.Windows.Forms.Button();
            this.txt_cookie_value = new System.Windows.Forms.TextBox();
            this.txt_cookie_name = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_post = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_post_add = new System.Windows.Forms.Button();
            this.txt_post_value = new System.Windows.Forms.TextBox();
            this.txt_post_name = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_response = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_request = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_url
            // 
            this.txt_url.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_url.Location = new System.Drawing.Point(9, 10);
            this.txt_url.Name = "txt_url";
            this.txt_url.Size = new System.Drawing.Size(938, 20);
            this.txt_url.TabIndex = 0;
            this.txt_url.Text = "http://192.168.1.221/huanan/login_quick.aspx";
            this.txt_url.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_url_KeyPress);
            // 
            // btn_request
            // 
            this.btn_request.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_request.Location = new System.Drawing.Point(1078, 9);
            this.btn_request.Name = "btn_request";
            this.btn_request.Size = new System.Drawing.Size(53, 23);
            this.btn_request.TabIndex = 1;
            this.btn_request.Text = "Reqest";
            this.btn_request.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_request.UseVisualStyleBackColor = true;
            this.btn_request.Click += new System.EventHandler(this.btn_request_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.rb_post);
            this.groupBox1.Controls.Add(this.rb_get);
            this.groupBox1.Location = new System.Drawing.Point(953, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 35);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // rb_post
            // 
            this.rb_post.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rb_post.AutoSize = true;
            this.rb_post.Location = new System.Drawing.Point(61, 12);
            this.rb_post.Name = "rb_post";
            this.rb_post.Size = new System.Drawing.Size(54, 17);
            this.rb_post.TabIndex = 1;
            this.rb_post.TabStop = true;
            this.rb_post.Text = "POST";
            this.rb_post.UseVisualStyleBackColor = true;
            // 
            // rb_get
            // 
            this.rb_get.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rb_get.AutoSize = true;
            this.rb_get.Checked = true;
            this.rb_get.Location = new System.Drawing.Point(7, 12);
            this.rb_get.Name = "rb_get";
            this.rb_get.Size = new System.Drawing.Size(47, 17);
            this.rb_get.TabIndex = 0;
            this.rb_get.TabStop = true;
            this.rb_get.Text = "GET";
            this.rb_get.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.txt_cookie);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btn_cookie_add);
            this.groupBox2.Controls.Add(this.txt_cookie_value);
            this.groupBox2.Controls.Add(this.txt_cookie_name);
            this.groupBox2.Location = new System.Drawing.Point(12, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(450, 126);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cookie";
            // 
            // txt_cookie
            // 
            this.txt_cookie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cookie.Location = new System.Drawing.Point(10, 41);
            this.txt_cookie.MaxLength = 0;
            this.txt_cookie.Multiline = true;
            this.txt_cookie.Name = "txt_cookie";
            this.txt_cookie.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_cookie.Size = new System.Drawing.Size(440, 79);
            this.txt_cookie.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "->";
            // 
            // btn_cookie_add
            // 
            this.btn_cookie_add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_cookie_add.Location = new System.Drawing.Point(397, 13);
            this.btn_cookie_add.Name = "btn_cookie_add";
            this.btn_cookie_add.Size = new System.Drawing.Size(47, 23);
            this.btn_cookie_add.TabIndex = 2;
            this.btn_cookie_add.Text = "Add";
            this.btn_cookie_add.UseVisualStyleBackColor = true;
            this.btn_cookie_add.Click += new System.EventHandler(this.btn_cookie_add_Click);
            // 
            // txt_cookie_value
            // 
            this.txt_cookie_value.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cookie_value.Location = new System.Drawing.Point(112, 15);
            this.txt_cookie_value.Name = "txt_cookie_value";
            this.txt_cookie_value.Size = new System.Drawing.Size(279, 20);
            this.txt_cookie_value.TabIndex = 1;
            // 
            // txt_cookie_name
            // 
            this.txt_cookie_name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_cookie_name.Location = new System.Drawing.Point(10, 15);
            this.txt_cookie_name.Name = "txt_cookie_name";
            this.txt_cookie_name.Size = new System.Drawing.Size(80, 20);
            this.txt_cookie_name.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.txt_post);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.btn_post_add);
            this.groupBox3.Controls.Add(this.txt_post_value);
            this.groupBox3.Controls.Add(this.txt_post_name);
            this.groupBox3.Location = new System.Drawing.Point(12, 164);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(450, 125);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Post";
            // 
            // txt_post
            // 
            this.txt_post.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_post.Location = new System.Drawing.Point(10, 41);
            this.txt_post.MaxLength = 0;
            this.txt_post.Multiline = true;
            this.txt_post.Name = "txt_post";
            this.txt_post.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_post.Size = new System.Drawing.Size(440, 77);
            this.txt_post.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "->";
            // 
            // btn_post_add
            // 
            this.btn_post_add.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_post_add.Location = new System.Drawing.Point(397, 13);
            this.btn_post_add.Name = "btn_post_add";
            this.btn_post_add.Size = new System.Drawing.Size(47, 23);
            this.btn_post_add.TabIndex = 6;
            this.btn_post_add.Text = "Add";
            this.btn_post_add.UseVisualStyleBackColor = true;
            this.btn_post_add.Click += new System.EventHandler(this.btn_post_add_Click);
            // 
            // txt_post_value
            // 
            this.txt_post_value.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_post_value.Location = new System.Drawing.Point(112, 15);
            this.txt_post_value.Name = "txt_post_value";
            this.txt_post_value.Size = new System.Drawing.Size(279, 20);
            this.txt_post_value.TabIndex = 5;
            // 
            // txt_post_name
            // 
            this.txt_post_name.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txt_post_name.Location = new System.Drawing.Point(10, 15);
            this.txt_post_name.Name = "txt_post_name";
            this.txt_post_name.Size = new System.Drawing.Size(76, 20);
            this.txt_post_name.TabIndex = 4;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.txt_response);
            this.groupBox4.Location = new System.Drawing.Point(12, 290);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1128, 309);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Response";
            // 
            // txt_response
            // 
            this.txt_response.Location = new System.Drawing.Point(6, 17);
            this.txt_response.MaxLength = 10241024;
            this.txt_response.Multiline = true;
            this.txt_response.Name = "txt_response";
            this.txt_response.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_response.Size = new System.Drawing.Size(1116, 286);
            this.txt_response.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox5.Controls.Add(this.txt_request);
            this.groupBox5.Location = new System.Drawing.Point(474, 34);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(666, 255);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Request";
            // 
            // txt_request
            // 
            this.txt_request.BackColor = System.Drawing.SystemColors.Info;
            this.txt_request.Location = new System.Drawing.Point(6, 14);
            this.txt_request.MaxLength = 10241024;
            this.txt_request.Multiline = true;
            this.txt_request.Name = "txt_request";
            this.txt_request.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_request.Size = new System.Drawing.Size(654, 235);
            this.txt_request.TabIndex = 0;
            // 
            // FrmWebHttpRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 611);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_request);
            this.Controls.Add(this.txt_url);
            this.MaximizeBox = false;
            this.Name = "FrmWebHttpRequest";
            this.Text = "WebHttpRequest Request";
            this.Load += new System.EventHandler(this.FrmSocketRequest_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_url;
        private System.Windows.Forms.Button btn_request;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb_post;
        private System.Windows.Forms.RadioButton rb_get;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cookie_add;
        private System.Windows.Forms.TextBox txt_cookie_value;
        private System.Windows.Forms.TextBox txt_cookie_name;
        private System.Windows.Forms.TextBox txt_post;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_post_add;
        private System.Windows.Forms.TextBox txt_post_value;
        private System.Windows.Forms.TextBox txt_post_name;
        private System.Windows.Forms.TextBox txt_cookie;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txt_response;
        private System.Windows.Forms.TextBox txt_request;
    } 