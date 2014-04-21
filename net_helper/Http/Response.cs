using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Response
{
    public byte[] data;
    public byte[] data_body;

    public string str_header;
    public string str_body;
    public List<String>  set_cookie=new List<string>();

}