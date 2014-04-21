using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text; 
using System.Windows.Forms;
using HtmlAgilityPack;
using System.Net;
 
    public partial class FrmHtmlAnalyse : Form
    {
        public FrmHtmlAnalyse()
        {
            InitializeComponent();
        }

        private void btn_load_Click(object sender, EventArgs e)
        {
            WebClient client = new WebClient(); 
            string url = this.txt_url.Text;    
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            if (cb_load_from_html_source.Checked == false)
            {
                this.txt_html_source.Text = System.Text.Encoding.UTF8.GetString(client.DownloadData(this.txt_url.Text));
            }
           
            doc.LoadHtml(this.txt_html_source.Text);
            this.txt_html_source.Text = doc.DocumentNode.InnerHtml; 
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            try
            { 
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(this.txt_html_source.Text);
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(this.txt_path.Text);

                this.dgv_result.DataSource = get_table_from_nodes(nodes);

                string result = "";
                foreach (HtmlNode node in nodes)
                {
                    result = result + "[" + node.Name + "]  " + node.XPath.ToString() + Environment.NewLine + node.OuterHtml + Environment.NewLine;
                    result = result + "--------------------------------------------------" + Environment.NewLine;
                }
                this.txt_result.Text = result;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        } 
        private void btn_fuzzy_find_Click(object sender, EventArgs e)
        {
            try
            {
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(this.txt_html_source.Text);
                HtmlNodeCollection nodes_all = doc.DocumentNode.SelectNodes(@"//*");
                List<HtmlNode> nodes = new List<HtmlNode>(); 

                foreach (HtmlNode node in nodes_all)
                {
                    string html = node.WriteTo();
                    if (html.Contains(this.txt_condition.Text))
                    {
                        nodes.Add(node);
                    } 
                }
 
                this.dgv_result.DataSource = get_table_from_nodes(nodes);

                string result = "";
                foreach (HtmlNode node in nodes)
                {
                    result = result + "[" + node.Name + "]  " + node.XPath.ToString() + Environment.NewLine + node.OuterHtml + Environment.NewLine;
                    result = result + "--------------------------------------------------" + Environment.NewLine;
                }
                this.txt_result.Text = result;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        public DataTable get_table_from_nodes(HtmlNodeCollection nodes)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("XPath");
            dt.Columns.Add("Html");

            foreach (HtmlNode node in nodes)
            {
                DataRow row_new = dt.NewRow();
                row_new["Name"] = node.Name;
                row_new["XPath"] = node.XPath;
                row_new["Html"] = node.WriteTo();
                dt.Rows.Add(row_new);
            } 
            return dt;
        }
        public DataTable get_table_from_nodes(List<HtmlNode> nodes)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("XPath");
            dt.Columns.Add("Html");

            foreach (HtmlNode node in nodes)
            {
                DataRow row_new = dt.NewRow();
                row_new["Name"] = node.Name;
                row_new["XPath"] = node.XPath;
                row_new["Html"] = node.WriteTo();
                dt.Rows.Add(row_new);
            } 
            return dt;
        }

    } 