using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace lc
{
    /// <summary>
    /// HandlerYqh 的摘要说明
    /// </summary>
    public class HandlerYqh : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpRequest req = context.Request;
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string filename = System.Web.HttpContext.Current.Request.MapPath("/") + "1.txt";

            string name = req.Params["name"]; //姓名
            if (name.Length == 0 || name.IndexOf("\"") > -1)
            {
                context.Response.Write("姓名不能为空");
                return;
            }
            string gender = req.Params["gender"]; //性别
            string phone = req.Params["phone"]; //手机号码
            string city = req.Params["city"]; //城市
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); //时间
            string str = File.ReadAllText(filename);
            if (str.IndexOf(phone) > -1)
            {
                context.Response.Write("您的手机号码已经提交过了喔~~");
                return;
            }
            string json = "{\"name\":\"" + name + "\",\"gender\":\"" + gender + "\",\"phone\":\"" + phone + "\",\"city\":\"" + city + "\",\"time\":\"" + time + "\"}";
            if (str.Length == 0)
            {
                str = json;
            }
            else
            {
                str = json + "," + str;
            }
            File.WriteAllText(filename, str);
            context.Response.Write("ok");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}