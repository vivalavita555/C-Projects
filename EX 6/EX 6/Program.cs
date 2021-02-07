using System;

namespace EX_6
{
    class Program
    {
        //Write a program and ask the user to enter anumber. 
        //The number should be between 1 to 10. If the user 
        //enters a valid number, display "Valid" on the console. 
        //Otherwise, display "Invalid". (This logic is used a lot 
        //in applications where values entered into input boxes 
        //need to be validated.
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a number between 1 and 10");
            int input = Convert.ToInt32(Console.ReadLine());

            if(input < 1 || input > 10)
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                Console.WriteLine("Valid");
            }
        }
    }
}
