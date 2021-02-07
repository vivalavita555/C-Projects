using System;
using System.Dynamic;

namespace Fibonacci
{
    class Program
    {
        public static int Fib(int fibN)
        {
            int n1 = 0;
            int n2 = 1;

            for(int i = 0; i < fibN; i++)
            {
                int temp = n1;
                n1 = n2;
                n2 += temp;
                Console.WriteLine(n1);
            }
            return n1;
            
        }
        static void Main(string[] args)
        {
            Fib(Convert.ToInt32(Console.ReadLine()));
        }
    }
}
