using System;
using System.Linq;

namespace Block2Ex2Summer
{
    class Program
    {
        static void Main(string[] args)
        {
            var sum = 0;
            while (true)
            {
                Console.Write(">Enter a number [OK] to exit: ");
                var input = Console.ReadLine();
                if (input != "ok")
                {
                    sum += int.Parse(input);
                    continue;
                }
                break;
            }
            Console.WriteLine(">The sum is: "+sum);
        }
    }
}
