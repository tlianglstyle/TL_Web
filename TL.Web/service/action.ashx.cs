using System;
using System.Collections.Generic;
using System.Web;
using System.Reflection;
using TL.Data;
using System.Data;
using TL.Common;
using System.IO;
using TL.Config;
using System.Drawing;
using System.Drawing.Imaging;

namespace TL.Web.service
{
    /// <summary>
    /// action 的摘要说明
    /// </summary>
    public class action : IHttpHandler
    {
        public User u = UserInfo.GetUserInfo();
        #region process
        public string GetSn()
        {
            DateTime date = DateTime.Now;
            string year = date.Year.ToString();
            string month = Get0(date.Month);
            string day = Get0(date.Day);
            string hour = Get0(date.Hour);
            string min = Get0(date.Minute);
            string sec = Get0(date.Second);
            string mil = Get00(date.Millisecond);
            return year + month + day + hour + min + sec + mil;
        }
        public string Get0(int str)
        {
            return str > 9 ? str.ToString() : "0" + str.ToString();
        }
        public string Get00(int str)
        {
            if (str > 99)
                return str.ToString();
            else if (str > 9 && str <= 99)
                return "0" + str.ToString();
            else
                return "00" + str.ToString();
        }
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Charset = "utf-8";

            string action = context.Request.QueryString["action"].ToString();
            int tid = paraInt("tid");
            string col = paraStr("col");
            Type t = Type.GetType("TL.Web.service.action");
            object[] constuctParms = new object[] { };
            object dObj = Activator.CreateInstance(t, constuctParms);
            MethodInfo methodInfo = t.GetMethod(action);
            BindingFlags flag = BindingFlags.Public | BindingFlags.Instance;
            object[] parameters = new object[] { context };
            object returnValue = methodInfo.Invoke(dObj, flag, Type.DefaultBinder, parameters, null);

