using System;

namespace Methods
{
    class Program
    {

        static void Main(string[] args)
        {
            var calculator = new Calculator();
            Console.WriteLine(calculator.Add(1,2));
            Console.WriteLine(calculator.Add(1,2,3));
            Console.WriteLine(calculator.Add(1,2,3,4));
        }

        static void UseParams()
        {
            int test = 50000;
            //var number = int.Parse("abc");
            var result = int.TryParse("abc", out test);
            if (result)
            {
                Console.WriteLine(test);
            }
            else
            {
                Console.WriteLine("Conversion failed");
            }
        }
        static void UsePoints()
        {
            //How to run an application that would normally crash and display a friendlier error message
            try
            {
                var point = new Point(10, 20);
                point.Move(null); //new Point(40, 60)
                Console.WriteLine("Point is at ({0},{1})", point.X, point.Y);

                point.Move(100, 200);
                Console.WriteLine("Point is at ({0},{1})", point.X, point.Y);
            }
            catch (Exception)
            {

                Console.WriteLine("An unexpected error occured");
            }
    

        }
    }
}
