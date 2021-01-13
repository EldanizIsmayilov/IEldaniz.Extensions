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

        public static string ToAzeriMonthString(this int month)
        {
            switch (month)
            {
                case 1: return "yanvar";
                case 2: return "fevral";
                case 3: return "mart";
                case 4: return "aprel";
                case 5: return "may";
                case 6: return "iyun";
                case 7: return "iyul";
                case 8: return "avqust";
                case 9: return "sentyabr";
                case 10: return "oktyabr";
                case 11: return "noyabr";
                case 12: return "dekabr";
                default: return null;
            }
        }

        public static string ToDuringDescription(this int day)
        {
            if (day < 90)
                return "";
            int year = 0;
            int month = 0;
            int week = 0;
            string result = "";

            if (day >= 365)
            {
                do
                {
                    day = day - 365;
                    year++;
                }
                while (day >= 365);
            }
            if (day >= 30 && day < 365)
            {
                do
                {
                    day = day - 30;
                    month++;
                }
                while (day >= 30);
            }
            if (day >= 7 && day < 30)
            {
                do
                {
                    day = day - 7;
                    week++;
                }
                while (day >= 7);
            }

            if (year >= 1) result += $"{year} il ";
            if (month >= 1) result += $"{month} ay ";
            if (week >= 1) result += $"{week} həftə ";
            if (day >= 1) result += $"{day} gün";
            result = "(" + result + ")";

            return result;
        }

    }
}
