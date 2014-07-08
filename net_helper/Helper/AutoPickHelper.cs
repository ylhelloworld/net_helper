using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


using HtmlAgilityPack;
using System.Net;
using MongoDB.Bson;
using MongoDB.Driver;



class AutoPickHelper
{
    static bool is_open_mongo = false;
    static string global_url = "";
    public static string select_data_from_url(string url)
    {
        global_url = url;

        string result = "";
        WebClient client = new WebClient();
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        string html = System.Text.Encoding.UTF8.GetString(client.DownloadData(url));
        doc.LoadHtml(html);


        HtmlNodeCollection nodes_all = doc.DocumentNode.SelectNodes(@"//*");
        List<HtmlNode> nodes = new List<HtmlNode>();

        BsonDocument doc_result = new BsonDocument();
        foreach (HtmlNode node in nodes_all)
        {

            switch (node.Name)
            {
                case "table":
                    result = result + "-----------------------------------------------------------------------------------------" + Environment.NewLine;
                    doc_result = select_table(node);
                    result = result + get_info_from_doc(doc_result);
                    result = result + "-----------------------------------------------------------------------------------------" + Environment.NewLine;
                    break;
                case "ul--":
                    result = result + "-----------------------------------------------------------------------------------------" + Environment.NewLine;
                    doc_result = select_ul(node);
                    result = result + get_info_from_doc(doc_result);
                    result = result + "-----------------------------------------------------------------------------------------" + Environment.NewLine;
                    break;

                case "ol--":
                    result = result + "-----------------------------------------------------------------------------------------" + Environment.NewLine;
                    doc_result = select_ol(node);
                    result = result + get_info_from_doc(doc_result);
                    result = result + "-----------------------------------------------------------------------------------------" + Environment.NewLine;
                    break;

                case "dl--":
                    select_ul(node);
                    result = result + get_info_from_doc(doc_result);
                    break;
                default:
                    break;
            }

        }
        return result;
    }
    public static BsonDocument select_table(HtmlNode node_input)
    {
        BsonDocument doc_result = new BsonDocument();
        doc_result.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
        doc_result.Add("from_url", global_url);
        doc_result.Add("from_html_type", "table");
        doc_result.Add("html_path", node_input.XPath);
        doc_result.Add("original_html", node_input.WriteTo());



        HtmlNodeCollection tr_nodes = node_input.SelectNodes(node_input.XPath + @"//tr");
        string[] cells = new string[] { @"//td", @"//th" };


        DataTable table = new DataTable();
        for (int i = 0; i < 500; i++)
        {
            table.Columns.Add("C" + i.ToString());
        }
        for (int i = 0; i < 500; i++)
        {
            DataRow row_new = table.NewRow();
            for (int j = 0; j < 500; j++)
            {
                row_new[j] = "X000000X";
            }
            table.Rows.Add(row_new);
        }


        for (int i = 0; i < tr_nodes.Count; i++)
        {
            BsonArray td_array = new BsonArray();
            foreach (string cell in cells)
            {
                HtmlNodeCollection td_nodes = node_input.SelectNodes(tr_nodes[i].XPath + cell);
                int start = 0;
                if (td_nodes != null)
                {
                    for (int k = 0; k < td_nodes.Count;k++ )
                    {
                        if (table.Rows[i][start].ToString() == "X000000X")
                        {
                            foreach (HtmlAttribute attr in td_nodes[k].Attributes)
                            {
                                if (attr.Name.ToLower() == "rowspan")
                                {
                                    int span_count = Convert.ToInt16(attr.Value);
                                    for (int j = 1; j < span_count; j++)
                                    {
                                        table.Rows[i + j][start] = td_nodes[k].InnerText;
                                    }
                                }
                                if (attr.Name.ToLower() == "colspan")
                                {
                                    int span_count = Convert.ToInt16(attr.Value);
                                    for (int j = 1; j < span_count; j++)
                                    { 
                                        table.Rows[i][start+j] = td_nodes[k].InnerText;
                                    }
                                }
                            }
                            table.Rows[i][start] = td_nodes[k].InnerText;
                            start = start + 1;
                        }
                        else
                        {
                            start = start + 1;
                            k = k - 1;
                        }
                    }
                }
            }
        }



        //add table to doc
        BsonArray header_array = new BsonArray();
        for (int i = 0; i < 500; i++)
        {
            if (table.Rows[0][i].ToString() != "X000000X")
            {
              header_array.Add(table.Rows[0][i].ToString());
            }
        }
        doc_result.Add("header", header_array);


        for(int i=1;i<500;i++)
        {
            BsonArray td_array = new BsonArray();
            for(int j=0;j<500;j++)
            {
                if (table.Rows[i][j].ToString() != "X000000X")
                {
                   td_array.Add(table.Rows[i][j].ToString());
                }  
            }
            if (td_array.Count != 0)
            {
                doc_result.Add((i - 1).ToString(), td_array);
            }
        }
         

        if (is_open_mongo) MongoHelper.insert_bson("web", doc_result);
        return doc_result;
    }
    public static BsonDocument select_ul(HtmlNode node_input)
    {
        BsonDocument doc_result = new BsonDocument();
        doc_result.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
        doc_result.Add("from_url", global_url);
        doc_result.Add("from_html_type", "ul");
        doc_result.Add("html_path", node_input.XPath);
        doc_result.Add("original_html", node_input.WriteTo());


        HtmlNodeCollection ul_nodes = node_input.SelectNodes(node_input.XPath + @"//li");

        BsonArray ul_array = new BsonArray();
        foreach (HtmlNode node in ul_nodes)
        {
            if (!string.IsNullOrEmpty(node.InnerText))
            {
                ul_array.Add(node.InnerText);
            }
        }
        doc_result.Add("ul", ul_array);

        if (is_open_mongo) MongoHelper.insert_bson("web", doc_result);

        return doc_result;


    }  
    public static BsonDocument select_ol(HtmlNode node_input)
    {
        BsonDocument doc_result = new BsonDocument();
        doc_result.Add("doc_id", DateTime.Now.ToString("yyyyMMddHHmmss") + DateTime.Now.Millisecond.ToString());
        doc_result.Add("from_url", global_url);
        doc_result.Add("from_html_type", "ol");
        doc_result.Add("html_path", node_input.XPath);
        doc_result.Add("original_html", node_input.WriteTo());


        HtmlNodeCollection ol_nodes = node_input.SelectNodes(node_input.XPath + @"//li");

        BsonArray ol_array = new BsonArray();
        foreach (HtmlNode node in ol_nodes)
        {
            if (!string.IsNullOrEmpty(node.InnerText))
            {
                ol_array.Add(node.InnerText);
            }
        }
        doc_result.Add("ol", ol_array);

        if (is_open_mongo) MongoHelper.insert_bson("web", doc_result);

        return doc_result; 
    }
    
