using System;
using System.Collections.Generic;
namespace Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            var Brum = new [] { 6, 6, 6 };
            var Bruh = new List<int>();
            Bruh.Add(1);
            Bruh.Add(5);
            Console.WriteLine(Bruh.IndexOf(5));
            Bruh.AddRange(new int[3] { 1, 2, 3 }); //We can add an array into the list using AddRange
            foreach (var n in Bruh)
            {
                Console.WriteLine(n);
            }
            Bruh.AddRange(Brum);
            foreach (var b in Bruh)
            {
                Console.WriteLine(b);
            }
        }
    }
}
