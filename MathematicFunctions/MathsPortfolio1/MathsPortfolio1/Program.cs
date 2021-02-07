using System;
using System.Collections.Generic;
using System.Linq;

namespace MathsPortfolio1
{
    class Program
    {
        static void Main(string[] args)
        {
            float[] samples = new float[] { 24f, 25f, 26.5f, 30f, 31f, 32f, 32.5f, 35f, 37f, 37f, 38.5f, 40f };

            float mean, median, mode;
            mean = GetMean(samples);
            median = GetMedian(samples);
            mode = GetMode(samples);

            float range, variance, stddev, mad;
            range = GetRange(samples);
            variance = GetVariance(samples, false);
            stddev = GetStdDev(samples, false);
            mad = GetMeanAbsDev(samples);

            float StdErrMean;
            StdErrMean = GetSEM(samples);

            
            Console.WriteLine("Mean, or average time to level:                   " + mean);
            Console.WriteLine("Median, or time taken by the most typical player: " + median);
            Console.WriteLine("Mode, or most common time taken:                  " + mode);
            Console.WriteLine();
            Console.WriteLine("Range, or difference between the shortest and longest time:                   " + range);
            Console.WriteLine("Variance, used to calculate Standard Deviation:                               " + variance);
            Console.WriteLine("Standard Deviation, or difference from mean, most samples fall within:        " + stddev);
            Console.WriteLine("Mean Absolute Deviation, or average difference between a sample and the mean: " + mad);
            Console.WriteLine();
            Console.WriteLine("Standard error of the mean: " + StdErrMean);
            Console.WriteLine("Confidence interval: 95% confidence that the true mean lies between\n " +
                (mean - StdErrMean * 1.96) + " and " + (mean + StdErrMean * 1.96));
            Console.ReadKey();
        }

        private static float GetSEM(float[] values)
        {
            //Standard Error of the Mean is ONLY used in samples because if you had the full population there would be no error to find.
            float stddev = GetStdDev(values, true);
            //To calculate the error we simply divide the Standard Deviation found earlier by the square root of the length of the sample.
            float StdErrMean = stddev / (float)Math.Sqrt(values.Length);
            return StdErrMean;   
        }

        private static float GetMeanAbsDev(float[] values)
        {
            //The Mean Absolute Deviation returns the absolute value of the difference from the mean
            float variance = 0;     //Note: the variance used here isn't the same as the one used in standard deviation
            float mean = GetMean(values);
            for (int i = 0; i < values.Length; i++)
            {
                variance += Math.Abs(values[i] - mean);     //Variance is the sum of each value's difference from the mean which is then absoluted (forced to be positive)
            }


            float mad = variance / values.Length;   //The Mean Absolute Deviation is similar to finding the mean. Just the sum of the abs differences divided by the length of the sample.
            return mad;   
        }

        private static float GetStdDev(float[] values, bool dataIsSampled)
        {
            //Standard Deviation is simply the square root of the variance we found earlier.
            float variance = GetVariance(values, dataIsSampled);
            float stddev = (float)Math.Sqrt(variance);
            return stddev;   
        }

        private static float GetVariance(float[] values, bool dataIsSampled)
        {
            //The purpose of variance is to tell us how far each value is from the mean, squares them and finally gets the average of those squares.
            float mean = GetMean(values);
            float variance = 0;

            for(int i = 0; i < values.Length; i++)
            {
                variance += (float)Math.Pow((values[i] - mean), 2);     //Checks each values difference from the mean, and then squares them.
            }
            if (dataIsSampled)
            {
                variance /= (values.Length - 1);
            }
            else
            {
                variance /= values.Length;  //Finds the average of the squares
            }

            return variance;   
        }

        private static float GetRange(float[] values)
        {
            //The range is very simple. Just subtract the smallest value from the largest value.
            float min = values[0];
            float max = values[values.Length - 1];  //Since arrays start at 0, the value at the end will be the number of values - 1.
            float range = max - min;
            return range;   
        }

        private static float GetMode(float[] values)
        {
            Dictionary<float, int> counts = new Dictionary<float, int>();
            
            //This loops counts the number of keys
            foreach(float value in values)
            {
                if (counts.ContainsKey(value))
                {
                    counts[value]++;
                }
                else
                {
                    counts[value] = 1;
                }
            }

            //This loop finds the most common key in the set of values, aka the mode.
            float mode = 0;
            int max = 0;
            foreach(float key in counts.Keys)
            {
                if(counts[key] > max)
                {
                    max = counts[key];
                    mode = key;
                }
            }

            return mode;   
        }

        private static float GetMedian(float[] values)
        {
            float median = 0;
            
            if(values.Length % 2 == 1)                                                      //If the number of values in the sample is odd...
            {
                median = values[values.Length / 2];                                         //The median is simply the middle value, so divide by two.
            }
            else                                                                            //But if the number of values in the sample is even...
            {
                median = (values[values.Length / 2 - 1] + values[values.Length / 2]) / 2;   //Then the median is the mean of the two middle numbers.
            }

            return median;   
        }

        private static float GetMean(float[] values)
        {
            float mean = 0;                             // The calulation of the mean
                                                        // is simply the sum of all
            foreach(float value in values)              // values in the sample
            {                                           // divided by the number of
                mean += value;                          // values in the sample.
            }                                           
            
            mean /= values.Length;
            return mean;   
        }
    }
}
