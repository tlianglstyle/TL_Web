using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TL.Data;
using System.Data;

namespace TL.Web
{
    public partial class share : System.Web.UI.Page
    {
        public DataRowView row = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            rpt_list.DataSource = BaseDAO.GetListAll("select * from share order by RecordDate desc");
            rpt_list.DataBind();
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
                            select top 12 * from share_img where shareid=@pid and id!=@cid

                            ";
            DataView dv = BaseDAO.GetListAll(sql);
            if (dv.Count > 0)
            {
                for (int i = 0; i < dv.Count; i++)
                {
                    //result += "<a href=\"share_detail.aspx?cid=" + dv[i]["ID"] + "\" class=\"ui_picwrap " + (i == 0 ? "first" : "") + "\" target=\"_blank\"><img src=\"p/s/" + pid + "/" + dv[i]["SID"] + "_min.jpg\" /></a>";
                    if (i == 0)
                        result += "<a href=\"sharec" + dv[i]["ID"] + ".aspx\" class=\"ui_picwrap " + (i == 0 ? "first" : "") + "\" target=\"_blank\"><img lazy-src=\"p/s/" + pid + "/" + dv[i]["SID"] + ".jpg\" /></a>";
                    else
                        result += "<a href=\"sharec" + dv[i]["ID"] + ".aspx\" class=\"ui_picwrap " + (i == 0 ? "first" : "") + "\" target=\"_blank\"><span lazy-src=\"p/s/" + pid + "/" + dv[i]["SID"] + "_min.jpg\"></span></a>";
                }
            }
            return result;
        }
    }
}