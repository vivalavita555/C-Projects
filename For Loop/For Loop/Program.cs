using System;

namespace For_Loop
{
    class Program
    {
        static void Main(string[] args)
        {
            int temp = 1;
            temp++;
            Console.WriteLine(temp);
            temp--;
            Console.WriteLine(temp);
            Console.WriteLine("1. loop");
                for(int i = 0; i < 5; i++)
            {
                Console.WriteLine("Value of i is : "+i);
            }
        }
    }


}
