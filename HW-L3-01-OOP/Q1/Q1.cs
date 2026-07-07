namespace HW_L3;

// Represents one book object
class Book
{
    // Book information properties
    public string Title { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public bool IsAvailable { get; set; }

    // Initialize new book
    public Book(string title, string author, string isbn)
    {
        Title = title;
        Author = author;
        ISBN = isbn;
        IsAvailable = true;
    }
}

// Manages collection of books
class Library
{
    // Store all books
    private List<Book> books = new List<Book>();

    // Add book to library
    public void AddBook(Book book)
    {
        books.Add(book);
    }

    // Borrow available book
    public void BorrowBook(string title)
    {
        var book = books
            .FirstOrDefault(b => b.Title == title && b.IsAvailable);

        if (book != null)
        {
            book.IsAvailable = false;
            WriteLine(
                $"Book borrowed successfully!\n" +
                $"Title: {book.Title}\n" +
                $"Author: {book.Author}\n" +
                $"ISBN: {book.ISBN}\n" +
                $"Available: {book.IsAvailable}"
            );
        }
        else
        {
            WriteLine("Book is not available");
        }
    }

    // Return borrowed book
    public void ReturnBook(string title)
    {
        var book = books
            .FirstOrDefault(b => b.Title == title);

        if (book != null)
        {
            book.IsAvailable = true;
            WriteLine(
                $"Book returned successfully!\n" +
                $"Title: {book.Title}\n" +
                $"Author: {book.Author}\n" +
                $"ISBN: {book.ISBN}\n" +
                $"Available: {book.IsAvailable}"
            );
        }
    }
}

class Question1
{
    public static void Q1()
    {
        // Create library object
        Library library = new Library();

        // Create book objects
        Book book1 = new Book(
            "C# Basics",
            "John Smith",
            "12345"
        );

        Book book2 = new Book(
            "OOP Design",
            "David Lee",
            "67890"
        );

        // Add books to library
        library.AddBook(book1);
        library.AddBook(book2);

        // Borrow selected book
        library.BorrowBook("C# Basics");

        WriteLine();

        // Return selected book
        library.ReturnBook("C# Basics");
    }
}