using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IEldaniz.Extensions
{
    public static class StringExtensions
    {
        public static string ToNString(this object value)
        {
            if (value == null || value == DBNull.Value)
                return null;
            else
                return value.ToString();

        }

        public static string ToString(this DateTime? dt, string format)
        {
            return dt == null ? " " : ((DateTime)dt).ToString(format);
        }
            

        public static bool IsZeroOrNullOrEmpty(this string value)
        {
            if (value == null)
                return true;

            value = value.Trim();
            if (value == "0" || value == string.Empty)
                return true;
            else
                return false;

        }

        public static bool IsNullOrWhiteSpaceOrEmpty(this string value)
        {
            if (value == null)
                return true;

            if (value.Trim() == "")
                return true;
            else
                return false;

        }

        public static string CutString(this string param, int startIndex, int? endIndex = null)
        {
            int _endIndex = param.Length;
            if (endIndex != null && _endIndex > endIndex.Value)
                _endIndex = endIndex.Value;
            return param.Substring(startIndex, _endIndex);
        }

        public static string ToSha256String(this string value)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytesOfString = Encoding.UTF8.GetBytes(value);
                var hashedInputBytes = sha256.ComputeHash(bytesOfString);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashedInputBytes)
                    sb.Append(b.ToString("X2"));
                return sb.ToString();
            }
        }
    }
}
