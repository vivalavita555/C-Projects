using System;
using System.Runtime.CompilerServices;

namespace LambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //args => expression
            //number => number*number;

            //  args expression     |--LAMBDA EXPRESSION--|
            //    v    v            v                     v
            Func<int, int> square = number => number*number;

            Console.WriteLine(Square(5));
            Console.WriteLine(square(5));
        }

        static int Square(int number)
        {
            return number*number;
        }
    }
}
