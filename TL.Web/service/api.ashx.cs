using System;
using System.Collections.Generic;
using System.Web;
using System.Reflection;
using TL.Data;
using System.Data;
using TL.Common;
using System.Web.SessionState;
using System.Web.Security;

namespace TL.Web.service
{
    /// <summary>
    /// api 的摘要说明
    /// </summary>
    public class api : IHttpHandler, IRequiresSessionState
    {
        #region process
        private static int pagesize = 15;
        private static int page = 1;
        private static string sort = "";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            string action = context.Request.QueryString["action"].ToString();
            page = HttpContext.Current.Request["page"] == null ? 1 : Convert.ToInt32(HttpContext.Current.Request["page"]);
            pagesize = HttpContext.Current.Request["rows"] == null ? 10 : Convert.ToInt32(HttpContext.Current.Request["rows"]);
            sort = HttpContext.Current.Request["sort"] == null ? "" : " order by a." + HttpContext.Current.Request["sort"] + " " + HttpContext.Current.Request["order"] + " ";
            Type t = Type.GetType("TL.Web.service.api");
            object[] constuctParms = new object[] { };
            object dObj = Activator.CreateInstance(t, constuctParms);
            MethodInfo methodInfo = t.GetMethod(action);
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance;
            object[] parameters = new object[] { context };
            object returnValue = methodInfo.Invoke(dObj, flag, Type.DefaultBinder, parameters, null);

