using System;
using System.Collections;
using System.Collections.Generic;

namespace Boxing
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new ArrayList();
            list.Add(1); //Int Value Type -> Can be Boxed
            list.Add("Brandon"); //String Reference Type -> Can't be Boxed
            list.Add(DateTime.Today); //Struct Value Type -> Can be Boxed

            /*var number = (int)list[1];*/ //Invalid Cast Exception (String is a reference type and cannot be cast)

            //var anotherList = new List<int>();
            //anotherList.Add();  //Won't throw exception!

            var names = new List<string>();
            names.Add(); //Type Safety and No Boxing
        }
    }
}
