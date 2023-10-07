using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarry_Management
{
    public class Librarian : Account
    {
        private LibrarryManager _librarryManager = null;
        public Librarian(int id, string password, Person person, AccountStatus status, LibrarryManager librarryManager) : base(id, password, person, status)
        {
            Console.WriteLine("Librarian {0} added",Person.FirstName);
            _librarryManager = librarryManager;
        }
        //librarian can add book
        public bool AddBookItem(BookItem bookItem)
        {
            if(_librarryManager != null)
            {
                return _librarryManager.AddBookItem(bookItem);
            }
            return false;
        }
        //can add member
        public bool AddMember(Member member)
        {
            if (_librarryManager != null)
            {
                return _librarryManager.AddMember(member);
            }
            return false;
        }

        //also can block and unblock a member
    }
}