    public static string get_info_from_doc(BsonDocument doc)
    {

        string result = "";
        switch (doc["from_html_type"].ToString())
        {
            case "table":
                result = result +
                    "DOC ID:".PadRight(15, ' ') + doc["doc_id"].ToString() + Environment.NewLine +
                    "URL:".PadRight(15, ' ') + doc["from_url"].ToString() + Environment.NewLine +
                    "HTML TYPE:".PadRight(15, ' ') + doc["from_html_type"].ToString() + Environment.NewLine +
                    "HTML PATH:".PadRight(15, ' ') + doc["html_path"].ToString() + Environment.NewLine + Environment.NewLine;
                    //"Original HTML:" + Environment.NewLine +
                    //"------------------------------------------------------------------------------------------" + Environment.NewLine +
                    //doc["original_html"].ToString() + Environment.NewLine +
                    // "------------------------------------------------------------------------------------------" + Environment.NewLine;

                foreach (BsonElement element in doc.Elements)
                {
                    if (element.Name != "doc_id" && element.Name != "from_url" && element.Name != "from_html_type" && element.Name != "html_path" && element.Name != "original_html")
                    {
                        BsonArray array = element.Value.AsBsonArray;
                        if (element.Name == "header")
                        {
                            result = result + "Header".PadRight(15, ' ');
                            foreach (BsonValue value in array)
                            {
                                result = result + value.ToString().Replace("&lt;", "<").Replace("&gt;", ">").Trim().PadRight(20, ' ');
                            }
                            result = result + Environment.NewLine;
                        }
                        else
                        {
                            result = result + ("Row " + element.Name).PadRight(15, ' ');
                            foreach (BsonValue value in array)
                            {
                                result = result + value.ToString().Replace("&lt;", "<").Replace("&gt;", ">").Trim().PadRight(20, ' ');
                            }
                            result = result + Environment.NewLine;
                        }
                    }
                }

                break;
            case "ul":
                result = result +
                "DOC ID:".PadRight(15, ' ') + doc["doc_id"].ToString() + Environment.NewLine +
                "URL:".PadRight(15, ' ') + doc["from_url"].ToString() + Environment.NewLine +
                "HTML TYPE:".PadRight(15, ' ') + doc["from_html_type"].ToString() + Environment.NewLine +
                "HTML PATH:".PadRight(15, ' ') + doc["html_path"].ToString() + Environment.NewLine + Environment.NewLine;

                BsonArray ul_array = doc["ul"].AsBsonArray;
                for (int i = 0; i < ul_array.Count; i++)
                {
                    result = result + ul_array[i].ToString() + Environment.NewLine;
                }
                break;
            case "ol":
                result = result +
                "DOC ID:".PadRight(15, ' ') + doc["doc_id"].ToString() + Environment.NewLine +
                "URL:".PadRight(15, ' ') + doc["from_url"].ToString() + Environment.NewLine +
                "HTML TYPE:".PadRight(15, ' ') + doc["from_html_type"].ToString() + Environment.NewLine +
                "HTML PATH:".PadRight(15, ' ') + doc["html_path"].ToString() + Environment.NewLine + Environment.NewLine;

                BsonArray ol_array = doc["ol"].AsBsonArray;
                for (int i = 0; i < ol_array.Count; i++)
                {
                    result = result + ol_array[i].ToString().Trim() + Environment.NewLine;
                }
                break;
            default:
                break;
        }
        return result;
    }
}

