using System;
using System.Linq;
using System.Collections.Generic;

namespace SelectManyLinq
{
    public static partial class SelectManyEnumerable
    {
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
    }
}