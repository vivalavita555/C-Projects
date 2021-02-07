using System;
using System.Collections.Generic;

namespace Fields
{

    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1);
            customer.Orders.Add(new Order());
            customer.Orders.Add(new Order());

            customer.Promote(); //Accidentally initialises the orders making the output 0!
            
            Console.WriteLine(customer.Orders.Count);
        }
    }
}
