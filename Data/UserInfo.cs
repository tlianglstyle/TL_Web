using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TL.Common;
using TL.Config;

namespace TL.Data
{
    public class UserInfo
    {
        public static User GetUserInfo()
        {
            User u = null;
            string cookie = Utils.GetCookie(GlobalConfig.CookieUser, "id");//用户id
            string pwd = Utils.GetCookie(GlobalConfig.CookieUser, "pwd");//用户密码
            string sql = "";
            if ((cookie.Trim() == "") || (pwd.Trim() == ""))
                sql = "select * from [user] where ID=1";
            else
                sql = string.Format("select * from [user] where ID='{0}' and pwd='{1}' ", cookie, pwd);
            DataView view = BaseDAO.GetListAll(sql);
            if (view.Count > 0)
            {
                DataRowView r = view[0];
                u = new User()
                {
                    ID = Convert.ToInt32(r["ID"]),
                    Name = r["Name"].ToString(),
                    uname = r["uname"].ToString(),
                    pwd = r["pwd"].ToString(),
                    phone = r["phone"].ToString(),
                    city = r["city"].ToString(),
                    clicks = Convert.ToInt32(r["clicks"]),
                    photos = Convert.ToInt32(r["photos"]),
                    blogs = Convert.ToInt32(r["blogs"]),
                    says = Convert.ToInt32(r["says"]),
                    jobID = Convert.ToInt32(r["jobID"]),
                    areaID = Convert.ToInt32(r["areaID"]),
                    url = r["url"].ToString(),
                    img = r["img"].ToString()
                };
            }
            return u;
        }
        public static void UserLogout()
        {

            Utils.WriteCookie(GlobalConfig.CookieUser, "id", "");
            Utils.WriteCookie(GlobalConfig.CookieUser, "pwd", "");
        }

    }
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string uname { get; set; }
        public string pwd { get; set; }
        public string phone { get; set; }
        public string city { get; set; }
        public int clicks { get; set; }
        public int photos { get; set; }
        public int blogs { get; set; }
        public int says { get; set; }
        public string url { get; set; }
        public string img { get; set; }
        public int jobID { get; set; }
        public int areaID { get; set; }
    }
}
