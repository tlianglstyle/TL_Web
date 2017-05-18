using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TL.Data;


namespace TL.Web
{
    public partial class share_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string f_c = Request.QueryString["f_c"] != null ? Request.QueryString["f_c"].ToString() : "-1";
            string f_t = Request.QueryString["f_t"] != null ? Request.QueryString["f_t"].ToString() : "-1";
            rpt_color.DataSource = BaseDAO.GetListAll("select ID,Name,stats,color,(case ID when " + f_c + " then 'c' else '' end) cls from Resource_Color");
            rpt_color.DataBind();
            rpt_type.DataSource = BaseDAO.GetListAll("select ID,Name,stats,(case ID when " + f_t + " then 'c' else '' end) cls from Resource_Type");
            rpt_type.DataBind();
        }
    }
}