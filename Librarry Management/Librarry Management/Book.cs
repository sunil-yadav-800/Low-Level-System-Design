using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarry_Management
{
    public abstract class Book
    {
        private string _title;
        private string _description;
        private string _language;
        private int _noOfPages;
        private List<string> _authors;

        protected Book(string title, string description, string language, int noOfPages, List<string> authors)
        {
            Title = title;
            Description = description;
            Language = language;
            NoOfPages = noOfPages;
            Authors = authors;
        }

        public string Title { get => _title; set => _title = value; }
        public string Description { get => _description; set => _description = value; }
        public string Language { get => _language; set => _language = value; }
        public int NoOfPages { get => _noOfPages; set => _noOfPages = value; }
        public List<string> Authors { get => _authors; set => _authors = value; }
    }
}
