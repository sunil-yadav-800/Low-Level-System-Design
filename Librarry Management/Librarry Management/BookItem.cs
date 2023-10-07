using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarry_Management
{
    public class BookItem : Book
    {
        private int _copyNo;
        private BookItemStatus _status = BookItemStatus.NotReserved;
        private int _memberId = 0;
        public BookItem(string title, string description, string language, int noOfPages, List<string> authors, int copyNo) : base(title, description, language, noOfPages, authors)
        {
            CopyNo = copyNo;
        }

        public int CopyNo { get => _copyNo; set => _copyNo = value; }
        public BookItemStatus Status { get => _status; set => _status = value; }
        public int MemberId { get => _memberId; set => _memberId = value; }
    }
}
