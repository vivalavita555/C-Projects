using System;
using System.Linq;

namespace ExtensionMethods
{
    public static class StringExtensions
    {
        public static string Shorten(this String str, int noOfWords)
        {
            if(noOfWords < 0)
                throw new ArgumentOutOfRangeException("noOfWords cannot be less than 0!");

            if(noOfWords == 0)
                return " ";
            
            var words = str.Split(' ');

            if (words.Length <= noOfWords)
                return str;
            

            return string.Join(" ", words.Take(noOfWords)) + "...";
        }
    }
}
