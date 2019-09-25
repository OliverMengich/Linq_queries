using System;
using System.Linq;
using System.Collections.Immutable;
 using System.Collections.Generic;

namespace LINQ_QUERIES
{
    class Program
    {
        public delegate void MyDelegate();
        
            
        public static event MyDelegate OnMyDelegate;
        public static void OnClick(object e, EventArgs args)
        {

        }
        static void Main(string[] args)
        {
            
            var Books = new BookRepository().GetBooks();
            var cheapBooks = new List<Book>();
            foreach (var book in Books)
            {
                 if (book.Price < 3)
                 cheapBooks.Add(book);
            }
            // foreach (var book in cheapBooks)
            // {
            //    System.Console.WriteLine(book.Title+" " + book.Price);
            // }
            // Now we use the Concept Of Linq queries
            var Books1 = new BookRepository().GetBooks();
            var cheapBooks1 = Books.Where(book =>book.Price <3).OrderBy(book => book.Title).Select(book => book.Title);
            foreach (var book in cheapBooks1)
            {
                System.Console.WriteLine(book);
            }
            // Linq Query Operators
            var cheapBooks2 = from  book  in Books where book.Price < 3 orderby book.Title
            select book;
            foreach (var bookkss in cheapBooks2)
            {
                Console.WriteLine("Price is " + bookkss.Price + " Book Title is " + bookkss.Title);
            }

            var Books2 = new BookRepository().GetBooks();
            var result = Books2.Skip(2).Take(3);
            foreach( var book in result)
            {
                System.Console.WriteLine("Book = "+ book.Title);
            }
            // var result1 = Books2.Single(book => book.Title == "Book2");
            var result2 = Books2.SingleOrDefault(book =>book.Title == "Book2++");
            if (result2 == null)System.Console.WriteLine("Book not found"); else
            System.Console.WriteLine("Result2 is "+ result2.Title);

            // var result3 = Books2.First(book=> book.Title == "Book 4");
             var result4 = Books2.FirstOrDefault(book=> book.Title == "Book4");
            //  var result5 = Books2.Last(book => book.Title == "Book4");
             var result5 = Books2.LastOrDefault(book=> book.Title == "Book6");
             var result6 = Books2.Max(book => book.Price); 
             var result7 = Books2.Min(book=> book.Price);
             var result8 = Books2.Sum(book=> book.Price);
             var result9 = Books2.Average(book => book.Price);
             
        }
    }
    class Book
    {   

        public string Title{ get;set;}
        public float Price {get; set;}
    }
     class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
              return new List<Book>
              {
                  new Book() {Title = "Book1",Price = 1},
                  new Book() {Title = "Book2" , Price = 2},
                  new Book() {Title = "Book3", Price = 3},
                  new Book() {Title = "Book4", Price = 4},
                  new Book() {Title = "Book5", Price = 5} 
              };
        }
    }
}
