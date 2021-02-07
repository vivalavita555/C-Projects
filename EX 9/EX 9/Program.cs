using System;

namespace EX_9
{
    class Program
    {
        //Your job is to write a program for a speed camera. 
        //For simplicity, ignore the detailes such as camera, 
        //sensors, etc and focus purely on the logic. Write a 
        //program that asks the user to enter the speed limit. 
        //Once set, the program asks for the speed of a car. 
        //If the user enters a value less than the speed limit, 
        //program should display Ok on the console. If the value 
        //is above the speed limit, the program should calculate 
        //the number of demerit points. For every 5mph above the 
        //speed limit, 1 demerit point should be incurred and displayed 
        //on the console. If the number of demerit points is above 12, 
        //the program should display License Suspended.
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the speed limit");
            int limit = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the speed of the car in mph");
            int speed = Convert.ToInt32(Console.ReadLine());

            int penalty = (speed - limit) / 5;

            if(speed > limit)
            {
                Console.WriteLine("You have violated the law, pay the " +
                                  "court a fine or serve your sentence. " +
                                  "Your stolen goods are now forfeit! \n" + penalty);
                if (penalty > 12)
                {
                    Console.WriteLine(penalty + ": License Suspended!");
                }

            }
            else
            {
                Console.WriteLine("Ok");
            }
            
        }
    }
}
