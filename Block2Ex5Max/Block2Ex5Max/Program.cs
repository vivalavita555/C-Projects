using System;

namespace Block2Ex5Max
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string of numbers separated by ','");
            var input = Console.ReadLine().Trim();
            var series = input.Split(',');
            var max = int.MinValue;
            for (int i = 0; i < series.Length; i++)
            {
                var number = int.Parse(series[i]);
                if (max < number)
                    max = number;
            }
            Console.WriteLine(max);
        }
    }
}
