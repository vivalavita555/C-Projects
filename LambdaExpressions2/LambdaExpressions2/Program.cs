using System;

//For this example we will return only books that cost less than $10 using both normal and lambda expressions

namespace LambdaExpressions2
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();
                                            //LAMBDA EXPRESSION//
            var cheapBooks = books.FindAll(b => b.Price < 10 /*IsCheaperThan10Dollars*/);

            foreach(var book in cheapBooks)
            {
                Console.WriteLine(book.Title);
            }
        }

        //static bool IsCheaperThan10Dollars(Book book)
        //{
        //    return book.Price < 10;
        //}
    }
}