            context.Response.Write("");
            context.Response.End();
        }
        protected int paraInt(string paraName)
        {
            if (HttpContext.Current.Request[paraName] != null)
                return Convert.ToInt32(HttpContext.Current.Request[paraName]);
            return 0;
        }
        protected double paraDouble(string paraName)
        {
            if (HttpContext.Current.Request[paraName] != null)
                return Convert.ToDouble(HttpContext.Current.Request[paraName]);
            return 0.00;
        }
        protected string paraStr(string paraName)
        {
            if (HttpContext.Current.Request[paraName] != null)
                return HttpContext.Current.Request[paraName].ToString();
            return "";
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #endregion


        public struct TreeStruct
        {
            public string id { get; set; }
            public string name { get; set; }
            public string parentid { get; set; }
            public string attributes { get; set; }
            public string level { get; set; }
            public string kcount { get; set; }
            public string ccount { get; set; }
            public string img { get; set; }
            public List<TreeStruct> children { get; set; }
        }

        public void GetRandomBlogsData(HttpContext context)
        {
            string callback = paraStr("callback");
            int pageid = paraInt("pid");
            int pagesize = paraInt("psize");
            string sql = @" (select top 1 id from blog_type where  ','+a.type+',' like '%,'+cast(id as varchar)+',%') tid,(select top 1 name from blog_type where ','+a.type+',' like  '%,'+cast(id as varchar)+',%') tname,
                [ID],[SID],[Name],[UserID],[IsValid],[RecordDate],[Remark],[OrderIndex],[clicks],[replys],[shares],[collects],[commends],[url],[img],[type],[title] from Blog a where 1=1 ";
        
            DataView dv = BaseDAO.GetList(pageid, pagesize, sql, " RecordDate desc ");
            int count = BaseDAO.GetListCount(sql);
            string str = Utils.DataViewToJson(dv, true, count).ToString();

            context.Response.Write(callback + "(" + str + ")");
            context.Response.End();
        }
        /// <summary>
        /// JZUI分页数据示例
        /// </summary>
        /// <param name="context"></param>
        public void GetBlogs(HttpContext context)
        {
            string callback = paraStr("callback");
            callback = callback == "" ? "callback" : callback;
            int pageid = paraInt("pageNum");
            int pagesize = paraInt("pageSize");
            string sql = @" (select top 1 id from blog_type where  ','+a.type+',' like '%,'+cast(id as varchar)+',%') tid,(select top 1 name from blog_type where ','+a.type+',' like  '%,'+cast(id as varchar)+',%') tname,
                [ID],[SID],[Name],[UserID],[IsValid],[RecordDate],[Remark],[OrderIndex],[clicks],[replys],[shares],[collects],[commends],[url],[img],[type],[title] from Blog a where 1=1 ";

            DataView dv = BaseDAO.GetList(pageid, pagesize, sql, " RecordDate desc ");
            DataTable dt = dv.Table;
            foreach (DataRow r in dt.Rows) { 
                r["name"] = Utils.GetSubString(r["name"].ToString(),40,"...");
                r["title"] = Utils.GetSubString(r["title"].ToString(), 60, "..."); 
            }
            int count = BaseDAO.GetListCount(sql);
            string str = Utils.DataViewToJson_JZ(pageid,new DataView(dt), true, count).ToString();

            context.Response.Write(callback + "(" + str + ")");
            //context.Response.Write(str);
            context.Response.End();
        }
        public void GetRandomDateData(HttpContext context)
        {
            string callback = paraStr("callback");
            int year = paraInt("year");
            int month = paraInt("month");
            string str = "[";
            str += "{ year: " + year + ", month: " + month + ", day: 1, dataDay: { id: 2, name: '刘大',status:0,edit:0} },";
            str += "{ year: " + year + ", month: " + month + ", day: 2, dataDay: { id: 4, name: '关二',status:1,edit:1} },";
            str += "{ year: " + year + ", month: " + month + ", day: 3, dataDay: { id: 6, name: '张三',status:1,edit:1} },";
            str += "{ year: " + year + ", month: " + month + ", day: 4, dataDay: { id: 7, name: '赵四',status:0,edit:0} },";
            str += "{ year: " + year + ", month: " + month + ", day: 5, dataDay: { id: 8, name: '王五',status:0,edit:0} },";
            str += "{ year: " + year + ", month: " + month + ", day: 9, dataDay: { id: 9, name: '马六',status:1,edit:0} },";
            str += "{ year: " + year + ", month: " + month + ", day: 10, dataDay: { id: 10, name: '魏七',status:0,edit:0} },";
            str += "{ year: " + year + ", month: " + month + ", day: 11, dataDay: { id: 12, name: '姜八',status:0,edit:1} },";
            str += "{ year: " + year + ", month: " + month + ", day: 12, dataDay: { id: 14, name: ' 严九',status:0,edit:0} }";
            str += "]";
            context.Response.Write(callback + "(" + str + ")");
            context.Response.End();
        }
        public void GetReportData(HttpContext context)
        {
            string callback = paraStr("callback");
            string str = @"[{
	                    name: '联想全球外设、京东8.18促销、联想乐基金网站、Thinkpad官网修改',
	                    date: '2014年8月25日－31日',
	                    members: [{
		                    name: '梁隽伟',
		                    hours: 20,
		                    lines: [{
			                    name: '1　联想全球外设1',
			                    level: 1,
			                    startdate: '2014-8-2',
			                    enddate: '2014-8-3'
		                    }, {
			                    name: '2　京东8.18促销2',
			                    level: 3,
			                    startdate: '2014-8-4',
			                    enddate: '2014-8-5'
		                    }, {
			                    name: '3　联想全球外设3',
			                    level: 2,
			                    startdate: '2014-8-6',
			                    enddate: '2014-8-7'
		                    }, {
			                    name: '4　联想全球外设4',
			                    level: 2,
			                    startdate: '2014-8-3',
			                    enddate: '2014-8-11'
		                    }, {
			                    name: '5　联想全球外设5',
			                    level: 1,
			                    startdate: '2014-8-9',
			                    enddate: '2014-8-10'
		                    }, {
			                    name: '6　联想全球外设6',
			                    level: 2,
			                    startdate: '2014-8-4',
			                    enddate: '2014-8-5'
		                    }, {
			                    name: '7　联想全球外设7',
			                    level: 3,
			                    startdate: '2014-8-10',
			                    enddate: '2014-8-14'
		                    }, {
			                    name: '8　联想全球外设8',
			                    level: 2,
			                    startdate: '2014-8-13',
			                    enddate: '2014-8-16'
		                    }, {
			                    name: '9　联想全球外设9',
			                    level: 1,
			                    startdate: '2014-8-12',
			                    enddate: '2014-8-14'
		                    }, {
			                    name: '10　联想全球外设10',
			                    level: 1,
			                    startdate: '2014-8-11',
			                    enddate: '2014-8-14'
		                    }, {
			                    name: '11　联想全球外设11',
			                    level: 1,
			                    startdate: '2014-8-12',
			                    enddate: '2014-8-12'
		                    }]
	                    }]
                    }]";
            context.Response.Write(callback + "(" + str + ")");
            context.Response.End();
        }
        public void GetReportUserData(HttpContext context)
        {
            string callback = paraStr("callback");
            string str = @"[{
	            id:1,
	            name:'梁隽伟1',
	            sum_hours:40,
	            sum_projects:6,
	            complete:1,
	            complete_hours:13,
	            wait:1,
	            wait_hours:10
	
            },{
	            id:2,
	            name:'梁隽伟2',
	            sum_hours:10,
	            sum_projects:6,
	            complete:2,
	            complete_hours:11,
	            wait:3,
	            wait_hours:10
	
            }]";
            context.Response.Write(callback + "(" + str + ")");
            context.Response.End();
        }


        public void jqueryform(HttpContext context)
        {
            System.Threading.Thread.Sleep(2000);
            context.Response.Write("1");
            context.Response.End();
        }
        public void wx_jzjz_validate(HttpContext context)
        {
            string WeChat_Token = "jzjztest";
            string signature = paraStr("signature");
            string timestamp = paraStr("timestamp");
            string nonce = paraStr("nonce");
            string echostr = paraStr("echostr");

            //从微信服务器接收传递过来的数据
            string[] ArrTmp = { WeChat_Token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序
            string tmpStr = string.Join("", ArrTmp);//将三个字符串组成一个字符串
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");//进行sha1加密
            tmpStr = tmpStr.ToLower();
            //加过密的字符串与微信发送的signature进行比较，一样则通过微信验证，否则失败。
            if (tmpStr == signature)
            {
                context.Response.Write("true");
            }
            else
            {
                context.Response.Write("false");
            }

            //context.Response.Write("1");
            context.Response.End();
        }
    }
}