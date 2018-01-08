using System;

namespace SelectManyLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            var enumerable = SelectManyEnumerable.Range(1, 10);
            var a = SelectManyEnumerable.Count(enumerable);
            
            Console.WriteLine("Hello World!");
        }
    }
}
