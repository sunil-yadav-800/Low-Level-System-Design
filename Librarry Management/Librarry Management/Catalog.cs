using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarry_Management
{
    public class Catalog : ISearch
    {
        private LibrarryManager _librarryManager = null;
        public Catalog(LibrarryManager librarryManager)
        {
            _librarryManager = librarryManager;
        }
        public List<BookItem> SearchByAuthor(string author)
        {
            List<BookItem> bookItems = null;
            try
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Books with author: {0}", author);
                if (_librarryManager != null)
                {
                    bookItems = _librarryManager.Books.FindAll(item=>item.Authors.Contains(author));
                    foreach(var book in bookItems)
                    {
                        var authors = string.Join(", ",book.Authors);
                        Console.WriteLine("{0} by {1}",book.Title,authors);
                    }
                }
               
            }
            catch (Exception ex)
            {

            }
            return bookItems;
        }

        public List<BookItem> SearchByTitle(string title)
        {
            List<BookItem> bookItems = null;
            try
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("Books with title: {0}", title);
                if (_librarryManager != null)
                {
                    bookItems = _librarryManager.Books.FindAll(item => item.Title == title);
                    foreach (var book in bookItems)
                    {
                        var authors = string.Join(", ", book.Authors);
                        Console.WriteLine("{0} by {1}", book.Title, authors);
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return bookItems;
        }
    }
}
