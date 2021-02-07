using System;
using System.Threading.Tasks.Dataflow;

namespace EX_8
{
    class Program
    {
        //Write a program and ask the user to enter the width 
        //and height of an image. Then tell if the image is 
        //landscape or portrait.
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the width");
            int width = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the height");
            int height = Convert.ToInt32(Console.ReadLine());

            if(width > height)
            {
                Console.WriteLine("Landscape");
            }
            else if(height > width) 
            {
                Console.WriteLine("Portrait");
            }
            else
            {
                Console.WriteLine("Square");
            }

        }
    }
}
