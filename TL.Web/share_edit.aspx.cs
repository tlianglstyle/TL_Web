using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TL.Data;

namespace TL.Web
{
    public partial class share_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (TL.Data.UserInfo.GetUserInfo().ID != 2)
                Response.Redirect("http://www.tliangl.com");
        }
    }
}