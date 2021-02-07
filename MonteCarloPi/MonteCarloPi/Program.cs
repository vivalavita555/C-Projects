using System;

namespace MonteCarloPi
{
    class Program
    {
        static void Main(string[] args)
        {
            double diameter = 100;
            double center = 50;
            Random rng = new Random();
            int inside = 0;
            int iterations = 1000000000;
            for(int i = 0; i < iterations; i++)
            {
                double x = ((double)rng.Next() / Int32.MaxValue * 100);
                double y = ((double)rng.Next() / Int32.MaxValue * 100);
                double xDistance = center - x;
                double yDistance = center - y;
                double totalDistance = (double)Math.Sqrt(xDistance * xDistance + yDistance * yDistance);
                if(totalDistance <= diameter / 2)
                {
                    inside++;
                }
            }

            double pi = (double)inside / iterations * 4;
            Console.WriteLine(pi);
        }
    }
}
