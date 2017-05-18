using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace TL.Config
{
    public class GlobalConfig
    {
        #region 变量
        /// <summary>
        /// 是否接受缓存
        /// </summary>
        public static bool ApplyMemCached = false;
        /// <summary>
        /// 连接字符串是否加密
        /// </summary>
        public static bool ConnectionStringEncrypt = false;
        /// <summary>
        /// 是否自动登录
        /// </summary>
        public static string CookieAutoLogin = "AutoLogin";
        /// <summary>
        /// 数据库信息
        /// </summary>
        public static string CookieDBInfo = "";
        /// <summary>
        /// 系统语言
        /// </summary>
        public static string CookieLanguage = "zh-CN";
        /// <summary>
        /// 系统CSS样式
        /// </summary>
        public static string CookieTheme = "Theme";
        /// <summary>
        /// 用户名
        /// </summary>
        public static string CookieUser = "TLWork";
        /// <summary>
        /// 加密字符串key
        /// </summary>
        public static string EncryptKey = "TLKey";
        /// <summary>
        /// 缓存位置
        /// </summary>
        public static string CachePosition = "TLCache";
        #endregion

        #region 方法
        /// <summary>
        /// 获取数据库连接字符串
        /// </summary>
        /// <param name="DBName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string DBName)
        {
            if (DBName.Length == 0)
            {
                throw new Exception("请正确配置数据库连接信息");
            }
            if (!ConnectionStringEncrypt)
            {
                return GetAppConfig(DBName, "connectionStrings");
            }
            return "";
        }
        #endregion
        public static string GetAppConfig(string name, string type)
        {
            if (type.ToLower() == "connectionstrings")
                return ConfigurationManager.ConnectionStrings[name].ToString();
            if (type.ToLower() == "appsettings")
                return ConfigurationManager.AppSettings[name].ToString();
            return "";
        }
    }
}
