using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TL.Common
{
    public class Validator
    {
        // Methods
        /// <summary>
        /// IsDouble
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsDouble(object expression)
        {
            return ((expression != null) && Regex.IsMatch(expression.ToString(), @"^([0-9])[0-9]*(\.\w*)?$"));
        }
        /// <summary>
        /// IsNumeric
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static bool IsNumeric(object expression)
        {
            return ((expression != null) && IsNumeric(expression.ToString()));
        }

        public static bool IsNumeric(string expression)
        {
            if (expression != null)
            {
                string input = expression;
                if ((((input.Length > 0) && (input.Length <= 11)) && Regex.IsMatch(input, "^[-]?[0-9]*[.]?[0-9]*$")) && (((input.Length < 10) || ((input.Length == 10) && (input[0] == '1'))) || (((input.Length == 11) && (input[0] == '-')) && (input[1] == '1'))))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool IsNumericArray(string[] strNumber)
        {
            if (strNumber == null)
            {
                return false;
            }
            if (strNumber.Length < 1)
            {
                return false;
            }
            foreach (string str in strNumber)
            {
                if (!IsNumeric(str))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
