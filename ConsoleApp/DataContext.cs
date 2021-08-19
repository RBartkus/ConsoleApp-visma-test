using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp
{
    class DataContext
    {
        public List<Book> books { get; set; }
        protected List<TakenBook> libraryCard { get; set; }

        public DataContext()
        {
            loadBooks();
            List<TakenBook> tb = new List<TakenBook>();
            this.libraryCard = tb;
        }


        //Data Manipulation

        public void addBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book: '{book.Name}' added to library");
        }
        public void deleteBook(string name)
        {
            books.Remove(books.Find(book => book.Name == name));
            Console.WriteLine($"Book {name} is deleted!");
        }

        public void takeBook(string name,int days) {
           var book =  books.Find(book => book.Name == name);
            books.Find(book => book.Name == name).Taken =true;
            DateTime dueDate = DateTime.Today.AddDays(days);
            TakenBook takenBook = new  TakenBook(book, dueDate);
            libraryCard.Add(takenBook);

        }
        public void returnBook(string name) 
        {
            var book = libraryCard.Find(book => book.Name == name);
            if (book.RetunDate < DateTime.Today)
                Console.WriteLine("You are late!!!");
            libraryCard.Remove(book);
            books.Find(book => book.Name == name).Taken = false;
        }

        //Filters
        public List<Book> filterByName(string name) {
            return books.FindAll(b => b.Name.Contains(name));
        }
        public List<Book> filterByAuthor(string author) {
            return books.FindAll(b => b.Author.Contains(author));
        }
        public List<Book> filterByCategory(string category) {
            return books.FindAll(b => b.Category.Contains(category));
        }
        public List<Book> filterByLanguage(string language) {
            return books.FindAll(b => b.Language.Contains(language));
        }
        public List<Book> filterByIsbn(string isbn) {
            return books.FindAll(b =>b.ISBN.Contains(isbn));
        }
        public List<Book> filterByAvailibility(bool taken) {
            return books.FindAll(b => b.Taken.Equals(taken));
        }


        //Data Loading/Saving

        public void saveBooks()
        {
            
            try
            {
                File.WriteAllText(@"C:\Users\romas\Desktop\Console-App\ConsoleApp\ConsoleApp\Books.json", JsonConvert.SerializeObject(books, Formatting .Indented));
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex);
                throw;
            }
        }
        private void loadBooks()
        {
            try
            {

                using (StreamReader reader = new StreamReader(@"C:\Users\romas\Desktop\Console-App\ConsoleApp\ConsoleApp\Books.json"))
                {
                    string json = reader.ReadToEnd();
                    books = JsonConvert.DeserializeObject<List<Book>>(json);
                }
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex);
            }
        }
  

        //Hellpers
        public bool bookExists(string name)
        {
            return books.Any(book => book.Name == name);
        }

        public bool bookTaken(string name)
        {
            var book = books.Find(book => book.Name == name);
            if (book.Taken == false)
                return false;
            else
                return true;
        }

        public bool bookDue(int days)
        {
           DateTime today = DateTime.Today;
           var dueDate = today.AddDays(days);
            if (dueDate <= today.AddMonths(3))
                return true;
            else
                return false;
        }
        
        //Some how List.Count() method do not work :?
        public int sizeOfLibraryCard()
        {
            if (libraryCard == null)
                return 0;
            else { 
            int size = 0;
            foreach (var item in libraryCard)
            {
                size++;
            }
            return size;
            }
         }

       
    }
}
