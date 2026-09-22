using System;
using DAL;
using System.IO;


namespace Bookstore
{
    internal class Book
    {
        private String title;
        private String author;
        private int id;

        private double price;


        public Book(String title, String author, int id,double price)
        {
            this.title = title;
            this.author = author;
            this.id = id;
            this.price = price;

        }

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
   
        public void displayInfo()
        {
            Console.WriteLine("Title: " + title);
            Console.WriteLine("Author: " + author);
            Console.WriteLine("Id: " + id);
            Console.WriteLine("Price: " + price);

            Console.WriteLine("===++++===");
        }

       public void SaveBook()
        {
            FILEDAL fileDAL = new FILEDAL();
            fileDAL.FILE_W(title, author, id, price);
        }


       public static List<Book> GetALLData(){
          List<Book> mybook = new List<Book>();
          StreamReader sr = new StreamReader("Books.txt");

          string line = sr.ReadLine();
        
          while(line != null){
              string[] arr = line.Split(',');

              Book book = new Book(arr[0],arr[1],int.Parse(arr[2]),double.Parse(arr[3]));

              mybook.Add(book);

              line = sr.ReadLine();
          }

          sr.Close();
          return mybook;

       }
  
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


        public static void UpdateBook(int id)
        {
            List<Book> mybook = GetALLData();

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

            StreamWriter sw = new StreamWriter("Books.txt",append:false);

            foreach(Book b in mybook)
            {
                sw.WriteLine($"{b.Title},{b.Author},{b.Id},{b.Price}");
            }

            sw.Close();

        }
    }
}