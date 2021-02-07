using System;

namespace Generics
{
    public class Utilities<T> where T : IComparable
    {
        public int Max(int a, int b) 
        {
            return a > b ? a : b;
        }

        public T Max<T>(T a, T b) 
        {
            return a.CompareTo(b) > 0 ? a : b;
        }
    }
}

/* The whole point of generics is so that we don't need to define the data type of a given object
 * however it's often times crucial to define the data type before performing any operations with the
 * object, this is where constraints come in! to define a contraint you're basically saying constrain
 * this object to just use that data type. To define one, at the end of the generic method (public T Max)
 * just put where *object* : *data type*
 *                     ^            ^
 *              in this case T   in this case IComparable
 * This includes any data type in existence, including Objects, Classes, Structures, Constructs, int, string etc...
*/