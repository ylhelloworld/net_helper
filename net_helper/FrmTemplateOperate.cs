using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public partial class FrmTemplateOperate: Form
{

    public string type = "add";
    public string template_id = "efnet_login";
    public FrmTemplateOperate()
    {
        InitializeComponent();
    } 

    private void FrmHtmlStorage_Load(object sender, EventArgs e)
    { 
        if (type == "update")
        {
            bind_data(template_id);
            this.txt_template_id.Enabled = false;
        }
    }

    private void btn_reload_Click(object sender, EventArgs e)
    {
        bind_data(template_id);
    }
    private void btn_beautify_Click(object sender, EventArgs e)
    {
        this.txt_cell.Text = JsonBeautify.beautify(this.txt_cell.Text);
    }

    private void dgv_html_element_CellClick(object sender, DataGridViewCellEventArgs e)
    { 
        try
        {
            this.lb_row.Text = e.RowIndex.ToString();
            this.lb_column.Text = e.ColumnIndex.ToString();
            string content = this.dgv_html_element.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            this.txt_cell.Text = content;
        }
        catch (Exception error)
        {
            this.lb_row.Text = "";
            this.lb_column.Text = "";
            this.txt_cell.Text = ""; 
        }
    }

    private void dgv_html_element_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
    {
        this.dgv_html_element.Columns["id"].ReadOnly = true;  
    }


    public void bind_data(string template_id)
    {
        DataTable dt_main = SQLServerHelper.get_table("select * from template_main where template_id='" + template_id + "'");
        if (dt_main.Rows.Count > 0)
        {
            this.txt_template_id.Text = dt_main.Rows[0]["template_id"].ToString();
            this.txt_template_url.Text = dt_main.Rows[0]["template_url"].ToString();
            this.txt_template_description.Text = dt_main.Rows[0]["template_description"].ToString();
        }

        DataTable dt_list = SQLServerHelper.get_table(" select id,order_num,type,html_path,regular_path,doc_path,redirect_template_id,remark,is_doc_id,is_use,create_time,update_time"+
                                                      " from template_list where template_id='" + template_id + "' order by order_num");
        this.dgv_html_element.DataSource = dt_list;
    }

 

    private void btn_save_Click(object sender, EventArgs e)
    {
        string sql = "";
        string template_id = this.txt_template_id.Text;
        string template_url = this.txt_template_url.Text;
        string template_description = this.txt_template_description.Text;


        //add or update the main template infomatino
        if (this.type == "add")
        {
            sql = "select * from template_main where template_id='" + template_id + "'";
            DataTable dt_temp = SQLServerHelper.get_table(sql);
            if (dt_temp.Rows.Count > 0)
            {
                MessageBox.Show("the template id has exist!!!");
                return;
            }
            else
            {
                sql = " insert into template_main (template_id,template_url,template_description) values ('{0}','{1}','{2}')";
                sql = string.Format(sql, template_id, template_url, template_description);
                SQLServerHelper.exe_sql(sql);
                this.txt_template_id.Enabled = false;
                this.type = ""; 
            }
        }
        else
        {
            sql = "update template_main set  template_url='{0}',template_description='{1}' where template_id='{2}'";
            sql = string.Format(sql,template_url, template_description, template_id);
            SQLServerHelper.exe_sql(sql); 

        }

        //add or update the detail template infomation
        for (int i = 0; i < this.dgv_html_element.Rows.Count - 1; i++)
        {
            string id = this.dgv_html_element.Rows[i].Cells["id"].Value.ToString();
            string type = this.dgv_html_element.Rows[i].Cells["type"].Value.ToString();
            string redirect_template_id = this.dgv_html_element.Rows[i].Cells["redirect_template_id"].Value.ToString();
            string html_path = SQLServerHelper.format_sql_str(this.dgv_html_element.Rows[i].Cells["html_path"].Value.ToString());
            string regular_path = SQLServerHelper.format_sql_str(this.dgv_html_element.Rows[i].Cells["regular_path"].Value.ToString());
            string doc_path = SQLServerHelper.format_sql_str(this.dgv_html_element.Rows[i].Cells["doc_path"].Value.ToString());
            string remark = SQLServerHelper.format_sql_str(this.dgv_html_element.Rows[i].Cells["remark"].Value.ToString()); 
            string is_doc_id = this.dgv_html_element.Rows[i].Cells["is_doc_id"].Value.ToString(); 
            string is_use = this.dgv_html_element.Rows[i].Cells["is_use"].Value.ToString();
            string update_time = DateTime.Now.ToString(); 
            string create_time = DateTime.Now.ToString();
            string order_num = this.dgv_html_element.Rows[i].Cells["order_num"].Value.ToString();
            if (string.IsNullOrEmpty(type))
            {
                type = "H";
            }
            if (string.IsNullOrEmpty(is_use))
            {
                is_use = "Y";
            }
            if (string.IsNullOrEmpty(id))
            {
                sql = " insert into template_list(type,html_path,regular_path,doc_path,remark,is_doc_id,is_use,create_time,template_id,order_num,redirect_template_id)" +
                      " values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},'{10}')";
                sql = string.Format(sql,type,html_path,regular_path,doc_path,remark,is_doc_id,is_use,create_time,template_id,order_num,redirect_template_id); 
            }
            else
            {
                sql = " update template_list set type='{0}',html_path='{1}',regular_path='{2}',doc_path='{3}'," +
                      " remark='{4}', is_doc_id='{5}',is_use='{6}',update_time='{7}' ,order_num={8},redirect_template_id='{9}'  where id={10}";
                sql = string.Format(sql,type,html_path,regular_path,doc_path,remark,is_doc_id,is_use,update_time,order_num,redirect_template_id,id);
            }
            SQLServerHelper.exe_sql(sql);
        }
    }

    private void btn_check_Click(object sender, EventArgs e)
    {
        string msg = MongoHelper.check_is_update_string(this.txt_cell.Text);
        if (msg == "right")
        {
            MessageBox.Show(" Bingo! Right JSON String!");
        }
        else
        {
            MessageBox.Show(msg);
        }
    }

    private void txt_cell_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.lb_column.Text) || string.IsNullOrEmpty(this.lb_row.Text) || this.dgv_html_element.Rows.Count == 0) return;
        this.dgv_html_element.Rows[Int16.Parse(this.lb_row.Text)].Cells[Int16.Parse(this.lb_column.Text)].Value = this.txt_cell.Text;
    }
 
}








