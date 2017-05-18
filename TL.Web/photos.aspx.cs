using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TL.Web
{
    public partial class photos : System.Web.UI.Page
    {
       public string paratemeters = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["p"] != null)
            {
                paratemeters = Request.QueryString["p"].ToString();
            }
        }
    }
}