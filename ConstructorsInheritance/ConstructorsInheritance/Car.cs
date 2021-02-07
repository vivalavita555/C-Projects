using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructorsInheritance
{
    public class Car : Vehicle
    {
        public Car(string regNo)
            :base(regNo)
        {
            Console.WriteLine("Car is being initalised " + regNo);
        }
    }
}
