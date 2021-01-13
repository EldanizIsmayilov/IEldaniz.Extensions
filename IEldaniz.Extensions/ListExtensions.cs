using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEldaniz.Extensions
{
    public static class ListExtensions
    {

        /// <summary>
        /// Checks if the value is in a set of values
        /// </summary>
        /// <typeparam name="T">Any type</typeparam>
        /// <param name="obj">The value to check in a set of values</param>
        /// <param name="values">The set of values to check for a value in</param>
        /// <returns></returns>
        public static bool In<T>(this T obj, params T[] values)
        {
            return values.Contains(obj);
        }

        public static bool ContainAtLeastOne<T>(this IEnumerable<T> obj, params T[] values)
        {
            return obj.Intersect(values).Any();
        }


        public static bool IsNullOrEmpty<T>(this IEnumerable<T> obj)
        {
            if (obj == null || obj.Count() == 0)
                return true;

            return false;
        }


        public static decimal Multiply<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (source.Count() == 0)
                return 0;

            decimal result = 1;
            foreach (var item in source)
            {
                result *= selector(item);
            }

            return result;
        }

        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        public static string ToStringWithComma<T>(this T[] array)
        {
            return string.Join(",", array);
        }

    }
}
