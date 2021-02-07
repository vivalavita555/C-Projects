using System;

namespace Block2Ex1DivisionBy3
{
    class Program
    {
        static void Main(string[] args)
        {
            var j = 0;
            for(var i = 1;i <=100; i++)
            {
                if(i%3==0)
                    j++;
            }
            Console.WriteLine(j);
        }
    }
}
