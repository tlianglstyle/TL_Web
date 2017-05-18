using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using TL.Config;
using TL.Log;

namespace TL.Data
{
    public class DBHelper
    {
        /// <summary>
        /// 检索SQL参数信息并填充
        /// </summary>
        /// <param name="cmd"></param>
        public void DeriveParameters(IDbCommand cmd)
        {
            if (cmd is SqlCommand)
            {
                SqlCommandBuilder.DeriveParameters(cmd as SqlCommand);
            }
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="sql"> Transact-SQL 语句</param>
        /// <param name="DBName">链接数据库</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteAction(string sql, string DBName)
        {
            int num;
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 120;
            using (SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName)))
            {
                PrepareCommand(cmd, connection, null, CommandType.Text, sql, null);
                try
                {
                    num = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
                }
                catch (Exception exception)
                {
                    SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
                    object[] objArray = new object[] { "DataBase:", DBName, "\r\nSetTime:", 120, "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteAction\r\nSql:", sql };
                    FileLog.log.Error(string.Concat(objArray), exception);
                    throw;
                }
            }
            return num;
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="par">参数</param>
        /// <param name="DBName">链接数据库</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteAction(string sql, DbParameter[] par, string DBName)
        {
            int num2;
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 120;
            using (SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName)))
            {
                PrepareCommand(cmd, connection, null, CommandType.Text, sql, (SqlParameter[])par);
                try
                {
                    num2 = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
                }
                catch (Exception exception)
                {
                    SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
                    object[] objArray = new object[] { "DataBase:", DBName, "\r\nSetTime:", 120, "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteAction\r\nSql:", sql };
                    FileLog.log.Error(string.Concat(objArray), exception);
                    throw;
                }
            }
            return num2;
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="DBName">链接数据库</param>
        /// <param name="time">设置在终止执行命令的尝试并生成错误之前的等待时间。</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteAction(string sql, string DBName, int time)
        {
            int num2;
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = time;
            using (SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName)))
            {
                PrepareCommand(cmd, connection, null, CommandType.Text, sql, null);
                try
                {
                    int num = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    SqlLog(sql, DBName, time, (TimeSpan)(DateTime.Now - now));
                    num2 = num;
                }
                catch (Exception exception)
                {
                    SqlLog(sql, DBName, time, (TimeSpan)(DateTime.Now - now));
                    string[] strArray = new string[] { "DataBase:", DBName, "\r\nSetTime:", time.ToString(), "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteAction\r\nSql:", sql };
                    FileLog.log.Error(string.Concat(strArray), exception);
                    throw;
                }
            }
            return num2;
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回受影响的行数。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="par">参数</param>
        /// <param name="DBName">链接数据库</param>
        /// <param name="time">设置在终止执行命令的尝试并生成错误之前的等待时间。</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteAction(string sql, DbParameter[] par, string DBName, int time)
        {
            int num2;
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = time;
            using (SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName)))
            {
                PrepareCommand(cmd, connection, null, CommandType.Text, sql, (SqlParameter[])par);
                try
                {
                    int num = cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    SqlLog(sql, DBName, time, (TimeSpan)(DateTime.Now - now));
                    num2 = num;
                }
                catch (Exception exception)
                {
                    SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
                    string[] strArray = new string[] { "DataBase:", DBName, "\r\nSetTime:", time.ToString(), "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteAction\r\nSql:", sql };
                    FileLog.log.Error(string.Concat(strArray), exception);
                    throw;
                }
            }
            return num2;
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回数据集。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="DBName"></param>
        /// <returns>DataSet数据集</returns>
        public DataSet ExecuteDataSet(string sql, string DBName)
        {
            DataSet dataSet = new DataSet();
            DateTime now = DateTime.Now;
            SqlCommand command = new SqlCommand();
            command.CommandTimeout = 120;
            using (SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName)))
            {
                PrepareCommand(command, connection, null, CommandType.Text, sql, null);
                command.CommandTimeout = 120;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                try
                {
                    adapter.Fill(dataSet);
                }
                catch (Exception exception)
                {
                    connection.Close();
                    object[] objArray = new object[] { "DataBase:", DBName, "\r\nSetTime:", 120, "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteDataSet\r\nSql:", sql };
                    FileLog.log.Error(string.Concat(objArray), exception);
                    throw;
                }
                finally
                {
                    connection.Close();
                }
                SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
            }
            return dataSet;
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回数据集。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="DBName"></param>
        /// <param name="time">设置在终止执行命令的尝试并生成错误之前的等待时间。</param>
        /// <returns>DataSet数据集</returns>
        public DataSet ExecuteDataSet(string sql, string DBName, int time)
        {
            DateTime now = DateTime.Now;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName));
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.CommandTimeout = time;
            command.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            try
            {
                adapter.Fill(dataSet);
            }
            catch (Exception exception)
            {
                connection.Close();
                string[] strArray = new string[] { "DataBase:", DBName, "\r\nSetTime:", time.ToString(), "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteDataSet\r\nSql:", sql };
                FileLog.log.Error(string.Concat(strArray), exception);
                throw;
            }
            finally
            {
                connection.Close();
            }
            SqlLog(sql, DBName, time, (TimeSpan)(DateTime.Now - now));
            return dataSet;
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回数据集。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="DBName"></param>
        /// <returns>DataTable数据集</returns>
        public DataTable ExecuteDataTable(string sql, string DBName)
        {
            DateTime now = DateTime.Now;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName));
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.CommandTimeout = 120;
            command.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            try
            {
                adapter.Fill(dataSet);
            }
            catch (Exception exception)
            {
                connection.Close();
                object[] objArray = new object[] { "DataBase:", DBName, "\r\nSetTime:", 120, "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteDataTable\r\nSql:", sql };
                FileLog.log.Error(string.Concat(objArray), exception);
                throw;
            }
            finally
            {
                connection.Close();
            }
            SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
            return dataSet.Tables[0];
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回数据集。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="DBName"></param>
        /// <param name="time">设置在终止执行命令的尝试并生成错误之前的等待时间。</param>
        /// <returns>DataTable数据集</returns>
        public DataTable ExecuteDataTable(string sql, string DBName, int time)
        {
            DateTime now = DateTime.Now;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName));
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.CommandTimeout = time;
            command.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            try
            {
                adapter.Fill(dataSet);
            }
            catch (Exception exception)
            {
                connection.Close();
                string[] strArray = new string[] { "DataBase:", DBName, "\r\nSetTime:", time.ToString(), "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteDataTable\r\nSql:", sql };
                FileLog.log.Error(string.Concat(strArray), exception);
                throw;
            }
            finally
            {
                connection.Close();
            }
            SqlLog(sql, DBName, time, (TimeSpan)(DateTime.Now - now));
            return dataSet.Tables[0];
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回数据集。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="DBName"></param>
        /// <returns>DataView数据集</returns>
        public DataView ExecuteDataView(string sql, string DBName)
        {
            DateTime now = DateTime.Now;
            SqlCommand command = new SqlCommand();
            string s = GlobalConfig.GetConnectionString(DBName);
            SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName));
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.CommandTimeout = 120;
            command.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            try
            {
                adapter.Fill(dataSet);
            }
            catch (Exception exception)
            {
                connection.Close();
                object[] objArray = new object[] { "DataBase:", DBName, "\r\nSetTime:", 120, "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteDataView\r\nSql:", sql };
                FileLog.log.Error(string.Concat(objArray), exception);
                throw;
            }
            finally
            {
                connection.Close();
            }
            SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
            return dataSet.Tables[0].DefaultView;
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回数据集。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="par"></param>
        /// <param name="DBName"></param>
        /// <returns>DataView数据集</returns>
        public DataView ExecuteDataView(string sql, DbParameter[] par, string DBName)
        {
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(GlobalConfig.GetConnectionString(DBName));
            cmd.CommandTimeout = 120;
            PrepareCommand(cmd, conn, null, CommandType.Text, sql, (SqlParameter[])par);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            try
            {
                adapter.Fill(dataSet);
            }
            catch (Exception exception)
            {
                conn.Close();
                object[] objArray = new object[] { "DataBase:", DBName, "\r\nSetTime:", 120, "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteDataView\r\nSql:", sql };
                FileLog.log.Error(string.Concat(objArray), exception);
                throw;
            }
            finally
            {
                conn.Close();
            }
            SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
            return dataSet.Tables[0].DefaultView;
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回数据集。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="DBName"></param>
        /// <param name="time">设置在终止执行命令的尝试并生成错误之前的等待时间。</param>
        /// <returns>DataView数据集</returns>
        public DataView ExecuteDataView(string sql, string DBName, int time)
        {
            DateTime now = DateTime.Now;
            SqlCommand command = new SqlCommand();
            SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName));
            command.CommandType = CommandType.Text;
            command.CommandText = sql;
            command.CommandTimeout = time;
            command.Connection = connection;
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            DataSet dataSet = new DataSet();
            try
            {
                adapter.Fill(dataSet);
            }
            catch (Exception exception)
            {
                connection.Close();
                string[] strArray = new string[] { "DataBase:", DBName, "\r\nSetTime:", time.ToString(), "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteDataView\r\nSql:", sql };
                FileLog.log.Error(string.Concat(strArray), exception);
                throw;
            }
            finally
            {
                connection.Close();
            }
            SqlLog(sql, DBName, time, (TimeSpan)(DateTime.Now - now));
            return dataSet.Tables[0].DefaultView;
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回数据集。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="par"></param>
        /// <param name="DBName"></param>
        /// <param name="time">设置在终止执行命令的尝试并生成错误之前的等待时间。</param>
        /// <returns>DataView数据集</returns>
        public DataView ExecuteDataView(string sql, DbParameter[] par, string DBName, int time)
        {
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(GlobalConfig.GetConnectionString(DBName));
            cmd.CommandTimeout = time;
            PrepareCommand(cmd, conn, null, CommandType.Text, sql, (SqlParameter[])par);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;
            DataSet dataSet = new DataSet();
            try
            {
                adapter.Fill(dataSet);
            }
            catch (Exception exception)
            {
                conn.Close();
                string[] strArray = new string[] { "DataBase:", DBName, "\r\nSetTime:", time.ToString(), "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteDataView\r\nSql:", sql };
                FileLog.log.Error(string.Concat(strArray), exception);
                throw;
            }
            finally
            {
                conn.Close();
            }
            SqlLog(sql, DBName, time, (TimeSpan)(DateTime.Now - now));
            return dataSet.Tables[0].DefaultView;
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回执行结果。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="par"></param>
        /// <param name="DBName"></param>
        /// <returns>返回值</returns>
        public object ExecuteProReturnValue(string sql, DbParameter[] par, string DBName)
        {
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(GlobalConfig.GetConnectionString(DBName));
            cmd.CommandTimeout = 120;
            PrepareCommand(cmd, conn, null, CommandType.StoredProcedure, sql, (SqlParameter[])par);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                conn.Close();
                object[] objArray = new object[] { "DataBase:", DBName, "\r\nSetTime:", 120, "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteProReturnValue\r\nSql:", sql };
                FileLog.log.Error(string.Concat(objArray), exception);
                throw;
            }
            finally
            {
                conn.Close();
            }
            SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
            return par[par.Length - 1].Value;
        }
        /// <summary>
        /// 对连接执行 Transact-SQL 语句并返回执行结果。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="par"></param>
        /// <param name="DBName"></param>
        /// <param name="time">设置在终止执行命令的尝试并生成错误之前的等待时间。</param>
        /// <returns>返回值</returns>
        public object ExecuteProReturnValue(string sql, DbParameter[] par, string DBName, int time)
        {
            DateTime now = DateTime.Now;
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = sql;
            command.CommandTimeout = time;
            SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName));
            command.Connection = connection;
            foreach (DbParameter parameter in par)
            {
                command.Parameters.Add((SqlParameter)parameter);
            }
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
                connection.Close();
                string[] strArray = new string[] { "DataBase:", DBName, "\r\nSetTime:", time.ToString(), "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteProReturnValue\r\nSql:", sql };
                FileLog.log.Error(string.Concat(strArray), exception);
                throw;
            }
            finally
            {
                connection.Close();
            }
            SqlLog(sql, DBName, time, (TimeSpan)(DateTime.Now - now));
            return par[par.Length - 1].Value;
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="DBName"></param>
        /// <returns>结果集中第一行的第一列；如果结果集为空，则为空引用（在 Visual Basic 中为 Nothing）。返回的最大字符数为 2033 个字符。</returns>
        public object ExecuteScalar(string sql, string DBName)
        {
            object obj3;
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 120;
            using (SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName)))
            {
                PrepareCommand(cmd, connection, null, CommandType.Text, sql, null);
                try
                {
                    object obj2 = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
                    obj3 = obj2;
                }
                catch (Exception exception)
                {
                    SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
                    object[] objArray = new object[] { "DataBase:", DBName, "\r\nSetTime:", 120, "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteScalar\r\nSql:", sql };
                    FileLog.log.Error(string.Concat(objArray), exception);
                    throw;
                }
            }
            return obj3;
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="par"></param>
        /// <param name="DBName"></param>
        /// <returns>结果集中第一行的第一列；如果结果集为空，则为空引用（在 Visual Basic 中为 Nothing）。返回的最大字符数为 2033 个字符。</returns>
        public object ExecuteScalar(string sql, string DBName, int time)
        {
            object obj3;
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = time;
            using (SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName)))
            {
                PrepareCommand(cmd, connection, null, CommandType.Text, sql, null);
                try
                {
                    object obj2 = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    SqlLog(sql, DBName, time, (TimeSpan)(DateTime.Now - now));
                    obj3 = obj2;
                }
                catch (Exception exception)
                {
                    SqlLog(sql, DBName, time, (TimeSpan)(DateTime.Now - now));
                    string[] strArray = new string[] { "DataBase:", DBName, "\r\nSetTime:", time.ToString(), "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteScalar\r\nSql:", sql };
                    FileLog.log.Error(string.Concat(strArray), exception);
                    throw;
                }
            }
            return obj3;
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="DBName"></param>
        /// <param name="time">设置在终止执行命令的尝试并生成错误之前的等待时间。</param>
        /// <returns>结果集中第一行的第一列；如果结果集为空，则为空引用（在 Visual Basic 中为 Nothing）。返回的最大字符数为 2033 个字符。</returns>
        public object ExecuteScalar(string sql, DbParameter[] par, string DBName)
        {
            object obj3;
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 120;
            using (SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName)))
            {
                PrepareCommand(cmd, connection, null, CommandType.Text, sql, (SqlParameter[])par);
                try
                {
                    object obj2 = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
                    obj3 = obj2;
                }
                catch (Exception exception)
                {
                    SqlLog(sql, DBName, 120, (TimeSpan)(DateTime.Now - now));
                    object[] objArray = new object[] { "DataBase:", DBName, "\r\nSetTime:", 120, "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteScalar\r\nSql:", sql };
                    FileLog.log.Error(string.Concat(objArray), exception);
                    throw;
                }
            }
            return obj3;
        }
        /// <summary>
        /// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略其他列或行。
        /// </summary>
        /// <param name="sql">Transact-SQL 语句</param>
        /// <param name="par"></param>
        /// <param name="DBName"></param>
        /// <param name="time">设置在终止执行命令的尝试并生成错误之前的等待时间。</param>
        /// <returns>结果集中第一行的第一列；如果结果集为空，则为空引用（在 Visual Basic 中为 Nothing）。返回的最大字符数为 2033 个字符。</returns>
        public object ExecuteScalar(string sql, DbParameter[] par, string DBName, int time)
        {
            object obj3;
            DateTime now = DateTime.Now;
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = time;
            using (SqlConnection connection = new SqlConnection(GlobalConfig.GetConnectionString(DBName)))
            {
                PrepareCommand(cmd, connection, null, CommandType.Text, sql, (SqlParameter[])par);
                try
                {
                    object obj2 = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    SqlLog(sql, DBName, time, (TimeSpan)(DateTime.Now - now));
                    obj3 = obj2;
                }
                catch (Exception exception)
                {
                    SqlLog(sql, DBName, time, (TimeSpan)(DateTime.Now - now));
                    string[] strArray = new string[] { "DataBase:", DBName, "\r\nSetTime:", time.ToString(), "\r\nExecuteTime:", ((TimeSpan)(DateTime.Now - now)).ToString(), "\r\nExecuteScalar\r\nSql:", sql };
                    FileLog.log.Error(string.Concat(strArray), exception);
                    throw;
                }
            }
            return obj3;
        }





        /// <summary>
        /// 是否支持全文搜索
        /// </summary>
        /// <returns></returns>
        public bool IsFullTextSearchEnabled()
        {
            return true;
        }
        /// <summary>
        /// 是否支持压缩数据库
        /// </summary>
        /// <returns></returns>
        public bool IsCompactDatabase()
        {
            return true;
        }
        /// <summary>
        /// 是否支持备份数据库
        /// </summary>
        /// <returns></returns>
        public bool IsBackupDatabase()
        {
            return true;
        }
        /// <summary>
        /// 返回刚插入记录的自增ID值, 如不支持则为""
        /// </summary>
        /// <returns></returns>
        public string GetLastIdSql()
        {
            return "SELECT SCOPE_IDENTITY()";
        }

        public DbProviderFactory Instance()
        {
            return SqlClientFactory.Instance;
        }
        /// <summary>
        /// 是否支持数据库优化
        /// </summary>
        /// <returns></returns>
        public bool IsDbOptimize()
        {
            return true;
        }
        /// <summary>
        /// 是否支持数据库收缩
        /// </summary>
        /// <returns></returns>
        public bool IsShrinkData()
        {
            return true;
        }
        /// <summary>
        /// 是否支持存储过程
        /// </summary>
        /// <returns></returns>
        public bool IsStoreProc()
        {
            return true;
        }
        /// <summary>
        /// 创建DbParameter对象
        /// </summary>
        /// <param name="ParamName">对象名称</param>
        /// <param name="DbType">类型</param>
        /// <param name="Size">大于0为字符串，小于0为数值</param>
        /// <returns>DbParameter对象</returns>
        public DbParameter MakeParam(string ParamName, DbType DbType, int Size)
        {
            if (Size > 0)
            {
                return new SqlParameter(ParamName, (SqlDbType)DbType, Size);
            }
            return new SqlParameter(ParamName, (SqlDbType)DbType);
        }
        /// <summary>
        /// 创建DbParameter对象
        /// </summary>
        /// <param name="ParamName">对象名称</param>
        /// <param name="DbType">类型</param>
        /// <param name="Direction">获取或设置一个值，该值指示参数是只可输入、只可输出、双向还是存储过程返回值参数。</param>
        /// <param name="Size">大于0为字符串，小于0为数值</param>
        /// <returns>DbParameter对象</returns>
        public DbParameter MakeParam(string ParamName, DbType DbType, ParameterDirection Direction, int Size)
        {
            SqlParameter parameter;
            if (Size > 0)
            {
                parameter = new SqlParameter(ParamName, (SqlDbType)DbType, Size);
            }
            else
            {
                parameter = new SqlParameter(ParamName, (SqlDbType)DbType);
            }
            parameter.Direction = Direction;
            return parameter;
        }




        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;
            }
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parameter in cmdParms)
                {
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #region 写入log4net日志
        /// <summary>
        /// 写入log4net日志
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="DBName"></param>
        /// <param name="time"></param>
        /// <param name="etime"></param>
        private static void SqlLog(string sql, string DBName, int time, TimeSpan etime)
        {
            if (GlobalConfig.GetAppConfig("DbLog", "appSettings").IndexOf(",SqlLog,") > -1)
            {
                FileLog.log.Info("DataBase:" + DBName + "\r\nSetTime:" + time.ToString() + "\r\nExecuteTime:" + etime.ToString() + "\r\nSql:" + sql);
            }
        }
        #endregion
    }
}
