using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace TL.Log
{
    public class HttpLog : IHttpModule
    {
        // Methods
        public void Application_OnError(object sender, EventArgs e)
        {
            HttpApplication application = (HttpApplication)sender;
            string message = application.Context.Server.GetLastError().ToString();
            FileLog.log.Error(message);

        }

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.Error += new EventHandler(this.Application_OnError);
        }
    }
}
