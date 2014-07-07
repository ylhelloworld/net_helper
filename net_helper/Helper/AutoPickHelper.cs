using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using HtmlAgilityPack;
using System.Net;
using MongoDB.Bson;
using MongoDB.Driver;


namespace WinCode.Helper
{
    class AutoPickHelper
    {
        static bool is_open_mongo = false;
        public static void select_data_from_url(string url)
        {

            WebClient client = new WebClient();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            string html = System.Text.Encoding.UTF8.GetString(client.DownloadData(url));
            doc.LoadHtml(html);


            HtmlNodeCollection nodes_all = doc.DocumentNode.SelectNodes(@"//*");
            List<HtmlNode> nodes = new List<HtmlNode>();

            foreach (HtmlNode node in nodes_all)
            { 
                if (node.WriteTo().Contains("txt"))
                {
                    nodes.Add(node);
                }
            }
        }
        public static void select_table(string html)
        { 
            BsonDocument doc_result = new BsonDocument();
            doc_result.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
            doc_result.Add("from_url", "url");
            doc_result.Add("from_html_type", "table");

            HtmlDocument doc = new HtmlDocument();
            doc.Load(html); 
            HtmlNodeCollection tr_nodes = doc.DocumentNode.SelectNodes(@"//tr"); 
            for (int i = 1; i < tr_nodes.Count; i++)
            {
                for (int j = 0; j < tr_nodes[i].ChildNodes.Count; j++)
                { 
                    doc_result.Add(tr_nodes[0].ChildNodes[j].InnerHtml, tr_nodes[i].ChildNodes[j].InnerHtml);
                }
            }

            if (is_open_mongo) MongoHelper.insert_bson("web", doc_result);
        }
        public static void select_ul(string html)
        {
            BsonDocument doc_result = new BsonDocument();
            doc_result.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
            doc_result.Add("from_url", "url");
            doc_result.Add("from_html_type", "ul");


            HtmlDocument doc = new HtmlDocument();
            doc.Load(html);
            HtmlNode ul_node= doc.DocumentNode.SelectNodes(@"//ul")[0];

            BsonArray ul_array = new BsonArray();
            for (int i = 0; i < ul_node.ChildNodes.Count; i++)
            {
                ul_array.Add(ul_node.ChildNodes[i].InnerHtml.ToString()); 
            }
            doc_result.Add("ul", ul_array);  

            if (is_open_mongo) MongoHelper.insert_bson("web", doc_result);
        }
        public static void select_dl(string html)
        {
            BsonDocument doc_result = new BsonDocument();
            doc_result.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
            doc_result.Add("from_url", "url");
            doc_result.Add("from_html_type", "dl");


            HtmlDocument doc = new HtmlDocument();
            doc.Load(html);
            HtmlNode dl_node = doc.DocumentNode.SelectNodes(@"//dl")[0];

            BsonArray dl_array = new BsonArray();
            for (int i = 0; i < dl_node.ChildNodes.Count; i++)
            {
                dl_array.Add(dl_node.ChildNodes[i].InnerHtml.ToString());
            }
            doc_result.Add("dl", dl_array);

            if (is_open_mongo) MongoHelper.insert_bson("web", doc_result); 
        }
    }
}
