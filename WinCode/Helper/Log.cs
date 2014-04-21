using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

public class Log
{
    public static void info(string description, string detail)
    {
        string time = DateTime.Now.ToString();
        string type = "info";
        string sql = "insert into log (time,type,description,detail) values('{0}','{1}','{2}','{3}')";
        description = SQLServerHelper.format_sql_str(description);
        detail = SQLServerHelper.format_sql_str(detail);
        sql = string.Format(sql, time, type, description, detail);
        SQLServerHelper.exe_sql(sql);
    }
    public static void error(string description, Exception error)
    {
        string time = DateTime.Now.ToString();
        string type = "error";
        string detail = error.ToString();

        description = SQLServerHelper.format_sql_str(description);
        detail = SQLServerHelper.format_sql_str(detail);

        string sql = "insert into log (time,type,description,detail) values('{0}','{1}','{2}','{3}')";
        sql = string.Format(sql, time, type, description, detail);
        SQLServerHelper.exe_sql(sql);
    }
    public static void error_with_msg(string description, string error_msg, Exception error)
    {
        string time = DateTime.Now.ToString();
        string type = "error";
        string detail = error_msg + Environment.NewLine + error.ToString();

        description = SQLServerHelper.format_sql_str(description);
        detail = SQLServerHelper.format_sql_str(detail);

        string sql = "insert into log (time,type,description,detail) values('{0}','{1}','{2}','{3}')";
        sql = string.Format(sql, time, type, description, detail);
        SQLServerHelper.exe_sql(sql);
    }
}
