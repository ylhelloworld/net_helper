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
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace WinCode
{
    public partial class FrmHtmlAgiligtyPack : Form
    {
        public FrmHtmlAgiligtyPack()
        {
            InitializeComponent();
        }

        private void btn_html_load_Click(object sender, EventArgs e)
        {
            
            string url = this.txt_url.Text;
            string condition = this.txt_condition.Text;
            HtmlWeb html_web = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            if (String.IsNullOrEmpty(this.txt_html.Text))
            {
                doc = html_web.Load(url);
            }
            else
            {
                doc.LoadHtml(this.txt_html.Text);
            }
            this.txt_html.Text = doc.DocumentNode.InnerHtml;

        }

        private void btn_html_select_Click(object sender, EventArgs e)
        { 
            try
            {
                HtmlWeb html_web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(this.txt_html.Text);
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(this.txt_condition.Text);

                string result = "";
                foreach (HtmlNode node in nodes)
                {
                    result = result +"["+node.Name+"]  "+ node.XPath.ToString() + Environment.NewLine+node.OuterHtml+Environment.NewLine;
                    result = result + "--------------------------------------------------" + Environment.NewLine;
                }
                this.txt_html_result.Text= result;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txt_id.Text))
            {
                MessageBox.Show("ID is empty!");
            }

            BsonDocument doc = new BsonDocument();
            doc.Add("id", this.txt_id.Text);
            MongoHelper.insert_bson(doc);
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.txt_select.Text))
            {
                QueryDocument doc_query = new QueryDocument();
                doc_query.Add("id", this.txt_id.Text);
                BsonDocument doc = MongoHelper.query_bson_from_bson(doc_query);
                this.txt_db_result.Text = doc.ToString();
            }
            else
            {
                QueryDocument doc_query1 = MongoHelper.get_query_from_str(this.txt_select.Text);
                BsonDocument doc1 = MongoHelper.query_bson_from_bson(doc_query1);
                this.txt_db_result.Text = doc1.ToString();
                doc1[""][""][""].ToString();
            }
        } 

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txt_select.Text))
            {
                try
                {
                    QueryDocument doc_query = new QueryDocument(); 
                    doc_query.Add("id", this.txt_id.Text);

                    UpdateDocument doc_update = MongoHelper.get_update_from_str(this.txt_update.Text); 
                    MongoHelper.update_bson(doc_query, doc_update);
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
            }
        }

        private void btn_test_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("col");
            DataRow row = dt.NewRow();
            row["col"] = "test";
            dt.Rows.Add(row);
            string josn_test = dt.ToJson(); 
            BsonDocument doc_test = dt.ToBsonDocument();
            MongoHelper.insert_bson(doc_test);

        } 
    }
}
