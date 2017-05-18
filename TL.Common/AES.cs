using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;


namespace TL.Common
{
    /// <summary>
    /// AES加密解密
    /// </summary>
    public class AES
    {
        #region 变量
        /// <summary>
        /// 加密解密key
        /// </summary>
        private static byte[] Keys = new byte[] { 0x41, 0x72, 0x65, 0x79, 0x6f, 0x75, 0x6d, 0x79, 0x53, 110, 0x6f, 0x77, 0x6d, 0x61, 110, 0x3f };
        #endregion

        #region 方法
        /// <summary>
        /// 解密算法
        /// </summary>
        /// <param name="decryptString"></param>
        /// <param name="decryptKey"></param>
        /// <returns></returns>
        public static string Decode(string decryptString, string decryptKey)
        {
            try
            {
                decryptKey = Utils.GetSubString(decryptKey, 0x20, ""); //ASCII; 0x20 is 32
                decryptKey = decryptKey.PadRight(0x20, ' ');
                RijndaelManaged managed = new RijndaelManaged();
                managed.Key = Encoding.UTF8.GetBytes(decryptKey);
                managed.IV = Keys;
                ICryptoTransform transform = managed.CreateDecryptor();
                byte[] inputBuffer = Convert.FromBase64String(decryptString);
                byte[] bytes = transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                return Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// 加密算法
        /// </summary>
        /// <param name="encryptString"></param>
        /// <param name="encryptKey"></param>
        /// <returns></returns>
        public static string Encode(string encryptString, string encryptKey)
        {
            encryptKey = Utils.GetSubString(encryptKey, 0x20, "");
            encryptKey = encryptKey.PadRight(0x20, ' ');
            RijndaelManaged managed = new RijndaelManaged();
            managed.Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 0x20));
            managed.IV = Keys;
            ICryptoTransform transform = managed.CreateEncryptor();
            byte[] bytes = Encoding.UTF8.GetBytes(encryptString);
            return Convert.ToBase64String(transform.TransformFinalBlock(bytes, 0, bytes.Length));
        }
        #endregion
    }
}
