using System;

namespace DateTimeExercises
{
    class Program
    {
        static void Main(string[] args)
        {


            var now = new DateTime();
            Console.WriteLine(now.ToLongDateString());
            Console.WriteLine(now.ToShortDateString());
            Console.WriteLine(now.ToLongTimeString());
            Console.WriteLine(now.ToLongTimeString());

        }
    }
}
