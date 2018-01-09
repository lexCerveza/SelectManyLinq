using System;
using System.Linq;
using System.Collections.Generic;

namespace SelectManyLinq
{
    public static partial class SelectManyEnumerable
    {
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            var count = 0;

            foreach (var item in source)
            {
                count++;
            }

            return count;
        }

        public static int Count<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            var count = 0;

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    count++;
                }
            }

            return count;
        }

        public static long LongCount<TSource>(this IEnumerable<TSource> source)
        {
            long count = 0;

            foreach (var item in source)
            {
                count++;
            }

            return count;
        }

        public static long LongCount<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            long count = 0;

            foreach (var item in source)
            {
                if (predicate(item))
                {
                    count++;
                }
            }

            return count;
        }

    }
}