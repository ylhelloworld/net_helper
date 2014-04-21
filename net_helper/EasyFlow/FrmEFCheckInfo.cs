using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinCode
{
    public partial class FrmEFCheckInfo : Form
    {
       
        public FrmEFCheckInfo()
        {
            InitializeComponent();
        }

        private void FrmCheck_Load(object sender, EventArgs e)
        {

        }

        private void btn_user_check_Click(object sender, EventArgs e)
        {
            this.dgv_result_user.DataSource = GetLeaveTable();
        }
        private void btn_check_Click(object sender, EventArgs e)
        {
              this.dgv_result .DataSource= GetEmployeeTable(); 
        }

        public DataTable GetEmployeeTable()
        {
            SqlDbHelper helper = new SqlDbHelper("Password=881201;Persist Security Info=True;User ID=yanglong;Initial Catalog=EFNETDB;Data Source=192.168.1.221");
            DataTable dt_result = new DataTable();
            dt_result.Columns.Add("user_id");
            dt_result.Columns.Add("form_id");
            dt_result.Columns.Add("form_name");
            dt_result.Columns.Add("remark");

            //查询员工，部门主管，标准群组，对应的权限
            string sql_1 = " select distinct resca001 form_id ,resca002 form_name,code user_id ,rescc004 kind from" +
                       " (" +
                       "     select resca001,resca002,rescc004,rescc006 as code " +
                       "     from resca" +
                       "     left join rescc on resca001=rescc001" +
                       "     where 1=1" +
                       "     and resca086='2'" +
                       "     and rescc004='1'" +
                       "     and resca026='Y'" +
                       "     union all" +
                       "     select resca001,resca002,rescc004,resal007  as code" +
                       "     from resca" +
                       "     left join rescc on resca001=rescc001" +
                       "     left join resal on resal001=rescc006" +
                       "     where 1=1" +
                       "     and resca086='2'" +
                       "     and rescc004='5'" +
                       "     and resca026='Y'" +
                       "     union all" +
                       "     select resca001,resca002,rescc004,resav002 as code" +
                       "     from resca" +
                       "     left join rescc on resca001=rescc001" +
                       "     left join resav on resav001=rescc006" +
                       "     where 1=1" +
                       "     and resca086='2'" +
                       "     and rescc004='21'" +
                       "     and resca026='Y'" +
                       " ) t";
            DataTable dt_1 = helper.ExecuteDataTable(sql_1);
            foreach (DataRow row in dt_1.Rows)
            {
                string user_id = row["user_id"].ToString();
                string form_id = row["form_id"].ToString();
                string form_name = row["form_name"].ToString();
                string kind = row["kind"].ToString();
                string sql_temp = String.Format("select * from ADMMG where MG001='{0}' and MG002='{1}'", user_id, form_id);
                DataTable dt_temp = helper.ExecuteDataTable(sql_temp);
                if (dt_temp.Rows.Count == 0)
                {
                    DataRow row_new = dt_result.NewRow();
                    row_new["user_id"] = user_id;
                    row_new["form_id"] = form_id;
                    row_new["form_name"] = form_name;
                    if (kind == "1")
                    {
                        row_new["remark"] = "员工代号";
                    }
                    else if (kind == "5")
                    {
                        row_new["remark"] = "部门主管";
                    }
                    else if (kind == "21")
                    {
                        row_new["remark"] = "标准群组";
                    }

                    dt_result.Rows.Add(row_new);
                }
            }
            //查询动态群组
            string sql_2 = " select resca001 form_id,resca002 form_name,rescc004 kind,rescc009 user_id" +
                        " from resca" +
                        " left join rescc on resca001=rescc001" +
                        " where 1=1" +
                        " and resca086='2'" +
                        " and rescc004='22'" +
                        " and resca026='Y'";
            DataTable dt_2 = helper.ExecuteDataTable(sql_2);
            foreach (DataRow row in dt_2.Rows)
            {
                string user_ids = row["user_id"].ToString();
                string form_id = row["form_id"].ToString();
                string form_name = row["form_name"].ToString();
                string kind = row["kind"].ToString();

                string[] list = user_ids.Split(';');
                foreach (string child in list)
                {
                    string user_id = child.Split('-')[0].ToString();
                    string sql_temp = String.Format("select * from ADMMG where MG001='{0}' and MG002='{1}'", user_id, form_id);
                    DataTable dt_temp = helper.ExecuteDataTable(sql_temp);
                    if (dt_temp.Rows.Count == 0)
                    {
                        DataRow row_new = dt_result.NewRow();
                        row_new["user_id"] = user_id;
                        row_new["form_id"] = form_id;
                        row_new["form_name"] = form_name;
                        row_new["remark"] = "动态群组";
                        dt_result.Rows.Add(row_new);
                    }
                }
            }
            //理级以上无权限
            string sql_3 = "select resak001 from resak where (resak898>getdate() or resak898 is null or resak898='') and resak006>=600";
            DataTable dt_3 = helper.ExecuteDataTable(sql_3);
            foreach (DataRow row in dt_3.Rows)
            {
                string user_id = row["resak001"].ToString();
                string sql_4 = " select distinct resca001,resca002 from resca " +
                               " left join rescc on resca001=rescc001" +
                               " where 1=1" +
                               " and resca086='2'" +
                               " and rescc004='26'" +
                               " and resca026='Y'";
                DataTable dt_4 = helper.ExecuteDataTable(sql_4);
                foreach (DataRow row1 in dt_4.Rows)
                {
                    string form_id = row1["resca001"].ToString();
                    string form_name = row1["resca002"].ToString();

                    string sql_temp = String.Format("select * from ADMMG where MG001='{0}' and MG002='{1}'", user_id, form_id);
                    DataTable dt_temp = helper.ExecuteDataTable(sql_temp);
                    if (dt_temp.Rows.Count == 0)
                    {
                        DataRow row_new = dt_result.NewRow();
                        row_new["user_id"] = user_id;
                        row_new["form_id"] = form_id;
                        row_new["form_name"] = form_name;
                        row_new["remark"] = "理级以上无此权限";
                        dt_result.Rows.Add(row_new);
                    }
                } 
            } 
            return dt_result; 
        }
 

        //查询已经离职还有表单未签核的员工
        public DataTable GetLeaveTable()
        {
            SqlDbHelper helper = new SqlDbHelper("Password=881201;Persist Security Info=True;User ID=yanglong;Initial Catalog=EFNETDB;Data Source=192.168.1.221");
            string sql = " select distinct resdb001 form_id, resca002 form_name,resdb002 form_no,resdb007 user_id, " +
                        "(case resdb005 when 1 then '員工簽核' when 18  then '填表人' when 19  then '填表人' else '其它' end) remark  " +
                        " from resdb " +
                        " left join resda on resdb001=resda001 and resdb002=resda002" +
                        " left join resca on   resdb001=resca001 " +
                        " left join resak on  resdb007=resak001  " +
                        " left join resdc on  resdb001=resdc001 and resdb002=resdc002 and resdb007=resdc006 " +
                        " where   resda020='2'" +
                        " and resda021='1' " +
                        " and resdb005 in (1,18,19)" +
                        " and resdc008 =1 " +
                        " and ( resak898<getdate() and resak898 is not null and resak898<>'' )  ";
            DataTable dt = helper.ExecuteDataTable(sql); 
            return  dt;  
        }
    }
}
