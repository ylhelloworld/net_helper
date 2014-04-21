using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;

public partial class FrmRequest_WebHttpRequest : Form
{
    public FrmRequest_WebHttpRequest()
    {
        InitializeComponent();
    }
    public string[] mark = new string[] { "\r\n" };

    private void FrmSocketRequest_Load(object sender, EventArgs e)
    {

    }

    private void txt_url_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == Convert.ToChar(13))
        {
            btn_request_Click(this.btn_request, new EventArgs());
        }
    }


    private void btn_request_Click(object sender, EventArgs e)
    {
        string str_url = this.txt_url.Text;
        string str_post = convert_post_string(this.txt_post.Text);
        string str_cookie = convert_cookie_string(this.txt_cookie.Text);
        string str_method = (rb_post.Checked) ? "POST" : "GET";
        this.txt_response.Text = get_response(str_url, str_method, str_post, str_cookie);
    }

    private void btn_cookie_add_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txt_cookie_name.Text) && !String.IsNullOrEmpty(txt_cookie_value.Text))
        {
            this.txt_cookie.Text = this.txt_cookie.Text + this.txt_cookie_name.Text + "=" + this.txt_cookie_value.Text + "\r\n";
        }
    }

    private void btn_post_add_Click(object sender, EventArgs e)
    {
        if (!String.IsNullOrEmpty(txt_post_name.Text) && !String.IsNullOrEmpty(txt_post_value.Text))
        {
            this.txt_post.Text = this.txt_post.Text + this.txt_post_name.Text + "=" + this.txt_post_value.Text + "\r\n";
        }
    }

    public string get_reqeust(string ip, string url, string method, string cookie, string post)
    {
        return "testing";
    }

    public string get_response(string url, string method, string post, string cookie)
    {
        string str_return = "";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = method;
        if (!String.IsNullOrEmpty(post))
        {
            byte[] send = Encoding.ASCII.GetBytes(post);
            request.ContentLength = send.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            request.KeepAlive = true;
            Stream stream = request.GetRequestStream();
            stream.Write(send, 0, send.Length);
            stream.Close();
        }
        if (!String.IsNullOrEmpty(cookie))
        {
            CookieContainer container = new CookieContainer();
            container.SetCookies(new Uri(url), cookie);
            request.CookieContainer = container;
        }
        this.txt_request.Text = get_request_header(request);
        try
        {
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
            str_return = reader.ReadToEnd();
            return str_return;
        }
        catch (WebException error)
        {
            return error.Message;
        }

    }

    //public CookieCollection convert_cookie_string(string str_cookie,string url)
    //{
    //    CookieCollection cookies = new CookieCollection();

    //    if (String.IsNullOrEmpty(str_cookie)) return cookies;
    //    string[] list = str_cookie.Split(mark, StringSplitOptions.RemoveEmptyEntries);
    //    if (list.Length > 0)
    //    {
    //        foreach (string child in list)
    //        {
    //            string[] list_1 = child.Split('=');
    //            if (list_1.Count > 1)
    //            {
    //                Cookie cookie = new Cookie();
    //                cookie.Domain = url;
    //                cookie.Name = list_1[0].ToString();
    //                cookie.Value = list_1[1].ToString();
    //            }
    //        }
    //    }
    //    return cookies;
    //}
    public string convert_cookie_string(string cookie)
    {
        if (String.IsNullOrEmpty(cookie)) return "";
        string[] list = cookie.Split(mark, StringSplitOptions.RemoveEmptyEntries);
        if (list.Length == 0)
        {
            return cookie;
        }
        else
        {
            string result = "";
            foreach (string child in list)
            {
                result = result + child + ",";
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }
    }

    public string convert_post_string(string post)
    {
        if (String.IsNullOrEmpty(post)) return "";
        string[] list = post.Split(mark, StringSplitOptions.RemoveEmptyEntries);
        if (list.Length == 0)
        {
            return post;
        }
        else
        {
            string result = "";
            foreach (string child in list)
            {
                result = result + child + "&";
            }
            result = result.Substring(0, result.Length - 1);
            return result;
        }
    }
    public string get_request_header(HttpWebRequest request)
    {
        string request_header = "this request header come from the class HttpWebRequest:\r\n" +
                                "====================================================================\r\n";

        request_header = request_header + "URL: " + request.Address + "\r\n";
        request_header = request_header + "Method: " + request.Method + "\r\n";
        request_header = request_header + "Length: " + request.ContentLength.ToString() + "\r\n";
        request_header = request_header + "ModifySince: " + request.IfModifiedSince.ToString() + "\r\n";
        return request_header;
    }
}
