using System;
using Bookstore;
using DAL;


namespace MAINprogram
{
      internal class MAINprogram
    {
           static void Main()
        {
              Console.WriteLine("Welcome to Bookstore");

              int id_N;

            while (true)
            {
                Console.WriteLine("===== HELLO FROM HaASIF =======");

           Console.WriteLine("1 TO ADD BOOK");
           Console.WriteLine("2 TO EXIT");
           Console.WriteLine("3 for VIEW ALL BOOKS");
           Console.WriteLine("4 for FIND BY ID");
           Console.WriteLine("5 FOR BACKUP");
           Console.WriteLine("6 FOR UPDATE");


              id_N = int.Parse(Console.ReadLine());
              Console.WriteLine("+++++++++++++");
              Console.WriteLine(" ");

              if(id_N == 2)
            {
                Console.WriteLine("BUH BYE");
                break;
            }
              else if(id_N == 1)
            {
                  Console.WriteLine("Enter Book Title");
                  string title = Console.ReadLine();

                  Console.WriteLine("Enter Book Author");
                  string author = Console.ReadLine();

                  Console.WriteLine("Enter Book ID");
                  int id = int.Parse(Console.ReadLine());

                  Console.WriteLine("Enter Book Price");
                  double price = double.Parse(Console.ReadLine());

                  Book book = new Book(title, author, id, price);
                  book.SaveBook();

            }
              
              else if(id_N == 3)
            {
                List<Book> booksDATA = Book.GetALLData();

                foreach(Book b in booksDATA)
                {
                    b.displayInfo();
                }
                
            }
            else if(id_N == 4)
            {
                Console.WriteLine("KINDLY ENTER BOOK ID");
                int S_id = int.Parse(Console.ReadLine());
                  Book foundBook = Book.findByID(S_id);

                  if(foundBook == null){
                    Console.WriteLine("NOTHING FOUND ");
                    break;
                  }

                  foundBook.displayInfo();
            }

            else if(id_N == 6)
            {
                Console.WriteLine("KINDLY ENTER BOOK ID FOR UPDATE");
                int S_id = int.Parse(Console.ReadLine());
                 Book.UpdateBook(S_id);
            }
            else if(id_N == 5)
            {
                 
                FILEDAL fileDAL = new FILEDAL();
                  fileDAL.back_up_FILE();
            }
              
              else
            {
                  Console.WriteLine("Invalid Input");
            }
            }

        }
    }
}