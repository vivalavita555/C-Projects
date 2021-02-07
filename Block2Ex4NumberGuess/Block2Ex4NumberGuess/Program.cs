using System;

namespace Block2Ex4NumberGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            int num = rnd.Next(1, 11);
            for (int i = 0; i <= 3; i++)
            {
                Console.Write("Guess: ");
                int guess = int.Parse(Console.ReadLine());
                if (guess == num)
                {
                    Console.WriteLine("You won! The number was: "+num );
                }
            }
            Console.WriteLine("You lose! The number was "+num);

        }
    }
}
