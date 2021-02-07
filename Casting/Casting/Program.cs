using System;

namespace Casting
{
    class Program
    {
        static void Main(string[] args)
        {
            Text text = new Text();
            Shape shape = text; //We implicitly converted type shape to text
            text.Width = 200;
            shape.Width = 100;

            Console.WriteLine(text.Width); //Result will be 100 since both text and shape are both references to the same object thus the value will be the latest of the compilation (shape.Width = 100;)
        }
    }
}
