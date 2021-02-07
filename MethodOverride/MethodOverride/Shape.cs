using System;
using System.Collections.Generic;
using System.Text;

namespace MethodOverride
{
    public class Shape
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Position Position { get; set; }

        public virtual void Draw()
        {

        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {
            //Any code specific to the circle itself
            //The algorithm for drawing a circle
            Console.WriteLine("Draw a circle");
        }
    }

    public class Rectangle : Shape
    {
        public override void Draw()
        {
            //Any code specific to the rectangle
            //The algorithm for drawing a rectangle
            Console.WriteLine("Draw a rectangle");

        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Draw a triangle");
        }

    }

    
}
