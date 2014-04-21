using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Builders;


public partial class FrmMongoDBOperate : Form
{
    public FrmMongoDBOperate()
    {
        InitializeComponent();
    }
    bool is_beautify = false;
    private void btn_select_Click(object sender, EventArgs e)
    { 
        string str_query = "{'user_name':'YangLong'}";
        if (string.IsNullOrEmpty(this.txt_select.Text)==false)
        {
            str_query = this.txt_select.Text;
        }
        MongoCursor<BsonDocument> cursor = MongoHelper.query_cursor_from_string(str_query);
        show_cursor_in_txt(cursor);
        show_cursor_in_tv(cursor);
        this.dgv_result.DataSource = MongoHelper.get_table_from_cursor(cursor); 
    }

    private void btn_insert_Click(object sender, EventArgs e)
    {
        string str_insert = txt_operate.Text;
        MongoHelper.insert_string(str_insert);
    }

    private void btn_update_Click(object sender, EventArgs e)
    { 
        string  str_query = this.txt_select.Text;
        string  str_update = this.txt_operate.Text;  
        QueryDocument query_doc = MongoHelper.get_query_from_str(str_query);
        UpdateDocument update_doc = MongoHelper.get_update_from_str(str_update);
        MongoHelper.update_bson(query_doc, update_doc);
    }
    public void show_cursor_in_txt(MongoCursor<BsonDocument> cursor)
    {
        this.txt_result.Text = "";
        foreach (BsonDocument doc in cursor)
        {
            this.txt_result.Text += doc.ToString() + Environment.NewLine;
        }
        this.txt_result.Text = JsonBeautify.beautify(this.txt_result.Text);
    }
    public void show_cursor_in_tv(MongoCursor<BsonDocument> cursor)
    {
        tv_result.Nodes.Clear();
        TreeNode node_root = new TreeNode("Query Document");
        int i = 0;
        foreach (BsonDocument doc in cursor)
        {
            TreeNode item = new TreeNode();
            item.Text = i.ToString();
            i = i + 1;
            add_doc_to_node(doc, ref item);
            node_root.Nodes.Add(item);
        }
        this.tv_result.Nodes.Add(node_root);
        //this.tv_result.ExpandAll();
    }
    public void add_doc_to_node(BsonDocument doc, ref TreeNode node_father)
    {
        foreach (BsonElement element in doc.Elements)
        {
            switch (element.Value.BsonType)
            {
                case BsonType.Document:
                    TreeNode node_doc = new TreeNode();
                    node_doc.Text = element.Name.ToString();

                    add_doc_to_node(element.Value.AsBsonDocument, ref node_doc);
                    node_father.Nodes.Add(node_doc);
                    break;
                case BsonType.Array:
                    TreeNode node_array = new TreeNode();
                    node_array.Text = element.Name;

                    add_doc_array_to_node(element.Value.AsBsonArray, ref node_array);
                    node_father.Nodes.Add(node_array);
                    break;
                default:
                    TreeNode node = new TreeNode();
                    node.Text = element.Name.ToString() + ":" + element.Value.ToString();
                    node_father.Nodes.Add(node);
                    break;
            }
        } 
    }
    public void add_doc_array_to_node(BsonArray array, ref TreeNode node_father)
    {
        for (int i = 0; i < array.Count; i++)
        {
            switch (array[i].BsonType)
            {
                case BsonType.Document:
                    TreeNode node_doc = new TreeNode();
                    node_doc.Text = i.ToString();

                    add_doc_to_node(array[i].AsBsonDocument, ref node_doc);
                    node_father.Nodes.Add(node_doc);
                    break;
                case BsonType.Array:
                    TreeNode node_array = new TreeNode();
                    node_array.Text = i.ToString();

                    add_doc_array_to_node(array[i].AsBsonArray, ref node_array);
                    node_father.Nodes.Add(node_array);
                    break;
                default:
                    TreeNode node = new TreeNode();
                    node.Text = array[i].ToString();
                    node_father.Nodes.Add(node);
                    break;
            }
        }
    }

    private void btn_beautify_Click(object sender, EventArgs e)
    {
        is_beautify = true;
        this.lab_beautify.Text = "Text has beautify"; 
        this.txt_select.Text = JsonBeautify.beautify(this.txt_select.Text);
        this.txt_operate.Text = JsonBeautify.beautify(this.txt_operate.Text);
    } 
}
