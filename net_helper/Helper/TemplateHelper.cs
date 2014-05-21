using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;


class TemplateHelper
{



    //根据定义的模板，保存HTML内容到DB
    public static void save_html_to_db(string url, string template_id)
    {

        string html = HtmlHelper.get_html(url);


        string sql = "select * from template_main a,template_list b where a.template_id=b.template_id and a.template_id='{0}' and is_use='Y' ";
        sql = String.Format(sql, template_id);
        DataTable dt = SQLServerHelper.get_table(sql);

        //Get Query Document 
        string doc_id = "";
        foreach (DataRow row in dt.Rows)
        {
            if (row["is_doc_id"].ToString().ToLower() == "y")
            {
                doc_id = get_doc_id(row["type"].ToString(), url, html, row["html_path"].ToString(), row["regular_path"].ToString(), row["doc_path"].ToString());
            }
        }

        if (string.IsNullOrEmpty(doc_id))
        {
            Random rand = new Random();
            string doc_id_start = "T-" + template_id + "-";
            sql = "select count(*) from template_main where template_id like '{0}%'";
            sql = string.Format(sql, doc_id_start);
            doc_id = doc_id_start + SQLServerHelper.get_table(sql).Rows.Count.ToString("0000");
        }
 

        //Create Document
        QueryDocument doc_query = new QueryDocument();
        doc_query.Add("doc_id", doc_id);


        if (MongoHelper.query_cursor_from_bson(doc_query).Count() == 0)
        {
            BsonDocument doc_insert = new BsonDocument();
            doc_insert.Add("doc_id", doc_id);
            MongoHelper.insert_bson(doc_insert);
            sql = "insert into data (doc_id,create_time) values ('{0}','{1}') ";
            sql = string.Format(sql, doc_id, DateTime.Now.ToString());
            SQLServerHelper.exe_sql(sql);
        }


        //Save Each Document to DB
        foreach (DataRow row in dt.Rows)
        {
            if (row["is_doc_id"].ToString() == "Y") continue;
            try
            {
                save_html_item_to_db(row["type"].ToString(), url, html, doc_id, row["html_path"].ToString(), row["regular_path"].ToString(),
                                     row["doc_path"].ToString(), row["redirect_template_id"].ToString());
            }
            catch (Exception error) { }
        }
    }
    //根据设置的跳转的URL，保存HTML到DB
    public static void save_redirect_html_to_db(string url, string template_id,string doc_id)
    {

        string html = HtmlHelper.get_html(url);


        string sql = "select * from template_main a,template_list b where a.template_id=b.template_id and a.template_id='{0}' and is_use='Y' ";
        sql = String.Format(sql, template_id);
        DataTable dt = SQLServerHelper.get_table(sql); 
        //Create Document
        QueryDocument doc_query = new QueryDocument();
        doc_query.Add("doc_id", doc_id);


        if (MongoHelper.query_cursor_from_bson(doc_query).Count() == 0)
        {
            BsonDocument doc_insert = new BsonDocument();
            doc_insert.Add("doc_id", doc_id);
            MongoHelper.insert_bson(doc_insert);
            sql = "insert into data (doc_id,create_time) values ('{0}','{1}') ";
            sql = string.Format(sql, doc_id, DateTime.Now.ToString());
            SQLServerHelper.exe_sql(sql);
        }


        //Save Each Document to DB
        foreach (DataRow row in dt.Rows)
        {
            if (row["is_doc_id"].ToString() == "Y") continue;
            try
            {
                save_html_item_to_db(row["type"].ToString(), url, html, doc_id, row["html_path"].ToString(), row["regular_path"].ToString(),
                                     row["doc_path"].ToString(), row["redirect_template_id"].ToString());
            }
            catch (Exception error) { }
        }
    }
    public static void save_html_item_to_db(string type, string url, string html, string doc_id, string html_path, string regular_path, string doc_path,string redirect_template_id)
    {

         /*---------------------------------------------------------------------------------------------------|
         | type     |  HTML PATH        |     Regular PATH    |        DOC PATH       |  Redirect Template ID |
         | ---------|-------------------|---------------------|-----------------------|-----------------------|
         | F        | Fixed Value       |           X         |ALL                    |           X           |
         | ---------|-------------------|---------------------|-----------------------|-----------------------|
         | U        | URL  Value        |          √         |ALL                    |           X           |
         | ---------|-------------------|---------------------|-----------------------|-----------------------|
         | H        | HTML Path         |          √         |ALL,INNER,PROPERTY     |           X           |
         | ---------|-------------------|---------------------|-----------------------|-----------------------|
         | FR       | Fixed Value       |           X         |ALL                    |          √           |
         | ---------|-------------------|---------------------|-----------------------|-----------------------|
         | HR       | HTML Path         |          √         |ALL,INNER,PROPERTY     |          √           | 
         |------------------------------|---------------------|-----------------------|-----------------------|
         | IMG      | HTML Path         |          √         |ALL,INNER,PROPERTY     |           X           | 
         |------------------------------|---------------------|-----------------------|----------------------*/

        QueryDocument doc_query = new QueryDocument();
        doc_query.Add("doc_id", doc_id);
        UpdateDocument doc_update = new UpdateDocument();
        Regex reg;
        HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
        HtmlNodeCollection nodes;

        string str_from = "";
        string str_update = "";
        switch (type)
        {
            case "F":
                str_update = doc_path.Replace("#ALL#", html_path);
                doc_update = MongoHelper.get_update_from_str(str_update);
                MongoHelper.update_bson(doc_query, doc_update);
                break;
            case "U":
                if (string.IsNullOrEmpty(regular_path))
                {
                    str_from = url;
                }
                else
                {
                    reg = new Regex(regular_path);
                    str_from = reg.Match(url).Value;
                }
                str_update = doc_path.Replace("#ALL#", str_from);
                doc_update = MongoHelper.get_update_from_str(str_update);
                MongoHelper.update_bson(doc_query, doc_update);
                break;

            case "H": 
                doc.LoadHtml(html);
                nodes = doc.DocumentNode.SelectNodes(html_path);

                foreach (HtmlNode node in nodes)
                {

                    string value_orig = "";
                    string value_new = "";

                    reg = new Regex(@"#[^#]*#");
                    MatchCollection colloct = reg.Matches(doc_path);
                    value_orig = colloct[0].Value;

                    if (value_orig == "#ALL#")
                    {
                        value_new = node.WriteTo();

                    }
                    else if (value_orig == "#INNER#")
                    {
                        value_new = node.InnerHtml;
                    }
                    else
                    {
                        value_new = node.Attributes[value_orig.Replace("#", "").Trim()].Value.ToString();
                    }

                    //使用正则表达式选取值
                    if (string.IsNullOrEmpty(regular_path))
                    {
                        str_from = value_new;
                    }
                    else
                    {
                        reg = new Regex(regular_path);
                        str_from = reg.Match(value_new).Value;
                    }

                    //替代update_path中设置的参数
                    str_update = doc_path.Replace(value_orig, str_from);
                    doc_update = MongoHelper.get_update_from_str(str_update);
                    MongoHelper.update_bson(doc_query, doc_update);
                }
                break;
            case "FR":
                str_update = doc_path.Replace("#ALL#", html_path);
                doc_update = MongoHelper.get_update_from_str(str_update);
                MongoHelper.update_bson(doc_query, doc_update);

                save_redirect_html_to_db(HtmlHelper.get_full_url(url,html_path), redirect_template_id,doc_id);
                break;

            case "HR": 
                doc.LoadHtml(html);
                nodes = doc.DocumentNode.SelectNodes(html_path);

                foreach (HtmlNode node in nodes)
                {

                    string value_orig = "";
                    string value_new = "";

                    reg = new Regex(@"#[^#]*#");
                    MatchCollection colloct = reg.Matches(doc_path);
                    value_orig = colloct[0].Value;

                    if (value_orig == "#ALL#")
                    {
                        value_new = node.WriteTo();

                    }
                    else if (value_orig == "#INNER#")
                    {
                        value_new = node.InnerHtml;
                    }
                    else
                    {
                        value_new = node.Attributes[value_orig.Replace("#", "").Trim()].Value.ToString();
                    }

                    //使用正则表达式选取值
                    if (string.IsNullOrEmpty(regular_path))
                    {
                        str_from = value_new;
                    }
                    else
                    {
                        reg = new Regex(regular_path);
                        str_from = reg.Match(value_new).Value;
                    }

                    //替代update_path中设置的参数
                    str_update = doc_path.Replace(value_orig, str_from);
                    doc_update = MongoHelper.get_update_from_str(str_update);
                    MongoHelper.update_bson(doc_query, doc_update);

                    save_redirect_html_to_db(HtmlHelper.get_full_url(url,str_from), redirect_template_id,doc_id); 
                }
                break;

            case "IMG":
                doc.LoadHtml(html);
                nodes = doc.DocumentNode.SelectNodes(html_path);

                string img_url = "";
                foreach (HtmlNode node in nodes)
                {

                    string value_orig = "";
                    string value_new = "";

                    reg = new Regex(@"#[^#]*#");
                    MatchCollection colloct = reg.Matches(doc_path);
                    value_orig = colloct[0].Value;

                    if (value_orig == "#ALL#")
                    {
                        value_new = node.WriteTo();

                    }
                    else if (value_orig == "#INNER#")
                    {
                        value_new = node.InnerHtml;
                    }
                    else
                    {
                        value_new = node.Attributes[value_orig.Replace("#", "").Trim()].Value.ToString();
                    }

                    //使用正则表达式选取值
                    if (string.IsNullOrEmpty(regular_path))
                    {
                        img_url = value_new;
                    }
                    else
                    {
                        reg = new Regex(regular_path);
                        img_url = reg.Match(value_new).Value;
                    }

                    str_from = img_url.Replace(@"/", "-").Replace(@"\", "-");
                    //替代update_path中设置的参数
                    str_update = doc_path.Replace(value_orig, str_from);
                    doc_update = MongoHelper.get_update_from_str(str_update);
                    MongoHelper.update_bson(doc_query, doc_update);

                    HtmlHelper.down_file_from_url(HtmlHelper.get_full_url(url, img_url), doc_id + str_from);
                }
                break;
            default:
                break;
        }


    }

    //从HTML中选取值，#ALL-整个HTML值，#INNER-内嵌HTML值，#XXXX-HTML中属性值
    public static string get_doc_id(string type, string url, string html, string html_path, string regular_path,string doc_path)
    {

        Regex reg;
        string str_doc_id = "";
        switch (type)
        {
            case "F":
                str_doc_id=html_path;
                break;
            case "U":
                if (string.IsNullOrEmpty(regular_path))
                {
                    str_doc_id = url;
                }
                else
                {
                    reg = new Regex(regular_path);
                    str_doc_id = reg.Match(url).Value;
                } 
                break; 
            case "H":
                //选取HtmlNodes 第一个符合的值:#ALL#、#INNER#、#XXX#
                HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                doc.LoadHtml(html);
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes(html_path);
                if (nodes.Count > 0)
                {
                    if (doc_path == "#ALL#")
                    {
                        str_doc_id = nodes[0].WriteTo();
                    }
                    else if (doc_path == "#INNER#")
                    {
                        str_doc_id = nodes[0].InnerHtml;
                    }
                    else
                    {
                        str_doc_id = nodes[0].Attributes[doc_path.Replace("#", "").Trim()].Value.ToString();
                    } 
                } 
                break;
            default:
                break;
        }
        return str_doc_id;
    }  

}