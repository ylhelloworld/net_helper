using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Collections;

 
    public partial class FrmRequest_Socket : Form
    {
        public FrmRequest_Socket()
        {
            InitializeComponent();
        }
        Proxy proxy = new Proxy(); 

        private void FrmSocketRequest_Load(object sender, EventArgs e)
        {

        }
        private void txt_url_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                string url = this.txt_url.Text;
                string url_lower = url.ToLower();
                if (url_lower.Contains("http://"))
                {
                    url = url.Substring(7, url.Length - 7);
                }
                IPHostEntry entry = Dns.Resolve(url);
                this.txt_ip.Text = entry.AddressList[0].ToString();
            }
        }

 
        private void btn_request_Click(object sender, EventArgs e)
        {
            StringBuilder sb_response = new StringBuilder();
            StringBuilder sb_request = new StringBuilder();


            //POST Data ,Cookie
            Hashtable hash_post = new Hashtable();
            Hashtable hash_cookie = new Hashtable();
            hash_post = get_post_hash(this.txt_post.Text);
            hash_cookie = get_cookie_hash(this.txt_cookie.Text);
 

            //Method
            string str_method="";
            if (rb_post.Checked == true)
            {
                str_method = "POST";
            }
            else
            {
                str_method = "GET";
            }


            proxy.get_response(this.txt_url.Text,str_method,hash_post,hash_cookie);



            if (proxy.sessions.Count > 0)
            {
                Session session = proxy.sessions[proxy.sessions.Count - 1];
                sb_request.Append(Environment.NewLine + "Request Header:" + Environment.NewLine);
                sb_request.Append("===================================================" + Environment.NewLine);
                sb_request.Append(session.request.content);


                sb_response.Append(Environment.NewLine + "Response Header:" + Environment.NewLine);
                sb_response.Append("==================================================" + Environment.NewLine);
                sb_response.Append(session.response.str_header + Environment.NewLine);
                sb_response.Append(Environment.NewLine + "Response Body:" + Environment.NewLine);
                sb_response.Append("==================================================" + Environment.NewLine);
                sb_response.Append(session.response.str_body + Environment.NewLine);
            }

            this.txt_request.Text= sb_request.ToString();
            this.txt_response.Text= sb_response.ToString();



            string str_cookie = "";
            foreach (string key in proxy.cookie.Keys)
            {
                str_cookie =str_cookie+ key + ":" + proxy.cookie[key].ToString() + "\r\n";
            }
            this.txt_cookie.Text = str_cookie;
       
        }



        public Hashtable get_post_hash(string txt)
        {
            Hashtable table = new Hashtable();
            string[] list = txt.Split(new char[]{'\r','\n'});
            foreach (string item in list)
            {
                string name = "";
                string value = "";
                int index = item.IndexOf('=');
                if (index > -1)
                {
                    name = item.Substring(0, index);
                    value = item.Substring(index + 1, item.Length - index - 1);
                    bool is_has = false;
                    foreach (string key in table.Keys)
                    {
                        if (key == name)
                        {
                            table[key] = value;
                            is_has = true;
                            break;
                        }
                    }
                    if (is_has == false)
                    {
                        table.Add(name, value);
                    }
                }
            }
            return table;
        }
        public Hashtable get_cookie_hash(string txt)
        {
            Hashtable table = new Hashtable();
            string[] list = txt.Split(new char[] { '\r','\n'});
            foreach (string item in list)
            {
                string name = "";
                string value = "";
                int index = item.IndexOf(':');
                if (index > -1)
                {
                    name = item.Substring(0, index);
                    value = item.Substring(index + 1, item.Length - index - 1);
                    bool is_has = false;
                    foreach (string key in table.Keys)
                    {
                        if (key == name)
                        {
                            table[key] = value;
                            is_has = true;
                            break;
                        }
                    }
                    if (is_has == false)
                    {
                        table.Add(name, value);
                    }
                }
            }
            return table;
        }

        private void btn_cookie_add_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_cookie_name.Text) && !String.IsNullOrEmpty(txt_cookie_value.Text))
            {
                this.txt_cookie.Text = this.txt_cookie.Text + this.txt_cookie_name.Text + ":" + this.txt_cookie_value.Text + "\r\n";
            }
        } 
        private void btn_post_add_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txt_post_name.Text) && !String.IsNullOrEmpty(txt_post_value.Text))
            {
                this.txt_post.Text = this.txt_post.Text + this.txt_post_name.Text + "=" + this.txt_post_value.Text + "\r\n";
            }
        } 
        private void btn_clear_Click(object sender, EventArgs e)
        {
            this.txt_cookie.Text = "";
            this.txt_post.Text = "";
            this.txt_request.Text = "";
            this.txt_response.Text = "";
        }
    } 