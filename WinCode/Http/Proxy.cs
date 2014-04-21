using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Proxy
{
    public List<Session> sessions=new List<Session>();
    public Hashtable cookie=new Hashtable();
    public void get_response(string url,string method, Hashtable hash_post,Hashtable hash_cookie)
    {
        Session session = new Session();

        Request  request = HttpSocketHelper.get_reqeust(url, method, hash_post, hash_cookie);
        session.request = request;
        session.request_time = DateTime.Now;
        Response  response= HttpSocketHelper.get_response(request);
        session.response = response;

        this.sessions.Add(session);

        foreach (string item in response.set_cookie)
        {
            cookie=HttpSocketHelper.add_string_to_cookie(item, cookie);
        } 
    }
}