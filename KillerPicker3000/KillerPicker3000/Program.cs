using System;

namespace KillerPicker3000
{
    class Program
    {
        static void Main(string[] args)
        {
            var killer = new string[19];
            killer[0] = "Trapper [B]";
            killer[1] = "Hillbillly [S]";
            killer[2] = "Wraith [C]";
            killer[3] = "Nurse [S]";
            killer[4] = "Huntress [A]";
            killer[5] = "Oni [B]";
            killer[6] = "Legion [C]";
            killer[7] = "Clown [F]";
            killer[8] = "Michael [B]";
            killer[9] = "Freddy [B]";
            killer[10] = "Pig [D]";
            killer[11] = "Demogorgon [C]";
            killer[12] = "Deathslinger [C]";
            killer[13] = "Plague [B]";
            killer[14] = "Spirit [S]";
            killer[15] = "Bubba [B]";
            killer[16] = "Ghostface [A]";
            killer[17] = "Doctor [B]";
            killer[18] = "Hag [B]";
            Random rnd = new Random();
            
            int i = rnd.Next(0, 18);
            Console.WriteLine("You need to play: "+killer[i]);
            Console.ReadLine();
        }
    }
}
