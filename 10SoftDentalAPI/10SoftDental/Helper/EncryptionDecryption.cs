using System;
using System.Text;
using System.Security.Cryptography;

namespace _10SoftDental.Helper
{
    public class EncryptionDecryption
    {
        public EncryptionDecryption()
        {

        }
        private string keyString = "552F79D3-1F36-48ab-934C-4629C2274D43";


        /// <summary>
        /// Get Encrpted Value of Passed value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string GetEncrypt(string value)
        {
            return Encrypt(keyString, value);
        }

        /// <summary>
        /// Get Decrypted value of passed encrypted string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public string GetDecrypt(string value)
        {
            return Decrypt(keyString, value.Replace(" ", "+"));
        }

        /// <summary>
        /// Encrypt value
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="strData"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string Encrypt(string strKey, string strData)
        {
            string strValue = "";
            if (!(strKey == ""))
            {
                if (strKey.Length < 16)
                {
                    strKey = strKey.PadRight(16 - strKey.Length, 'X').Substring(0, 16);
                }
                else
                {
                    if (strKey.Length > 16)
                    {
                        strKey = strKey.Substring(0, 16);
                    }
                }
                byte[] byteKey = Encoding.UTF8.GetBytes(strKey.Substring(0, 8));
                byte[] byteVector = Encoding.UTF8.GetBytes(strKey.Substring(8));
                byte[] byteData = Encoding.UTF8.GetBytes(strData);
                DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
                System.IO.MemoryStream objMemoryStream = new System.IO.MemoryStream();
                CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateEncryptor(byteKey, byteVector), CryptoStreamMode.Write);
                objCryptoStream.Write(byteData, 0, byteData.Length);
                objCryptoStream.FlushFinalBlock();
                strValue = Convert.ToBase64String(objMemoryStream.ToArray());
                objDES.Clear();
                objCryptoStream.Clear();
                objCryptoStream.Close();
            }
            else
            {
                strValue = strData;
            }
            return strValue;
        }

        /// <summary>
        /// decrypt value
        /// </summary>
        /// <param name="strKey"></param>
        /// <param name="strData"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private string Decrypt(string strKey, string strData)
        {
            string strValue = "";
            if (!(strData == ""))
            {
                if (strKey.Length < 16)
                {
                    strKey = strKey.PadRight(16 - strKey.Length, 'X').Substring(0, 16);
                }
                else
                {
                    if (strKey.Length > 16)
                    {
                        strKey = strKey.Substring(0, 16);
                    }
                }
                byte[] byteKey = Encoding.UTF8.GetBytes(strKey.Substring(0, 8));
                byte[] byteVector = Encoding.UTF8.GetBytes(strKey.Substring(8));
                byte[] byteData = new byte[strData.Length + 1];
                try
                {
                    byteData = Convert.FromBase64String(strData);
                }
                catch
                {
                    strValue = strData;
                }
                if (strValue == "")
                {
                    try
                    {
                        DESCryptoServiceProvider objDES = new DESCryptoServiceProvider();
                        System.IO.MemoryStream objMemoryStream = new System.IO.MemoryStream();
                        CryptoStream objCryptoStream = new CryptoStream(objMemoryStream, objDES.CreateDecryptor(byteKey, byteVector), CryptoStreamMode.Write);
                        objCryptoStream.Write(byteData, 0, byteData.Length);
                        objCryptoStream.FlushFinalBlock();
                        System.Text.Encoding objEncoding = System.Text.Encoding.UTF8;
                        strValue = objEncoding.GetString(objMemoryStream.ToArray());
                        objDES.Clear();
                        objCryptoStream.Clear();
                        objCryptoStream.Close();
                    }
                    catch
                    {
                        strValue = "";
                    }
                }
            }
            else
            {
                strValue = strData;
            }
            return strValue;
        }
    }
}