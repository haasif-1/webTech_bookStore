using System;
using DAL;
using System.IO;


namespace Bookstore
{
    // This class represents one book in the bookstore.
    // It stores the book's title, author, ID, and price, and it contains methods to save, read, update, and find books.
    internal class Book
    {
        // These private fields hold the values for one book.
        // They are not directly accessible from outside the class.
        private String title;
        private String author;
        private int id;

        private double price;


        // This constructor creates a Book object using the values passed in.
        // It is used when a user adds a new book or when the program reads data from the file.
        public Book(String title, String author, int id,double price)
        {
            this.title = title;
            this.author = author;
            this.id = id;
            this.price = price;

        }

        // Title property: lets us get or set the title value safely.
        public string Title
        {
            set
            {
                title = value; 
            }
            get
            {
                return title;
            }
        }
    
        // Author property: stores the writer of the book.
        public string Author
        {
            set
            {
                author = value;
            }
            get
            {
                return author;
            }
        }

        // Id property: identifies each book uniquely.
        public int Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }

        // Price property: stores the price as a decimal-like number.
        public double Price
        {
            set
            {
                price = value;

            }
            get{
                return price;
            }
        }
   
        // This method prints the details of one book to the console.
        // It is used when the program wants to show a book to the user.
        public void displayInfo()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Id: " + id);
            Console.WriteLine("Price: " + price);

            Console.WriteLine("===++++===");
        }

       // This method saves the current book into the file-based data store.
       // It creates a FILEDAL object and sends the book data to be written to Books.txt.
       public void SaveBook()
        {
            FILEDAL fileDAL = new FILEDAL();
            fileDAL.FILE_W(title, author, id, price);
        }


       // This method reads every row in the Books.txt file and turns each row into a Book object.
       // After reading all books, it returns a list containing them.
       public static List<Book> GetALLData(){
          List<Book> mybook = new List<Book>();
          StreamReader sr = new StreamReader("Books.txt");

          string line = sr.ReadLine();
        
          // Keep reading until there are no more lines left in the file.
          while(line != null){
              string[] arr = line.Split(',');

              // Each line is expected to look like: title,author,id,price
              Book book = new Book(arr[0],arr[1],int.Parse(arr[2]),double.Parse(arr[3]));

              mybook.Add(book);

              line = sr.ReadLine();
          }

          sr.Close();
          return mybook;

       }
  
       // This method searches for a book by its ID in the saved list.
       // If the ID matches, it returns that Book object. Otherwise it returns null.
       public static Book findByID(int id)
        {
            List<Book> mybook = GetALLData();

            foreach(Book b in mybook)
            {
                if(b.Id == id)
                {
                    return b;
                }
            }

            return null;
        }


        // This method updates an existing book when the user chooses the update option.
        // It loads all books, finds the matching ID, asks for new values, and rewrites the file.
        public static void UpdateBook(int id)
        {
            List<Book> mybook = GetALLData();

            // Loop through all books and find the one with the matching ID.
            for(int i=0;i<mybook.Count;i++)
            {
                if(mybook[i].Id == id)
                {
                    Console.WriteLine("Enter new Title");
                    string newTitle = Console.ReadLine();
                    mybook[i].Title = newTitle;

                    Console.WriteLine("Enter new Author");
                    string newAuthor = Console.ReadLine();
                    mybook[i].Author = newAuthor;

                    Console.WriteLine("Enter new Price");
                    double newPrice = double.Parse(Console.ReadLine());
                    mybook[i].Price = newPrice;

                    break;
                }
            }

            // Rewrite the file without appending so the updated list replaces the old data.
            StreamWriter sw = new StreamWriter("Books.txt",append:false);

            foreach(Book b in mybook)
            {
                sw.WriteLine($"{b.Title},{b.Author},{b.Id},{b.Price}");
            }

            sw.Close();

        }
    }
}