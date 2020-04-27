using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEldaniz.Extensions
{
    public static class NumberExtensions
    {

        public static short ToShort(this string param)
        {
            short result = 0;
            if (!string.IsNullOrEmpty(param))
            {
                if (!short.TryParse(param, out result))
                    throw new Exception("String does not convert to short");
            }
            return result;
        }

        public static short ToShort(this object param)
        {
            return param.ToString().ToShort();
        }

        public static short? ToNShort(this object value)
        {
            if (value == null || value == DBNull.Value)
                return null;
            else
                return value.ToShort();
        }

        public static bool IsValidInt(this string param)
        {
            if (param == null)
                return false;
            int result;

            return int.TryParse(param, out result);
        }

        public static int ToInt(this string param)
        {
            int result = 0;
            if (!string.IsNullOrEmpty(param))
            {
                if (!int.TryParse(param.Trim(), out result))
                    throw new Exception("String does not convert to int");
            }
            return result;
        }

        public static byte ToByte(this string param)
        {
            byte result = 0;
            if (!string.IsNullOrEmpty(param))
            {
                if (!byte.TryParse(param.Trim(), out result))
                    throw new Exception("String does not convert to byte");
            }
            return result;
        }

        public static sbyte ToSByte(this string param)
        {
            sbyte result = 0;
            if (!string.IsNullOrEmpty(param))
            {
                if (!sbyte.TryParse(param.Trim(), out result))
                    throw new Exception("String does not convert to byte");
            }
            return result;
        }

        public static byte ToByte(this bool param)
        {
            if (param)
                return 1;
            else
                return 0;
        }

        public static int ToInt(this bool param)
        {
            if (param)
                return 1;
            else
                return 0;
        }

        public static int ToInt(this object param)
        {
            return param.ToString().ToInt();
        }

        public static int? ToNInt(this object value)
        {
            if (value == null || value == DBNull.Value || value == "")
                return null;
            else
                return value.ToInt();
        }

        public static int? ToNInt(this bool? value)
        {
            return value?.ToInt();
        }

        public static int ToInt(this string param, bool isNullOrEmpty)
        {
            if (isNullOrEmpty)
            {
                if (param.IsNullOrWhiteSpaceOrEmpty())
                    return 0;
            }
            return param.ToInt();
        }

        public static long ToLong(this string param)
        {
            long result = 0;
            if (!string.IsNullOrEmpty(param))
            {
                if (!long.TryParse(param.Trim(), out result))
                    throw new Exception("String does not convert to int");
            }
            return result;
        }

        public static long ToLong(this object param)
        {
            return param.ToString().ToLong();
        }

        public static long ToLong(this string param, bool isNullOrEmpty)
        {
            if (isNullOrEmpty)
            {
                if (param.IsNullOrWhiteSpaceOrEmpty())
                    return 0;
            }
            return param.ToLong();
        }

        public static long? ToNLong(this object value)
        {
            if (value == null || value == DBNull.Value)
                return null;
            else
                return value.ToLong();
        }

        public static long? ToNLong(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;
            else
                return value.ToLong();
        }

        public static bool IsValidLong(this object param)
        {
            if (param == null)
                return false;
            long result;
            return long.TryParse(param.ToString(), out result);
        }

        public static decimal ToDecimal(this string param)
        {
            decimal result = 0;
            param = param.Trim();
            if (!string.IsNullOrEmpty(param))
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign | NumberStyles.AllowExponent;
                if (!decimal.TryParse(param.Replace(',', '.'), style, CultureInfo.InvariantCulture, out result))
                    throw new Exception("String does not convert to decimal");
            }
            return result;
        }

        public static decimal ToDecimal(this string param, bool isNullOrEmpty)
        {
            if (isNullOrEmpty)
            {
                if (param.IsNullOrWhiteSpaceOrEmpty())
                    return 0;
            }

            return param.ToDecimal();

        }

        public static decimal ToDecimal(this object param)
        {
            return param.ToString().ToDecimal();
        }

        public static bool IsValidDecimal(this string param)
        {
            if (param == null)
                return false;
            decimal result;

            return decimal.TryParse(param.Trim(), out result);
        }

        public static decimal? ToNDecimal(this string param)
        {
            if (string.IsNullOrEmpty(param))
                return null;
            else
                return param.ToDecimal();
        }

        public static string NumberToWord(this string number)
        {
            string[] digits = { "", "bir", "iki", "üç", "dörd", "beş", "altı", "yeddi", "səkkiz", "doqquz" };
            string[] tens = { "", "on", "iyirmi", "otuz", "qırx", "əlli", "altmış", "yetmiş", "səksən", "doxsan" };
            string[] bigs = { "", "min", "milyon", "milyard", "trilyon" };

            string res = "";
            int bigsIndex = 0;
            while (number.Length > 0)
            {
                if (number.Length < 3)
                    number = number.PadLeft(3, '0');
                string currentThreeDigit = number.Substring(number.Length - 3);
                int index1 = Convert.ToInt32(currentThreeDigit[0].ToString());
                int index2 = Convert.ToInt32(currentThreeDigit[1].ToString());
                int index3 = Convert.ToInt32(currentThreeDigit[2].ToString());
                string bigHundText = "";
                string bigText = "";

                if (index1 == 1)
                    bigHundText = "yüz";
                else if (index1 > 1 && index1 < 10)
                    bigHundText = digits[index1] + " yüz";
                else bigHundText = "";

                if (bigsIndex == 1)
                {
                    if (currentThreeDigit == "001")
                        bigText = bigs[bigsIndex];
                    else if (currentThreeDigit == "000")
                        bigText = "";
                    else
                        bigText = digits[index3] + " " + bigs[bigsIndex];
                }
                else
                {
                    bigText = digits[index3] + " " + bigs[bigsIndex];
                }


                res = bigHundText.Trim() + " " + tens[index2] + " " + bigText.Trim() + " " + res;
                bigsIndex++;
                number = number.Remove(number.Length - 3);
            }
            res = res.Trim();
            if (res == string.Empty)
                res = " sıfır";
            return res;
        }
    }
}
