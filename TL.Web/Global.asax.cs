using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text.RegularExpressions;

namespace TL.Web
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码

        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            string oldUrl = HttpContext.Current.Request.RawUrl;
            string pattern_blog = @"^(.+)article(\d+)\.aspx(\?.*)*$";
            string replace_blog = "$1blog_detail.aspx?id=$2";
            string pattern_share = @"^(.+)sharep(\d+)\.aspx(\?.*)*$";
            string replace_share = "$1share_detail.aspx?id=$2";
            string pattern_share_c = @"^(.+)sharec(\d+)\.aspx(\?.*)*$";
            string replace_share_c = "$1share_detail.aspx?cid=$2";
            string pattern_photo_c = @"^(.+)(\d+.\d+.\d+)\.aspx(\?.*)*$";
            string replace_photo_c = "$1photos.aspx?p=$2";
            if (Regex.IsMatch(oldUrl, pattern_blog, RegexOptions.IgnoreCase | RegexOptions.Compiled))
            {
                string newUrl = Regex.Replace(oldUrl, pattern_blog, replace_blog, RegexOptions.Compiled |
                RegexOptions.IgnoreCase);
                this.Context.RewritePath(newUrl);
            }
            else if (Regex.IsMatch(oldUrl, pattern_share, RegexOptions.IgnoreCase | RegexOptions.Compiled))
            {
                string newUrl = Regex.Replace(oldUrl, pattern_share, replace_share, RegexOptions.Compiled |
                RegexOptions.IgnoreCase);
                this.Context.RewritePath(newUrl);
            }
            else if (Regex.IsMatch(oldUrl, pattern_share_c, RegexOptions.IgnoreCase | RegexOptions.Compiled))
            {
                string newUrl = Regex.Replace(oldUrl, pattern_share_c, replace_share_c, RegexOptions.Compiled |
                RegexOptions.IgnoreCase);
                this.Context.RewritePath(newUrl);
            }
            else if (Regex.IsMatch(oldUrl, pattern_photo_c, RegexOptions.IgnoreCase | RegexOptions.Compiled))
            {
                string newUrl = Regex.Replace(oldUrl, pattern_photo_c, replace_photo_c, RegexOptions.Compiled |
                RegexOptions.IgnoreCase);
                this.Context.RewritePath(newUrl);
            }
        }
        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }

    }
}
