using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.Collections;

class HttpSocketHelper
{
    public static Request get_reqeust(string url, string method, Hashtable hash_post, Hashtable hash_cookie)
    {
        Request request = new Request();

        string str_send = "";

        string str_cookie = convert_cookie_to_string(hash_cookie);

        string str_post = "";
        byte[] byte_post = new byte[0];
        if (method == "POST")
        {
            str_post = convert_post_to_string(hash_post);
            byte_post = Encoding.ASCII.GetBytes(str_post);
        }


        str_send = method + " " + url + " HTTP/1.1\r\n" +
                 "Host: " + get_host_from_url(url) + "\r\n" +
                 "Content-Length: " + byte_post.Length.ToString() + "\r\n" +
                 "Connection:Close\r\n" +
                 "Accept: text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8\r\n" +
                 "User-Agent: Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/31.0.1650.63 Safari/537.36\r\n" +
                 "Accept-Encoding: gzip,deflate,sdch\r\n" +
                 "Accept-Language: zh-CN,zh;q=0.8\r\n" +
                 str_cookie +
                 "\r\n" +
                 str_post;

        request.content = str_send;
        request.url = url;

        return request;
    }
    public static Response get_response(Request request)
    {

        Byte[] data_send = Encoding.ASCII.GetBytes(request.content);

        Response response = new Response();
        byte[] data_response = get_response_data(request); 
        byte[] data_body;


        int start = find_new_2line_pos(data_response);
        string str_response = Encoding.UTF8.GetString(data_response, 0, data_response.Length);
        string str_header = str_response.Substring(0, str_response.IndexOf("\r\n\r\n"));
        string str_body = "";


        //页面跳转
        if (str_header.StartsWith("HTTP/1.1 302") || str_header.StartsWith("HTTP/1.1 301"))
        {
            string redirect_url = str_header.Substring(str_header.IndexOf("\r\nLocation: ") + "\r\nLocation: ".Length);
            redirect_url = redirect_url.Substring(0, redirect_url.IndexOf("\r\n"));
            Hashtable table = new Hashtable();
            Request request_redirect = get_reqeust(redirect_url, "GET", table, table);
            return get_response(request_redirect);
        }


        data_body = new byte[data_response.Length - start];

        
        Array.Copy(data_response, start, data_body, 0, data_response.Length - start);



        //当返回头中有Content-Length时,表示一次传输,能够确定长度,
        //当返回头中有Transfer-Encoding: chunked 时,表示,分段传输
        //Content-Length ,Transfer-Encoding: chunked 二者只能由其一
        if (str_header.IndexOf("Content-Length") < 0)
        {
            data_body = get_chuncked_data(data_body);
        }
        
        //GZip解压
        if (str_header.IndexOf("gzip") > -1)
        {
            data_body = decompress_zip(data_body);
        }


        //根据HTTP Header 解码
        if (str_header.ToLower().Contains("charset=gbk") || str_header.ToLower().Contains("charset=gb2312"))
        {
            str_body = Encoding.GetEncoding("GBK").GetString(data_body, 0, data_body.Length);
        }
        else
        {
            str_body = Encoding.UTF8.GetString(data_body, 0, data_body.Length);
        }


        //根据HTML Header解码 
        Regex reg_GB2312 = new Regex(@"<meta[^>]+Content-Type[^>]+gb2312[^>]*>", RegexOptions.IgnoreCase);
        Regex reg_GBK = new Regex(@"<meta[^>]+Content-Type[^>]+gbk[^>]*>", RegexOptions.IgnoreCase);
        Regex reg_Big5 = new Regex(@"<meta[^>]+Content-Type[^>]+Big5[^>]*>", RegexOptions.IgnoreCase);
        Regex reg_UTF8 = new Regex(@"<meta[^>]+Content-Type[^>]+utf-8[^>]*>", RegexOptions.IgnoreCase);
 
        if (reg_GB2312.IsMatch(str_body) || reg_GBK.IsMatch(str_body))
        {
            str_body = Encoding.GetEncoding("GBK").GetString(data_body, 0, data_body.Length);
        }
        if (reg_Big5.IsMatch(str_body))
        {
            str_body = Encoding.GetEncoding("Big5").GetString(data_body, 0, data_body.Length);
        }
        if (reg_UTF8.IsMatch(str_body))
        {
            str_body = Encoding.UTF8.GetString(data_body, 0, data_body.Length);
        }


        response.data = data_response;
        response.data_body = data_body;
        response.str_header = str_header;
        response.str_body = str_body;


        //添加Cookie
        foreach (string item in str_header.Split(new char[]{'\r','\n'},StringSplitOptions.RemoveEmptyEntries))
        {
            if (item.IndexOf("Set-Cookie:") > -1)
            {
                response.set_cookie.Add(item.Replace("Set-Cookie:", ""));
            }
        } 
        return response;
    }

