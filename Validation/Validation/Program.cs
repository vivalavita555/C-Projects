using System;

namespace Validation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pick a number beteen 1 and 10!");
            int num = Convert.ToInt32(Console.ReadLine());
            if (num > 0 && num < 11)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }

            Console.WriteLine("\nEnter your first number.");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter your second number.");
            int num2 = Convert.ToInt32(Console.ReadLine());                
            if (num1 > num2) 
            {
                Console.WriteLine("The First Number : " + num1 + " is higher");
            }
            else if (num1 < num2)
            {
                Console.WriteLine("The Second Number : "+num2+" is higher");
            }
            else
            {
                Console.WriteLine("The numbers are equal");
            }

            Console.WriteLine("\nEnter the height");
            float h = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("\nEnter the width");
            float w = Convert.ToSingle(Console.ReadLine());
            if (h > w)
            {
                Console.WriteLine("The image is portrait");
            }
            else if (w > h)
            {
                Console.WriteLine("The image is landscape");
            }
            else
            {
                Console.WriteLine("Nice cock :thumbsup:");
            }


        }
    }
}
