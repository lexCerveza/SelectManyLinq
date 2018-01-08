using System;
using System.Linq;
using System.Collections.Generic;

namespace SelectManyLinq
{
    public static class SelectManyEnumerable
    {
        public static IEnumerable<TResult> Empty<TResult>()
        {
            yield break;
        }

        public static IEnumerable<int> Range(int start, int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }

        public static IEnumerable<TResult> Repeat<TResult>(TResult element, int count)
        {
            for (var i = 0; i < count; i++)
            {
                yield return element;
            }
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return source.SelectMany(elem => predicate(elem) ?
                SelectManyEnumerable.Repeat(elem, 1) :
                SelectManyEnumerable.Empty<TSource>());
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            return source.SelectMany((elem, index) => predicate(elem, index) ?
                SelectManyEnumerable.Repeat(elem, 1) :
                SelectManyEnumerable.Empty<TSource>());
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.SelectMany(elem => SelectManyEnumerable.Repeat(selector(elem), 1));
        }
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            return source.SelectMany((elem, index) => SelectManyEnumerable.Repeat(selector(elem, index), 1));
        }

        // stupid implementation but uses SelectMany )))s
        public static int Count<TSource>(this IEnumerable<TSource> source)
        {
            var count = 0;

            var enumerableToIterate = source.SelectMany(elem => 
            {
                count++;
                return SelectManyEnumerable.Repeat(elem, 1);
            });
            
            // iterate enumerable because it's lazy
            foreach (var elem in enumerableToIterate) {}

            return count;
        }

        public static long LongCount<TSource>(
            this IEnumerable<TSource> source)
        {
            return 0L;
        }

        public static long LongCount<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, bool> predicate)
        {
            return 0L;
        }
    }
}