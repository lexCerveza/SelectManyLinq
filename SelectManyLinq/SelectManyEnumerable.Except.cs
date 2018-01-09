using System;
using System.Linq;
using System.Collections.Generic;

namespace SelectManyLinq
{
    public static partial class SelectManyEnumerable
    {
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