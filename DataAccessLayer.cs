using System;
using System.IO;


using Bookstore;

namespace DAL{
      internal class FILEDAL
    {
          public void FILE_W(string t,string a,int id,double price)
        {
             StreamWriter sw = new StreamWriter("Books.txt",append:true);
            
            sw.WriteLine($"{t},{a},{id},{price}");

            Console.WriteLine("BOOK ADDED successfully");

        sw.Close();

        }

        public void back_up_FILE()
        {
            StreamWriter s1 = new StreamWriter("copy_Books.txt",append:true);
            StreamReader s2 = new StreamReader("Books.txt");

            string s = s2.ReadLine();
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
