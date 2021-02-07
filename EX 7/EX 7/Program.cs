using System;
using System.Dynamic;

namespace EX_7
{
    class Program
    {
        //Write a program which takes two numbers form the 
        //console and displays the maximum of the two.
        static void Main(string[] args)
        {
            Console.WriteLine("Please input the first number");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Please input the second number");
            int num2 = Convert.ToInt32(Console.ReadLine());

            if (num1 > num2)
            {
                Console.WriteLine(num1);
            }
            else
            {
                Console.WriteLine(num2);
            }
        }
    }
}
