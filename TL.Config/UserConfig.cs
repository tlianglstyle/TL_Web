using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace TL.Config
{
    /// <summary>
    /// 用户配置
    /// </summary>
    public class UserConfig
    {
        #region 方法
        /// <summary>
        /// 获取数据库类型
        /// </summary>
        /// <returns></returns>
        public static string GetDbType()
        {
            string dbType = "SqlServer";
            dbType = ConfigurationManager.AppSettings["DbType"].ToLower();
            return dbType;
        }
        /// <summary>
        /// 获取数据库名称
        /// </summary>
        /// <returns></returns>
        public static string GetDbName()
        {
            return ConfigurationManager.AppSettings["DBName"].ToString();
        }
        #endregion
    }
}
