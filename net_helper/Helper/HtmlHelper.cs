using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;


class HtmlHelper
{
    public static string down_html_file = @"D:\down_html_file\";
    public static string down_img_file = @"D:\down_img_file\";
    public static WebClient client = new WebClient();
    //保存HTML为本地文件
    public static string save_html_to_file(string url)
    {

        try
        {
            //make a temp url to struct file path 
            string url_temp = get_normal_url(url);



            //保存文件
            string path_new = down_html_file;
            string[] list_new = url_temp.Split('/');
            for (int i = 2; i < list_new.Length - 1; i++)
            {
                path_new = path_new + list_new[i] + @"\";
                if (Directory.Exists(path_new) == false)
                {
                    Directory.CreateDirectory(path_new);
                }
            }
            path_new = path_new + list_new[list_new.Length - 1];



            if (File.Exists(path_new) == false)
            {
                client.DownloadFile(url, path_new);
            }
            Log.info("save html to file", url);
            return url;
        }
        catch (Exception error)
        {
            Log.error_with_msg("save html to file ", url, error);
            return "error [save_html_to_file]" + Environment.NewLine + url + Environment.NewLine + error.Message;
        }
    }
    //保存HTML中url中的文件
    public static string save_html_url_to_file(string url)
    {
        string msg = "";
        string url_temp = "";
        string url_item = "";
        string url_func = "";
        try
        {
            //make a temp url to get current page url("")
            url_temp = get_normal_url(url);


            string ext = url_temp.Substring(url_temp.LastIndexOf('.'), url_temp.Length - url_temp.LastIndexOf('.'));

            //查找如：url(../images/icon1.jpg)
            if (ext == ".css" || ext == ".html" || ext == ".shtml" || ext == ".htm")
            {
                string html = get_html(url);
                Regex reg = new Regex(@"url\([^)]*\)");
                MatchCollection colloct = reg.Matches(html);
                foreach (Match match in colloct)
                {
                    url_item = match.Value;
                    url_item = url_item.Substring(4, url_item.Length - 5);
                    url_item = url_item.Replace("'", "").Trim(); //删除单引号
                    url_item = url_item.Replace(@"""", "").Trim();//删除双引号
                    url_func = get_full_url(url_temp, url_item);
                    save_html_to_file(url_func);

                    msg += "[url()]" + url_func + Environment.NewLine;
                    Log.info("down file from css url() ", url_func);
                }
            }
        }
        catch (Exception error)
        {
            Log.error_with_msg("save html url to file", "Page URL:" + url + Environment.NewLine + "Temp URL:" + url_temp + Environment.NewLine
                                + "Item URL" + url_item + Environment.NewLine + "Func URL:" + url_func, error);
            return "error [get_url_func_file ]" + Environment.NewLine + error.Message;
        }

        return msg;
    }
    public static string get_full_url(string url_orig, string url)
    {

        //make a temp url to get new url on this page
        url_orig = get_normal_url(url_orig);

        url = url.Trim();

        string[] list_orig = url_orig.Split('/');
        string[] list = url.Split('/');


        string url_new = "";
        try
        {
            if (list[0] == "..") //上级目录
            {
                for (int i = 0; i < list_orig.Length - 2; i++)
                {
                    url_new = url_new + list_orig[i].ToString() + "/";
                }
                for (int i = 1; i < list.Length; i++)
                {
                    url_new = url_new + list[i].ToString() + "/";
                }
            }
            else if (list[0] == "http:" || list[0] == "https:") //绝对路径
            {
                url_new = url + "/";
            }
            else if (list[0] == "") //根目录
            {
                for (int i = 0; i < 3; i++)
                {
                    url_new = url_new + list_orig[i].ToString() + "/";
                }

                for (int i = 1; i < list.Length; i++)
                {
                    url_new = url_new + list[i].ToString() + "/";
                } 
            }
            else  //当前目录
            {
                for (int i = 0; i < list_orig.Length - 1; i++)
                {
                    url_new = url_new + list_orig[i].ToString() + "/";
                }
  
                for (int i = 0; i < list.Length; i++)
                {
                    url_new = url_new + list[i].ToString() + "/";
                }
            }
            url_new = url_new.Substring(0, url_new.Length - 1);
            return url_new;
        }
        catch (Exception error)
        {
            Log.error_with_msg("get full url", "Parent URL:" + url_orig + Environment.NewLine + "Child URL:" + url, error);
            return "wrong [get_full_url]" + Environment.NewLine + error.Message;
        }
    }
    public static string get_normal_url(string url)
    {
        url = url.Trim();

        //http://www.baidu.com/ http://www.baidu.com/gv/
        if (url.Substring(url.Length - 1, 1) == @"/")
        {
            url = url + "index.html";
        }
        //http://www.baidu.com   https://www.baidu.com 
        if (url.LastIndexOf('/') == 6 || url.LastIndexOf('/') == 7)
        {
            url = url + @"/index.html";
        }

        //http://www.baidu.com/test.php?test=test
        if (url.IndexOf('?') > 0)
        {
            url = url.Substring(0, url.IndexOf('?'));
        }
        return url;
    }
    public static string get_html(string url)
    {
        byte[] bhtml = client.DownloadData(url);
        return Encoding.UTF8.GetString(bhtml);
    }
    public static string down_file_from_url(string url, string file_name)
    {
        try
        {
            string file_path = down_img_file + file_name; 


            if (File.Exists(file_path) == false)
            {
                client.DownloadFile(url, file_path);
            }
            Log.info("save html to file", url);
            return url;
        }
        catch (Exception error)
        {
            Log.error_with_msg("down file from url ", url, error);
            return "error [down_file_url]" + Environment.NewLine + url + Environment.NewLine + error.Message;
        }

    }
}