using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TL.Common
{
    public class TypeConverter
    {
        // Methods

        public static float ObjectToFloat(object strValue)
        {
            return ObjectToFloat(strValue.ToString(), 0f);
        }

        public static float ObjectToFloat(object strValue, float defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToFloat(strValue.ToString(), defValue);
        }

        public static int ObjectToInt(object expression)
        {
            return ObjectToInt(expression, 0);
        }

        public static int ObjectToInt(object expression, int defValue)
        {
            if (expression != null)
            {
                return StrToInt(expression.ToString(), defValue);
            }
            return defValue;
        }

        public static bool StrToBool(object expression, bool defValue)
        {
            if (expression != null)
            {
                return StrToBool(expression, defValue);
            }
            return defValue;
        }

        public static bool StrToBool(string expression, bool defValue)
        {
            if (expression != null)
            {
                if (string.Compare(expression, "true", true) == 0)
                {
                    return true;
                }
                if (string.Compare(expression, "false", true) == 0)
                {
                    return false;
                }
            }
            return defValue;
        }

        public static float StrToFloat(object strValue)
        {
            if (strValue == null)
            {
                return 0f;
            }
            return StrToFloat(strValue.ToString(), 0f);
        }

        public static float StrToFloat(object strValue, float defValue)
        {
            if (strValue == null)
            {
                return defValue;
            }
            return StrToFloat(strValue.ToString(), defValue);
        }

        public static float StrToFloat(string strValue, float defValue)
        {
            if ((strValue == null) || (strValue.Length > 10))
            {
                return defValue;
            }
            float result = defValue;
            if ((strValue != null) && Regex.IsMatch(strValue, @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                float.TryParse(strValue, out result);
            }
            return result;
        }

        public static int StrToInt(string str)
        {
            return StrToInt(str, 0);
        }

        public static int StrToInt(string str, int defValue)
        {
            int num;
            if ((string.IsNullOrEmpty(str) || (str.Trim().Length >= 11)) || !Regex.IsMatch(str.Trim(), @"^([-]|[0-9])[0-9]*(\.\w*)?$"))
            {
                return defValue;
            }
            if (int.TryParse(str, out num))
            {
                return num;
            }
            return Convert.ToInt32(StrToFloat(str, (float)defValue));
        }
        public static List<string> TwoObjToList(object value, object tyle)
        {
            List<string> list = new List<string>();
            list.Add(value.ToString());
            list.Add(tyle.ToString());
            return list;
        }


        public enum DBtyle { Int, String, Object, Date, Char }
    }
}