    public static byte[] get_response_data(Request request)
    {
        Byte[] data_send = Encoding.ASCII.GetBytes(request.content);
        MemoryStream ms = new MemoryStream();
        Socket http = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        http.Connect(get_host_from_url(request.url), 80);
        http.Send(data_send);
        byte[] buffer = new byte[256];

        int count = 0;
        do
        {
            count = http.Receive(buffer, buffer.Length, SocketFlags.None);
            ms.Write(buffer, 0, count);
        }
        while (count > 0);

        ms.Seek(0, SeekOrigin.Begin);
        return ms.ToArray();
    }
 
    public static string get_host_from_url(string url)
    {
        int index = url.IndexOf(@"//");
        if (index <= 0)
            return "";
        string temp = url.Substring(index + 2);
        index = temp.IndexOf(@"/");
        if (index > 0)
            return temp.Substring(0, index);
        else
            return temp;
    }
    public static byte[] decompress_zip(byte[] data)
    {
        MemoryStream ms = new MemoryStream(data);

        GZipStream stream = new GZipStream(ms, CompressionMode.Decompress);

        byte[] data_total = new byte[40 * 1024];
        long total = 0;

        byte[] buffer = new byte[8];
        int count = 0;
        do
        {
            count = stream.Read(buffer, 0, 8);
            if (data_total.Length <= total + count) //放大数组
            {
                byte[] temp = new byte[data_total.Length * 10];
                data_total.CopyTo(temp, 0);
                data_total = temp;
            }
            buffer.CopyTo(data_total, total);
            total += count;
        } while (count != 0);
        byte[] data_desc = new byte[total];
        Array.Copy(data_total, 0, data_desc, 0, total);
        return data_desc;
    }

    public static byte[] get_chuncked_data(byte[] data)
    {
        MemoryStream ms = new MemoryStream();
        int start = 0;
        int pos = 0;
        int length = 0;
        do
        {
            pos = find_new_line_pos(data, start);
            byte[] length_data=new byte[pos-start];
            Array.Copy(data, start, length_data, 0, pos- start);  
            length = Convert.ToInt32(System.Text.Encoding.Default.GetString(length_data),16); 
            ms.Write(data, pos+2, length);
            start = pos + 2 + length+2;
        }
        while (length > 0); 
        return ms.ToArray();
    }

    public static int find_new_2line_pos(byte[] data)
    {
        for (int i = 0; i < data.Length - 3; ++i)
        {
            if (data[i] == 13 && data[i + 1] == 10 && data[i + 2] == 13 && data[i + 3] == 10)
                return i + 4;
        }
        return -1;
    }
    public static int find_new_line_pos(byte[] data, int start)
    {
        for (int i = start; i < data.Length - 3; ++i)
        {
            if (data[i] == 13 && data[i + 1] == 10)
                return i;
        }
        return -1;
    }
    public static string convert_cookie_to_string(Hashtable table)
    {

        if (table.Count == 0)
        {
            return "";
        }
        string result = "";
        foreach (string key in table.Keys)
        {
            if (!string.IsNullOrEmpty(table[key].ToString()))
            {
                result =result+ key + "=" + table[key].ToString() + ";";
            }
            else
            {
                result = result + key;
            }
        }
        return "Cookie: " + result + "\r\n";
    }
    public static string convert_post_to_string(Hashtable table)
    {
        if (table.Count == 0)
        {
            return "";
        }
        string result = "";
        foreach (string key in table.Keys)
        {
            if (!string.IsNullOrEmpty(table[key].ToString()))
            {
                result =result+ key + "=" + table[key].ToString() + "&";
            }
            else
            {
                result = result + key;
            }
        }
        return result.Substring(0, result.Length - 1);
    }
    public static Hashtable add_string_to_cookie(string cookie,Hashtable table)
    {
        string[] list = cookie.Split(';');

        foreach (string item in list)
        {
            string name = "";
            string value = "";
            int index=item.IndexOf('=');
            if (index> -1)
            { 
                name = item.Substring(0, index);
                value = item.Substring(index + 1, item.Length - index-1);
                bool is_has = false;
                foreach (string key in table.Keys)
                {
                    if (key == name)
                    {
                        table[key] = value;
                        is_has = true;
                        break;
                    }
                }
                if (is_has == false)
                {
                    table.Add(name, value);
                }
            }

        }
        return table;
    }
}