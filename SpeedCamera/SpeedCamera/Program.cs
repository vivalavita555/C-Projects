using System;

namespace SpeedCamera
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the speed limit");
            int limit = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nEnter the car's speed");
            int speed = Convert.ToInt32(Console.ReadLine());
            int pts = ((speed - limit) / 5);
            
            if (speed < limit)
            {
                Console.WriteLine("\nOK");
            }
            else if (pts > 12)
            {
                Console.WriteLine("License Suspended");
            }
            else
            {
                Console.WriteLine("LIMIT EXCEEDED! \nDemerit Points Incurred: " + pts);
            }
        }
    }
}
