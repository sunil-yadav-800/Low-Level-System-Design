using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarry_Management
{
    public interface ISearch
    {
        List<BookItem> SearchByTitle(string title);
        List<BookItem> SearchByAuthor(string author);
    }
}
