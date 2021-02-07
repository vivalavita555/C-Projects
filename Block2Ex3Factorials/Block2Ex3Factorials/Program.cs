using System;

namespace Block2Ex3Factorials
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.Write("Enter a number: ");
            //var input = int.Parse(Console.ReadLine());
            //var f = 1;
            //for (int i = 2; i <= input; i++)
            //    f *= i;

            //Console.WriteLine(string.Format("Factorial of {0} is {1}", input, f));
            int n = int.Parse(Console.ReadLine());

            int factorial = 1;
            for (int i = n; i > 0; i--)
                factorial *= i;
            //return factorial;
            Console.WriteLine(factorial);

        }
    }
}
