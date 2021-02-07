using System;
using System.Collections.Generic;
using System.Text;

namespace Fields
{
    public class Customer
    {
        public int Id;
        public string Name;
        public List<Order> Orders = new List<Order>(); //12:15

        //public Customer()
        //{
        //    Orders = new List<Order>();
        //}
        public Customer(int id)
        {
            this.Id = id;
        }

        public Customer(int id, string name)
            : this(id)
        {
            this.Name = name;
        }

        public void Promote()
        {
            Orders = new List<Order>();
            //....
        }
    }
}
