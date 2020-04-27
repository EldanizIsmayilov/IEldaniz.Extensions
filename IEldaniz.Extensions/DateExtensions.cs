using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEldaniz.Extensions
{
    public static class DateExtensions
    {
        public static DateTime ToDate(this string dateString)
        {
            return dateString.ToDate("dd.MM.yyyy");
        }

        public static DateTime ToDate(this string dateString, string format)
        {
            DateTime dt = DateTime.ParseExact(dateString.Trim(), format, System.Globalization.CultureInfo.InvariantCulture);
            return dt;
        }
        public static DateTime? TryToDate(this string dateString)
        {
            if (string.IsNullOrWhiteSpace(dateString))
                return null;
            else
            {
                DateTime dt;
                string[] formats =
                {
                        "dd.MM.yyyy", "dd.M.yyyy", "d.M.yyyy", "d.MM.yyyy",
                        "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy","M/dd/yyyy hh:mm:ss tt",
                        "M/d/yyyy hh:mm:ss tt", "MM/dd/yyyy hh:mm:ss tt", "MM/d/yyyy hh:mm:ss tt",
                        "M/dd/yyyy hh:mm:ss tt","MM.dd.yyyy hh:mm:ss tt", "dd.MM.yyyy hh:mm:ss tt",
                        "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy","dd.MM.yyyy hh:mm:ss", "dd/MM/yyyy",
                    };
                DateTime.TryParseExact(dateString, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dt);
                return dt;
            }
        }

        public static DateTime? ToNDate(this string dateString)
        {
            if (dateString.IsNullOrWhiteSpaceOrEmpty())
                return null;
            else
                return dateString.ToDate("dd.MM.yyyy");
        }

        public static DateTime ToDate(this object data)
        {
            return (DateTime)data;
        }

        public static DateTime? ToNDate(this object data)
        {
            if (data == null || data == DBNull.Value)
                return null;
            else
                return (DateTime)data;
        }


        public static DateTime? ToNDate(this string dateString, string format)
        {
            if (dateString == null)
                return null;
            else
                return dateString.ToDate(format);
        }

        /// <summary>
        /// Returns value indicating whether the passed string is a valid date
        /// </summary>
        /// <param name="dateString">String representation of date</param>
        /// <returns></returns>
        public static bool IsValidDate(this string dateString)
        {
            return dateString.IsValidDate("dd.MM.yyyy");
        }

        /// <summary>
        /// Returns value indicating whether the passed string is a valid date
        /// </summary>
        /// <param name="dateString">String representation of date</param>
        /// <param name="format">Date format</param>
        /// <returns></returns>
        public static bool IsValidDate(this string dateString, string format)
        {
            DateTime dateTime;
            return DateTime.TryParseExact(dateString.Trim(), format, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateTime);
        }

        public static bool IsSameDay(this DateTime datetime1, DateTime datetime2)
        {
            return datetime1.Year == datetime2.Year
                && datetime1.Month == datetime2.Month
                && datetime1.Day == datetime2.Day;
        }
    }
}
