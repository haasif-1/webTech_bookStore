using System;
using System.IO;


using Bookstore;

namespace DAL{
      // This class handles file-based data storage for the bookstore.
      // It writes new books to Books.txt and copies the file contents to copy_Books.txt as a backup.
      internal class FILEDAL
    {
          // This method saves a single book as a comma-separated line in the Books.txt file.
          // Each line stores: title, author, id, and price.
          public void FILE_W(string t,string a,int id,double price)
        {
             // append:true means new records are added without deleting the earlier ones.
             StreamWriter sw = new StreamWriter("Books.txt",append:true);
            
            // Each book is stored on one line in a simple CSV-like format.
            sw.WriteLine($"{t},{a},{id},{price}");

            Console.WriteLine("BOOK ADDED successfully");

        // Always close the file after writing so the data is properly saved.
        sw.Close();

        }

        // This method creates a backup by reading all lines from Books.txt and writing them to copy_Books.txt.
        public void back_up_FILE()
        {
            // append:true keeps all backup data instead of overwriting the file every time.
            StreamWriter s1 = new StreamWriter("copy_Books.txt",append:true);
            StreamReader s2 = new StreamReader("Books.txt");

            // Read the first line from the source file.
            string s = s2.ReadLine();
            // Keep reading until there are no more lines left.
            while(s != null)
            {
                s1.WriteLine(s);
                s = s2.ReadLine();
            }

            s1.Close();
            s2.Close();


        }
    }
}
