using System;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;
using System.IO;
using System.Data;
using System.Collections;
using System.Web;
using System.Net;
using System.Web.UI;
using System.Drawing;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Configuration;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using TL.Common;

namespace TL.Common
{
    public class Utils
    {
        public static string DateStringFromNow(object dateObj)
        {
            try
            {
                return DateStringFromNow(Convert.ToDateTime(dateObj.ToString()));
            }
            catch
            {
                return "";
            }
        }
        public static string DateStringFromNow(string dateString)
        {
            try
            {
                return DateStringFromNow(Convert.ToDateTime(dateString));
            }
            catch
            {
                return "";
            }
        }
        public static string DateStringFromNow(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.TotalDays > 60)
            {
                return dt.ToShortDateString();
            }
            else
                if (span.TotalDays > 30)
                {
                    return "1个月前";
                }
                else
                    if (span.TotalDays > 14)
                    {
                        return "2周前";
                    }
                    else
                        if (span.TotalDays > 7)
                        {
                            return "1周前";
                        }
                        else
                            if (span.TotalDays > 1)
                            {
                                return string.Format("{0}天前", (int)Math.Floor(span.TotalDays));
                            }
                            else
                                if (span.TotalHours > 1)
                                {
                                    return string.Format("{0}小时前", (int)Math.Floor(span.TotalHours));
                                }
                                else
                                    if (span.TotalMinutes > 1)
                                    {
                                        return string.Format("{0}分钟前", (int)Math.Floor(span.TotalMinutes));
                                    }
                                    else
                                        if (span.TotalSeconds >= 1)
                                        {
                                            return string.Format("{0}秒前", (int)Math.Floor(span.TotalSeconds));
                                        }
                                        else
                                        {
                                            return "1秒前";
                                        }
        }
        // Fields
        public const string ASSEMBLY_VERSION = "3.0.0";
        private static FileVersionInfo AssemblyFileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
        private static Regex RegexBr = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);
        public static Regex RegexFont = new Regex("<font color=\".*?\">([\\s\\S]+?)</font>", GetRegexCompiledOptions());
        private static string TemplateCookieName = string.Format("dnttemplateid_{0}_{1}_{2}", AssemblyFileVersion.FileMajorPart, AssemblyFileVersion.FileMinorPart, AssemblyFileVersion.FileBuildPart);

        // Methods
        public static string AdDeTime(int times)
        {
            return DateTime.Now.AddMinutes((double)times).ToString();
        }

        /// 将现有的文件覆盖到新的文件
        public static bool BackupFile(string sourceFileName, string destFileName)
        {
            return BackupFile(sourceFileName, destFileName, true);
        }

        public static bool BackupFile(string sourceFileName, string destFileName, bool overwrite)
        {
            bool flag;
            if (!File.Exists(sourceFileName))
            {
                throw new FileNotFoundException(sourceFileName + "文件不存在！");
            }
            if (!overwrite && File.Exists(destFileName))
            {
                return false;
            }
            try
            {
                File.Copy(sourceFileName, destFileName, true);
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public static bool CheckColorValue(string color)
        {
            if (StrIsNullOrEmpty(color))
            {
                return false;
            }
            color = color.Trim().Trim(new char[] { '#' });
            if ((color.Length != 3) && (color.Length != 6))
            {
                return false;
            }
            return !Regex.IsMatch(color, "[^0-9a-f]", RegexOptions.IgnoreCase);
        }

        public static string ChkSQL(string str)
        {
            if (str != null)
            {
                return str.Replace("'", "''");
            }
            return "";
        }

        public static string CleanInput(string strIn)
        {
            return Regex.Replace(strIn.Trim(), @"[^\w\.@-]", "");
        }

        public static string ClearBR(string str)
        {
            Match match = null;
            for (match = RegexBr.Match(str); match.Success; match = match.NextMatch())
            {
                str = str.Replace(match.Groups[0].ToString(), "");
            }
            return str;
        }
        /// <summary>
        /// 去掉字符串的最后一个字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ClearLastChar(string str)
        {
            if (!(str == ""))
            {
                return str.Substring(0, str.Length - 1);
            }
            return "";
        }

        public static string ClearUBB(string sDetail)
        {
            return Regex.Replace(sDetail, @"\[[^\]]*?\]", string.Empty, RegexOptions.IgnoreCase);
        }

        public static string ConvertSimpleFileName(string fullname, string repstring, int leftnum, int rightnum, int charnum)
        {
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string fileExtName = GetFileExtName(fullname); //获取文件名的类型
            if (StrIsNullOrEmpty(fileExtName))
            {
                throw new Exception("字符串不含有扩展名信息");
            }
            int num = 0;
            int length = 0;
            length = fullname.LastIndexOf('.');
            str4 = fullname.Substring(0, length);
            num = str4.Length;
            if (length <= charnum)
            {
                return fullname;
            }
            str2 = str4.Substring(0, leftnum);
            str3 = str4.Substring(num - rightnum, rightnum);
            if ((repstring == "") || (repstring == null))
            {
                return (str2 + str3 + "." + fileExtName);
            }
            return (str2 + repstring + str3 + "." + fileExtName);
        }

        public static double ConvertToUnixTimestamp(DateTime date)
        {
            DateTime time = new DateTime(0x7b2, 1, 1, 0, 0, 0, 0);
            TimeSpan span = (TimeSpan)(date - time);
            return Math.Floor(span.TotalSeconds);
        }

        public static bool CreateDir(string name)
        {
            return MakeSureDirectoryPathExists(name);
        }

        public static string CutString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }
        /// <summary>
        /// 切割字符串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)    //开始索引坐标
            {
                if (length < 0)     //字符串长度
                {
                    length *= -1;
                    if ((startIndex - length) < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex -= length;
                    }
                }
                if (startIndex > str.Length)
                {
                    return "";
                }
            }
            else if ((length >= 0) && ((length + startIndex) > 0))
            {
                length += startIndex;
                startIndex = 0;
            }
            else
            {
                return "";
            }
            if ((str.Length - startIndex) < length)
            {
                length = str.Length - startIndex;
            }
            return str.Substring(startIndex, length);
        }

        /// <summary>
        /// DataTableToJson
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dt_dispose"></param>
        /// <returns></returns>
        public static StringBuilder DataTableToJson(DataTable dt, bool dt_dispose)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("[\r\n");
            string[] strArray = new string[dt.Columns.Count];
            int index = 0;
            string format = "{{";
            string str2 = "";
            DbType[] dbArray = new DbType[dt.Columns.Count];
            foreach (DataColumn column in dt.Columns)
            {
                strArray[index] = column.Caption.ToLower().Trim();
                format = format + "\"" + column.Caption.ToLower().Trim() + "\":";
                str2 = column.DataType.ToString().Trim().ToLower();
                if (((str2.IndexOf("int") > 0) || (str2.IndexOf("deci") > 0)) || (((str2.IndexOf("floa") > 0) || (str2.IndexOf("doub") > 0)) || (str2.IndexOf("bool") > 0)))
                {
                    object obj2 = format;
                    format = string.Concat(new object[] { obj2, "{", index, "}" });
                    dbArray[index] = DbType.Int32;
                }
                else if ((str2.IndexOf("string") > 0))
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                    dbArray[index] = DbType.String;
                }
                else if ((str2.IndexOf("datetime") > 0))
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                    dbArray[index] = DbType.DateTime;
                }

                else
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                }
                format = format + ",";
                index++;
            }
            if (format.EndsWith(","))
            {
                format = format.Substring(0, format.Length - 1);
            }
            format = format + "}},";
            index = 0;
            object[] args = new object[strArray.Length];
            #region
            foreach (DataRow row in dt.Rows)
            {
                string[] strArray2 = strArray;
                for (int i = 0; i < strArray2.Length; i++)
                {
                    string text1 = strArray2[i];

                    args[index] = row[strArray[index]].ToString().Trim().Replace(@"\", @"\\").Replace("'", @"\'");
                    string str3 = args[index].ToString();
                    switch (dbArray[i])
                    {
                        case DbType.DateTime:
                            if (str3 == "")
                                args[index] = "1990-01-01";
                            else
                            {
                                DateTime date = new DateTime();
                                if (DateTime.TryParse(str3, out date))
                                    args[index] = date.ToString("yyyy-MM-dd");
                                else
                                    args[index] = "1990-01-01";
                            }
                            goto Label_0266;
                        case DbType.Int32:
                            if (str3 == "")
                                args[index] = 0;
                            goto Label_0266;
                        case DbType.String:
                            if (str3 == "")
                                args[index] = "";
                            goto Label_0266;
                        default:
                            goto Label_0266;
                    }
                Label_0266:
                    index++;
                }
                index = 0;
                builder.Append(string.Format(format, args));
            }
            if (builder.ToString().EndsWith(","))
            {
                builder.Remove(builder.Length - 1, 1);
            }
            if (dt_dispose)
            {
                dt.Dispose();
            }
            return builder.Append("\r\n]");
            #endregion
        }
        /// <summary>
        /// 遍历获取类的属性及属性的值：
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string getProperties<T>(T t)
        {
            string tStr = string.Empty;
            if (t == null)
            {
                return tStr;
            }
            StringBuilder builder = new StringBuilder("");
            foreach (System.Reflection.PropertyInfo p in t.GetType().GetProperties())
            {
                builder.Append(p.Name + ":" + p.PropertyType + ",");
            }
            if (builder.Length > 0)
            {
                string str = builder.ToString();
                tStr = Utils.GetCutString(str, str.Length - 1);
                return tStr;
            }

            System.Reflection.PropertyInfo[] properties = t.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            if (properties.Length <= 0)
            {
                return tStr;
            }
            foreach (System.Reflection.PropertyInfo item in properties)
            {
                string name = item.Name;
                object value = item.GetValue(t, null);
                if (item.PropertyType.IsValueType || item.PropertyType.Name.StartsWith("String"))
                {
                    tStr += string.Format("{0}:{1},", name, value);
                }
                else
                {
                    getProperties(value);
                }
            }
            return tStr;
        }


        /// <summary>
        /// DataViewToJson
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dt_dispose"></param>
        /// <returns></returns>
        public static StringBuilder DataViewToJson(DataView dv, bool dt_dispose)
        {
            DataTable dt = dv.ToTable();
            StringBuilder builder = new StringBuilder();
            builder.Append("{\"total\":" + dv.Count + ",\"rows\":[\r\n");
            string[] strArray = new string[dt.Columns.Count];
            int index = 0;
            string format = "{{";
            string str2 = "";
            DbType[] dbArray = new DbType[dt.Columns.Count];
            foreach (DataColumn column in dt.Columns)
            {
                strArray[index] = column.Caption.ToLower().Trim();
                format = format + "\"" + column.Caption.ToLower().Trim() + "\":";
                str2 = column.DataType.ToString().Trim().ToLower();
                if (((str2.IndexOf("int") > 0) || (str2.IndexOf("deci") > 0)) || (((str2.IndexOf("floa") > 0) || (str2.IndexOf("doub") > 0)) || (str2.IndexOf("bool") > 0)))
                {
                    object obj2 = format;
                    format = string.Concat(new object[] { obj2, "{", index, "}" });
                    dbArray[index] = DbType.Int32;
                }
                else if ((str2.IndexOf("string") > 0))
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                    dbArray[index] = DbType.String;
                }
                else if ((str2.IndexOf("datetime") > 0))
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                    dbArray[index] = DbType.DateTime;
                }

                else
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                }
                format = format + ",";
                index++;
            }
            if (format.EndsWith(","))
            {
                format = format.Substring(0, format.Length - 1);
            }
            format = format + "}},";
            index = 0;
            object[] args = new object[strArray.Length];
            #region
            foreach (DataRow row in dt.Rows)
            {
                string[] strArray2 = strArray;
                for (int i = 0; i < strArray2.Length; i++)
                {
                    string text1 = strArray2[i];

                    args[index] = row[strArray[index]].ToString().Trim().Replace(@"\", @"\\").Replace("'", @"\'");
                    string str3 = args[index].ToString();
                    switch (dbArray[i])
                    {
                        case DbType.DateTime:
                            if (str3 == "")
                                args[index] = "1990-01-01";
                            else
                            {
                                DateTime date = new DateTime();
                                if (DateTime.TryParse(str3, out date))
                                    args[index] = date.ToString("yyyy-MM-dd");
                                else
                                    args[index] = "1990-01-01";
                            }
                            goto Label_0266;
                        case DbType.Int32:
                            if (str3 == "")
                                args[index] = 0;
                            goto Label_0266;
                        case DbType.String:
                            if (str3 == "")
                                args[index] = "";
                            goto Label_0266;
                        default:
                            goto Label_0266;
                    }
                Label_0266:
                    index++;
                }
                index = 0;
                builder.Append(string.Format(format, args));
            }
            if (builder.ToString().EndsWith(","))
            {
                builder.Remove(builder.Length - 1, 1);
            }
            if (dt_dispose)
            {
                dt.Dispose();
            }
            return builder.Append("\r\n]}");
            #endregion
        }
        /// <summary>
        /// DataViewToJson
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dt_dispose"></param>
        /// <returns></returns>
        public static StringBuilder DataViewToJson(DataView dv)
        {
            bool dt_dispose = true;
            DataTable dt = dv.ToTable();
            StringBuilder builder = new StringBuilder();
            builder.Append("[");
            string[] strArray = new string[dt.Columns.Count];
            int index = 0;
            string format = "{{";
            string str2 = "";
            DbType[] dbArray = new DbType[dt.Columns.Count];
            foreach (DataColumn column in dt.Columns)
            {
                strArray[index] = column.Caption.ToLower().Trim();
                format = format + "\"" + column.Caption.ToLower().Trim() + "\":";
                str2 = column.DataType.ToString().Trim().ToLower();
                if (((str2.IndexOf("int") > 0) || (str2.IndexOf("deci") > 0)) || (((str2.IndexOf("floa") > 0) || (str2.IndexOf("doub") > 0)) || (str2.IndexOf("bool") > 0)))
                {
                    object obj2 = format;
                    format = string.Concat(new object[] { obj2, "{", index, "}" });
                    dbArray[index] = DbType.Int32;
                }
                else if ((str2.IndexOf("string") > 0))
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                    dbArray[index] = DbType.String;
                }
                else if ((str2.IndexOf("datetime") > 0))
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                    dbArray[index] = DbType.DateTime;
                }

                else
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                }
                format = format + ",";
                index++;
            }
            if (format.EndsWith(","))
            {
                format = format.Substring(0, format.Length - 1);
            }
            format = format + "}},";
            index = 0;
            object[] args = new object[strArray.Length];
            #region
            foreach (DataRow row in dt.Rows)
            {
                string[] strArray2 = strArray;
                for (int i = 0; i < strArray2.Length; i++)
                {
                    string text1 = strArray2[i];

                    args[index] = row[strArray[index]].ToString().Trim().Replace(@"\", @"\\").Replace("'", @"\'");

                    //如果是密码需要解密显示
                    if (strArray[index] == "password")
                        args[index] = Common.AES.Decode(row[strArray[index]].ToString().Trim().Replace(@"\", @"\\").Replace("'", @"\'").Replace("\t", " "), "YomiFrameWorkKey");
                    //如果是密码需要解密显示

                    string str3 = args[index].ToString();
                    switch (dbArray[i])
                    {
                        case DbType.DateTime:
                            if (str3 == "")
                                args[index] = "1990-01-01";
                            else
                            {
                                DateTime date = new DateTime();
                                if (DateTime.TryParse(str3, out date))
                                    args[index] = date.ToString("yyyy-MM-dd");
                                else
                                    args[index] = "1990-01-01";
                            }
                            goto Label_0266;
                        case DbType.Int32:
                            if (str3 == "")
                                args[index] = 0;
                            goto Label_0266;
                        case DbType.String:
                            if (str3 == "")
                                args[index] = "";
                            goto Label_0266;
                        default:
                            goto Label_0266;
                    }
                Label_0266:
                    index++;
                }
                index = 0;
                builder.Append(string.Format(format, args));
            }
            if (builder.ToString().EndsWith(","))
            {
                builder.Remove(builder.Length - 1, 1);
            }
            if (dt_dispose)
            {
                dt.Dispose();
            }
            return builder.Append("]");
            #endregion
        }
        /// <summary>
        /// DataViewToJsonByPage tanliang 2013-1-16
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dt_dispose"></param>
        /// <returns></returns>
        public static StringBuilder DataViewToJson(DataView dv, bool dt_dispose, int sum_count)
        {
            DataTable dt = dv.ToTable();
            StringBuilder builder = new StringBuilder();
            builder.Append("{\"total\":" + sum_count + ",\"rows\":[\r\n");
            string[] strArray = new string[dt.Columns.Count];
            int index = 0;
            string format = "{{";
            string str2 = "";
            DbType[] dbArray = new DbType[dt.Columns.Count];
            foreach (DataColumn column in dt.Columns)
            {
                strArray[index] = column.Caption.ToLower().Trim();
                format = format + "\"" + column.Caption.ToLower().Trim() + "\":";
                str2 = column.DataType.ToString().Trim().ToLower();
                if (((str2.IndexOf("int") > 0) || (str2.IndexOf("deci") > 0)) || (((str2.IndexOf("floa") > 0) || (str2.IndexOf("doub") > 0)) || (str2.IndexOf("bool") > 0)))
                {
                    object obj2 = format;
                    format = string.Concat(new object[] { obj2, "{", index, "}" });
                    dbArray[index] = DbType.Int32;
                }
                else if ((str2.IndexOf("string") > 0))
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                    dbArray[index] = DbType.String;
                }
                else if ((str2.IndexOf("datetime") > 0))
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                    dbArray[index] = DbType.DateTime;
                }

                else
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                }
                format = format + ",";
                index++;
            }
            if (format.EndsWith(","))
            {
                format = format.Substring(0, format.Length - 1);
            }
            format = format + "}},";
            index = 0;
            object[] args = new object[strArray.Length];
            #region
            foreach (DataRow row in dt.Rows)
            {
                string[] strArray2 = strArray;
                for (int i = 0; i < strArray2.Length; i++)
                {
                    string text1 = strArray2[i];
                    args[index] = row[strArray[index]].ToString().Trim().Replace(@"\", @"\\").Replace("'", @"\'").Replace("\t", " ").Replace("\r\n", "<br>");

                    //如果是密码需要解密显示
                    if (strArray[index] == "password")
                        args[index] = Common.AES.Decode(row[strArray[index]].ToString().Trim().Replace(@"\", @"\\").Replace("'", @"\'").Replace("\t", " "), "YomiFrameWorkKey");
                    //如果是密码需要解密显示

                    string str3 = args[index].ToString();
                    switch (dbArray[i])
                    {
                        case DbType.DateTime:
                            if (str3 == "")
                                args[index] = "1990-01-01 00:00:00";
                            else
                            {
                                DateTime date = new DateTime();
                                if (DateTime.TryParse(str3, out date))
                                    args[index] = date.ToString("yyyy-MM-dd HH:mm:ss");
                                else
                                    args[index] = "1990-01-01 00:00:00";
                            }
                            goto Label_0266;
                        case DbType.Int32:
                            if (str3 == "")
                                args[index] = 0;
                            goto Label_0266;
                        case DbType.String:
                            if (str3 == "")
                                args[index] = "";
                            goto Label_0266;
                        default:
                            goto Label_0266;
                    }
                Label_0266:
                    index++;
                }
                index = 0;
                builder.Append(string.Format(format, args));
            }
            if (builder.ToString().EndsWith(","))
            {
                builder.Remove(builder.Length - 1, 1);
            }
            if (dt_dispose)
            {
                dt.Dispose();
            }
            return builder.Append("\r\n]}");
            #endregion
        }
        public static StringBuilder DataViewToJson_JZ(int pageid,DataView dv, bool dt_dispose, int sum_count)
        {
            DataTable dt = dv.ToTable();
            StringBuilder builder = new StringBuilder();
            builder.Append("{\"rs\": 1,");
            builder.Append("\"data\": {");
            builder.Append("\"pageInfo\": ");
            builder.Append("{\"totalNum\":" + sum_count + ",\"pageNum\":" + pageid + ",\"pageSize\":" + dt.Rows.Count + ",\"resultList\":[\r\n");
            string[] strArray = new string[dt.Columns.Count];
            int index = 0;
            string format = "{{";
            string str2 = "";
            DbType[] dbArray = new DbType[dt.Columns.Count];
            foreach (DataColumn column in dt.Columns)
            {
                strArray[index] = column.Caption.ToLower().Trim();
                format = format + "\"" + column.Caption.ToLower().Trim() + "\":";
                str2 = column.DataType.ToString().Trim().ToLower();
                if (((str2.IndexOf("int") > 0) || (str2.IndexOf("deci") > 0)) || (((str2.IndexOf("floa") > 0) || (str2.IndexOf("doub") > 0)) || (str2.IndexOf("bool") > 0)))
                {
                    object obj2 = format;
                    format = string.Concat(new object[] { obj2, "{", index, "}" });
                    dbArray[index] = DbType.Int32;
                }
                else if ((str2.IndexOf("string") > 0))
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                    dbArray[index] = DbType.String;
                }
                else if ((str2.IndexOf("datetime") > 0))
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                    dbArray[index] = DbType.DateTime;
                }

                else
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                }
                format = format + ",";
                index++;
            }
            if (format.EndsWith(","))
            {
                format = format.Substring(0, format.Length - 1);
            }
            format = format + "}},";
            index = 0;
            object[] args = new object[strArray.Length];
            #region
            foreach (DataRow row in dt.Rows)
            {
                string[] strArray2 = strArray;
                for (int i = 0; i < strArray2.Length; i++)
                {
                    string text1 = strArray2[i];
                    args[index] = row[strArray[index]].ToString().Trim().Replace(@"\", @"\\").Replace("'", @"\'").Replace("\t", " ").Replace("\r\n", "<br>");

                    //如果是密码需要解密显示
                    if (strArray[index] == "password")
                        args[index] = Common.AES.Decode(row[strArray[index]].ToString().Trim().Replace(@"\", @"\\").Replace("'", @"\'").Replace("\t", " "), "YomiFrameWorkKey");
                    //如果是密码需要解密显示

                    string str3 = args[index].ToString();
                    switch (dbArray[i])
                    {
                        case DbType.DateTime:
                            if (str3 == "")
                                args[index] = "1990-01-01 00:00:00";
                            else
                            {
                                DateTime date = new DateTime();
                                if (DateTime.TryParse(str3, out date))
                                    args[index] = date.ToString("yyyy-MM-dd HH:mm:ss");
                                else
                                    args[index] = "1990-01-01 00:00:00";
                            }
                            goto Label_0266;
                        case DbType.Int32:
                            if (str3 == "")
                                args[index] = 0;
                            goto Label_0266;
                        case DbType.String:
                            if (str3 == "")
                                args[index] = "";
                            goto Label_0266;
                        default:
                            goto Label_0266;
                    }
                Label_0266:
                    index++;
                }
                index = 0;
                builder.Append(string.Format(format, args));
            }
            if (builder.ToString().EndsWith(","))
            {
                builder.Remove(builder.Length - 1, 1);
            }
            if (dt_dispose)
            {
                dt.Dispose();
            }
            return builder.Append("\r\n]}}}");
            #endregion
        }
        /// <summary>
        /// DataViewToJsonByPage tanliang 2013-1-16
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dt_dispose"></param>
        /// <returns></returns>
        public static StringBuilder DataViewToJson(DataView dv, bool dt_dispose, int sum_count, bool istime)
        {
            DataTable dt = dv.ToTable();
            StringBuilder builder = new StringBuilder();
            builder.Append("{\"total\":" + sum_count + ",\"rows\":[\r\n");
            string[] strArray = new string[dt.Columns.Count];
            int index = 0;
            string format = "{{";
            string str2 = "";
            DbType[] dbArray = new DbType[dt.Columns.Count];
            foreach (DataColumn column in dt.Columns)
            {
                strArray[index] = column.Caption.ToLower().Trim();
                format = format + "\"" + column.Caption.ToLower().Trim() + "\":";
                str2 = column.DataType.ToString().Trim().ToLower();
                if (((str2.IndexOf("int") > 0) || (str2.IndexOf("deci") > 0)) || (((str2.IndexOf("floa") > 0) || (str2.IndexOf("doub") > 0)) || (str2.IndexOf("bool") > 0)))
                {
                    object obj2 = format;
                    format = string.Concat(new object[] { obj2, "{", index, "}" });
                    dbArray[index] = DbType.Int32;
                }
                else if ((str2.IndexOf("string") > 0))
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                    dbArray[index] = DbType.String;
                }
                else if ((str2.IndexOf("datetime") > 0))
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                    dbArray[index] = DbType.DateTime;
                }

                else
                {
                    object obj3 = format;
                    format = string.Concat(new object[] { obj3, "\"{", index, "}\"" });
                }
                format = format + ",";
                index++;
            }
            if (format.EndsWith(","))
            {
                format = format.Substring(0, format.Length - 1);
            }
            format = format + "}},";
            index = 0;
            object[] args = new object[strArray.Length];
            #region
            foreach (DataRow row in dt.Rows)
            {
                string[] strArray2 = strArray;
                for (int i = 0; i < strArray2.Length; i++)
                {
                    string text1 = strArray2[i];

                    args[index] = row[strArray[index]].ToString().Trim().Replace(@"\", @"\\").Replace("'", @"\'").Replace("\t", " ");
                    string str3 = args[index].ToString();
                    switch (dbArray[i])
                    {
                        case DbType.DateTime:
                            if (!istime)
                            {
                                if (str3 == "")
                                    args[index] = "1990-01-01";
                                else
                                {
                                    DateTime date = new DateTime();
                                    if (DateTime.TryParse(str3, out date))
                                        args[index] = date.ToString("yyyy-MM-dd");
                                    else
                                        args[index] = "1990-01-01";
                                }
                            }
                            else
                            {
                                if (str3 == "")
                                    args[index] = "1990-01-01 00:00:00";
                                else
                                {
                                    DateTime date = new DateTime();
                                    if (DateTime.TryParse(str3, out date))
                                        args[index] = date.ToString("yyyy-MM-dd HH:mm:ss");
                                    else
                                        args[index] = "1990-01-01 00:00:00";
                                }
                            }
                            goto Label_0266;
                        case DbType.Int32:
                            if (str3 == "")
                                args[index] = 0;
                            goto Label_0266;
                        case DbType.String:
                            if (str3 == "")
                                args[index] = "";
                            goto Label_0266;
                        default:
                            goto Label_0266;
                    }
                Label_0266:
                    index++;
                }
                index = 0;
                builder.Append(string.Format(format, args));
            }
            if (builder.ToString().EndsWith(","))
            {
                builder.Remove(builder.Length - 1, 1);
            }
            if (dt_dispose)
            {
                dt.Dispose();
            }
            return builder.Append("\r\n]}");
            #endregion
        }
        public static StringBuilder ArrayToJson<T>(T[] t, bool dt_dispose)
        {

            StringBuilder builder = new StringBuilder();
            string strModelProperties = "";             //model 属性名称+类型
            DbType[] dbArray = null;                    //字段类型
            string[] strArray = null;                    //model 属性名称集合
            int index = 0;
            string format = "{{";                       //模板
            string str2 = "";
            if (t.Length > 0)
            {
                strModelProperties = getProperties(t[0]);
                string[] strs = strModelProperties.Split(new char[] { ':', ',' });
                dbArray = new DbType[strs.Length / 2];
                strArray = new string[strs.Length / 2];
                for (int i = 0; i < strArray.Length; i++)
                {
                    strArray[i] = strs[i * 2];
                    format = format + "\"" + strs[i * 2] + "\":";
                    str2 = strs[((i + 1) * 2 - 1)].ToString().Trim().ToLower();
                    if (((str2.IndexOf("int") > 0) || (str2.IndexOf("deci") > 0)) || (((str2.IndexOf("floa") > 0) || (str2.IndexOf("doub") > 0)) || (str2.IndexOf("bool") > 0)))
                    {
                        object obj2 = format;
                        format = string.Concat(new object[] { obj2, "{", i, "}" });
                        dbArray[i] = DbType.Int32;
                    }
                    else if ((str2.IndexOf("string") > 0))
                    {
                        object obj3 = format;
                        format = string.Concat(new object[] { obj3, "\"{", i, "}\"" });
                        dbArray[i] = DbType.String;
                    }
                    else if ((str2.IndexOf("datetime") > 0))
                    {
                        object obj3 = format;
                        format = string.Concat(new object[] { obj3, "\"{", i, "}\"" });
                        dbArray[i] = DbType.DateTime;
                    }

                    else
                    {
                        object obj3 = format;
                        format = string.Concat(new object[] { obj3, "\"{", i, "}\"" });
                    }
                    format = format + ",";
                }
                if (format.EndsWith(","))
                {
                    format = format.Substring(0, format.Length - 1);
                }
                format = format + "}},";
                index = 0;
                object[] args = new object[strArray.Length];
                for (int i = 0; i < t.Length; i++)
                {

                    string[] strArray2 = strArray;
                    for (int j = 0; j < strArray2.Length; j++)
                    {
                        string text1 = strArray2[i];
                        Convert.ChangeType(t[j], typeof(T));

                        args[index] = t[i];// row[strArray[index]].ToString().Trim().Replace(@"\", @"\\").Replace("'", @"\'");
                        string str3 = args[index].ToString();
                        switch (dbArray[i])
                        {
                            case DbType.DateTime:
                                if (str3 == "")
                                    args[index] = "1990-01-01";
                                else
                                {
                                    DateTime date = new DateTime();
                                    if (DateTime.TryParse(str3, out date))
                                        args[index] = date.ToString("yyyy-MM-dd");
                                    args[index] = "1990-01-01";
                                }
                                goto Label_0266;
                            case DbType.Int32:
                                if (str3 == "")
                                    args[index] = 0;
                                goto Label_0266;
                            case DbType.String:
                                if (str3 == "")
                                    args[index] = "";
                                goto Label_0266;
                            default:
                                goto Label_0266;
                        }
                    Label_0266:
                        index++;
                    }
                    index = 0;
                    builder.Append(string.Format(format, args));

                    return builder.Append("\r\n]}");
                }
            }
            return builder.Append("\r\n]}");
        }

        public static StringBuilder DataTableToJSON(DataTable dt)
        {
            return DataTableToJson(dt, true);
        }

        public static string[] DistinctStringArray(string[] strArray)
        {
            return DistinctStringArray(strArray, 0);
        }

        public static string[] DistinctStringArray(string[] strArray, int maxElementLength)
        {
            Hashtable hashtable = new Hashtable();
            foreach (string str in strArray)
            {
                string str2 = str;
                if ((maxElementLength > 0) && (str2.Length > maxElementLength))
                {
                    str2 = str2.Substring(0, maxElementLength);
                }
                hashtable[str2.Trim()] = str;
            }
            string[] array = new string[hashtable.Count];
            hashtable.Keys.CopyTo(array, 0);
            return array;
        }

        public static string EncodeHtml(string strHtml)
        {
            if (strHtml != "")
            {
                strHtml = strHtml.Replace(",", "&def");
                strHtml = strHtml.Replace("'", "&dot");
                strHtml = strHtml.Replace(";", "&dec");
                return strHtml;
            }
            return "";
        }

        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }

        public static string[] FindNoUTF8File(string Path)
        {
            StringBuilder builder = new StringBuilder();
            FileInfo[] files = new DirectoryInfo(Path).GetFiles();
            for (int i = 0; i < files.Length; i++)
            {
                if (files[i].Extension.ToLower().Equals(".htm"))
                {
                    FileStream sbInputStream = new FileStream(files[i].FullName, FileMode.Open, FileAccess.Read);
                    bool flag = IsUTF8(sbInputStream);
                    sbInputStream.Close();
                    if (!flag)
                    {
                        builder.Append(files[i].FullName);
                        builder.Append("\r\n");
                    }
                }
            }
            return SplitString(builder.ToString(), "\r\n");
        }

        public static string FormatBytesStr(int bytes)
        {
            if (bytes > 0x40000000)
            {
                double num = bytes / 0x40000000;
                return (num.ToString("0") + "G");
            }
            if (bytes > 0x100000)
            {
                double num2 = bytes / 0x100000;
                return (num2.ToString("0") + "M");
            }
            if (bytes > 0x400)
            {
                double num3 = bytes / 0x400;
                return (num3.ToString("0") + "K");
            }
            return (bytes.ToString() + "Bytes");
        }

        public static string GetAjaxPageNumbers(int curPage, int countPage, string callback, int extendPage)
        {
            string str = "page";
            int num = 1;
            int num2 = 1;
            string str2 = "<a href=\"###\" onclick=\"" + string.Format(callback, "&" + str + "=1");
            string str3 = "<a href=\"###\" onclick=\"" + string.Format(callback, string.Concat(new object[] { "&", str, "=", countPage }));
            str2 = str2 + "\">&laquo;</a>";
            str3 = str3 + "\">&raquo;</a>";
            if (countPage < 1)
            {
                countPage = 1;
            }
            if (extendPage < 3)
            {
                extendPage = 2;
            }
            if (countPage > extendPage)
            {
                if ((curPage - (extendPage / 2)) > 0)
                {
                    if ((curPage + (extendPage / 2)) < countPage)
                    {
                        num = curPage - (extendPage / 2);
                        num2 = (num + extendPage) - 1;
                    }
                    else
                    {
                        num2 = countPage;
                        num = (num2 - extendPage) + 1;
                        str3 = "";
                    }
                }
                else
                {
                    num2 = extendPage;
                    str2 = "";
                }
            }
            else
            {
                num = 1;
                num2 = countPage;
                str2 = "";
                str3 = "";
            }
            StringBuilder builder = new StringBuilder("");
            builder.Append(str2);
            for (int i = num; i <= num2; i++)
            {
                if (i == curPage)
                {
                    builder.Append("<span>");
                    builder.Append(i);
                    builder.Append("</span>");
                }
                else
                {
                    builder.Append("<a href=\"###\" onclick=\"");
                    builder.Append(string.Format(callback, str + "=" + i));
                    builder.Append("\">");
                    builder.Append(i);
                    builder.Append("</a>");
                }
            }
            builder.Append(str3);
            return builder.ToString();
        }

        public static string GetAppConfig(string name, string type)
        {
            if (type.ToLower() == "connectionstrings")
                return ConfigurationManager.ConnectionStrings[name].ToString();
            if (type.ToLower() == "appsettings")
                return ConfigurationManager.AppSettings[name].ToString();
            return "";
        }

        public static string GetAssemblyCopyright()
        {
            return AssemblyFileVersion.LegalCopyright;
        }

        public static string GetAssemblyProductName()
        {
            return AssemblyFileVersion.ProductName;
        }

        public static string GetAssemblyVersion()
        {
            return string.Format("{0}.{1}.{2}", AssemblyFileVersion.FileMajorPart, AssemblyFileVersion.FileMinorPart, AssemblyFileVersion.FileBuildPart);
        }

        /// <summary>
        /// 获取cookis 信息
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public static string GetCookie(string strName)
        {
            if ((HttpContext.Current.Request.Cookies != null) && (HttpContext.Current.Request.Cookies[strName] != null))
            {
                return HttpContext.Current.Request.Cookies[strName].Value.ToString();
            }
            return "";
        }

        public static string GetCookie(string strName, string key)
        {
            if (((HttpContext.Current.Request.Cookies != null) && (HttpContext.Current.Request.Cookies[strName] != null)) && (HttpContext.Current.Request.Cookies[strName][key] != null))
            {
                return HttpContext.Current.Request.Cookies[strName][key].ToString();
            }
            return "";
        }

        public static string GetCutString(string str, int Length)
        {
            if (str.Length >= Length)
            {
                return CutString(str, 0, Length);
            }
            return str;
        }

        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public static string GetDate(string datetimestr, string replacestr)
        {
            if (datetimestr == null)
            {
                return replacestr;
            }
            if (datetimestr.Equals(""))
            {
                return replacestr;
            }
            try
            {
                datetimestr = Convert.ToDateTime(datetimestr).ToString("yyyy-MM-dd").Replace("1900-01-01", replacestr);
            }
            catch
            {
                return replacestr;
            }
            return datetimestr;
        }

        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetDateTime(int relativeday)
        {
            return DateTime.Now.AddDays((double)relativeday).ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetDateTimeF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        public static string GetEmailHostName(string strEmail)
        {
            if (strEmail.IndexOf("@") < 0)
            {
                return "";
            }
            return strEmail.Substring(strEmail.LastIndexOf("@")).ToLower();
        }

        /// <summary>
        /// 获取文件名的类型
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static string GetFileExtName(string fileName)
        {
            if (StrIsNullOrEmpty(fileName) || (fileName.IndexOf('.') <= 0))
            {
                return "";
            }
            fileName = fileName.ToLower().Trim();
            return fileName.Substring(fileName.LastIndexOf('.'), fileName.Length - fileName.LastIndexOf('.'));
        }

        public static string GetFilename(string url)
        {
            if (url == null)
            {
                return "";
            }
            string[] strArray = url.Split(new char[] { '/' });
            return strArray[strArray.Length - 1].Split(new char[] { '?' })[0];
        }

        public static string GetHttpWebResponse(string url)
        {
            return GetHttpWebResponse(url, string.Empty);
        }

        private static string GetHttpWebResponse(string url, string postData)
        {
            string str;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = postData.Length;
            request.Timeout = 0x4e20;
            HttpWebResponse response = null;
            try
            {
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(postData);
                if (writer != null)
                {
                    writer.Close();
                }
                response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                {
                    str = reader.ReadToEnd();
                }
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }
            return str;
        }

        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return GetInArrayID(strSearch, stringArray, true);
        }

        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                    {
                        return i;
                    }
                }
                else if (strSearch == stringArray[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public static string GetMapPath(string strPath)
        {
            if (HttpContext.Current != null)
            {
                return HttpContext.Current.Server.MapPath(strPath);
            }
            strPath = strPath.Replace("/", @"\");
            if (strPath.StartsWith(@"\"))
            {
                strPath = strPath.Substring(strPath.IndexOf('\\', 1)).TrimStart(new char[] { '\\' });
            }
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
        }

        public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage)
        {
            return GetPageNumbers(curPage, countPage, url, extendPage, "page");
        }

        public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage, string pagetag)
        {
            return GetPageNumbers(curPage, countPage, url, extendPage, pagetag, null);
        }

        public static string GetPageNumbers(int curPage, int countPage, string url, int extendPage, string pagetag, string anchor)
        {
            if (pagetag == "")
            {
                pagetag = "page";
            }
            int num = 1;
            int num2 = 1;
            if (url.IndexOf("?") > 0)
            {
                url = url + "&";
            }
            else
            {
                url = url + "?";
            }
            string str = "<a href=\"" + url + "&" + pagetag + "=1";
            string str2 = string.Concat(new object[] { "<a href=\"", url, "&", pagetag, "=", countPage });
            if (anchor != null)
            {
                str = str + anchor;
                str2 = str2 + anchor;
            }
            str = str + "\">&laquo;</a>";
            str2 = str2 + "\">&raquo;</a>";
            if (countPage < 1)
            {
                countPage = 1;
            }
            if (extendPage < 3)
            {
                extendPage = 2;
            }
            if (countPage > extendPage)
            {
                if ((curPage - (extendPage / 2)) > 0)
                {
                    if ((curPage + (extendPage / 2)) < countPage)
                    {
                        num = curPage - (extendPage / 2);
                        num2 = (num + extendPage) - 1;
                    }
                    else
                    {
                        num2 = countPage;
                        num = (num2 - extendPage) + 1;
                        str2 = "";
                    }
                }
                else
                {
                    num2 = extendPage;
                    str = "";
                }
            }
            else
            {
                num = 1;
                num2 = countPage;
                str = "";
                str2 = "";
            }
            StringBuilder builder = new StringBuilder("");
            builder.Append(str);
            for (int i = num; i <= num2; i++)
            {
                if (i == curPage)
                {
                    builder.Append("<span>");
                    builder.Append(i);
                    builder.Append("</span>");
                }
                else
                {
                    builder.Append("<a href=\"");
                    builder.Append(url);
                    builder.Append(pagetag);
                    builder.Append("=");
                    builder.Append(i);
                    if (anchor != null)
                    {
                        builder.Append(anchor);
                    }
                    builder.Append("\">");
                    builder.Append(i);
                    builder.Append("</a>");
                }
            }
            builder.Append(str2);
            return builder.ToString();
        }

        public static string GetPostPageNumbers(int countPage, string url, string expname, int extendPage)
        {
            int num = 1;
            int num2 = 1;
            int num3 = 1;
            string str = "<a href=\"" + url + "-1" + expname + "\">&laquo;</a>";
            string str2 = string.Concat(new object[] { "<a href=\"", url, "-", countPage, expname, "\">&raquo;</a>" });
            if (countPage < 1)
            {
                countPage = 1;
            }
            if (extendPage < 3)
            {
                extendPage = 2;
            }
            if (countPage > extendPage)
            {
                if ((num3 - (extendPage / 2)) > 0)
                {
                    if ((num3 + (extendPage / 2)) < countPage)
                    {
                        num = num3 - (extendPage / 2);
                        num2 = (num + extendPage) - 1;
                    }
                    else
                    {
                        num2 = countPage;
                        num = (num2 - extendPage) + 1;
                        str2 = "";
                    }
                }
                else
                {
                    num2 = extendPage;
                    str = "";
                }
            }
            else
            {
                num = 1;
                num2 = countPage;
                str = "";
                str2 = "";
            }
            StringBuilder builder = new StringBuilder("");
            builder.Append(str);
            for (int i = num; i <= num2; i++)
            {
                builder.Append("<a href=\"");
                builder.Append(url);
                builder.Append("-");
                builder.Append(i);
                builder.Append(expname);
                builder.Append("\">");
                builder.Append(i);
                builder.Append("</a>");
            }
            builder.Append(str2);
            return builder.ToString();
        }

        public static string GetRealIP()
        {
            return YJRequest.GetIP();
        }

        public static RegexOptions GetRegexCompiledOptions()
        {
            return RegexOptions.None;
        }

        public static string GetRootUrl(string forumPath)
        {
            int port = HttpContext.Current.Request.Url.Port;
            return string.Format("{0}://{1}{2}{3}", new object[] { HttpContext.Current.Request.Url.Scheme, HttpContext.Current.Request.Url.Host.ToString(), ((port == 80) || (port == 0)) ? "" : (":" + port), forumPath });
        }

        public static string GetSourceTextByUrl(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Timeout = 0x4e20;
            StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream());
            return reader.ReadToEnd();
        }

        public static string GetSpacesString(int spacesCount)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < spacesCount; i++)
            {
                builder.Append(" &nbsp;&nbsp;");
            }
            return builder.ToString();
        }

        public static string GetStandardDate(string fDate)
        {
            return GetStandardDateTime(fDate, "yyyy-MM-dd");
        }

        public static string GetStandardDateTime(string fDateTime)
        {
            return GetStandardDateTime(fDateTime, "yyyy-MM-dd HH:mm:ss");
        }

        public static string GetStandardDateTime(string fDateTime, string formatStr)
        {
            if (fDateTime == "0000-0-0 0:00:00")
            {
                return fDateTime;
            }
            DateTime result = new DateTime(0x76c, 1, 1, 0, 0, 0, 0);
            if (DateTime.TryParse(fDateTime, out result))
            {
                return result.ToString(formatStr);
            }
            return "N/A";
        }

        public static string GetStaticPageNumbers(int curPage, int countPage, string url, string expname, int extendPage)
        {
            return GetStaticPageNumbers(curPage, countPage, url, expname, extendPage, 0);
        }

        public static string GetStaticPageNumbers(int curPage, int countPage, string url, string expname, int extendPage, int forumrewrite)
        {
            int num = 1;
            int num2 = 1;
            string str = "<a href=\"" + url + "-1" + expname + "\">&laquo;</a>";
            string str2 = string.Concat(new object[] { "<a href=\"", url, "-", countPage, expname, "\">&raquo;</a>" });
            if (forumrewrite == 1)
            {
                str = "<a href=\"" + url + "/1/list" + expname + "\">&laquo;</a>";
                str2 = string.Concat(new object[] { "<a href=\"", url, "/", countPage, "/list", expname, "\">&raquo;</a>" });
            }
            if (forumrewrite == 2)
            {
                str = "<a href=\"" + url + "/\">&laquo;</a>";
                str2 = string.Concat(new object[] { "<a href=\"", url, "/", countPage, "/\">&raquo;</a>" });
            }
            if (countPage < 1)
            {
                countPage = 1;
            }
            if (extendPage < 3)
            {
                extendPage = 2;
            }
            if (countPage > extendPage)
            {
                if ((curPage - (extendPage / 2)) > 0)
                {
                    if ((curPage + (extendPage / 2)) < countPage)
                    {
                        num = curPage - (extendPage / 2);
                        num2 = (num + extendPage) - 1;
                    }
                    else
                    {
                        num2 = countPage;
                        num = (num2 - extendPage) + 1;
                        str2 = "";
                    }
                }
                else
                {
                    num2 = extendPage;
                    str = "";
                }
            }
            else
            {
                num = 1;
                num2 = countPage;
                str = "";
                str2 = "";
            }
            StringBuilder builder = new StringBuilder("");
            builder.Append(str);
            for (int i = num; i <= num2; i++)
            {
                if (i == curPage)
                {
                    builder.Append("<span>");
                    builder.Append(i);
                    builder.Append("</span>");
                }
                else
                {
                    builder.Append("<a href=\"");
                    if (forumrewrite == 1)
                    {
                        builder.Append(url);
                        if (i != 1)
                        {
                            builder.Append("/");
                            builder.Append(i);
                        }
                        builder.Append("/list");
                        builder.Append(expname);
                    }
                    else if (forumrewrite == 2)
                    {
                        builder.Append(url);
                        builder.Append("/");
                        if (i != 1)
                        {
                            builder.Append(i);
                            builder.Append("/");
                        }
                    }
                    else
                    {
                        builder.Append(url);
                        if (i != 1)
                        {
                            builder.Append("-");
                            builder.Append(i);
                        }
                        builder.Append(expname);
                    }
                    builder.Append("\">");
                    builder.Append(i);
                    builder.Append("</a>");
                }
            }
            builder.Append(str2);
            return builder.ToString();
        }

        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }

        public static string GetSubString(string p_SrcString, int p_Length, string p_TailString)
        {
            return GetSubString(p_SrcString, 0, p_Length, p_TailString);
        }

        public static string GetSubString(string p_SrcString, int p_StartIndex, int p_Length, string p_TailString)
        {
            string str = p_SrcString;
            byte[] bytes = Encoding.UTF8.GetBytes(p_SrcString);
            foreach (char ch in Encoding.UTF8.GetChars(bytes))
            {
                if (((ch > 'ࠀ') && (ch < '一')) || ((ch > 0xac00) && (ch < 0xd7a3)))
                {
                    if (p_StartIndex >= p_SrcString.Length)
                    {
                        return "";
                    }
                    return p_SrcString.Substring(p_StartIndex, ((p_Length + p_StartIndex) > p_SrcString.Length) ? (p_SrcString.Length - p_StartIndex) : p_Length);
                }
            }
            if (p_Length < 0)
            {
                return str;
            }
            byte[] sourceArray = Encoding.Default.GetBytes(p_SrcString);
            if (sourceArray.Length <= p_StartIndex)
            {
                return str;
            }
            int length = sourceArray.Length;
            if (sourceArray.Length > (p_StartIndex + p_Length))
            {
                length = p_Length + p_StartIndex;
            }
            else
            {
                p_Length = sourceArray.Length - p_StartIndex;
                p_TailString = "";
            }
            int num2 = p_Length;
            int[] numArray = new int[p_Length];
            byte[] destinationArray = null;
            int num3 = 0;
            for (int i = p_StartIndex; i < length; i++)
            {
                if (sourceArray[i] > 0x7f)
                {
                    num3++;
                    if (num3 == 3)
                    {
                        num3 = 1;
                    }
                }
                else
                {
                    num3 = 0;
                }
                numArray[i] = num3;
            }
            if ((sourceArray[length - 1] > 0x7f) && (numArray[p_Length - 1] == 1))
            {
                num2 = p_Length + 1;
            }
            destinationArray = new byte[num2];
            Array.Copy(sourceArray, p_StartIndex, destinationArray, 0, num2);
            return (Encoding.Default.GetString(destinationArray) + p_TailString);
        }

        public static string GetTemplateCookieName()
        {
            return TemplateCookieName;
        }

        public static string GetTextFromHTML(string HTML)
        {
            Regex regex = new Regex("</?(?!br|/?p|img)[^>]*>", RegexOptions.IgnoreCase);
            return regex.Replace(HTML, "");
        }

        /// <summary>
        /// 获取当前日期
        /// </summary>
        /// <returns></returns>
        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public static string GetTrueForumPath()
        {
            string path = HttpContext.Current.Request.Path;
            if (path.LastIndexOf("/") != path.IndexOf("/"))
            {
                return path.Substring(path.IndexOf("/"), path.LastIndexOf("/") + 1);
            }
            return "/";
        }

        public static string GetUnicodeSubString(string str, int len, string p_TailString)
        {
            string str2 = string.Empty;
            int byteCount = Encoding.Default.GetByteCount(str);
            int length = str.Length;
            int num3 = 0;
            int num4 = 0;
            if (byteCount <= len)
            {
                return str;
            }
            for (int i = 0; i < length; i++)
            {
                if (Convert.ToInt32(str.ToCharArray()[i]) > 0xff)
                {
                    num3 += 2;
                }
                else
                {
                    num3++;
                }
                if (num3 > len)
                {
                    num4 = i;
                    break;
                }
                if (num3 == len)
                {
                    num4 = i + 1;
                    break;
                }
            }
            if (num4 >= 0)
            {
                str2 = str.Substring(0, num4) + p_TailString;
            }
            return str2;
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="str">解码字符串</param>
        /// <returns></returns>
        public static string HtmlDecode(string str)
        {
            return HttpUtility.HtmlDecode(str);
        }

        /// <summary>
        /// 编码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlEncode(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }

        public static bool InArray(string str, string stringarray)
        {
            return InArray(str, SplitString(stringarray, ","), false);
        }

        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }

        public static bool InArray(string str, string stringarray, string strsplit)
        {
            return InArray(str, SplitString(stringarray, strsplit), false);
        }

        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return (GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0);
        }

        public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(str, SplitString(stringarray, strsplit), caseInsensetive);
        }

        public static bool InIPArray(string ip, string[] iparray)
        {
            string[] strArray = SplitString(ip, ".");
            for (int i = 0; i < iparray.Length; i++)
            {
                string[] strArray2 = SplitString(iparray[i], ".");
                int num2 = 0;
                for (int j = 0; j < strArray2.Length; j++)
                {
                    if (strArray2[j] == "*")
                    {
                        return true;
                    }
                    if ((strArray.Length <= j) || !(strArray2[j] == strArray[j]))
                    {
                        break;
                    }
                    num2++;
                }
                if (num2 == 4)
                {
                    return true;
                }
            }
            return false;
        }

        public static string IntToStr(int intValue)
        {
            return Convert.ToString(intValue);
        }

        public static bool IsAllowedExtension(HttpPostedFile hifile, string fe)
        {
            int contentLength = hifile.ContentLength;
            byte[] buffer = new byte[contentLength];
            hifile.InputStream.Read(buffer, 0, contentLength);
            MemoryStream input = new MemoryStream(buffer);
            BinaryReader reader = new BinaryReader(input);
            string str = "";
            try
            {
                str = reader.ReadByte().ToString();
                str = str + reader.ReadByte().ToString();
            }
            catch
            {
                return false;
            }
            reader.Close();
            input.Close();
            bool flag = false;
            string[] strArray = new string[] { "255216", "6677", "7173", "208207", "8297", "8075", "98109", "3780", "13780", "239187", "7790" };
            string[] strArray2 = new string[] { ".jpg", ".bmp", ".gif", ".xls,.doc,.ppt", ".rar", ".zip", ".txt", ".pdf", ".png", ".xoml", ".dll" };
            for (int i = 0; i < strArray.Length; i++)
            {
                if (str == strArray[i])
                {
                    string[] strArray3 = strArray2[i].Split(new char[] { ',' });
                    for (int j = 0; j < strArray3.Length; j++)
                    {
                        if (fe.IndexOf(strArray3[j].ToLower()) > -1)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
            }
            return flag;
        }

        public static bool IsBase64String(string str)
        {
            return Regex.IsMatch(str, @"[A-Za-z0-9\+\/\=]");
        }

        public static bool IsCompriseStr(string str, string stringarray, string strsplit)
        {
            if (!StrIsNullOrEmpty(stringarray))
            {
                str = str.ToLower();
                string[] strArray = SplitString(stringarray.ToLower(), strsplit);
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (str.IndexOf(strArray[i]) > -1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsDateString(string str)
        {
            return Regex.IsMatch(str, @"(\d{4})-(\d{1,2})-(\d{1,2})");
        }

        public static bool IsDouble(object Expression)
        {
            return Validator.IsDouble(Expression);
        }

        public static bool IsImgFilename(string filename)
        {
            filename = filename.Trim();
            if (filename.EndsWith(".") || (filename.IndexOf(".") == -1))
            {
                return false;
            }
            string str = filename.Substring(filename.LastIndexOf(".") + 1).ToLower();
            if ((!(str == "jpg") && !(str == "jpeg")) && (!(str == "png") && !(str == "bmp")))
            {
                return (str == "gif");
            }
            return true;
        }

        public static bool IsInt(string str)
        {
            return Regex.IsMatch(str, "^[0-9]*$");
        }

        public static bool IsIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        public static bool IsIPSect(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){2}((2[0-4]\d|25[0-5]|[01]?\d\d?|\*)\.)(2[0-4]\d|25[0-5]|[01]?\d\d?|\*)$");
        }

        public static bool IsNumeric(object Expression)
        {
            return Validator.IsNumeric(Expression);
        }

        public static bool IsNumericArray(string[] strNumber)
        {
            return Validator.IsNumericArray(strNumber);
        }

        public static bool IsNumericList(string numList)
        {
            if (StrIsNullOrEmpty(numList))
            {
                return false;
            }
            return IsNumericArray(numList.Split(new char[] { ',' }));
        }

        public static bool IsRuleTip(Hashtable NewHash, string ruletype, out string key)
        {
            key = "";
            foreach (DictionaryEntry entry in NewHash)
            {
                try
                {
                    foreach (string str in SplitString(entry.Value.ToString(), "\r\n"))
                    {
                        string str2;
                        if (!(str != "") || ((str2 = ruletype.Trim().ToLower()) == null))
                        {
                            goto Label_00F9;
                        }
                        if (!(str2 == "email"))
                        {
                            if (str2 == "ip")
                            {
                                goto Label_00AB;
                            }
                            if (str2 == "timesect")
                            {
                                goto Label_00BE;
                            }
                            goto Label_00F9;
                        }
                        if (IsValidDoEmail(str.ToString()))
                        {
                            goto Label_00F9;
                        }
                        throw new Exception();
                    Label_00AB:
                        if (IsIPSect(str.ToString()))
                        {
                            goto Label_00F9;
                        }
                        throw new Exception();
                    Label_00BE: ;
                        string[] strArray2 = str.Split(new char[] { '-' });
                        if (!IsTime(strArray2[1].ToString()) || !IsTime(strArray2[0].ToString()))
                        {
                            throw new Exception();
                        }
                    Label_00F9: ;
                    }
                    continue;
                }
                catch
                {
                    key = entry.Key.ToString();
                    return false;
                }
            }
            return true;
        }

        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        public static bool IsSafeUserInfoString(string str)
        {
            return !Regex.IsMatch(str, "^\\s*$|^c:\\\\con\\\\con$|[%,\\*\"\\s\\t\\<\\>\\&]|游客|^Guest");
        }

        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, "^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }

        public static bool IsURL(string strUrl)
        {
            return Regex.IsMatch(strUrl, @"^(http|https)\://([a-zA-Z0-9\.\-]+(\:[a-zA-Z0-9\.&%\$\-]+)*@)*((25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|([a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(\:[0-9]+)*(/($|[a-zA-Z0-9\.\,\?\'\\\+&%\$#\=~_\-]+))*$");
        }

        private static bool IsUTF8(FileStream sbInputStream)
        {
            bool flag = true;
            long length = sbInputStream.Length;
            byte num2 = 0;
            for (int i = 0; i < length; i++)
            {
                byte num3 = (byte)sbInputStream.ReadByte();
                if ((num3 & 0x80) != 0)
                {
                    flag = false;
                }
                if (num2 == 0)
                {
                    if (num3 >= 0x80)
                    {
                        do
                        {
                            num3 = (byte)(num3 << 1);
                            num2 = (byte)(num2 + 1);
                        }
                        while ((num3 & 0x80) != 0);
                        num2 = (byte)(num2 - 1);
                        if (num2 == 0)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if ((num3 & 0xc0) != 0x80)
                    {
                        return false;
                    }
                    num2 = (byte)(num2 - 1);
                }
            }
            if (num2 > 0)
            {
                return false;
            }
            if (flag)
            {
                return false;
            }
            return true;
        }

        public static bool IsValidDoEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool IsValidEmail(string strEmail)
        {
            return Regex.IsMatch(strEmail, @"^[\w\.]+([-]\w+)*@[A-Za-z0-9-_]+[\.][A-Za-z0-9-_]");
        }

        public static string JsonCharFilter(string sourceStr)
        {
            sourceStr = sourceStr.Replace(@"\", @"\\");
            sourceStr = sourceStr.Replace("\b", "\\\b");
            sourceStr = sourceStr.Replace("\t", "\\\t");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\n", "\\\n");
            sourceStr = sourceStr.Replace("\f", "\\\f");
            sourceStr = sourceStr.Replace("\r", "\\\r");
            return sourceStr.Replace("\"", "\\\"");
        }

        [DllImport("dbgHelp", SetLastError = true)]
        private static extern bool MakeSureDirectoryPathExists(string name);
        public static string mashSQL(string str)
        {
            if (str != null)
            {
                return str.Replace("'", "'");
            }
            return "";
        }

        public static string MD5(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            bytes = new MD5CryptoServiceProvider().ComputeHash(bytes);
            string str2 = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str2 = str2 + bytes[i].ToString("x").PadLeft(2, '0');
            }
            return str2;
        }

        public static string MergeString(string source, string target)
        {
            return MergeString(source, target, ",");
        }

        public static string MergeString(string source, string target, string mergechar)
        {
            if (StrIsNullOrEmpty(target))
            {
                target = source;
                return target;
            }
            target = target + mergechar + source;
            return target;
        }

        public static string[] PadStringArray(string[] strArray, int minLength, int maxLength)
        {
            if (minLength > maxLength)
            {
                int num = maxLength;
                maxLength = minLength;
                minLength = num;
            }
            int num2 = 0;
            for (int i = 0; i < strArray.Length; i++)
            {
                if ((minLength > -1) && (strArray[i].Length < minLength))
                {
                    strArray[i] = null;
                }
                else
                {
                    if (strArray[i].Length > maxLength)
                    {
                        strArray[i] = strArray[i].Substring(0, maxLength);
                    }
                    num2++;
                }
            }
            string[] strArray2 = new string[num2];
            int index = 0;
            int num5 = 0;
            while ((index < strArray.Length) && (num5 < strArray2.Length))
            {
                if ((strArray[index] != null) && (strArray[index] != string.Empty))
                {
                    strArray2[num5] = strArray[index];
                    num5++;
                }
                index++;
            }
            return strArray2;
        }

        public static string RemoveFontTag(string title)
        {
            Match match = RegexFont.Match(title);
            if (match.Success)
            {
                return match.Groups[1].Value;
            }
            return title;
        }

        public static string RemoveHtml(string content)
        {
            return Regex.Replace(content, "<[^>]*>", string.Empty, RegexOptions.IgnoreCase);
        }

        public static string RemoveUnsafeHtml(string content)
        {
            content = Regex.Replace(content, @"(\<|\s+)o([a-z]+\s?=)", "$1$2", RegexOptions.IgnoreCase);
            content = Regex.Replace(content, @"(script|frame|form|meta|behavior|style)([\s|:|>])+", "$1.$2", RegexOptions.IgnoreCase);
            return content;
        }

        public static string ReplaceString(string SourceString, string SearchString, string ReplaceString, bool IsCaseInsensetive)
        {
            return Regex.Replace(SourceString, Regex.Escape(SearchString), ReplaceString, IsCaseInsensetive ? RegexOptions.IgnoreCase : RegexOptions.None);
        }

        public static string ReplaceStrToScript(string str)
        {
            return str.Replace(@"\", @"\\").Replace("'", @"\'").Replace("\"", "\\\"");
        }

        public static void ResponseFile(string filepath, string filename, string filetype)
        {
            Stream stream = null;
            byte[] buffer = new byte[0x2710];
            try
            {
                stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                long length = stream.Length;
                HttpContext.Current.Response.ContentType = filetype;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + UrlEncode(filename.Trim()).Replace("+", " "));
                while (length > 0L)
                {
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        int count = stream.Read(buffer, 0, 0x2710);
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, count);
                        HttpContext.Current.Response.Flush();
                        buffer = new byte[0x2710];
                        length -= count;
                    }
                    else
                    {
                        length = -1L;
                    }
                }
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("Error : " + exception.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            HttpContext.Current.Response.End();
        }

        public static bool RestoreFile(string backupFileName, string targetFileName)
        {
            return RestoreFile(backupFileName, targetFileName, null);
        }

        public static bool RestoreFile(string backupFileName, string targetFileName, string backupTargetFileName)
        {
            try
            {
                if (!File.Exists(backupFileName))
                {
                    throw new FileNotFoundException(backupFileName + "文件不存在！");
                }
                if (backupTargetFileName != null)
                {
                    if (!File.Exists(targetFileName))
                    {
                        throw new FileNotFoundException(targetFileName + "文件不存在！无法备份此文件！");
                    }
                    File.Copy(targetFileName, backupTargetFileName, true);
                }
                File.Delete(targetFileName);
                File.Copy(backupFileName, targetFileName);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }

        public static string RTrim(string str)
        {
            for (int i = str.Length; i >= 0; i--)
            {
                char ch = str[i];
                if (!ch.Equals(" "))
                {
                    char ch2 = str[i];
                    if (!ch2.Equals("\r"))
                    {
                        char ch3 = str[i];
                        if (!ch3.Equals("\n"))
                        {
                            continue;
                        }
                    }
                }
                str.Remove(i, 1);
            }
            return str;
        }

        public static int SafeInt32(object objNum)
        {
            if (objNum == null)
            {
                return 0;
            }
            string expression = objNum.ToString();
            if (!IsNumeric(expression))
            {
                return 0;
            }
            if (expression.ToString().Length <= 9)
            {
                return int.Parse(expression);
            }
            if (expression.StartsWith("-"))
            {
                return -2147483648;
            }
            return 0x7fffffff;
        }

        public static string SBCCaseToNumberic(string SBCCase)
        {
            char[] chars = SBCCase.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(chars, i, 1);
                if ((bytes.Length == 2) && (bytes[1] == 0xff))
                {
                    bytes[0] = (byte)(bytes[0] + 0x20);
                    bytes[1] = 0;
                    chars[i] = Encoding.Unicode.GetChars(bytes)[0];
                }
            }
            return new string(chars);
        }

        public static string SHA256(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            SHA256Managed managed = new SHA256Managed();
            return Convert.ToBase64String(managed.ComputeHash(bytes));
        }

        public static string[] SplitString(string strContent, string strSplit)
        {
            if (StrIsNullOrEmpty(strContent))
            {
                return new string[0];
            }
            if (strContent.IndexOf(strSplit) < 0)
            {
                return new string[] { strContent };
            }
            return Regex.Split(strContent, Regex.Escape(strSplit), RegexOptions.IgnoreCase);
        }

        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem)
        {
            return SplitString(strContent, strSplit, ignoreRepeatItem, 0);
        }

        public static string[] SplitString(string strContent, string strSplit, int count)
        {
            string[] strArray = new string[count];
            string[] strArray2 = SplitString(strContent, strSplit);
            for (int i = 0; i < count; i++)
            {
                if (i < strArray2.Length)
                {
                    strArray[i] = strArray2[i];
                }
                else
                {
                    strArray[i] = string.Empty;
                }
            }
            return strArray;
        }

        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int maxElementLength)
        {
            string[] strArray = SplitString(strContent, strSplit);
            if (!ignoreRepeatItem)
            {
                return strArray;
            }
            return DistinctStringArray(strArray, maxElementLength);
        }

        public static string[] SplitString(string strContent, string strSplit, bool ignoreRepeatItem, int minElementLength, int maxElementLength)
        {
            string[] strArray = SplitString(strContent, strSplit);
            if (ignoreRepeatItem)
            {
                strArray = DistinctStringArray(strArray);
            }
            return PadStringArray(strArray, minElementLength, maxElementLength);
        }

        public static int StrDateDiffHours(string time, int hours)
        {
            if (StrIsNullOrEmpty(time))
            {
                return 1;
            }
            TimeSpan span = (TimeSpan)(DateTime.Now - DateTime.Parse(time).AddHours((double)hours));
            if (span.TotalHours > 2147483647.0)
            {
                return 0x7fffffff;
            }
            if (span.TotalHours < -2147483648.0)
            {
                return -2147483648;
            }
            return (int)span.TotalHours;
        }

        public static int StrDateDiffMinutes(string time, int minutes)
        {
            if (StrIsNullOrEmpty(time))
            {
                return 1;
            }
            TimeSpan span = (TimeSpan)(DateTime.Now - DateTime.Parse(time).AddMinutes((double)minutes));
            if (span.TotalMinutes > 2147483647.0)
            {
                return 0x7fffffff;
            }
            if (span.TotalMinutes < -2147483648.0)
            {
                return -2147483648;
            }
            return (int)span.TotalMinutes;
        }

        public static int StrDateDiffSeconds(string Time, int Sec)
        {
            TimeSpan span = (TimeSpan)(DateTime.Now - DateTime.Parse(Time).AddSeconds((double)Sec));
            if (span.TotalSeconds > 2147483647.0)
            {
                return 0x7fffffff;
            }
            if (span.TotalSeconds < -2147483648.0)
            {
                return -2147483648;
            }
            return (int)span.TotalSeconds;
        }

        public static string StrFilter(string str, string bantext)
        {
            string oldValue = "";
            string newValue = "";
            string[] strArray = SplitString(bantext, "\r\n");
            for (int i = 0; i < strArray.Length; i++)
            {
                oldValue = strArray[i].Substring(0, strArray[i].IndexOf("="));
                newValue = strArray[i].Substring(strArray[i].IndexOf("=") + 1);
                str = str.Replace(oldValue, newValue);
            }
            return str;
        }

        public static string StrFormat(string str)
        {
            if (str == null)
            {
                return "";
            }
            str = str.Replace("\r\n", "<br />");
            str = str.Replace("\n", "<br />");
            return str;
        }

        public static bool StrIsNullOrEmpty(string str)
        {
            if ((str != null) && !(str.Trim() == string.Empty))
            {
                return false;
            }
            return true;
        }

        public static bool StrToBool(object expression, bool defValue)
        {
            return TypeConverter.StrToBool(expression, defValue);
        }

        public static bool StrToBool(string expression, bool defValue)
        {
            return TypeConverter.StrToBool(expression, defValue);
        }

        public static float StrToFloat(object strValue, float defValue)
        {
            return TypeConverter.StrToFloat(strValue, defValue);
        }

        public static float StrToFloat(string strValue, float defValue)
        {
            return TypeConverter.StrToFloat(strValue, defValue);
        }

        public static int StrToInt(object expression, int defValue)
        {
            return TypeConverter.ObjectToInt(expression, defValue);
        }

        public static int StrToInt(string expression, int defValue)
        {
            return TypeConverter.StrToInt(expression, defValue);
        }

        public static Color ToColor(string color)
        {
            int num;
            int num2;
            char[] chArray;
            int blue = 0;
            color = color.TrimStart(new char[] { '#' });
            color = Regex.Replace(color.ToLower(), "[g-zG-Z]", "");
            switch (color.Length)
            {
                case 3:
                    chArray = color.ToCharArray();
                    num = Convert.ToInt32(chArray[0].ToString() + chArray[0].ToString(), 0x10);
                    num2 = Convert.ToInt32(chArray[1].ToString() + chArray[1].ToString(), 0x10);
                    blue = Convert.ToInt32(chArray[2].ToString() + chArray[2].ToString(), 0x10);
                    return Color.FromArgb(num, num2, blue);

                case 6:
                    chArray = color.ToCharArray();
                    num = Convert.ToInt32(chArray[0].ToString() + chArray[1].ToString(), 0x10);
                    num2 = Convert.ToInt32(chArray[2].ToString() + chArray[3].ToString(), 0x10);
                    blue = Convert.ToInt32(chArray[4].ToString() + chArray[5].ToString(), 0x10);
                    return Color.FromArgb(num, num2, blue);
            }
            return Color.FromName(color);
        }

        public static string ToSChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.SimplifiedChinese, 0);
        }

        public static string ToTChinese(string str)
        {
            return Strings.StrConv(str, VbStrConv.TraditionalChinese, 0);
        }

        public void transHtml(string path, string outpath)
        {
            FileStream stream;
            Page page = new Page();
            StringWriter writer = new StringWriter();
            page.Server.Execute(path, writer);
            if (File.Exists(page.Server.MapPath("") + @"\" + outpath))
            {
                File.Delete(page.Server.MapPath("") + @"\" + outpath);
                stream = File.Create(page.Server.MapPath("") + @"\" + outpath);
            }
            else
            {
                stream = File.Create(page.Server.MapPath("") + @"\" + outpath);
            }
            byte[] bytes = Encoding.Default.GetBytes(writer.ToString());
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
        }

        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }

        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = strValue;
            cookie.Expires = DateTime.Now.AddMinutes((double)expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string strName, string key, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie[key] = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string strName, string key, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Expires = DateTime.Now.AddMinutes((double)expires);
            cookie[key] = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        // Properties
        public static string[] Monthes
        {
            get
            {
                return new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            }
        }

        #region enum
        /// <summary>
        /// 此方法用户获取enum 特性标签
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string EnumString(object o)
        {
            Type t = o.GetType();
            string s = o.ToString();
            EnumDescriptionAttribute[] os = (EnumDescriptionAttribute[])t.GetField(s).GetCustomAttributes(typeof(EnumDescriptionAttribute), false);
            if (os != null && os.Length == 1)
                return os[0].Text;
            return s;
        }
        #endregion


        /// <summary>
        /// 将c# DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name="time">时间</param>
        /// <returns>long</returns>
        public static long ConvertDateTimeInt(System.DateTime time)
        {
            //double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            //intResult = (time- startTime).TotalMilliseconds;
            long t = (time.Ticks - startTime.Ticks) / 10000;            //除10000调整为13位
            return t;
        }
    }
}