            context.Response.Write("");
            context.Response.End();
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
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
        protected int paraInt(string paraName, HttpContext context)
        {
            if (context.Request[paraName] != null)
                return Convert.ToInt32(context.Request[paraName]);
            return 0;
        }
        protected double paraDouble(string paraName, HttpContext context)
        {
            if (HttpContext.Current.Request[paraName] != null)
                return Convert.ToDouble(HttpContext.Current.Request[paraName]);
            return 0.00;
        }
        protected string paraStr(string paraName, HttpContext context)
        {
            if (context.Request[paraName] != null)
                return context.Request[paraName].ToString();
            return "";
        }
        #endregion
        public void login(HttpContext context)
        {
            string name = context.Request.Form["email-address"].ToString().Replace("'", "").Replace(",", "").Replace(" ", "");
            string password = context.Request.Form["password"].ToString().Replace("'", "").Replace(",", "").Replace(" ", "");
            string sql = "select * from [user] where name='" + name + "' and pwd='" + password + "'";
            DataView dv = BaseDAO.GetListAll(sql);
            if (dv.Count > 0)
            {
                Utils.WriteCookie(GlobalConfig.CookieUser, "id", dv[0]["ID"].ToString(), 60);
                Utils.WriteCookie(GlobalConfig.CookieUser, "pwd", dv[0]["pwd"].ToString(), 60);
                context.Response.Write("1");
            }
            else
            {
                context.Response.Write("0");
            }
        }
        public void register(HttpContext context)
        {
            string name = context.Request.Form["email-address"].ToString().Replace("'", "").Replace(",", "").Replace(" ", "");
            string yourname = context.Request.Form["yourname"].ToString().Replace("'", "").Replace(",", "").Replace(" ", "");
            string password = context.Request.Form["password"].ToString().Replace("'", "").Replace(",", "").Replace(" ", "");
            string telephone = context.Request.Form["telephone"].ToString().Replace("'", "").Replace(",", "").Replace(" ", "");
            string city = context.Request.Form["city"].ToString();

            string sql = "select * from [user] where name='" + name + "' and pwd='" + password + "'";
            if (BaseDAO.GetListAll(sql).Count > 0)
            {
                context.Response.Write("2");
            }
            else
            {
                sql = " insert into [user] (name,uname,pwd,phone,url,img) values('" + name + "','" + yourname + "','" + password + "','" + telephone + "','" + city + "','default.png')";
                if (BaseDAO.Action(sql) > 0)
                {
                    sql = "select * from [user] where name='" + name + "' and pwd='" + password + "'";
                    DataView dv = BaseDAO.GetListAll(sql);
                    if (dv.Count > 0)
                    {
                        Utils.WriteCookie(GlobalConfig.CookieUser, "id", dv[0]["ID"].ToString());
                        Utils.WriteCookie(GlobalConfig.CookieUser, "pwd", dv[0]["pwd"].ToString());
                    }
                    context.Response.Write("1");
                }
                else
                {
                    context.Response.Write("0");
                }
            }
        }
        public void uploadResourceImg(HttpContext context)
        {
            HttpPostedFile file = context.Request.Files["Filedata"];
            int id = Convert.ToInt32(context.Request["id"]);
            string uploadPath = HttpContext.Current.Server.MapPath("../r/img/");
            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                file.SaveAs(uploadPath + id + ".jpg");
                context.Response.Write("1");
            }
        }
        public void uploadResourceImgContent(HttpContext context)
        {
            HttpPostedFile file = context.Request.Files["Filedata"];
            int id = Convert.ToInt32(context.Request["id"]);
            string uploadPath = HttpContext.Current.Server.MapPath("../r/content/");
            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                string sql = " insert into Resource_Img (resourceID,url) values(" + id + ",'" + "" + "') select @@IDENTITY ";
                int tid = Convert.ToInt32(BaseDAO.GetScalar(sql));
                if (tid > 0)
                {
                    file.SaveAs(uploadPath + tid + ".jpg");
                    context.Response.Write("1");
                }
            }
        }
        public void uploadShareImg(HttpContext context)
        {
            HttpPostedFile file = context.Request.Files["Filedata"];
            int pid = Convert.ToInt32(context.Request["pid"]);
            string uploadPath = HttpContext.Current.Server.MapPath("../p/s/" + pid + "/");
            if (file != null)
            {
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                string sql = @"
                declare @sid int  
                set @sid=(select count(1)+1 from share_img where shareid=" + pid + @") 
                insert into share_img (sid,userid,isvalid,recorddate,shareid)values(@sid,2,0,getdate()," + pid + ") select @sid  ";
                int cid = Convert.ToInt32(BaseDAO.GetScalar(sql));
                if (cid > 0)
                {
                    file.SaveAs(uploadPath + cid + ".jpg");

                    FileInfo f = new FileInfo(uploadPath + cid + ".jpg");
                    string newName_m = cid + "_min.jpg";
                    string newName_230 = cid + "_230.jpg";

                    if (File.Exists(uploadPath + newName_m))
                    {
                        File.Delete(uploadPath + newName_m);
                    }
                    else
                    {
                        Bitmap bm = new Bitmap(uploadPath + cid + ".jpg");
                        int ww = 150;
                        int hh = Convert.ToInt32(bm.Height * 150 / bm.Width);
                        Bitmap bm1 = new Bitmap(bm, ww, hh);
                        bm1.Save(uploadPath + newName_m, ImageFormat.Jpeg);
                    }

                    if (File.Exists(uploadPath + newName_230))
                    {
                        File.Delete(uploadPath + newName_230);
                    }
                    else
                    {
                        Bitmap bm = new Bitmap(uploadPath + cid + ".jpg");
                        int ww = 400;
                        int hh = Convert.ToInt32(bm.Height * 400 / bm.Width);
                        Bitmap bm1 = new Bitmap(bm, ww, hh);
                        bm1.Save(uploadPath + newName_230, ImageFormat.Jpeg);
                    }

                    context.Response.Write("1");
                }
            }
        }

        public void submitResource(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.Form["infoid"]);
            string name = context.Request.Form["infoName"].ToString().Replace(" ", "").Replace("'", "").Replace("\\", "").Replace("\"", "");


            string remark = context.Request.Form["infoRemark"].ToString().Replace(" ", "").Replace("'", "").Replace("\\", "").Replace("\"", "");
            string content = context.Request.Form["infoContentValue"].ToString();
            string url = context.Request.Form["infoUrl"].ToString().Replace(" ", "").Replace("'", "").Replace("\\", "").Replace("\"", "");
            string img = "";
            string color = context.Request.Form["colorData_t"].ToString().Remove(0, 1);
            string type = context.Request.Form["typeData_t"].ToString().Remove(0, 1);

            string sql = "";


            if (id == 0)
            {
                sql = "insert into Resource(RecordDate,UserID,Name,content,remark,url,img,color,type) values(getdate()," + u.ID + ",'" + name + "','" + content + "','" + remark + "','" + url + "','" + img + "','" + color + "','" + type + "')";
            }
            else
            {
                sql = "update Resource set Name='" + name + "',type='" + type + "',color='" + color + "',url='" + url + "',img='" + img + "',remark='" + remark + "',content='" + content + "' where id=" + id;
            }
            if (BaseDAO.Action(sql) > 0)
            {
                if (id == 0)
                {
                    string[] arr_color = color.Split(',');
                    for (int i = 0; i < arr_color.Length; i++)
                    {
                        sql = "update Resource_color set stats=(select count(1) from Resource  where ','+color+','  like '%," + arr_color[i].ToString() + ",%' ) where id=" + arr_color[i].ToString();
                        BaseDAO.Action(sql);
                    }
                    string[] arr_type = type.Split(',');
                    for (int i = 0; i < arr_type.Length; i++)
                    {
                        sql = "update Resource_type set stats=(select count(1) from Resource  where ','+type+','  like '%," + arr_type[i].ToString() + ",%' ) where id=" + arr_type[i].ToString();
                        BaseDAO.Action(sql);
                    }
                }
                context.Response.Write(id == 0 ? BaseDAO.GetMaxId("Resource") - 1 : id);
            }
            else
            {
                context.Response.Write("0");
            }

            context.Response.End();
        }
        public void submitBlog(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.Form["topicid"]);
            string name = context.Request.Form["topicName"].ToString().Replace(" ", "").Replace("'", "").Replace("\\", "").Replace("\"", "");

            string topicType = context.Request.Form["topicType"].ToString();//文章类型

            string title = context.Request.Form["topicTitle"].ToString().Replace(" ", "").Replace("'", "").Replace("\\", "").Replace("\"", "");
            string content = context.Request.Form["topicContentValue"].ToString();

            string type = "1";//文章标签
            if (context.Request.Form["topicData_t"].ToString().Length > 1) { type = context.Request.Form["topicData_t"].ToString().Remove(0, 1); }

            if (topicType == "2")
            {

                if (context.Request.Form["voteType"].ToString() == "1")
                    topicType = "2";
                else
                    topicType = "3";
            }
            else
            {
                topicType = "1";
            }
            if(content.Length<100||!System.Text.RegularExpressions.Regex.IsMatch(content, @"[\u4e00-\u9fa5]")){
                return;
            }
            string sql = "";
            if (id == 0)
                sql = "insert into Blog(RecordDate,UserID,Name,content,title,type,IsValid) values(getdate()," + u.ID + ",'" + name + "','" + content + "','" + title + "','" + type + "'," + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + ")";
            else
            {
                sql = "update Blog set Name='" + name + "',type='" + type + "',title='" + title + "',content='" + content + "' where id=" + id;
            }
            if (BaseDAO.Action(sql) > 0)
            {
                if (id == 0)
                {
                    string[] arr_type = type.Split(',');
                    for (int i = 0; i < arr_type.Length; i++)
                    {
                        sql = "update Blog_type set stats=(select count(1) from Blog  where ','+type+','  like '%," + arr_type[i].ToString() + ",%' ) where id=" + arr_type[i].ToString();
                        BaseDAO.Action(sql);
                    }
                }
                context.Response.Write("1");
            }
            else
            {
                context.Response.Write("0");
            }

            context.Response.End();
        }
        public void submitShare(HttpContext context)
        {
            int id = Convert.ToInt32(context.Request.Form["infoid"]);
            string name = context.Request.Form["infoName"].ToString().Replace(" ", "").Replace("'", "").Replace("\\", "").Replace("\"", "");


            string collects = context.Request.Form["collects"].ToString().Replace(" ", "").Replace("'", "").Replace("\\", "").Replace("\"", "");
            string content = context.Request.Form["infoContent"].ToString();

            string sql = "";

            if (id == 0)
            {
                sql = @"insert into share (name,userid,isvalid,remark,collects,url,content)values ('" + name + "',0,0,'" + content + "'," + collects + ",1,'" + content + "') ";
            }
            else
            {
                sql = "";
            }
            if (BaseDAO.Action(sql) > 0)
            {
                context.Response.Write(id == 0 ? BaseDAO.GetMaxId("Share") - 1 : id);
            }
            else
            {
                context.Response.Write("0");
            }

            context.Response.End();
        }


        public void DeleteResource(HttpContext context)
        {
            int result = 0;
            string list = paraStr("list");
            if (BaseDAO.DeleteList("Resource", list))
            {
                string filepath = HttpContext.Current.Server.MapPath("../r/img/" + list + ".jpg");
                if (File.Exists(filepath))
                    File.Delete(filepath);
                DataView dv = BaseDAO.GetListAll("select ID from Resource_Img where resourceID=" + list);
                for (int i = 0; i < dv.Count; i++)
                {
                    filepath = HttpContext.Current.Server.MapPath("../r/content/" + dv[i]["ID"] + ".jpg");
                    if (File.Exists(filepath))
                        File.Delete(filepath);
                }
            }

            context.Response.Write("{\"ID\":\"" + result + "\"}");
            context.Response.End();
        }
         
        public void shareAuto(HttpContext context)
        {
            int tid = paraInt("tid", context);
            string col = paraStr("col", context);

            if (autoAdd(tid, "share", col))
            {
                context.Response.Write("1");
            }
            else
                context.Response.Write("0");
            context.Response.End();
        }
        public void submitResourceReply(HttpContext context)
        {
            int tid = Convert.ToInt32(context.Request.Form["tid"]);
            string content = context.Request.Form["replyContent"].ToString().Replace("'", "").Replace("\"", "").Replace("<", "").Replace(">", "");
            string sql = "insert into Resource_Reply(RecordDate,UserID,resourceID,content,[status]) values(getdate()," + u.ID + "," + tid + ",'" + content + "',0)";
            if (BaseDAO.Action(sql) > 0)
            {
                autoAdd(tid, "resource", "replys");
                context.Response.Write("1");
            }
            else
                context.Response.Write("0");
            context.Response.End();
        }
        public void submitBlogReply(HttpContext context)
        {
            int tid = Convert.ToInt32(context.Request.Form["tid"]);
            string rName = context.Request.Form["rName"].ToString().Replace("'", "").Replace("\"", "").Replace("<", "").Replace(">", "");
            string rMail = context.Request.Form["rMail"].ToString().Replace("'", "").Replace("\"", "").Replace("<", "").Replace(">", "");
            string rAddress = context.Request.Form["rAddress"].ToString().Replace("'", "").Replace("\"", "").Replace("<", "").Replace(">", "");
            string content = context.Request.Form["replyContent"].ToString().Replace("'", "").Replace("\"", "").Replace("<", "").Replace(">", "");


            if (rName.Length > 0)//自定义姓名
            {

                string name = rMail;
                string yourname = rName;
                string password = "123";
                string telephone = "";
                string city = "";
                string url = rAddress;

                string sql = "select * from [user] where uname='" + rName + "'";
                if (BaseDAO.GetListAll(sql).Count > 0)
                {
                    context.Response.Write("3");//该名字已存在
                }
                else
                {
                    sql = " insert into [user] (name,uname,pwd,phone,city,url,img) values('" + name + "','" + yourname + "','" + password + "','" + telephone + "','" + city + "','" + url + "','default.png')";
                    if (BaseDAO.Action(sql) > 0)
                    {
                        sql = "select * from [user] where uname='" + rName + "' ";
                        DataView dv = BaseDAO.GetListAll(sql);
                        if (dv.Count > 0)
                        {
                            u.ID = Convert.ToInt32(dv[0]["ID"]);
                            Utils.WriteCookie(GlobalConfig.CookieUser, "id", dv[0]["ID"].ToString(), 60);
                            Utils.WriteCookie(GlobalConfig.CookieUser, "pwd", dv[0]["pwd"].ToString(), 60);
                            sql = "insert into Blog_Reply(RecordDate,UserID,blogID,content,[status]) values(getdate()," + u.ID + "," + tid + ",'" + content + "',0)";
                            if (BaseDAO.Action(sql) > 0)
                            {
                                autoAdd(tid, "blog", "replys");
                                context.Response.Write("1");
                            }
                            else
                                context.Response.Write("0");
                        }
                    }
                    else
                    {
                        context.Response.Write("0");
                    }
                }
            }
            else
            {
                string sql = "insert into Blog_Reply(RecordDate,UserID,blogID,content,[status]) values(getdate()," + u.ID + "," + tid + ",'" + content + "',0)";
                if (BaseDAO.Action(sql) > 0)
                {
                    autoAdd(tid, "blog", "replys");
                    context.Response.Write("1");
                }
                else
                    context.Response.Write("0");
            }
            context.Response.End();
        }
        public void submitTalk(HttpContext context)
        {
            int tid = Convert.ToInt32(context.Request.Form["tid"]);
            string rName = context.Request.Form["rName"].ToString().Replace("'", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("\"", "");
            string rMail = context.Request.Form["rMail"].ToString().Replace("'", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("\"", "");
            if (rMail == "http://")
                rMail = "";
            string rAddress = context.Request.Form["rAddress"].ToString().Replace("'", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("\"", "");
            string content = context.Request.Form["replyContent"].ToString().Replace("'", "").Replace("\"", "").Replace("<", "").Replace(">", "").Replace("\"", "");


            if (rName.Length > 0)//自定义姓名
            {

                string name = rMail;
                string yourname = rName;
                string password = "123";
                string telephone = "";
                string city = "";
                string url = rAddress;

                string sql = "select * from [user] where uname='" + rName + "'";
                if (BaseDAO.GetListAll(sql).Count > 0)
                {
                    context.Response.Write("3");//该名字已存在
                }
                else
                {
                    sql = " insert into [user] (name,uname,pwd,phone,city,url,img,status) values('" + name + "','" + yourname + "','" + password + "','" + telephone + "','" + city + "','" + url + "','default.png',1)";
                    if (BaseDAO.Action(sql) > 0)
                    {
                        sql = "select * from [user] where uname='" + rName + "' ";
                        DataView dv = BaseDAO.GetListAll(sql);
                        if (dv.Count > 0)
                        {
                            u.ID = Convert.ToInt32(dv[0]["ID"]);
                            Utils.WriteCookie(GlobalConfig.CookieUser, "id", dv[0]["ID"].ToString(), 60);
                            Utils.WriteCookie(GlobalConfig.CookieUser, "pwd", dv[0]["pwd"].ToString(), 60);
                            sql = "insert into Talk(RecordDate,UserID,parentID,content,[status]) values(getdate()," + u.ID + "," + tid + ",'" + content + "',0)";
                            if (BaseDAO.Action(sql) > 0)
                            {
                                context.Response.Write(UserInfo.GetUserInfo().uname);
                                //context.Response.Write("1");
                            }
                            else
                                context.Response.Write("0");
                        }
                    }
                    else
                    {
                        context.Response.Write("0");
                    }
                }
            }
            else
            {
                string sql = "insert into Talk(RecordDate,UserID,parentID,content,[status]) values(getdate()," + u.ID + "," + tid + ",'" + content + "',0)";
                if (BaseDAO.Action(sql) > 0)
                {
                    context.Response.Write(UserInfo.GetUserInfo().uname);
                    //context.Response.Write("1");
                }
                else
                    context.Response.Write("0");
            }
            context.Response.End();
        }

        //字段自增
        public static bool autoAdd(int tid, string tb, string col)
        {
            string sql = "  update [" + tb + "] set " + col + "=" + col + "+1 where id=" + tid;
            return BaseDAO.Action(sql) > 0 ? true : false;
        }
    }
}