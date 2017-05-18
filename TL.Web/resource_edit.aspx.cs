using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using TL.Data;

namespace TL.Web
{
    public partial class resource_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (TL.Data.UserInfo.GetUserInfo().ID != 2)
                Response.Redirect("http://www.tliangl.com");
            rpt_color.DataSource = BaseDAO.GetListAll("select ID,Name,stats from resource_color");
            rpt_color.DataBind();

            rpt_type.DataSource = BaseDAO.GetListAll("select ID,Name,stats from resource_Type");
            rpt_type.DataBind();
        }
    }
}