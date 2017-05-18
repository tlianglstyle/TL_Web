using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using TL.Data;
using TL.Common;

namespace TL.Web
{
    public partial class resource_detail : System.Web.UI.Page
    {
        public DataRowView row = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            DataView dv = BaseDAO.GetListAll("select a.*,u.uname from Resource a left join [user] u on a.userid=u.id where a.id=" + id);
            if (dv.Count > 0)
                row = dv[0];
            else
            {
                Response.Redirect("resource.aspx");
            }
            service.action.autoAdd(id, "resource", "clicks");
            string colors = row["color"].ToString();
            rpt_color.DataSource = BaseDAO.GetListAll("select * from Resource_Color where id in (" + colors + ")");
            rpt_color.DataBind();
            string types = row["type"].ToString();
            rpt_type.DataSource = BaseDAO.GetListAll("select * from Resource_Type where id in (" + types + ")");
            rpt_type.DataBind();


            rpt_img.DataSource = BaseDAO.GetListAll("select * from Resource_img where resourceID=" + id + " order by RecordDate");
            rpt_img.DataBind();

            rpt_other.DataSource = BaseDAO.GetListAll("select top 5 * from Resource where id<>" + id + " order by RecordDate desc ");
            rpt_other.DataBind();

            rpt_list.DataSource = BaseDAO.GetListAll("select a.*,u.uname uname,u.img uimg from Resource_Reply a left join [user] u on a.userid=u.id where a.resourceid=" + id + " order by a.RecordDate desc ");
            rpt_list.DataBind();


        }
    }
}