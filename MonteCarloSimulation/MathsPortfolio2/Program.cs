using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsPortfolio2
{
    public class Program
    {
        const int numberOfLayouts = 50;
        static int[] roomsPerLevelLayout = new int[numberOfLayouts]
        {   10, 10, 10, 10, 11, 11, 12, 12, 12, 13,
            14, 14, 14, 14, 14, 14, 14, 15, 15, 15,
            15, 16, 16, 16, 16, 17, 17, 17, 18, 18,
            18, 18, 19, 19, 20, 20, 20, 20, 20, 21,
            22, 22, 22, 23, 23, 24, 24, 26, 27, 30
        };

        const int numberOfRooms = 120;
        static int[] coinsPerRoom = new int[numberOfRooms]
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
            3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
            3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
            4, 4, 4, 4, 4, 4, 4, 4, 4, 4,
            5, 5, 5, 5, 5, 6, 6, 6, 6, 6,
            7, 7, 7, 7, 8, 8, 8, 9, 9, 10
        };

        static Random rng = new Random();
        static int coinsOnCurrentLevel = 0;
        static int numberOfSimulations = 10000000;

        static void Main(string[] args)
        {
            CalculateAllPermutations();
            Console.WriteLine("\n\nRunning simulation, " + numberOfSimulations + " iterations, please wait...");
            RunSimulation();
            Console.ReadKey();
        }

        private static void CalculateAllPermutations()
        {
            double[] permutationsPerLayout = new double[numberOfRooms];
            Console.WriteLine("Number of permutations possible, by layout type:");
            for (int i = 0; i < numberOfLayouts; i++)
            {
                permutationsPerLayout[i] = CalculatePermutations(roomsPerLevelLayout[i], numberOfRooms);
                Console.WriteLine("Layout number: " + i + "     " + permutationsPerLayout[i].ToString("e1"));      // Print each permutation to the console in scientific notation

                if (i % 4 == 3) Console.WriteLine();
            }
        }

        static double Factorial(int n)
        {
            double factorial = 1;           // A simple Factorial calculating algorithm
            for (int i = n; i > 0; i--)
                factorial *= i;
            return factorial;
        }

        private static double CalculatePermutations(int sample, int objects)
        {
            double permutations = Factorial(sample) / (Factorial(sample - objects));        // The equation for calculating permutations
            return permutations;
        }

        private static void generateLevel(int levelLayoutType)
        {
            bool[] roomUsed = new bool[numberOfRooms];
            coinsOnCurrentLevel = 0;
            for (int i = 0; i < roomsPerLevelLayout[levelLayoutType]; i++)
            {
                int roomSelected = 0;
                do
                {
                    roomSelected = rng.Next(numberOfRooms);
                } while (roomUsed[roomSelected] == true);
                coinsOnCurrentLevel += coinsPerRoom[roomSelected];
            }
        }

        private static void RunSimulation()
        {
            int maxValue = 0;
            double averageValue;
            int runningTotal = 0;
            for(int i = 0; i < numberOfSimulations; i++)
            {
                int rngLayout = rng.Next(0, numberOfLayouts);   // A random layout is chosen each iteration.
                generateLevel(roomsPerLevelLayout[rngLayout]);
                
                if(coinsOnCurrentLevel > maxValue)              // A simple Find Maximum algorithm to find the layouts with most possible coins
                {
                    maxValue = coinsOnCurrentLevel;
                }
                runningTotal += coinsOnCurrentLevel;
            }
            averageValue = (double)runningTotal / numberOfSimulations;
            Console.WriteLine("\nThe average value of coins is: " + averageValue);          //Print results to console
            Console.WriteLine("The maximum value per simulation is: " + maxValue);
            Console.WriteLine("The total coins per simulation is: " + runningTotal);
            Console.WriteLine("\nRatio of average maximum:");
            Console.WriteLine(averageValue / maxValue + ", or " +
                             (averageValue / maxValue * 100).ToString("f1") + "%, or " +
                   Math.Round(averageValue / maxValue * 10) + "/10ths");
        }
    }
}
