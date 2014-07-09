using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

public class SQLServerHelper
{
     //public static string str_con = @"Data Source=yanglong\SQLSERVER2012;Initial Catalog=HtmlSelect;Integrated Security=True";
     public static string str_con = @"Data Source=.;Initial Catalog=HtmlSelect;Integrated Security=True";
    public static DataTable get_table(string sql)
    {
        SqlConnection con = new SqlConnection(str_con);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;

        SqlDataAdapter dap = new SqlDataAdapter();
        dap.SelectCommand = cmd;
        DataSet ds = new DataSet();
        dap.Fill(ds);
        return ds.Tables[0];
    }
    public static void exe_sql(string sql)
    {
        SqlConnection con = new SqlConnection(str_con);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.Text;
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();
    }
    public static string format_sql_str(string sql)
    {
        sql = sql.Replace("'", "''");
        return sql;         
    }
}

