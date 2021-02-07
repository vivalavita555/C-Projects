using System.IO;

namespace AbstractClasses
{
    public class Rectangle : Shape
    {
        public override void Draw()
        {
            System.Console.WriteLine("Draw a rectangle");
        }
    }
     class Program
    {
        static void Main(string[] args)
        {
            var circle = new Circle();
            circle.Draw();

            var rectangle = new Rectangle();
            rectangle.Draw();
        }
    }
}
