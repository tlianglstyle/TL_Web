using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using TL.Config;
using System.Data;
using System.Reflection;
using System.Data.SqlClient;

namespace TL.Data
{
    public class BaseDAO
    {
        private DbConnection connection = null;
        /// <summary>
        /// 数据库连接
        /// </summary>
        protected DbConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    if (UserConfig.GetDbType().ToLower() == "sqlserver")
                        connection = new SqlConnection(GlobalConfig.GetConnectionString(UserConfig.GetDbName()));
                }
                return connection;
            }
        }



        #region 数据读取方法
        private static object model_update;
        //public static object GetObjectProperty(string field)
        //{
        //    if (model_update == null) return null;
        //    Type t = model_update.GetType();
        //    IEnumerable<System.Reflection.PropertyInfo> property = from pi in t.GetProperties() where pi.Name.ToLower() == field.ToLower() select pi;
        //    return property.First().GetValue(model_update, null);
        //}
        public static int SqlLog(string sid, string content)
        {
            return new DBHelper().ExecuteAction("insert into T_Log (ID,SID,Operate,OperateInfo,RecordDate) values(" + GetMaxId("T_Log") + ",'代码断点调试','" + sid + "','" + content + "','" + DateTime.Now.ToLongTimeString() + "')", UserConfig.GetDbName());
        }
        public static int Action(string strSql)
        {
            return new DBHelper().ExecuteAction(strSql.ToString(), UserConfig.GetDbName());
        }
        //public static int Action(string tb_name, object model)
        //{
        //    int id = GetMaxId(tb_name);
        //    string path = AppDomain.CurrentDomain.BaseDirectory;
        //    if (!path.EndsWith(@"\"))
        //    {
        //        path += @"\";
        //    }

        //    model_update = model;
        //    Assembly asmb = Assembly.LoadFrom(path + "bin/YOMIFrameWork.Entity.dll");
        //    Type type = asmb.GetType("YOMIFrameWork.Entity." + tb_name);
        //    PropertyInfo[] props = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    StringBuilder strSql = new StringBuilder();
        //    SqlParameter[] parameters = null;
        //    if (Convert.ToInt32(GetObjectProperty("ID")) == 0)
        //    {
        //        strSql.Append("insert into " + tb_name + "(");
        //        for (int i = 0; i < props.Length; i++)
        //        {
        //            if (props[i].Name == "RoleCode" || props[i].Name == "RoleName") continue;//用户表不需要增加或修改
        //            if (i > 0) strSql.Append(",");
        //            strSql.Append("[" + props[i].Name + "]");
        //        }
        //        strSql.Append(") values (");
        //        for (int i = 0; i < props.Length; i++)
        //        {
        //            if (props[i].Name == "RoleCode" || props[i].Name == "RoleName") continue;//用户表不需要增加或修改
        //            if (i > 0) strSql.Append(",");
        //            strSql.Append("@" + props[i].Name);
        //        }
        //        strSql.Append(")");
        //        parameters = new SqlParameter[props.Length];
        //        for (int i = 0; i < props.Length; i++)
        //        {
        //            object propertyValue = GetObjectProperty(props[i].Name);
        //            if (props[i].Name == "ID") propertyValue = Convert.ToInt32(propertyValue) == 0 ? id : Convert.ToInt32(propertyValue);
        //            if (props[i].Name == "UserID") propertyValue = 1;
        //            if (props[i].Name == "RecordDate") propertyValue = DateTime.Now;
        //            SqlParameter sPara = new SqlParameter("@" + props[i].Name, propertyValue == null ? DBNull.Value : propertyValue);
        //            parameters[i] = sPara;
        //        }
        //    }
        //    else
        //    {
        //        int colCount = 0;
        //        int j = 0;

        //        strSql.Append("update " + tb_name + " set ");
        //        for (int i = 0; i < props.Length; i++)
        //        {
        //            object propertyValue = GetObjectProperty(props[i].Name);
        //            if (propertyValue != null)
        //            {
        //                if (props[i].Name == "RoleCode" || props[i].Name == "RoleName") continue;//用户表不需要增加或修改
        //                if (colCount > 0) strSql.Append(",");
        //                strSql.Append(props[i].Name + " = @" + props[i].Name); colCount++;
        //            }
        //        }
        //        strSql.Append(" where ID=@ID ");

        //        parameters = new SqlParameter[colCount];
        //        for (int i = 0; i < props.Length; i++)
        //        {
        //            if (props[i].Name == "RoleCode" || props[i].Name == "RoleName") continue;//用户表不需要增加或修改
        //            object propertyValue = GetObjectProperty(props[i].Name);
        //            if (propertyValue != null)
        //            {
        //                SqlParameter sPara = new SqlParameter("@" + props[i].Name, propertyValue);
        //                parameters[j] = sPara;
        //                j++;
        //            }
        //        }
        //    }

        //    int rows = new DBHelper().ExecuteAction(strSql.ToString(), parameters, UserConfig.GetDbName());
        //    if (rows > 0)
        //    {
        //        return id;
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        public static DataView GetList(string tb_name)
        {
            string sql = "SELECT * FROM  " + tb_name + " order by OrderIndex";
            return new DBHelper().ExecuteDataView(sql, UserConfig.GetDbName());
        }
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <returns></returns>
        public static DataView GetList(string tb_name, string filter)
        {
            string sql = "select * FROM " + tb_name + " " + (filter.Trim() == "" ? "" : " where " + filter + " ") + "order by OrderIndex";
            return new DBHelper().ExecuteDataView(sql, UserConfig.GetDbName());
        }
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <returns></returns>
        public static DataView GetList(string tb_name, string filter, string sort)
        {
            string sql = "select * FROM " + tb_name + "  " + (filter.Trim() == "" ? "" : " where " + filter + " ") + " order by " + (sort == "" ? "RecordDate" : sort) + "";
            return new DBHelper().ExecuteDataView(sql, UserConfig.GetDbName());
        }
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="tb_name"></param>
        /// /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static DataView GetList(string tb_name, int page, int size, string filter)
        {
            string sql = "select * from ( select  row_number() over( order by RecordDate) as rowid,* from " + tb_name + (filter.Trim() == "" ? "" : " where " + filter + " ") + " ) tb_temp where rowid between " + ((page - 1) * size + 1) + " and " + (page * size);
            return new DBHelper().ExecuteDataView(sql, UserConfig.GetDbName());
        }
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="tb_name"></param>
        /// /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="filter"></param>
        /// /// <param name="sort"></param>
        /// <returns></returns>
        public static DataView GetList(string tb_name, int page, int size, string filter, string sort)
        {
            string sql = "select * from ( select  row_number() over( " + (sort == "" ? "order by RecordDate" : "order by " + sort) + ") as rowid,* from " + tb_name + " a " + (filter.Trim() == "" ? "" : " where " + filter + " ") + " ) tb_temp where rowid between " + ((page - 1) * size + 1) + " and " + (page * size);
            return new DBHelper().ExecuteDataView(sql, UserConfig.GetDbName());
        }
        /// <summary>
        /// 分页数据
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="sql_self"></param>
        /// <returns></returns>
        public static DataView GetList(int page, int size, string sql_self)
        {
            string sql = "select * from ( select  row_number() over( order by a.RecordDate) as rowid," + sql_self + " ) tb_temp where rowid between " + ((page - 1) * size + 1) + " and " + (page * size);
            return new DBHelper().ExecuteDataView(sql, UserConfig.GetDbName());
        }
        /// <summary>
        /// 分页数据 //默认为时间排序
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="sql_self"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        public static DataView GetList(int page, int size, string sql_self, string sort)
        {
            // ms sql2005 使用此代码
            //string sql = "select * from ( select  row_number() over( " + (sort == "" ? "order by a.RecordDate" : "order by " + sort) + ") as rowid," + sql_self + " ) tb_temp where rowid between " + ((page - 1) * size + 1) + " and " + (page * size);
            //            string sql = @"select top " + size + @" * from (
            //            select " + sql_self + @"
            //            ) tb 
            //             where id not in(
            //             select top " + (page - 1) * size + @" id from (
            //             select " + sql_self + @"
            //             ) temp
            //             ) " + (sort == "" ? "order by id" : "order by " + sort);
            string sql = @"select top " + size + @" * from (
            select top 10000 " + sql_self + (sort == "" ? "order by id" : "order by " + sort) + @"
            ) tb 
             where id not in(
             select top " + (page - 1) * size + @" id from (
             select top 10000 " + sql_self + (sort == "" ? "order by id" : "order by " + sort) + @"
             ) temp
             ) ";
            return new DBHelper().ExecuteDataView(sql, UserConfig.GetDbName());
        }
        /// <summary>
        /// 分页数据   //排序可选
        /// </summary>
        /// <param name="page"></param>
        /// <param name="size"></param>
        /// <param name="sql_self"></param>
        /// <param name="sort"></param>
        /// <param name="autoSort">是否自动排序</param>
        /// <returns></returns>
        public static DataView GetList(int page, int size, string sql_self, string sort, bool autoSort)
        {
            // ms sql 2000下：
            //备注：自定义sql使用top+ not in 分页时有时会出现not in子集过大，导致条件失效
            //建议使用临时表
            string sql = @"select * into #temp from (select " + sql_self + ") temp@@"
                    + (autoSort ? (sort == "" ? " order by id" : " order by " + sort) : "") + " ";
            sql += " select top " + size + @" * from #temp 
                    where not exists (
                    select 1 from (select top " + (page - 1) * size + @" id from #temp) a
                    where a.id=#temp.id
                    )
                    drop table #temp 
                    ";
            return new DBHelper().ExecuteDataView(sql, UserConfig.GetDbName());
        }
        /// <summary>
        /// 所有数据
        /// </summary>
        /// <param name="sql_self"></param>
        /// <returns></returns>
        public static DataView GetListAll(string sql_self)
        {
            return new DBHelper().ExecuteDataView(sql_self, UserConfig.GetDbName());
        }
        public static object GetScalar(string sql_self)
        {
            return new DBHelper().ExecuteScalar(sql_self, UserConfig.GetDbName());
        }
        /// <summary>
        /// 数据总数
        /// </summary>
        /// <returns></returns>
        public static int GetListCount(string tb_name, string filter)
        {
            string sql = "select count(1) from " + tb_name + (filter.Trim() == "" ? "" : " where " + filter + " ");
            return Convert.ToInt32(new DBHelper().ExecuteScalar(sql, UserConfig.GetDbName()));
        }
        /// <summary>
        /// 数据总数
        /// </summary>
        /// <returns></returns>
        public static int GetListCount(string sql_self)
        {
            string sql = "select count(1) from (select " + sql_self + ") temp";
            return Convert.ToInt32(new DBHelper().ExecuteScalar(sql, UserConfig.GetDbName()));
        }
        public static bool DeleteList(string tb_name, string IDlist)
        {
            if (IDlist.Length == 0) return false;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tb_name);
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = new DBHelper().ExecuteAction(strSql.ToString(), UserConfig.GetDbName());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool DeleteListSelf(string tb_name, string filter)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + tb_name);
            strSql.Append(" where 1=1 and " + filter);
            int rows = new DBHelper().ExecuteAction(strSql.ToString(), UserConfig.GetDbName());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        /// <param name="tableName">表名</param>
        /// <returns></returns>
        public static int GetMaxId(string tableName)
        {
            string sql = "select isnull(max(ID),0)+1  from " + tableName;
            object obj = new DBHelper().ExecuteScalar(sql, UserConfig.GetDbName());
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        #endregion
    }
}
