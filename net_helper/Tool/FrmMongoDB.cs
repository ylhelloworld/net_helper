using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;  
using System.IO; 

using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

using MongoDB.Driver.Builders;
 

namespace WinCode
{
    public partial class FrmMongoDB : Form
    {
         
        MongoDatabase db;
        public FrmMongoDB()
        {
            InitializeComponent();
        }
        private void FrmMongoDB_Load(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://127.0.0.1:27017");
            var server = client.GetServer();
            db = server.GetDatabase("mydb"); 
        }

        private void btn_find_Click(object sender, EventArgs e)
        {
            var query = Query.NE("user_id", "000001");
            MongoCursor<BsonDocument> result = MongoHelper.query_cursor_from_query(query);

            foreach (BsonDocument doc in result)
            {
                this.txt_result.Text += doc.ToString() + Environment.NewLine;
            }
            this.dgv_result.DataSource = MongoHelper.get_table_from_cursor(result); 
       
        } 
        private void btn_insert_Click(object sender, EventArgs e)
        {

            MongoHelper.insert_string(this.txt_conditon.Text);

            var query = Query.NE("user_id", "000001");
            MongoCursor<BsonDocument> result = MongoHelper.query_cursor_from_query(query);

            foreach (BsonDocument doc in result)
            {
                this.txt_result.Text += doc.ToString() + Environment.NewLine;
            }
            this.dgv_result.DataSource = MongoHelper.get_table_from_cursor(result); 
           
           
        }
         private void btn_test_Click(object sender, EventArgs e)
          {
              MongoCollection collection = MongoHelper.base_db.GetCollection("user");
              QueryDocument query_doc = MongoHelper.get_query_from_str("{}");
              UpdateDocument update_doc = new UpdateDocument();  
              collection.Update(query_doc, update_doc);
              update_doc.Add("$set", new BsonDocument() { { "test", "test" } });

              QueryDocument doc_query = new QueryDocument(){{ "", "" },{"",""}};
              
          } 
 


         //使用实体进行操作
         public void user_entities()
        {
            //var collection = db.GetCollection<User>("user");

            ////新增一笔数据
            //var user = new User("NO.1", "yanglong");
            //collection.Insert(user); 


            ////查询条件
            //var query = Query<User>.EQ(e => e.user_name, "yanglong");  

            ////查询并修改
            //User find_user = collection.FindOne(query);
            //find_user.user_name = "longyang";
            //collection.Save(find_user);


            ////查询并更新
            //var update = Update<User>.Set(e => e.user_name, "yanglong");
            //collection.Update(query, update);

            ////删除数据
            //collection.Remove(query);

        }

    }  
}
