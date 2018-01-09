using System;
using System.Linq;
using System.Collections.Generic;

namespace SelectManyLinq
{
    public static partial class SelectManyEnumerable
    {
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
    }
}