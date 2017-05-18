using System;
using System.Collections.Generic;
using System.Web;
using System.Reflection;
using TL.Data;
using System.Data;
using TL.Common;

namespace TL.Web.service
{
    /// <summary>
    /// service 的摘要说明
    /// </summary>
    public class service : IHttpHandler
    {
        public User u = UserInfo.GetUserInfo();
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
            Type t = Type.GetType("TL.Web.service.service");
            object[] constuctParms = new object[] { };
            object dObj = Activator.CreateInstance(t, constuctParms);
            MethodInfo methodInfo = t.GetMethod(action);
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance;
            object[] parameters = new object[] { context };
            object returnValue = methodInfo.Invoke(dObj, flag, Type.DefaultBinder, parameters, null);

            context.Response.Write("");
            context.Response.End();
        }
        public void DeleteList(HttpContext context)
        {
            string tb = paraStr("tb");
            string list = paraStr("list");
            int result = BaseDAO.DeleteList(tb, list) ? 1 : 0;
            context.Response.Write("{\"ID\":\"" + result + "\"}");
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
        public void GetShareList(HttpContext context)
        {
            int f_c = paraInt("f_c");
            int f_t = paraInt("f_t");
            int o = paraInt("o");
            int rid = paraInt("rid");
            int rsize = paraInt("rsize");
            int pid = paraInt("pid");
            int psize = paraInt("psize");
            int sid = paraInt("sid");

            int pageid = (pid - 1) * (psize / rsize) + rid;
            int pagesize = rsize;

            string sql = "";
            if (sid == 0)
            {
                sql = " b.Name pname,b.clicks,b.collects,b.commends,b.replys,a.* from Share_Img a left join Share b on a.shareID=b.ID where 1=1 and b.isvalid=0 and a.isvalid=0 ";
                if (f_c != -1)
                    sql += " and ','+b.color+','  like '%," + f_c + ",%'  ";
                if (f_t != -1)
                    sql += " and ','+b.type+','  like '%," + f_t + ",%'  ";
                if (o != -1)
                {
                    switch (o)
                    {
                        case 1:
                            sort = " temp@@.sid,temp@@.RecordDate desc ";//使用GetListAutoSort重载，请使用表别名temp@@
                            break;
                        case 2:
                            sort = " temp@@.sid,temp@@.clicks desc ";
                            break;
                        case 3:
                            sort = " temp@@.sid,temp@@.commends desc ";
                            break;
                        case 4:
                            sort = " temp@@.sid,temp@@.replys desc ";
                            break;
                        default:
                            sort = " temp@@.sid ";
                            break;
                    }
                }
                else
                {
                    sort = " temp@@.sid,temp@@.RecordDate desc  ";//通过sid打乱顺序
                }
            }
            else
            {
                sql = " a.* from (";
                sql += "select * from (";
                sql += "select top 10000 b.Name pname,b.clicks,b.collects,b.commends,b.replys,c.* from Share_Img c left join Share b on c.shareID=b.ID where 1=1 and b.isvalid=0 and c.isvalid=0 ";
                sql += " and c.shareid=" + sid;
                sql += " ) u1 ";
                sql += " union all";//all防止排序混乱
                sql += " select * from (";
                sql += "select top 10000 b.Name pname,b.clicks,b.collects,b.commends,b.replys,c.* from Share_Img c left join Share b on c.shareID=b.ID where 1=1 and b.isvalid=0 and c.isvalid=0 ";
                sql += " and c.shareid!=" + sid;
                if (f_c != -1)
                    sql += " and ','+b.color+','  like '%," + f_c + ",%'  ";
                if (f_t != -1)
                    sql += " and ','+b.type+','  like '%," + f_t + ",%'  ";
                if (o != -1)
                {
                    switch (o)
                    {
                        case 1:
                            sql += " order by  c.sid,b.RecordDate desc ";
                            break;
                        case 2:
                            sql += " order by c.sid,b.clicks desc ";
                            break;
                        case 3:
                            sql += " order by c.sid,b.commends desc ";
                            break;
                        case 4:
                            sql += " order by c.sid,b.replys desc ";
                            break;
                        default:
                            sql += " order by c.sid ";
                            break;
                    }
                }
                else
                {
                    sql += " order by c.sid,b.RecordDate desc  ";//通过sid打乱顺序
                }
                sql += ") u2 ";
                sql += ") a ";
            }
            DataView dv = BaseDAO.GetList(pageid, pagesize, sql, sort, sid == 0 ? true : false);
            int count = BaseDAO.GetListCount(sql);
            context.Response.Write(Utils.DataViewToJson(dv, true, count).ToString());
            context.Response.End();
        }
        public void GetResource(HttpContext context)
        {
            int f_c = paraInt("f_c");
            int f_t = paraInt("f_t");
            int o = paraInt("o");
            int rid = paraInt("rid");
            int rsize = paraInt("rsize");
            int pid = paraInt("pid");
            int psize = paraInt("psize");

            int pageid = (pid - 1) * (psize / rsize) + rid;
            int pagesize = rsize;
            string sql = " * from Resource a where 1=1 ";
            if (f_c != -1)
                sql += " and ','+a.color+','  like '%," + f_c + ",%'  ";
            if (f_t != -1)
                sql += " and ','+a.type+','  like '%," + f_t + ",%'  ";
            if (o != -1)
            {
                switch (o)
                {
                    case 1:
                        sort = " RecordDate desc ";
                        break;
                    case 2:
                        sort = " clicks desc ";
                        break;
                    case 3:
                        sort = " commends desc ";
                        break;
                    case 4:
                        sort = " replys desc ";
                        break;
                }
            }

            DataView dv = BaseDAO.GetList(pageid, pagesize, sql, sort);
            int count = BaseDAO.GetListCount(sql);
            context.Response.Write(Utils.DataViewToJson(dv, true, count).ToString());
            context.Response.End();
        }
        public void GetBlog(HttpContext context)
        {
            string f_d = paraStr("f_d");
            int f_t = paraInt("f_t");
            int pageid = paraInt("pid");
            int pagesize = paraInt("psize");
            string sql = @" (select top 1 id from blog_type where  ','+a.type+',' like '%,'+cast(id as varchar)+',%') tid,(select top 1 name from blog_type where ','+a.type+',' like  '%,'+cast(id as varchar)+',%') tname,
                [ID],[SID],[Name],[UserID],[IsValid],[RecordDate],[Remark],[OrderIndex],[clicks],[replys],[shares],[collects],[commends],[url],[img],[type],[title] from Blog a where a.IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + "  ";
            if (f_t != -1)
                sql += " and ','+a.type+','  like '%," + f_t + ",%'  ";
            else if (f_d != "-1")
                sql += " and Year(cast(RecordDate as datetime))=" + f_d.Split('.')[0] + " and Month(cast(RecordDate as datetime))=" + f_d.Split('.')[1];
            sql += " and (a.[type] like '%,%' or len(a.[type])=1) ";
            DataView dv = BaseDAO.GetList(pageid, pagesize, sql, " RecordDate desc ");
            int count = BaseDAO.GetListCount(sql);
            context.Response.Write(Utils.DataViewToJson(dv, true, count).ToString());
            context.Response.End();
        }
        public void GetTalk(HttpContext context)
        {
            int pageid = paraInt("pid");
            int pagesize = paraInt("psize");
            string sql = @" u.uname uname,u.url url,u.img uimg,
                (case (select count(1) from talk where status=1 and parentid=a.id) 
                 when 0 then '' 
                 else  (select top 1 u2.uname from talk t2 left join [user] u2 on u2.id=t2.userid where parentid=a.id) end 
                ) reply_uname ,
                (case (select count(1) from talk where status=1 and parentid=a.id) 
                 when 0 then '' 
                 else  (select top 1 u1.url from talk t1 left join [user] u1 on u1.id=t1.userid where parentid=a.id and t1.status=1) end 
                ) reply_url ,
                (case (select count(1) from talk where parentid=a.id and status=1) 
                 when 0 then '' 
                 else  (select top 1 cast(content as varchar(8000)) from talk where parentid=a.id and status=1) end 
                ) reply_content,
                (case (select count(1) from talk where parentid=a.id and status=1) 
                 when 0 then '' 
                 else  (select top 1 recorddate from talk where parentid=a.id and status=1) end 
                ) reply_recorddate,
                a.*
                from talk a 
                left join [user] u on a.userid=u.id 
                where a.parentid=0 and a.status=1  
                ";
            DataView dv = BaseDAO.GetList(pageid, pagesize, sql, " a.RecordDate desc ");
            int count = BaseDAO.GetListCount(sql);
            context.Response.Write(Utils.DataViewToJson(dv, true, count).ToString());
            context.Response.End();
        }
        public void GetResourceDetail(HttpContext context)
        {
            int tid = paraInt("tid");
            string sql = " *  from Resource a where id=" + tid;

            DataView dv = BaseDAO.GetListAll(" select " + sql);
            int count = BaseDAO.GetListCount(sql);
            context.Response.Write(Utils.DataViewToJson(dv, true, count).ToString());
            context.Response.End();
        }
        public void GetBlogDetail(HttpContext context)
        {
            int tid = paraInt("tid");
            string sql = " *  from Blog a where IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + " and id=" + tid;

            DataView dv = BaseDAO.GetListAll(" select " + sql);
            int count = BaseDAO.GetListCount(sql);
            context.Response.Write(Utils.DataViewToJson(dv, true, count).ToString());
            context.Response.End();
        }

    }
}
