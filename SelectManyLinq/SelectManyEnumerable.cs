using System;
using System.Linq;
using System.Collections.Generic;

namespace SelectManyLinq
{
    public static partial class SelectManyEnumerable
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
    }
}