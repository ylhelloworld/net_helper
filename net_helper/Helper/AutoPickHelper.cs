using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using HtmlAgilityPack;
using System.Net;


namespace WinCode.Helper
{
    class AutoPickHelper
    {
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
    }
}
