using System;
using System.Collections.Generic;
using System.Text;

namespace MethodOverride
{
    public class Canvas
    {
        public void DrawShapes(List<Shape> shapes)
        {
            foreach(var shape in shapes)
            {
                shape.Draw(); //So since Circle and Rectangle are both shapes, either or could be drawn at one time. If a circle is drawn it uses its own Draw function derived by Method Overriding, same going for Rectangle and allows you to add any new shape types with minimal impact on the code, a sign of good code design. PolyMorphism! Poly meaning Same, Morph meaning Form.
            }
        }
    }
}
