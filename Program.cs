using System;
using System.Linq;

namespace SelectManyLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var enumerable = SelectManyEnumerable.Range(1, 10);
            var a = SelectManyEnumerable.Count(enumerable);

            var first = SelectManyEnumerable.Range(1, 5);
            var second = SelectManyEnumerable.Range(1, 3);

            var concat = SelectManyEnumerable.Concat(first, second);

            var except = first.Except(second).ToArray();

            Console.WriteLine("Hello World!");
        }
    }
}
