using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

public class UrlSelectHelper
{
    public static ArrayList get_fixed_urls(string id)
    {

        ArrayList urls = new ArrayList();

        string sql = " select * from url_fixed where id={0}";
        sql = string.Format(sql, id);
        DataTable dt = SQLServerHelper.get_table(sql);
        if (dt.Rows.Count == 0) return urls;


        string url = dt.Rows[0]["url"].ToString();
        string url_value = dt.Rows[0]["url_value"].ToString();
        string type = dt.Rows[0]["type"].ToString();
 

        BsonDocument doc = new BsonDocument();
        string[] list_param;
        //==================================================================================================================================================

        /*-----------------------------------------------------------------------------------------------------------------------|
         | type     |  template_id   |           url             |          url_values       |         doc values                |
         | ---------|----------------|---------------------------|---------------------------|-----------------------------------|
         | P0       |  ID            |-----?id=helloworld        |NULL                       |NULL                               |
         | ---------|----------------|---------------------------|---------------------------|-----------------------------------|
         | P1       |  ID            |-----?id={0}               |①                         |NULL                               |
         | ---------|----------------|---------------------------|---------------------------|-----------------------------------|
         | P2       |  ID            |-----?id={0}&name={1}      |②                         |NULL                               |
         | ---------|----------------|---------------------------|---------------------------|-----------------------------------|
         | PN       |  ID            |-----?id={0}&name={1}......|③                         |NULL                               |
         | ---------|----------------|---------------------------|---------------------------|-----------------------------------|
         | D0       |  ID            |NULL                       |{'doc_id':'test'}#image.url|{url:['---?id=2','----?id=3'...]}  |
         | ---------|----------------|---------------------------|---------------------------|-----------------------------------|
         | D1       |  ID            |-----?id={0}               |{'doc_id':'test'}#image.url|{url:['1','2'....]}                |
         | ---------|----------------|---------------------------|---------------------------|-----------------------------------|
         | DN       |  ID            |-----?id={0}&name={1}......|{'doc_id':'test'}#image.url|{url:[[2,3..],[4,9...]....]}       |
         |-----------------------------------------------------------------------------------------------------------------------|
         
         
         备注: ①P1 url_values: {'values':['1','2','3','4'],'range':[1,200]}
               ②P2 url_values: {'values':[['100','3'],['200','2'],['125','5']],'range':[[['0','150'],['1','5']],[['200','300'],['1','4']]]}
               ③PN url_values:{'values':[['100','3','333'],['200','2','33'],['125','5','3434']]} */

        //==================================================================================================================================================

        switch (type)
        {
            case "P0":

                urls.Add(url);
                break;

            case "P1":

                doc = MongoHelper.get_doc_from_str(url_value);
                foreach (BsonElement element in doc.Elements)
                {
                    switch (element.Name)
                    {
                        case "values":
                            BsonArray list_values = element.Value.AsBsonArray;
                            for (int i = 0; i < list_values.Count; i++)
                            {
                                urls.Add(String.Format(url, list_values[i].ToString()));
                            }
                            break;
                        case "range":
                            BsonArray list_two = element.Value.AsBsonArray;
                            int start = list_two[0].AsInt32;
                            int end = list_two[1].AsInt32;
                            for (int i = start; i <= end; i++)
                            {
                                urls.Add(String.Format(url, i.ToString()));
                            }
                            break;

                        default:
                            break;
                    }
                } 
                break;

            case "P2":

                doc = MongoHelper.get_doc_from_str(url_value);
                foreach (BsonElement element in doc.Elements)
                {
                    BsonArray list_values = new BsonArray();
                    switch (element.Name)
                    {
                        case "values":
                            list_values = element.Value.AsBsonArray;
                            for (int i = 0; i < list_values.Count; i++)
                            {
                                BsonArray list_values_two = list_values[i].AsBsonArray;
                                urls.Add(string.Format(url, list_values_two[0].ToString(), list_values_two[1].ToString()));
                            }
                            break;

                        case "range":
                            list_values = element.Value.AsBsonArray;
                            for (int i = 0; i < list_values.Count; i++)
                            {
                                BsonArray list_values_two = list_values[i].AsBsonArray;
                                int start1 = list_values_two[0].AsBsonArray[0].ToInt32();
                                int end1 = list_values_two[0].AsBsonArray[1].ToInt32();

                                int start2 = list_values_two[1].AsBsonArray[0].ToInt32();
                                int end2 = list_values_two[1].AsBsonArray[1].ToInt32();

                                for (int m = start1; m <= end1; m++)
                                {
                                    for (int n = start2; n <= end2; n++)
                                    {
                                        urls.Add(string.Format(url, m.ToString(), n.ToString()));
                                    }
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                break;
            case "PN":
                doc = MongoHelper.get_doc_from_str(url_value);
                foreach (BsonElement element in doc.Elements)
                {
                    BsonArray list_values = new BsonArray();
                    switch (element.Name)
                    {
                        case "values":
                            list_values = element.Value.AsBsonArray;
                            for (int i = 0; i < list_values.Count; i++)
                            {
                                BsonArray list_values_more = list_values[i].AsBsonArray;
                                list_param = new string[list_values_more.Count];
                                for (int j = 0; j < list_values_more.Count; j++)
                                {
                                    list_param[j] = list_values_more[j].AsString;
                                }
                                urls.Add(string.Format(url, list_param));
                            }
                            break;
                        default:
                            break;
                    }
                }
                break;
            case "D0":
                MongoCursor<BsonDocument> cursor1 = MongoHelper.query_cursor_from_string(url_value.Split('#')[0].ToString());
                foreach (BsonDocument doc_select_url in cursor1)
                {
                    ArrayList temp_list = select_values_from_doc(doc_select_url, url_value.Split('#')[1].ToString());

                    foreach (string item in temp_list)
                    {
                        urls.Add(item);
                    }
                } 
                break;
            case "D1":
                MongoCursor<BsonDocument> cursor2 = MongoHelper.query_cursor_from_string(url_value.Split('#')[0].ToString());
                foreach (BsonDocument doc_select_url in cursor2)
                {
                    ArrayList temp_list = select_values_from_doc(doc_select_url, url_value.Split('#')[1].ToString());

                    foreach (string item in temp_list)
                    {
                        urls.Add(string.Format(url, item));
                    }
                }
                break;
            case "DN":

                MongoCursor<BsonDocument> cursor3 = MongoHelper.query_cursor_from_string(url_value.Split('#')[0].ToString());
                foreach (BsonDocument doc_select_url in cursor3)
                {
                    ArrayList array_urls = select_array_from_doc(doc_select_url, url_value.Split('#')[1].ToString());

                    foreach (BsonArray array_url in array_urls)
                    {
                        list_param = new string[array_url.Count];

                        for (int j = 0; j < array_url.Count; j++)
                        {
                            list_param[j] = array_url[j].AsString;
                        }
                        urls.Add(string.Format(url, list_param));
                    }
                }
                break;
            default:
                break; 
        } 
        return urls;
    }
    public static ArrayList select_values_from_doc(BsonDocument doc, string str_select)
    {
        ArrayList list_return = new ArrayList();
        string[] list = str_select.Split('.');

        BsonDocument doc_select = doc; 

        for (int i = 0; i < list.Length; i++)
        {
            if (i != list.Length - 1)
            {
                foreach (BsonElement element in doc_select.Elements)
                {
                    if (element.Name == list[i].ToString())
                    {
                        doc_select =element.Value.ToBsonDocument(); 
                    }
                }
            }
            //最后一层，取值
            else
            {
                foreach (BsonElement element in doc_select.Elements)
                {
                    if (element.Name == list[i].ToString())
                    {
                        BsonValue value = element.Value;
                        if (value.BsonType == BsonType.Array)
                        {
                            BsonArray list_value = value.AsBsonArray;
                            for (int j = 0; j < list_value.Count; j++)
                            {
                                list_return.Add(list_value[j].ToString());
                            }
                        }
                        else
                        {
                            list_return.Add(value.ToString());
                        }
                    }
                }
            }
        } 
      
        return list_return;
    }
    public static ArrayList select_array_from_doc(BsonDocument doc, string str_select)
    {
        ArrayList list_return = new ArrayList();
        string[] list = str_select.Split('.');

        BsonDocument doc_select = doc;

        for (int i = 0; i <list.Length; i++)
        {
            if (i != list.Length - 1)
            {
                foreach (BsonElement element in doc_select.Elements)
                {
                    if (element.Name == list[i].ToString())
                    {
                        doc_select = new BsonDocument();
                        doc_select.Add(element);
                    }
                }
            }
            //最后一层，取值
            else
            {
                foreach (BsonElement element in doc_select.Elements)
                {
                    if (element.Name == list[i].ToString())
                    {
                        BsonValue value = element.Value;
                        if (value.BsonType == BsonType.Array)
                        {
                            BsonArray list_value = value.AsBsonArray;
                            for (int j = 0; j < list_value.Count; j++)
                            {
                                if (list_value[j].BsonType == BsonType.Array)
                                {
                                    list_return.Add(list_value[j].AsBsonArray);
                                }
                            }
                        } 
                    }
                }
            }
        }

        return list_return;
    }
}

