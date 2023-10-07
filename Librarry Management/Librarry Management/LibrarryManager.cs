using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarry_Management
{
    public class LibrarryManager
    {
        private List<BookItem> _books = new List<BookItem>();
        private List<Account> _accounts = new List<Account>();
        private static LibrarryManager _librarryManager = null;
        private LibrarryManager()
        {
        }
        public List<BookItem> Books { get => _books; set => _books = value; }
        public List<Account> Accounts { get => _accounts; set => _accounts = value; }
        public static LibrarryManager GetLibrarryManagerInstance()
        {
            if (_librarryManager == null)
            {
                _librarryManager = new LibrarryManager();
            }
            return _librarryManager;
        }
        public bool AddBookItem(BookItem bookItem)
        {
            try
            {
                Books.Add(bookItem);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool AddMember(Member member)
        {
            try
            {
                Accounts.Add(member);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

    }
}
