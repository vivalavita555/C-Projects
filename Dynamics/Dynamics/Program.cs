using System;

namespace Dynamics
{
    class Program
    {
        static void Main(string[] args)
        {
            //With Reflection...
            object obj = "Brandawg";
            obj.GetHashCode();
            var methodInfo = obj.GetType().GetMethod("GetHashCode");
            methodInfo.Invoke(null, null);

            //With Dynamic...
            dynamic obj2 = "Brandawg";
            obj2.Optimize();

            //Dynamic Types are types that can change at runtime
            dynamic name = "bruh"; //Dynamic {string}
            name = 10; //Dynamic {int}
            //This code will successfully run because when name is given the value of 10, the type of name is changed to int
            //When changing from a dynamic type to a static type, if it will implicitly convert (like int to float or char to string) there is no need to cast
        }
    }
}
