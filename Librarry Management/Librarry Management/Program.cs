using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarry_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            //create librarry manager
            LibrarryManager librarryManager = LibrarryManager.GetLibrarryManagerInstance();
            Console.WriteLine("Librarry Manager created.");

            //create a librarian
            Librarian librarian = new Librarian(1,"11111",new Person("admin",""),AccountStatus.Active,librarryManager);

            //add members
            Member mem1 = new Member(2, "22222", new Person("sunil", "yadav"), AccountStatus.Active, DateTime.Now, 0, librarryManager);
            bool member1 = librarian.AddMember(mem1);
            if(member1 == true)
            {
                Console.WriteLine("Member added ");
            }
            else
            {
                Console.WriteLine("Member not added ");
            }

            //add books
            List<string> authors = new List<string>();
            authors.Add("author1");
            authors.Add("author2");
            BookItem bookItem1 = new BookItem("learn c", "c programming", "English", 100, authors, 1);
            bool book1 = librarian.AddBookItem(bookItem1);
            if(book1 == true)
            {
                Console.WriteLine("book added");
            }
            BookItem bookItem2 = new BookItem("learn c", "c programming", "English", 100, authors, 2);
            bool book2 = librarian.AddBookItem(bookItem2);
            if (book2 == true)
            {
                Console.WriteLine("book added");
            }
            BookItem bookItem3 = new BookItem("learn c#", "c# programming", "English", 200, authors, 1);
            bool book3 = librarian.AddBookItem(bookItem3);
            if (book2 == true)
            {
                Console.WriteLine("book added");
            }


            //checkout book
            mem1.CheckOutBookItem(bookItem1);
            mem1.CheckOutBookItem(bookItem2);
            mem1.CheckOutBookItem(bookItem3);


            //return book
            mem1.ReturnBook(bookItem1);
            mem1.CheckOutBookItem(bookItem1);




            //search book by catalog
            Catalog cat = new Catalog(librarryManager);
            cat.SearchByTitle("learn c");
            cat.SearchByAuthor("author1");

            Console.ReadLine();
        }
    }
}
