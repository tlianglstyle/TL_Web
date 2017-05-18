using System;
using System.Collections.Generic;
using System.Web;
using System.Reflection;
using System.Web.SessionState;

namespace jx.web.service
{
    /// <summary>
    /// action 的摘要说明
    /// </summary>
    public class action : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string method = context.Request.QueryString["action"].ToString();
            Type t = Type.GetType("jx.web.service.action");
            object[] constuctParms = new object[] { };
            object dObj = Activator.CreateInstance(t, constuctParms);
            MethodInfo sss = t.GetMethod(method);
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance;
            object[] parameters = new object[] { context };
            object returnValue = sss.Invoke(dObj, flag, Type.DefaultBinder, parameters, null);

            context.Response.Write("");
            context.Response.End();


        }

        public void submitItem(HttpContext context)
        {
            string hd_data = context.Request.Form["hd_data"].ToString();
            context.Session["hd_data"] = hd_data;
            //string[] arr = hd_data.Split('|');
            //for (int i = 0; i < arr.Length - 1; i++)
            //{
            //    string[] arrRow = arr[i].ToString().Split('_');
            //}
            context.Response.Write("1");
            context.Response.End();
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