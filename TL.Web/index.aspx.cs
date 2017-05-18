using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TL.Data;

namespace TL.Web
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select top 5 ID,Name from blog where len(Name)>20 order by recorddate desc ";
            rpt_topic.DataSource = BaseDAO.GetListAll(sql);
            rpt_topic.DataBind();

            sql = @"	select top 5 * from(
	            select a.ID,a.UserID,u.uname UserName,cast(a.content as varchar) content,b.ID pid,cast(b.Name as varchar) pname,a.RecordDate,1 t from Blog_Reply a left join Blog b on a.blogID=b.id  left join [User] u on a.UserID=u.ID
	            union 
	            select a.ID,a.UserID,u.uname UserName,cast(a.content as varchar) content,b.ID pid,cast(b.Name as varchar) pname,a.RecordDate,2 t from Resource_Reply a left join Resource b on a.resourceID=b.id    left join [User] u on a.UserID=u.ID
	            ) fff 
	            where pid>0 
	            order by RecordDate desc";
            rpt_reply.DataSource = BaseDAO.GetListAll(sql);
            rpt_reply.DataBind();
        }
    }
}