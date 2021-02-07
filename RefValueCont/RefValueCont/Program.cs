using System;

namespace RefValueCont
{
    public class Person
    {
        public int Age;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var number = 1;
            Increment(number);
            Console.WriteLine(number); //number will be 1 since it will disregard the Increment number

            var person = new Person() { Age = 20 };
            MakeOld(person);
            Console.WriteLine(person.Age); //Since both person variables point to the same object, they will combine properly
            Console.ReadKey();
        }
        public static void Increment(int number)
        {
            number += 10;
        }
        public static void MakeOld(Person person)
        {
            person.Age += 10;
        }
    }
}
