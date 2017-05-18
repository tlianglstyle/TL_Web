using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TL.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //string appid = "100515616";
            //string appkey = "c13453f2de1276ecfc9c29c806661a4c";
            //string AuthorizationCode = "";//用户的openid。
            //if (Request.QueryString["code"] != null)
            //{
            //    AuthorizationCode = Request.QueryString["code"].ToString();

            //    string url = "https://graph.qq.com/oauth2.0/token?";
            //    url += "grant_type=authorization_code";
            //    url += "&client_id=" + appid;
            //    url += "&client_secret=" + appkey;
            //    url += "&code=" + AuthorizationCode;
            //    url += "&redirect_uri=www.tliangl.com";
            //    Response.Redirect(url);
            //}
            //else if (Request.QueryString["access_token"] != null)
            //{
            //    string access_token = Request.QueryString["access_token"].ToString();
            //    string url = "https://graph.qq.com/user/get_user_info?";
            //    url += "oauth_consumer_key=" + appid;
            //    url += "&access_token=" + access_token;
            //    url += "&openid=" + AuthorizationCode;
            //    url += "&format=json";
            //    Response.Redirect(url);
            //}
        }
    }
}