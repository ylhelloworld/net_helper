using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using HtmlAgilityPack;
using System.IO;
using System.Text.RegularExpressions;

namespace WinCode
{
    public partial class FrmHtmlDownload : Form
    {
        public FrmHtmlDownload()
        {
            InitializeComponent();
        } 

        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        string msg = "";
        private void btn_load_Click(object sender, EventArgs e)
        {
            string html = HtmlHelper.get_html(this.txt_url.Text);
            doc.LoadHtml(html);
            this.txt_html.Text = html;
        }
        private void btn_down_Click(object sender, EventArgs e)
        {

            List<string> list = new List<string>();
            this.txt_result.Text = "";
            //image 
            HtmlNodeCollection list_img = doc.DocumentNode.SelectNodes("//img[@src]");
            if (list_img != null)
            {
                foreach (HtmlNode node in list_img)
                {
                    list.Add(node.Attributes["src"].Value);
                }
            }
            //script
            HtmlNodeCollection list_script = doc.DocumentNode.SelectNodes("//script[@src]");
            if (list_script != null)
            {
                foreach (HtmlNode node in list_script)
                {
                    list.Add(node.Attributes["src"].Value);
                }
            }
            //link
            HtmlNodeCollection list_link = doc.DocumentNode.SelectNodes("//link[@href]");
            if (list_link != null)
            {
                foreach (HtmlNode node in list_link)
                {
                    list.Add(node.Attributes["href"].Value);
                }
            }

            HtmlHelper.save_html_to_file(this.txt_url.Text);
            foreach (string item in list)
            {
                string new_url = HtmlHelper.get_full_url(this.txt_url.Text, item);

                msg=HtmlHelper.save_html_to_file(new_url);
                if (!string.IsNullOrEmpty(msg)) { this.txt_result.Text += msg + Environment.NewLine; }
                Application.DoEvents();

            }
        }

        private void txt_result_TextChanged(object sender, EventArgs e)
        {
            this.txt_result.SelectionStart = this.txt_result.TextLength;
            this.txt_result.ScrollToCaret(); 
        } 
    }
}
