using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TL.Web.jxchart
{
    public partial class use : System.Web.UI.Page
    {
        public string themes = "default";//选择的背景类型,值为vc时启用v_c
        public string v_c = "";//自定义的背景颜色值
        public string type = "line";
        public string hd_data = "";
        public string setting_title = "";//标题
        public string setting_legend = "";//图例
        public string setting_x = "";
        public string setting_y = "";
        public string setting_pointValue = "";//是否显示点值
        public string setting_y_gridLineWidth = "1";//y轴分割线


        public string setting_title_family = "";
        public string setting_title_fontSize = "";
        public string setting_title_color = "";
        public string setting_x_family = "";
        public string setting_x_fontSize = "";
        public string setting_x_color = "";
        public string setting_y_family = "";
        public string setting_y_fontSize = "";
        public string setting_y_color = "";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (GetCookieValue("v_c") != null && GetCookieValue("v_c") != "")
            {
                v_c = GetCookieValue("v_c").ToString();
            }

            if (GetCookieValue("type") != null && GetCookieValue("type") != "")
            {
                type = GetCookieValue("type").ToString();
            }
            if (GetCookieValue("setting_title") != null && GetCookieValue("setting_title") != "")
            {
                setting_title = GetCookieValue("setting_title").ToString();
            }
            if (GetCookieValue("setting_legend") != null && GetCookieValue("setting_legend") != "")
            {
                setting_legend = GetCookieValue("setting_legend").ToString();
            }
            if (GetCookieValue("setting_x") != null && GetCookieValue("setting_x") != "")
            {
                setting_x = GetCookieValue("setting_x").ToString();
            }
            if (GetCookieValue("setting_y") != null && GetCookieValue("setting_y") != "")
            {
                setting_y = GetCookieValue("setting_y").ToString();
            }



            if (GetCookieValue("setting_title_family") != null && GetCookieValue("setting_title_family") != "")
            {
                setting_title_family = GetCookieValue("setting_title_family").ToString();
            }
            if (GetCookieValue("setting_title_fontSize") != null && GetCookieValue("setting_title_fontSize") != "")
            {
                setting_title_fontSize = GetCookieValue("setting_title_fontSize").ToString();
            }
            if (GetCookieValue("setting_title_color") != null && GetCookieValue("setting_title_color") != "")
            {
                setting_title_color = GetCookieValue("setting_title_color").ToString();
            }
            if (GetCookieValue("setting_x_family") != null && GetCookieValue("setting_x_family") != "")
            {
                setting_x_family = GetCookieValue("setting_x_family").ToString();
            }
            if (GetCookieValue("setting_x_fontSize") != null && GetCookieValue("setting_x_fontSize") != "")
            {
                setting_x_fontSize = GetCookieValue("setting_x_fontSize").ToString();
            }
            if (GetCookieValue("setting_x_color") != null && GetCookieValue("setting_x_color") != "")
            {
                setting_x_color = GetCookieValue("setting_x_color").ToString();
            }
            if (GetCookieValue("setting_y_family") != null && GetCookieValue("setting_y_family") != "")
            {
                setting_y_family = GetCookieValue("setting_y_family").ToString();
            }
            if (GetCookieValue("setting_y_fontSize") != null && GetCookieValue("setting_y_fontSize") != "")
            {
                setting_y_fontSize = GetCookieValue("setting_y_fontSize").ToString();
            }
            if (GetCookieValue("setting_y_color") != null && GetCookieValue("setting_y_color") != "")
            {
                setting_y_color = GetCookieValue("setting_y_color").ToString();
            }



            if (GetCookieValue("soon_temp") != null && GetCookieValue("soon_temp") == "true")
            {
                //setting_title = "";
                //setting_x = "n";
                //setting_y = "n";
                //setting_legend = "n";
                //setting_pointValue = "n";
                //setting_y_gridLineWidth = "0";
            }

        }
        public static string GetCookieValue(string cookiename)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookiename];
            string str = string.Empty;
            if (cookie != null)
            {
                str = cookie.Value;
            }
            return str;
        }
    }
}