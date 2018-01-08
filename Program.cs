using System;

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

            Console.WriteLine("Hello World!");
        }
    }
}
