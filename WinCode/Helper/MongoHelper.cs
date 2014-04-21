using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson.Serialization;


public class MongoHelper
{

    public static string con_str = "mongodb://127.0.0.1:27017";
    public static string db_name = "db";
    public static string base_doc_name = "web";
    public static MongoDatabase base_db;

    static MongoHelper()
    {
        var client = new MongoClient(con_str);
        var server = client.GetServer();
        base_db = server.GetDatabase(db_name);
    }
    public static MongoCursor<BsonDocument> query_cursor_from_bson(string doc_name, QueryDocument query_doc)
    {
        MongoCollection<BsonDocument> collection = base_db.GetCollection(doc_name);
        MongoCursor<BsonDocument> result = collection.Find(query_doc);
        return result;
    }
    public static MongoCursor<BsonDocument> query_cursor_from_bson(QueryDocument query_doc)
    {
        MongoCollection<BsonDocument> collection = base_db.GetCollection(base_doc_name);
        MongoCursor<BsonDocument> result = collection.Find(query_doc);
        return result;
    }
    public static MongoCursor<BsonDocument> query_cursor_from_query(string doc_name, IMongoQuery query)
    {
        MongoCollection<BsonDocument> collection = base_db.GetCollection(doc_name);
        MongoCursor<BsonDocument> result = collection.Find(query);
        return result;
    }
    public static MongoCursor<BsonDocument> query_cursor_from_query(IMongoQuery query)
    {
        MongoCollection<BsonDocument> collection = base_db.GetCollection(base_doc_name);
        MongoCursor<BsonDocument> result = collection.Find(query);
        return result;
    }
    public static MongoCursor<BsonDocument> query_cursor_from_string(string doc_name, string str_bson)
    {
        var query_doc = get_query_from_str(str_bson);
        MongoCollection<BsonDocument> collection = base_db.GetCollection(doc_name);
        MongoCursor<BsonDocument> result = collection.Find(query_doc);
        return result;
    }
    public static MongoCursor<BsonDocument> query_cursor_from_string(string str_bson)
    {
        var query_doc = get_query_from_str(str_bson);
        MongoCollection<BsonDocument> collection = base_db.GetCollection(base_doc_name);
        MongoCursor<BsonDocument> result = collection.Find(query_doc);
        return result;
    }

    public static BsonDocument query_bson_from_bson(string doc_name, QueryDocument query_doc)
    {
        MongoCollection<BsonDocument> collection = base_db.GetCollection(doc_name);
        BsonDocument result = collection.FindOne(query_doc);
        return result;
    }
    public static BsonDocument query_bson_from_bson(QueryDocument query_doc)
    {
        MongoCollection<BsonDocument> collection = base_db.GetCollection(base_doc_name);
        BsonDocument result = collection.FindOne(query_doc);
        return result;
    }
    public static BsonDocument query_bson_from_query(string doc_name, IMongoQuery query)
    {
        MongoCollection<BsonDocument> collection = base_db.GetCollection(doc_name);
        BsonDocument result = collection.FindOne(query);
        return result;
    }
    public static BsonDocument query_bson_from_query(IMongoQuery query)
    {
        MongoCollection<BsonDocument> collection = base_db.GetCollection(base_doc_name);
        BsonDocument result = collection.FindOne(query);
        return result;
    }
    public static BsonDocument query_bson_from_string(string doc_name, string str_bson)
    {
        var query_doc = get_query_from_str(str_bson);
        MongoCollection<BsonDocument> collection = base_db.GetCollection(doc_name);
        BsonDocument result = collection.FindOne(query_doc);
        return result;
    }
    public static BsonDocument query_bson_from_string(string str_bson)
    {
        var query_doc = get_query_from_str(str_bson);
        MongoCollection<BsonDocument> collection = base_db.GetCollection(base_doc_name);
        BsonDocument result = collection.FindOne(query_doc);
        return result;
    }

