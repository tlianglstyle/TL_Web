using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TL.Data;
using System.Data;

namespace TL.Web
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string sql = "select  * from [Resource]";
            //DataView dv= BaseDAO.GetListAll(sql);
            DataView d = BaseDAO.GetListAll(sql);

            sql = " update talk set status=1 where id<60";
            //sql = " update blog blog set IsValid=1";
            //DataView dv= BaseDAO.GetListAll(sql);
            int f = BaseDAO.Action(sql);

            rpt_list.DataSource = BaseDAO.GetListAll("select * from share where id in (4,3,8,11) order by RecordDate");
            rpt_list.DataBind();
            rpt_article.DataSource = BaseDAO.GetListAll("select ID,Name from blog where IsValid=" + System.Configuration.ConfigurationManager.AppSettings["Validate"].ToString() + "  and ([type] like '%,%' or len([type])=1) order by RecordDate desc");
            rpt_article.DataBind();
        }
        public string GetChildren(int pid)
        {
            string result = "";
            string sql = @"declare @pid int  
                            set @pid=" + pid + @" 
                            declare @cid int  
                            set @cid =(select top 1 url from share where id=@pid)
                            select top 1 * from share_img where shareid=@pid and sid=@cid
                            union all
                            select top 8 * from share_img where shareid=@pid and id!=@cid

                            ";
            DataView dv = BaseDAO.GetListAll(sql);
            if (dv.Count > 0)
            {
                for (int i = 0; i < dv.Count; i++)
                {
                    //result += "<a href=\"share_detail.aspx?cid=" + dv[i]["ID"] + "\" class=\"ui_picwrap " + (i == 0 ? "first" : "") + "\" target=\"_blank\"><img src=\"p/s/" + pid + "/" + dv[i]["SID"] + "_min.jpg\" /></a>";
                    if (i == 0)
                        result += "<a v=\"" + (i + 2) + "\" href=\"sharec" + dv[i]["ID"] + ".aspx\" class=\"ui_picwrap " + (i == 0 ? "first" : "") + "\" target=\"_blank\"><img lazy-src=\"p/s/" + pid + "/" + dv[i]["SID"] + ".jpg\" /></a>";
                    else
                        result += "<a v=\"" + (i + 2) + "\" href=\"sharec" + dv[i]["ID"] + ".aspx\" class=\"ui_picwrap " + (i == 0 ? "first" : "") + "\" target=\"_blank\"><span lazy-src=\"p/s/" + pid + "/" + dv[i]["SID"] + "_min.jpg\"></span></a>";
                }
            }
            return result;
        }
    }
}