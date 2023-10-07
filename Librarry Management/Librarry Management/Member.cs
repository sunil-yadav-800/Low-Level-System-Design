using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarry_Management
{
    public class Member : Account
    {
        private DateTime _dateOfMembership;
        private int _totalBookIssued;
        private LibrarryManager _librarryManager = null;
        public Member(int id, string password, Person person, AccountStatus status, DateTime dateOfMembership, int totalBookIssued, LibrarryManager librarryManager) : base(id, password, person, status)
        {
            Console.WriteLine("Member {0} created", Person.FirstName);
            _librarryManager = librarryManager;
            DateOfMembership = dateOfMembership;
            TotalBookIssued = totalBookIssued;
        }

        public DateTime DateOfMembership { get => _dateOfMembership; set => _dateOfMembership = value; }
        public int TotalBookIssued { get => _totalBookIssued; set => _totalBookIssued = value; }

        public bool CheckOutBookItem(BookItem bookItem)
        {
            if(TotalBookIssued == Constsnts.MAX_BOOK_ALLOWED)
            {
                Console.WriteLine("Member: {0} has already checkout maximum number of book, inorder to take another book member has to return the taken book",this.Person.FirstName);
                return false;
            }
            if (_librarryManager != null)
            {
                var bookItem1 = _librarryManager.Books.Find(item => item.CopyNo == bookItem.CopyNo);
                if (bookItem1 != null)
                {
                    if (bookItem1.Status == BookItemStatus.NotReserved)
                    {
                        _librarryManager.Books.Find(item => item.CopyNo == bookItem.CopyNo).Status = BookItemStatus.Reserved;
                        _librarryManager.Books.Find(item => item.CopyNo == bookItem.CopyNo).MemberId = this.Id;
                        TotalBookIssued += 1;
                        Console.WriteLine("book: {0} : checkout successfully by {1}", bookItem1.Title+" - "+bookItem1.CopyNo , this.Person.FirstName);
                        return true;
                    }
                    else
                    {
                        var userName = _librarryManager.Accounts.Find(item=>item.Id == this.Id).Person.FirstName;
                        Console.WriteLine("book: {0} : is already reserved/checkout by {1}", bookItem1.Title + " - " + bookItem1.CopyNo, userName);
                    }
                }
                else
                {
                    Console.WriteLine("BookItem: {0} not found in the librarry", bookItem1.Title + " - " + bookItem1.CopyNo);
                    return false;
                }
                
            }
            return false;
        }
        public bool ReserveBookItem(BookItem bookItem)
        {
            if (_librarryManager != null)
            {
                var bookItem1 = _librarryManager.Books.Find(item => item.CopyNo == bookItem.CopyNo);
                 if (bookItem == null)
                {
                    Console.WriteLine("BookItem: {0} not found in the librarry", bookItem1.Title + " - " + bookItem1.CopyNo);
                    return false;
                }
                else if (bookItem1 != null && bookItem1.Status == BookItemStatus.NotReserved)
                {
                    _librarryManager.Books.Find(item => item.CopyNo == bookItem.CopyNo).Status = BookItemStatus.Reserved;
                    _librarryManager.Books.Find(item => item.CopyNo == bookItem.CopyNo).MemberId = this.Id;
                    
                    Console.WriteLine("book: {0} has reserved by {1} whenever it will be available, we will inform you", bookItem1.Title + " - " + bookItem1.CopyNo, this.Person.FirstName);
                    return true;
                }
                else if (bookItem1 != null && bookItem1.Status == BookItemStatus.Reserved)
                {
                    var userName = _librarryManager.Accounts.Find(item => item.Id == this.Id).Person.FirstName;
                    Console.WriteLine("book: {0} : is already reserved/checkout by {1}", bookItem1.Title + " - " + bookItem1.CopyNo, userName);
                    return false;
                }
            }
            return false;
        }

        public bool ReturnBook(BookItem bookItem)
        {
            if (_librarryManager != null)
            {
                var bookItem1 = _librarryManager.Books.Find(item => item.CopyNo == bookItem.CopyNo);
                if (bookItem1 != null)
                {
                    _librarryManager.Books.Find(item => item.CopyNo == bookItem.CopyNo).Status = BookItemStatus.NotReserved;
                    _librarryManager.Books.Find(item => item.CopyNo == bookItem.CopyNo).MemberId = 0;
                    TotalBookIssued -= 1;
                    var userName = _librarryManager.Accounts.Find(item => item.Id == this.Id).Person.FirstName;
                    Console.WriteLine("book: {0} : is returned by {1}", bookItem1.Title + " - " + bookItem1.CopyNo, userName);
                    return true;
                }
                return false;
            }
            return false;

        }
    }
}