    public static void insert_bson(string doc_name, BsonDocument insert_doc)
    {
        MongoCollection<BsonDocument> collecions = base_db.GetCollection(doc_name);
        collecions.Insert(insert_doc);
    }
    public static void insert_bson(BsonDocument insert_doc)
    {
        MongoCollection<BsonDocument> collecions = base_db.GetCollection(base_doc_name);
        collecions.Insert(insert_doc);
    }
    public static void insert_string(string doc_name, string str_bson)
    {
        MongoCollection<BsonDocument> collection = base_db.GetCollection(doc_name);
        BsonDocument doc_insert = get_doc_from_str(str_bson);
        collection.Insert(doc_insert);
    }
    public static void insert_string(string str_bson)
    {
        MongoCollection<BsonDocument> collection = base_db.GetCollection(base_doc_name);
        BsonDocument doc_insert = get_doc_from_str(str_bson);
        collection.Insert(doc_insert);
    }
    public static void update_bson(string doc_name, QueryDocument query_doc, UpdateDocument update_doc)
    {
        MongoCollection<BsonDocument> collecions = base_db.GetCollection(doc_name);
        collecions.Update(query_doc, update_doc);
    }
    public static void update_bson(QueryDocument query_doc, UpdateDocument update_doc)
    {
        MongoCollection<BsonDocument> collecions = base_db.GetCollection(base_doc_name); 
        collecions.Update(query_doc, update_doc);
    }
    public static void update_string(string doc_name, string str_query, string str_update)
    {
        MongoCollection<BsonDocument> collection = base_db.GetCollection(doc_name);
        QueryDocument query_doc = get_query_from_str(str_query);
        UpdateDocument update_doc = get_update_from_str(str_update);
        collection.Update(query_doc, update_doc);
    }
    public static void update_string(string str_query, string str_update)
    {
        MongoCollection<BsonDocument> collection = base_db.GetCollection(base_doc_name);
        QueryDocument query_doc = get_query_from_str(str_query);
        UpdateDocument update_doc = get_update_from_str(str_update);
        collection.Update(query_doc, update_doc);
    }
    public static BsonDocument get_doc_from_str(string str)
    {
        BsonDocument doc = BsonSerializer.Deserialize<BsonDocument>(str);
        return doc;
    }
    public static QueryDocument get_query_from_str(string str)
    {
        BsonDocument doc = BsonSerializer.Deserialize<BsonDocument>(str);
        QueryDocument doc_query = new QueryDocument();
        doc_query.AddRange(doc.Elements);
        return doc_query;
    }
    public static UpdateDocument get_update_from_str(string str)
    {
        BsonDocument doc = BsonSerializer.Deserialize<BsonDocument>(str);
        UpdateDocument doc_update = new UpdateDocument();
        doc_update.AddRange(doc.Elements);
        return doc_update;
    }

    public static string check_is_doc_str(string str)
    {
        try
        {
            BsonDocument doc = get_doc_from_str(str);
            return "right";
        }
        catch (Exception error)
        {
            return "error" + Environment.NewLine + error.ToString();
        }
    }
    public static string check_is_query_str(string str)
    {
        try
        {
            QueryDocument doc = get_query_from_str(str);
            return "right";
        }
        catch (Exception error)
        {
            return "error" + Environment.NewLine + error.ToString();
        }
    }
    public static string check_is_update_string(string str)
    {
        try
        {
            UpdateDocument doc = get_update_from_str(str);
            return "right";
        }
        catch (Exception error)
        {
            return "error" + Environment.NewLine + error.ToString();
        }
    }
    /// <summary>
    /// 查询结果生成DataTable
    /// </summary>
    /// <param name="result">传入BsonDcoument集合MongoCursor</param>
    /// <returns>DataTable</returns>
    public static DataTable get_table_from_cursor(MongoCursor<BsonDocument> result)
    {
        DataTable table = new DataTable();
        //插入列
        foreach (BsonDocument doc in result)
        {
            foreach (BsonElement test in doc.Elements)
            {
                string str_name = test.Name;
                bool is_has = false;
                foreach (DataColumn column in table.Columns)
                {
                    if (column.ColumnName == str_name)
                    {
                        is_has = true;
                    }
                }
                if (is_has == false)
                {
                    table.Columns.Add(str_name);
                }
            }
        }
        //插入列
        foreach (BsonDocument doc in result)
        {
            DataRow row_new = table.NewRow();
            foreach (BsonElement test in doc.Elements)
            {
                row_new[test.Name.ToString()] = test.Value.ToString();
            }
            table.Rows.Add(row_new);
        }
        return table;
    }
}
 