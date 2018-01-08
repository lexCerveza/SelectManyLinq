using System;
using System.Linq;
using System.Collections.Generic;

namespace SelectManyLinq
{
    public static class SelectManyLinqExtensions
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
                Enumerable.Repeat(elem, 1) :
                Enumerable.Empty<TSource>());
        }

        public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, int, bool> predicate)
        {
            return source.SelectMany((elem, index) => predicate(elem, index) ?
                Enumerable.Repeat(elem, 1) :
                Enumerable.Empty<TSource>());
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.SelectMany(elem => Enumerable.Repeat(selector(elem), 1));
        }
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TResult> selector)
        {
            return source.SelectMany((elem, index) => Enumerable.Repeat(selector(elem, index), 1));
        }
    }
}