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

        public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            var enumerables = new[] { first, second };
            return enumerables.SelectMany(element => element);
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source)
        {
            foreach (var item in source)
            {
                return true;
            }

            return false;
        }

        public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item))
                {
                    return false;
                }
            }

            return true;
        }
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second)
        {
            return ExceptImpl(first, second, EqualityComparer<TSource>.Default);
        }
        
        public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            return ExceptImpl(first, second, comparer);
        }

        private static IEnumerable<TSource> ExceptImpl<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IEqualityComparer<TSource> comparer)
        {
            var hashSetFromFirstSequence = new HashSet<TSource>(second, comparer);

            return first.SelectMany(element => 
                hashSetFromFirstSequence.Add(element) ? 
                    SelectManyEnumerable.Repeat(element, 1) : 
                    SelectManyEnumerable.Empty<TSource>());
        }
    }
}