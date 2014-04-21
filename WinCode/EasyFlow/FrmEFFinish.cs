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
    public partial class FrmEFFinish : Form
    {

        public FrmEFFinish()
        {
            InitializeComponent();
        }
        SqlDbHelper helper = new SqlDbHelper("Password=881201;Persist Security Info=True;User ID=yanglong;Initial Catalog=EFNETDBTest;Data Source=192.168.1.221");

        private void btn_finish_Click(object sender, EventArgs e)
        { 
            int test = 2;
            MessageBox.Show(test.ToString("D4"));
        }


        private void btn_find_Click(object sender, EventArgs e)
        {
            string form_type = this.txt_form_type.Text;
            string form_no = this.txt_form_no.Text;
            string sql_resda = String.Format("select * from resda  where resda001='{0}' and resda002 like '%{1}%'", form_type, form_no);
            DataTable table_resda = helper.ExecuteDataTable(sql_resda);
            string sql_resdb = String.Format("select * from resdb  where resdb001='{0}' and resdb002 like '%{1}%'", form_type, form_no);
            DataTable table_resdb = helper.ExecuteDataTable(sql_resdb);
            string sql_resdc = String.Format("select * from resdc  where resdc001='{0}' and resdc002 like '%{1}%'", form_type, form_no);
            DataTable table_resdc = helper.ExecuteDataTable(sql_resdc);
            string sql_resdd = String.Format("select * from resdd  where resdd001='{0}' and resdd002 like '%{1}%'", form_type, form_no);
            DataTable table_resdd = helper.ExecuteDataTable(sql_resdd);

            this.dgv_resda.DataSource = table_resda;
            this.dgv_resdb.DataSource = table_resdb;
            this.dgv_resdc.DataSource = table_resdc;
            this.dgv_resdd.DataSource = table_resdd;
        }

        public void insert_resdc(string resdb001, string resdb002, string resdb003, string resdb004, string resdb005, string resdb006, string resdb007)
        {
      
            /*==================================================================================================================================
             resdb005[流程角色]:1=员工代号, 2=直属主管, 5=部门主管, 8=部门签核, 9=部门签核（含子部门),19=填表人,21=标准群组,22=动态群组        
             resdb006[签核种类]:1=准、不准, 2=同意、不同意, 3=會辦處理, 4=通知                                                                
             
             resdc007[簽核狀態碼]:4=已通知, 7=已签核, 12=他人已签核
             resdc008[签核结果]:2=同意, 8=已通知, 10=他人已签核
            //===================================================================================================================================*/
            string company_name = "";
            string sql_insert = "";
            string sql_temp = " insert into  {0}..resdc(resdc001,resdc002,resdc003,resdc004,resdc005,resdc006,resdc007,resdc008,COMPANY,CREATOR,USR_GROUP,CREATE_DATE)" +
                                " values " +
                                " ('{1}','{2}','{3}','{4}','{5}','{6}',{7},{8},'EFNETDB','CY120467','0000','20120702');";
            string emp_no="";
            string resdc007="";
            string resdc008="";
            switch (resdb006)
            {
                case "1":
                    resdc007="7";//已签核
                    resdc008 = "2";//同意
                    break;
                case "2":
                    resdc007 = "7";//已签核
                    resdc008 = "2";//同意
                    break;
                case "3":
                    resdc007 = "7";//已签核
                    resdc008 = "2";//同意
                    break;
                case "4":
                    resdc007="4";//已通知
                    resdc008 = "8";//已通知
                    break;
                default :
                    break; 
            }
          

            switch (resdb005)
            { 
                
                case "1"://员工代号 
                    sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, "0001", resdb007, resdc007, resdc008);
                    break;
                case "2"://直属主管
                    string sql_2 = string.Format("SELECT resak013 FROM {0}..resak WHERE resak001='{1}'", company_name, resdb007);
                    DataTable table2 = helper.ExecuteDataTable(sql_2);
                    if (table2.Rows.Count > 0)
                    {
                        emp_no = table2.Rows[0].ToString();
                        sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, "0001", emp_no, resdc007, resdc008);
                    }
                    break;
                case "5"://部门主管
                    string sql_5 = string.Format("SELECT resal007 FROM {0}..resal WHERE resal001='{1}'", company_name, resdb007);
                    DataTable table5= helper.ExecuteDataTable(sql_5);
                    if (table5.Rows.Count > 0)
                    {
                        emp_no = table5.Rows[0].ToString();
                        sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, "0001", emp_no, resdc007, resdc008);
                    }
                    break; 
                case "8": //部门成员
                    string sql_8 = String.Format("select distinct {0}..resan003 from resan where resan001='{1}'", company_name, resdb007);
                    DataTable table8 = helper.ExecuteDataTable(sql_8);
                    if (table8.Rows.Count > 0)
                    {
                        emp_no = table8.Rows[0].ToString();
                        sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, "0001", emp_no, resdc007, resdc008);
                    }
                    if (table8.Rows.Count > 1)
                    {
                        int i_8 = 1;
                        for(i_8=1;i_8<table8.Rows.Count ;i_8++)
                        {
                            if (resdb006 == "4")
                            {
                                sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, (i_8 + 1).ToString("D3"), emp_no, "4", "8");
                            }
                            else
                            {
                                sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, (i_8 + 1).ToString("D3"), emp_no, "12", "10");
                            }
                        }
                    } 
                    break;
                case "9"://部门成员
                    string sql_9 = String.Format("select distinct {0}..resan003 from resan where resan001='{1}'", company_name, resdb007);
                    DataTable table9 = helper.ExecuteDataTable(sql_9);
                    if (table9.Rows.Count > 0)
                    {
                        emp_no = table9.Rows[0].ToString();
                        sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, "0001", emp_no, resdc007, resdc008);
                    }
                    if (table9.Rows.Count > 1)
                    {
                        int i_9 = 1;
                        for (i_9 = 1; i_9 < table9.Rows.Count; i_9++)
                        {
                            if (resdb006 == "4")
                            {
                                sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, (i_9 + 1).ToString("D3"), emp_no, "4", "8");
                            }
                            else
                            {
                                sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, (i_9 + 1).ToString("D3"), emp_no, "12", "10");
                            }
                        }
                    }
                    break;
                case "19"://填表人
                    string sql_19 = String.Format("select resda016 from {0}..resda where resda001='{1}' and resda002='{2}'", company_name, resdb001, resdb002);
                    DataTable table19 = helper.ExecuteDataTable(sql_19);
                    if (table19.Rows.Count > 0)
                    {
                        emp_no = table19.Rows[0].ToString();
                        sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, "0001", emp_no, resdc007, resdc008);
                    }
                    break;

                case "21"://标准群组
                    string sql_21 = String.Format("select * from  {0}..resav  where resav001='{1}'", company_name, resdb007);
                    DataTable table21 = helper.ExecuteDataTable(sql_21);
                    if (table21.Rows.Count > 0)
                    {
                        emp_no = table21.Rows[0].ToString();
                        sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, "0001", emp_no, resdc007, resdc008);
                    }
                    if (table21.Rows.Count > 1)
                    {
                        int i_21 = 1;
                        for (i_21 = 1; i_21 < table21.Rows.Count; i_21++)
                        {
                            if (resdb006 == "4")
                            {
                                sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, (i_21 + 1).ToString("D3"), emp_no, "4" , "8");
                            }
                            else
                            {
                                sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, (i_21 + 1).ToString("D3"), emp_no, "12", "10");
                            }
                        }
                    }
                    break;
                case "22"://动态群组
                    string sql_22 = String.Format("select * from  {0}..resav  where resav001='{1}'", company_name, resdb007);
                    DataTable table22 = helper.ExecuteDataTable(sql_22);
                    if (table22.Rows.Count > 0)
                    {
                        emp_no = table22.Rows[0].ToString();
                        sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, "0001", emp_no, resdc007, resdc008);
                    }
                    if (table22.Rows.Count > 1)
                    {
                        int i_22 = 1;
                        for (i_22 = 1; i_22 < table22.Rows.Count; i_22++)
                        {
                            if (resdb006 == "4")
                            {
                                sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, (i_22 + 1).ToString("D3"), emp_no, "4", "8");
                            }
                            else
                            {
                                sql_insert = sql_insert + String.Format(sql_temp, company_name, resdb001, resdb002, resdb003, resdb004, (i_22 + 1).ToString("D3"), emp_no, "12", "10");
                            }
                        }
                    }
                    break;
                default:
                    break; 
            }
        }

        public void insert_resdd(string resdc001, string resdc002)
        {
            string company_name = "";
            string sql_select = "";
            string sql_templete = " insert into {0}..resdd(resdd001,resdd002,resdd003,resdd004,resdd005,resdd006,resdd007,resdd008,resdd009,resdd010,resdd012,resdd013,resdd014,resdd015)" +
                                " values  " +
                                " ('{1}','{2}','{3}','{4}','{5}','01','{6}''{6}',getdate(),getdate(),getdate(),getdate(),1,{7},{8});";

            string str_sql = String.Format("select * from {0}..resdc where resdc001='{1}' and resdc002='{2}'", company_name, resdc001, resdc002);
            DataTable dt = helper.ExecuteDataTable(str_sql);

            foreach (DataRow row in dt.Rows)
            { 
                sql_select = sql_select + String.Format(sql_templete, company_name, row["resdc001"].ToString(), row["resdc002"].ToString(), row["resdc003"].ToString(), row["resdc004"].ToString(), row["resdd005"].ToString(), row["resdc006"].ToString(), row["resdc007"].ToString(), row["resdc008"].ToString()); 
            } 
        } 
    }
}