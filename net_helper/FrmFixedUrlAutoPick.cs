using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;


using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson.Serialization;

namespace WinCode
{
    public partial class FrmFixedUrlAutoPick : Form
    {
        public FrmFixedUrlAutoPick()
        {
            InitializeComponent();
        }
        private void FrmFixedUrlAutoPick_Load(object sender, EventArgs e)
        {
            bind_data("");
        }
        private void btn_find_Click(object sender, EventArgs e)
        {
            bind_data(this.txt_condition.Text);
        } 
        private void txt_pick_result_TextChanged(object sender, EventArgs e)
        {
            this.txt_pick_result.SelectionStart = this.txt_pick_result.TextLength;
            this.txt_pick_result.ScrollToCaret();
        }  
        private void btn_pick_Click(object sender, EventArgs e)
        {
            pick_data();
        } 
        private void btn_start_Click(object sender, EventArgs e)
        {
            int interval = (int)num_interval.Value;
            this.timer.Enabled = true;
            this.timer.Interval = interval;
            this.timer.Start();
        } 
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.timer.Enabled = false;
            this.timer.Stop();
        } 
        private void timer_Tick(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(pick_data_random));
            thread.Start();
        }
        public void bind_data(string condition)
        {

            if (string.IsNullOrEmpty(condition))
            {
                condition = "%";
            }
            else
            {
                condition = "%" + condition + "%";
            }

            string sql = "select * from url_fixed where template_id like '{0}' or url like '{0}' or remark like '{0}'";
            sql = string.Format(sql, condition);
            DataTable dt = SQLServerHelper.get_table(sql);

            DataColumn col = new DataColumn();
            col.DataType = Type.GetType("System.Boolean");
            col.ColumnName = "selected";
            col.DefaultValue = false;
            dt.Columns.Add(col);
            dt.Columns["selected"].SetOrdinal(0);

            this.dgv_find_result.DataSource = dt;
        } 
        public void pick_data()
        {
            foreach (DataGridViewRow row in dgv_find_result.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true && String.IsNullOrEmpty(row.Cells["id"].Value.ToString()) == false)
                {
                    string template_id = row.Cells["template_id"].Value.ToString();
                    ArrayList list = UrlSelectHelper.get_fixed_urls(row.Cells["id"].Value.ToString());
                    foreach (string item in list)
                    {
                        this.txt_pick_result.Text += item + Environment.NewLine;
                        string doc_id = TemplateHelper_Match.save_html_to_db(item, template_id);
                        select_new_data_to_sqlserver(doc_id);
                    }
                }
            }
        }
        public void pick_data_random()
        {
            //加入随机时间，进行混淆 
            Random random = new Random();
            Thread.Sleep(random.Next(2000));

            foreach (DataGridViewRow row in dgv_find_result.Rows)
            {
                if (Convert.ToBoolean(row.Cells["selected"].Value) == true && String.IsNullOrEmpty(row.Cells["id"].Value.ToString()) == false)
                {
                    string template_id = row.Cells["template_id"].Value.ToString();
                    ArrayList list = UrlSelectHelper.get_fixed_urls(row.Cells["id"].Value.ToString());
                    foreach (string item in list)
                    {
                        this.txt_pick_result.Text += item + Environment.NewLine;
                        string doc_id = TemplateHelper_Match.save_html_to_db(item, template_id);
                        select_new_data_to_sqlserver(doc_id);
                    }
                }
            } 
        }
        public void select_new_data_to_sqlserver(string doc_id)
        {

            string sql = "";
            string max_timespan = "";
            DataTable dt_temp = new DataTable();

            //find the last insert data
            QueryDocument doc_query = new QueryDocument();
            doc_query.Add("doc_id", doc_id);
            BsonDocument doc = MongoHelper.query_bson_from_bson(doc_query);

            switch (doc["type"].ToString())
            {
                case "win0":
                    sql = " select max(timespan) from win" +
                          " where website='{0}'"+
                          " start_time='{1}'" +
                          " and host='{2}'" +
                          " and client='{3}'" +
                          " and give_type='{4}'"; 
                    sql = string.Format(sql, doc["website"].ToString(),doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString(), "0");
                    max_timespan = SQLServerHelper.get_table(sql).Rows[0][0].ToString();

                    sql = " select * from win" +
                          " where website='{0}'"+
                          " start_time='{1}'" +
                          " and host='{2}'" +
                          " and client='{3}'" +
                          " and give_type='{4}'"+
                          " and timespan='{5}'";
                    sql = string.Format(sql, doc["website"].ToString(),doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString(), "0",max_timespan);
                    dt_temp = SQLServerHelper.get_table(sql);

                    if (dt_temp.Rows[0]["three"].ToString() != doc["three0"].ToString() ||
                        dt_temp.Rows[0]["one"].ToString() != doc["one0"].ToString()||
                        dt_temp.Rows[0]["zero"].ToString() != doc["zero0"].ToString())
                    {
                        sql = " insert into win" +
                              " (timespan,website,start_time,host,client,give_type,three,one,zero)" +
                              " values" +
                              " ({0},{1},{2},{3},{4},{5},{6},{7},{8})";
                        sql=string.Format(sql,doc["doc_id"].ToString(),doc["website"].ToString(),doc["start_time"].ToString(),doc["host"].ToString(),doc["client"].ToString(),"0",
                                          doc["three0"].ToString(), doc["one0"].ToString(), doc["zero0"].ToString());
                        SQLServerHelper.exe_sql(sql); 
                    } 
                    break;
                case "win1":
                    sql = " select max(timespan) from win" +
                          " where website='{0}'" +
                          " start_time='{1}'" +
                          " and host='{2}'" +
                          " and client='{3}'" +
                          " and give_type='{4}'";
                    sql = string.Format(sql, doc["website"].ToString(), doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString(), "1");
                    max_timespan = SQLServerHelper.get_table(sql).Rows[0][0].ToString();

                    sql = " select * from win" +
                            " where website='{0}'" +
                            " start_time='{1}'" +
                            " and host='{2}'" +
                            " and client='{3}'" +
                            " and give_type='{4}'" +
                            " and timespan='{5}'";
                    sql = string.Format(sql, doc["website"].ToString(), doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString(), "1", max_timespan);
                    dt_temp = SQLServerHelper.get_table(sql);

                    if (dt_temp.Rows[0]["three"].ToString() != doc["three1"].ToString() ||
                        dt_temp.Rows[0]["one"].ToString() != doc["one1"].ToString() ||
                        dt_temp.Rows[0]["zero"].ToString() != doc["zero1"].ToString())
                    {
                        sql = " insert into win" +
                              " (timespan,website,start_time,host,client,give_type,three,one,zero)" +
                              " values" +
                              " ({0},{1},{2},{3},{4},{5},{6},{7},{8})";
                        sql = string.Format(sql, doc["doc_id"].ToString(), doc["website"].ToString(), doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString(), "1",
                                          doc["three1"].ToString(), doc["one1"].ToString(), doc["zero1"].ToString());
                        SQLServerHelper.exe_sql(sql);
                    } 
                    break;
                case "win_1":
                    sql = " select max(timespan) from win" +
                           " where website='{0}'" +
                           " start_time='{1}'" +
                           " and host='{2}'" +
                           " and client='{3}'" +
                           " and give_type={4}";
                    sql = string.Format(sql, doc["website"].ToString(), doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString(), "-1");
                    max_timespan = SQLServerHelper.get_table(sql).Rows[0][0].ToString();

                    sql = " select * from win" +
                         " where website='{0}'" +
                         " start_time='{1}'" +
                         " and host='{2}'" +
                         " and client='{3}'" +
                         " and give_type='{4}'" +
                         " and timespan='{5}'";
                    sql = string.Format(sql, doc["website"].ToString(), doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString(), "-1", max_timespan);
                    dt_temp = SQLServerHelper.get_table(sql);

                    if (dt_temp.Rows[0]["three"].ToString() != doc["three_1"].ToString() ||
                        dt_temp.Rows[0]["one"].ToString() != doc["one_1"].ToString() ||
                        dt_temp.Rows[0]["zero"].ToString() != doc["zero_1"].ToString())
                    {
                        sql = " insert into win" +
                              " (timespan,website,start_time,host,client,give_type,three,one,zero)" +
                              " values" +
                              " ({0},{1},{2},{3},{4},{5},{6},{7},{8})";
                        sql = string.Format(sql, doc["doc_id"].ToString(), doc["website"].ToString(), doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString(), "-1",
                                          doc["three_1"].ToString(), doc["one_1"].ToString(), doc["zero_1"].ToString());
                        SQLServerHelper.exe_sql(sql);
                    }
                    break;
                case "point":
                    sql = " select max(timespan) from point" +
                          " website='{0}'"+
                          " where start_time='{1}'" +
                          " and host='{2}'" +
                          " and client='{3}'";
                    sql = string.Format(sql,doc["website"].ToString(), doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString());
                    max_timespan = SQLServerHelper.get_table(sql).Rows[0][0].ToString();

                    sql = " select * from win" +
                          " where website='{0}'"+
                          " start_time='{1}'" +
                          " and host='{2}'" +
                          " and client='{3}'" + 
                          " and timespan='{4}'";
                    sql = string.Format(sql, doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString(), max_timespan);
                    dt_temp = SQLServerHelper.get_table(sql);
                    if (dt_temp.Rows[0]["point_1_0"].ToString() != doc["point_1_0"].ToString() ||
                        dt_temp.Rows[0]["point_2_0"].ToString() != doc["point_2_0"].ToString() ||
                        dt_temp.Rows[0]["point_3_0"].ToString() != doc["point_3_0"].ToString() ||
                        dt_temp.Rows[0]["point_4_0"].ToString() != doc["point_4_0"].ToString() ||
                        dt_temp.Rows[0]["point_5_0"].ToString() != doc["point_5_0"].ToString() ||
                        dt_temp.Rows[0]["point_2_1"].ToString() != doc["point_2_1"].ToString() ||
                        dt_temp.Rows[0]["point_3_1"].ToString() != doc["point_3_1"].ToString() ||
                        dt_temp.Rows[0]["point_4_1"].ToString() != doc["point_4_1"].ToString() ||
                        dt_temp.Rows[0]["point_5_1"].ToString() != doc["point_5_1"].ToString() ||
                        dt_temp.Rows[0]["point_3_2"].ToString() != doc["point_3_2"].ToString() ||
                        dt_temp.Rows[0]["point_4_2"].ToString() != doc["point_4_2"].ToString() ||
                        dt_temp.Rows[0]["point_5_2"].ToString() != doc["point_5_2"].ToString() ||
                        dt_temp.Rows[0]["point_other_3"].ToString() != doc["point_other_3"].ToString() ||
                        dt_temp.Rows[0]["point_0_0"].ToString() != doc["point_0_0"].ToString() ||
                        dt_temp.Rows[0]["point_1_1"].ToString() != doc["point_1_1"].ToString() ||
                        dt_temp.Rows[0]["point_2_2"].ToString() != doc["point_2_2"].ToString() ||
                        dt_temp.Rows[0]["point_3_3"].ToString() != doc["point_3_3"].ToString() ||
                        dt_temp.Rows[0]["point_other_1"].ToString() != doc["point_other_1"].ToString() ||
                        dt_temp.Rows[0]["point_0_1"].ToString() != doc["point_0_1"].ToString() ||
                        dt_temp.Rows[0]["point_0_2"].ToString() != doc["point_0_2"].ToString() ||
                        dt_temp.Rows[0]["point_0_3"].ToString() != doc["point_0_3"].ToString() ||
                        dt_temp.Rows[0]["point_0_4"].ToString() != doc["point_0_4"].ToString() ||
                        dt_temp.Rows[0]["point_0_5"].ToString() != doc["point_0_5"].ToString() ||
                        dt_temp.Rows[0]["point_1_2"].ToString() != doc["point_1_2"].ToString() ||
                        dt_temp.Rows[0]["point_1_3"].ToString() != doc["point_1_3"].ToString() ||
                        dt_temp.Rows[0]["point_1_4"].ToString() != doc["point_1_4"].ToString() ||
                        dt_temp.Rows[0]["point_1_5"].ToString() != doc["point_1_5"].ToString() ||
                        dt_temp.Rows[0]["point_2_3"].ToString() != doc["point_2_3"].ToString() ||
                        dt_temp.Rows[0]["point_2_4"].ToString() != doc["point_2_4"].ToString() ||
                        dt_temp.Rows[0]["point_2_5"].ToString() != doc["point_2_5"].ToString() ||
                        dt_temp.Rows[0]["point_other_0"].ToString() != doc["point_other_0"].ToString())
                    {
                       sql = " insert into point" +
                             " (timespan,website,start_time,host,client,"+
                             "  point_1_0,point_2_0,point_3_0,point_4_0,point_5_0,point_2_1,point_3_1,point_4_1,point_5_1,point_3_2,point_4_2,point_5_2,point_other_3,"+
                             "  point_0_0,point_1_1,point_2_2,point_3_3,point_other_1"+
                             "  point_0_1,point_0_2,point_0_3,point_0_4,point_0_5,point_1_2,point_1_3,point_1_4,point_1_5,point_2_3,point_2_4,point_2_5,point_other_0)"+
                             " values" +
                             " ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}',"+
                             "  '{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}','{30}','{31}','{32}','{33}','{34}','{35}',)";

                        sql = string.Format(sql,doc["doc_id"].ToString(),doc["website"].ToString(),doc["start_time"].ToString(),doc["host"].ToString(),doc["client"].ToString(),
                                            doc["point_1_0"].ToString(), doc["point_2_0"].ToString(), doc["point_3_0"].ToString(), doc["point_4_0"].ToString(), doc["point_5_0"].ToString(),
                                            doc["point_2_1"].ToString(), doc["point_3_1"].ToString(), doc["point_4_1"].ToString(), doc["point_5_1"].ToString(),
                                            doc["point_3_2"].ToString(), doc["point_4_2"].ToString(), doc["point_5_2"].ToString(),
                                            doc["point_other_3"].ToString(),
                                            doc["point_0_0"].ToString(), doc["point_1_1"].ToString(), doc["point_2_2"].ToString(), doc["point_3_3"].ToString(), 
                                            doc["point_other_1"].ToString(),
                                            doc["point_0_1"].ToString(), doc["point_0_2"].ToString(), doc["point_0_3"].ToString(), doc["point_0_4"].ToString(), doc["point_0_5"].ToString(),
                                            doc["point_1_2"].ToString(), doc["point_1_3"].ToString(), doc["point_1_4"].ToString(), doc["point_1_5"].ToString(),
                                            doc["point_2_3"].ToString(), doc["point_2_4"].ToString(), doc["point_2_5"].ToString(),
                                            doc["point_other_0"].ToString()); 
                        SQLServerHelper.exe_sql(sql);
                    }
                    break;
                case "total":
                    sql = " select max(timespan) from total" +
                          " where website='{0}'"+
                          " start_time='{1}'" +
                          " and host='{2}'" +
                          " and client='{3}'";
                    sql = string.Format(sql, doc["website"].ToString(),doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString());
                    max_timespan = SQLServerHelper.get_table(sql).Rows[0][0].ToString();

                    sql = " select * from total" +
                          " where website='{0}'"+
                          " start_time='{1}'" +
                          " and host='{2}'" +
                          " and client='{3}'" +
                          " and timespan='{4}'";
                    sql = string.Format(sql, doc["website"].ToString(),doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString(), max_timespan);
                    dt_temp = SQLServerHelper.get_table(sql);
                    if (dt_temp.Rows[0]["total_0"].ToString() != doc["total_0"].ToString() ||
                        dt_temp.Rows[0]["total_1"].ToString() != doc["total_1"].ToString() ||
                        dt_temp.Rows[0]["total_2"].ToString() != doc["total_2"].ToString() ||
                        dt_temp.Rows[0]["total_3"].ToString() != doc["total_3"].ToString() ||
                        dt_temp.Rows[0]["total_4"].ToString() != doc["total_4"].ToString() ||
                        dt_temp.Rows[0]["total_5"].ToString() != doc["total_5"].ToString() ||
                        dt_temp.Rows[0]["total_6"].ToString() != doc["total_6"].ToString() ||
                       dt_temp.Rows[0]["total_more"].ToString() != doc["total_more"].ToString())
                    {
                       sql = " insert into total" +
                             " (timespan,web_site,start_time,host,client,total_0,total_1,total_2,total_3,total_4,total_5,total_6,total_more" +
                             "  values"+
                             " ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')";
                        sql = string.Format(sql, doc["doc_id"].ToString(), doc["website"].ToString(), doc["start_time"].ToString(), doc["host"].ToString(), doc["client"].ToString(),
                                            doc["total_0"].ToString(), doc["total_1"].ToString(), doc["total_2"].ToString(), doc["total_3"].ToString(), doc["total_4"].ToString(),
                                            doc["total_5"].ToString(), doc["total_6"].ToString(), doc["total_more"].ToString());
                        SQLServerHelper.exe_sql(sql);
                    } 
                    break; 
                default:
                    break;
            }
        }

    }
}
