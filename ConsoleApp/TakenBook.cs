using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class TakenBook:Book
    {
        public DateTime TakenDate { get; set; }
        public DateTime RetunDate { get; set; }

        public TakenBook(Book book, DateTime dueDate)
        {
            this.Author = book.Author;
            this.Name = book.Name;
            this.Category = book.Category;
            this.Language = book.Language;
            this.PublicationDate = book.PublicationDate;
            this.ISBN = book.ISBN;
            this.Taken = true;
            this.TakenDate = DateTime.Today;
            this.RetunDate = dueDate;
        }
    }
}
