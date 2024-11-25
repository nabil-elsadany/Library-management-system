
using System;
namespace task3
{
    class Book
    {
        string title;
        string author;
        double ISBN;
        bool availability;

        public Book(string title = "NON", string author = "NON", double ISBN = 0, bool availability = true)
        {
            this.title = title;
            this.author = author;
            this.ISBN = ISBN;
            this.availability = availability;
        }

        public string getTitle() { return title; }

        public void tetTitle(string title) { this.title = title; }

        public string getAuthor() { return author; }

        public void setAuthor(string author) { this.author = author; }

        public double getISBN() { return ISBN; }

        public void setISBN(double ISBN) { this.ISBN = ISBN; }

        public bool getAvailability() { return availability; }

        public void setAvailability(bool availability) { this.availability = availability; }
    }

    class Library
    {
        List<Book> books = new List<Book>();

        public bool AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Book added successfully: Title: {book.getTitle()}, Author: {book.getAuthor()}, ISBN: {book.getISBN()}, Availability: {book.getAvailability()}.");
            return true;
        }

        public Book SearchBook(string title)
        {
            Book book = new Book();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].getTitle() == title)
                {


                    Console.WriteLine($"the book {book.getTitle()} is hear ");
                    return book;
                }
                else
                {
                    Console.WriteLine("book is not hear");
                    return null;
                }

            }
            return null;

        }

        public bool BorrowBook(string title)
        {
            Book book = SearchBook(title);
            if (book != null && book.getAvailability())
            {
                book.setAvailability(false);
                Console.WriteLine($"You borrowed the book: {book.getTitle()}");
                return true;
            }
            Console.WriteLine($"The book '{title}' is not available for borrowing.");
            return false;
        }

        public bool ReturnBook(string title)
        {
            Book book = SearchBook(title);
            if (book != null && !book.getAvailability())
            {
                book.setAvailability(true);
                Console.WriteLine($"You returned the book: {book.getTitle()}");
                return true;
            }
            Console.WriteLine($"The book '{title}' was not borrowed or doesn't exist.");
            return false;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Library library = new Library();

            // Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", 9780743273565));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", 9780061120084));
            library.AddBook(new Book("1984", "George Orwell", 9780451524935));

            // Searching and borrowing books
            Console.WriteLine("Borrowing books...");
            library.BorrowBook("The Great Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library

            // Returning books
            Console.WriteLine("Returning books...");
            library.ReturnBook("The Great Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed

            Console.ReadLine();
        }
    }
}

