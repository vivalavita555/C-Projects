using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new BookRepository().GetBooks();
            //Without LINQ
            //var cheapBooks = new List<Book>();
            //foreach(var book in books)
            //{
            //    if (book.Price < 10)
            //    {
            //        cheapBooks.Add(book);
            //    }
            //}
            //============================= WITH LINQ =====================================
            //LINQ Query Operators
            var cheaperBooks =      // _
                from b in books     //  \ 
                where b.Price < 10  //   > this is the Operator Equivelant to the below LINQ Method
                orderby b.Title     //  /
                select b.Title;     // ‾

            //LINQ Extension Methods ======================================================
            var cheapBooks = books //It's conventional to list your LINQ statements like so:
                                  .Where(book => book.Price < 10)
                                  .OrderBy(book => book.Title);
            foreach(var book in cheapBooks)
            {
                Console.WriteLine(book.Title + " || £" + book.Price);
            }
        }
    }
}


