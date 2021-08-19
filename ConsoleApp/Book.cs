using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        public int PublicationDate { get; set; }
        public string ISBN { get; set; }
        public bool Taken { get; set; }

        public Book()
        {
            this.Taken = false;
        }
        public Book(string name,string author,string category,string language,int publicationDate, string isbn)
        {
            this.Author = author;
            this.Name = name;
            this.Category = category;
            this.Language = language;
            this.PublicationDate = publicationDate;
            this.ISBN = isbn;
            this.Taken = false;
        }
    }



}

