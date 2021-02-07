using System;

namespace WhileLoopEcho
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Please enter your name: ");
                var input = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(input))
                    break;
                Console.WriteLine("@Echo: "+input);
            }
        }
    }
}
