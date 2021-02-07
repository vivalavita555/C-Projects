using System;
using System.Collections.Generic;
using System.Text;

namespace ConstructorsInheritance
{
    public class Vehicle
    {
        private readonly string _regNo;

        //public Vehicle()
        //{
        //    Console.WriteLine("Vehicle is being initialised");
        //}

        //Since the default constructor is commented out, Car object needs base keyword
    
        public Vehicle(string regNo)
        {
            _regNo = regNo;

            Console.WriteLine("Vehicle is being initalised " + regNo);
        }
    }
}
