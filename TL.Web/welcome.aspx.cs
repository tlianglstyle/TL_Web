using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TL.Data;

namespace TL.Web
{
    public partial class welcome : System.Web.UI.Page
    {
        public string timeSent()
        {
            int h = DateTime.Now.Hour;
            if (h > 0 && h < 12)
            {
                return "上午好";
            }
            else if (h > 13 && h < 17)
            {
                return "下午好";
            }
            else
            {
                return "晚上好";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select ID,Name from blog where IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + " and ([type] like '%,%' or len([type])=1) order by recorddate desc ";
            rpt_topic.DataSource = BaseDAO.GetListAll(sql);
            rpt_topic.DataBind();

            sql = @"	select top 5 * from(
	            select a.ID,a.UserID,u.uname UserName,u.img uimg,cast(a.content as varchar) content,b.ID pid,cast(b.Name as varchar) pname,a.RecordDate,1 t from Blog_Reply a left join Blog b on a.blogID=b.id and b.IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + @"  and (b.[type] like '%,%' or len(b.[type])=1) left join [User] u on a.UserID=u.ID
	            union 
	            select a.ID,a.UserID,u.uname UserName,u.img uimg,cast(a.content as varchar) content,b.ID pid,cast(b.Name as varchar) pname,a.RecordDate,2 t from Resource_Reply a left join Resource b on a.resourceID=b.id    left join [User] u on a.UserID=u.ID
	            ) fff 
	            where pid>0 
	            order by RecordDate desc";
            rpt_reply.DataSource = BaseDAO.GetListAll(sql);
            rpt_reply.DataBind();

            sql = "select  ID,Name from Blog_Type where orderindex=2";//顶部标签类型
            rpt_tag.DataSource = BaseDAO.GetListAll(sql);
            rpt_tag.DataBind();
        }
    }
}