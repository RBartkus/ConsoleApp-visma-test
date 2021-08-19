using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//

namespace ConsoleApp
{

    class Menu
    {
        DataContext data = new DataContext();
        public void runMenu()
        {
           
            while (true)
            {
                showMenu();
            }
        }
        private void showMenu()
        {
            Console.WriteLine("       Main Menu");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Press number to select command");
            Console.WriteLine("-------------------------");
            Console.WriteLine("1) Add New Book");
            Console.WriteLine("2) Take Book");
            Console.WriteLine("3) Return Book");
            Console.WriteLine("4) List All The Books");
            Console.WriteLine("5) Delete Book");
            Console.WriteLine("6) Save");
            Console.WriteLine("7) Quit and Save");
            Console.WriteLine("----------------------------------");


            switch (Console.ReadLine())
            {
                case "1":
                    addBookMenu();
                    break;
                case "2":
                    takeBookMenu();
                    break;
                case "3":
                    returnBookMenu();
                    break;
                case "4":
                    showAllBooksMenu();
                    break;
                case "5":
                    deleteBookMenu();
                    break;
                case "6":
                    data.saveBooks();
                    Console.WriteLine("Saved");
                    break;
                case "7":
                    data.saveBooks();
                   Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("no such command, try again...");
                    break;
            }
        }

        private void takeBookMenu()
        {
            Console.WriteLine("Book name: ");
            string name = Console.ReadLine();
            if (data.bookExists(name) == true && data.bookTaken(name) == false && data.sizeOfLibraryCard() < 4)
            {
                Console.WriteLine("For how many days: ");
                int days = Int32.Parse(Console.ReadLine());
                if (data.bookDue(days) == true) 
                {
                    data.takeBook(name,days);
                    Console.WriteLine($"Book {name} taken until {DateTime.Today.AddDays(days)}, have good read");
                }
           
                else
                    Console.WriteLine("Sorry, its to loong for book be gone");
            }
            else
                Console.WriteLine("Book with this name do not exist or taken");
        }
        private void returnBookMenu() 
        {

            if (data.sizeOfLibraryCard() != 0)
            {
                Console.WriteLine("Book name: ");
                string name = Console.ReadLine();
                data.returnBook(name);
            }
            else
                Console.WriteLine("Your library card is empty!");

        }
        private void addBookMenu() {
            Book newBook = new Book();
            Console.WriteLine("Book Name: ");
            newBook.Name = Console.ReadLine();
            Console.WriteLine("Book Author: ");
            newBook.Author = Console.ReadLine();
            Console.WriteLine("Book Category: ");
            newBook.Category = Console.ReadLine();
            Console.WriteLine("Book Language: ");
            newBook.Language = Console.ReadLine();
            Console.WriteLine("Book ISBN: ");
            newBook.ISBN = Console.ReadLine();
            Console.WriteLine("Book Publication Date(int): ");
            newBook.PublicationDate = Int32.Parse( Console.ReadLine());
            data.addBook(newBook);
            
        }
        
        
        private void showAllBooksMenu()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("1) List All Books");
                Console.WriteLine("2) List By Author");
                Console.WriteLine("3) List By Category");
                Console.WriteLine("4) List By ISBN");
                Console.WriteLine("5) List By Name");
                Console.WriteLine("6) List All Taken Books");
                Console.WriteLine("7) List All Availible Books");
                Console.WriteLine("8) Return To Main Menu");
                Console.WriteLine("----------------------------------");

                switch (Console.ReadLine())
                {
                    case "1":
                        printBooks(data.books);
                        break;
                    case "2":
                        Console.WriteLine("Enter Book Author: ");
                        printBooks(data.filterByAuthor(Console.ReadLine()));
                        break;
                    case "3":
                        Console.WriteLine("Enter Book Category: ");
                        printBooks(data.filterByCategory(Console.ReadLine()));
                        break;
                    case "4":
                        Console.WriteLine("Enter Book ISBN: ");
                        printBooks(data.filterByIsbn(Console.ReadLine()));
                        break;
                    case "5":
                        Console.WriteLine("Enter Book Name: ");
                        printBooks(data.filterByName(Console.ReadLine()));
                        break;
                    case "6":
                        printBooks(data.filterByAvailibility(true));
                        break;
                    case "7":
                        printBooks(data.filterByAvailibility(false));
                        break;

                    case "8":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("no such command, try again...");
                        break;
                }
            }
        }

        private void printBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"{book.Name} | {book.Author} | {book.PublicationDate} | {book.ISBN} | {book.Category} | Book is taken:{book.Taken}");
            }
        }

        private void deleteBookMenu() {
            Console.WriteLine("Enter book name: ");
            string name = Console.ReadLine();
            data.deleteBook(name);
        }

    }
}
