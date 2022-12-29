// AlexeyQwake Qwake

using Microsoft.EntityFrameworkCore;

namespace EFCoreLearn.Repos;

public class BookRepository
{
    public Book GetBookById(int id, AppContext db)
    {
        Book resultBook;

        resultBook = db.Books.FirstOrDefault(x => x.Id == id)!;


        return resultBook!;
    }

    public List<Book> GetAllBooks(AppContext db)
    {
        List<Book> booksList;

        booksList = db.Books.ToList();

        return booksList;
    }

    public void AddBook(Book book, AppContext db)
    {
        db.Books.Add(book);
    }

    public void DeleteBook(Book book, AppContext db)
    {
        db.Books.Remove(book);
    }

    public void UpdateBookYearById(int id, int year, AppContext db)
    {
        db.Books.FirstOrDefault(x => x.Id == id)!.IssueYear = year;
    }

    public List<Book> GetBookListByGenre(string genre, int startYear, int endYear, AppContext db)
    {
        var bookList = db.Books.Where(x => x.Genre == genre && x.IssueYear <= endYear && x.IssueYear >= startYear)
            .ToList();
        return bookList;
    }

    public int BookCountByAuthor(string author, AppContext db)
    {
        var bookCount = db.Books.Count(x => x.Author == author);
        return bookCount;
    }
    
    public int BookCountByGenre(string genre, AppContext db)
    {
        var bookCount = db.Books.Count(x => x.Genre == genre);
        return bookCount;
    }

    public bool CheckBook(string name, string author, AppContext db)
    {
        var flag = db.Books.Any(x => x.Name == name && x.Author == author);
        return flag;
    }

    public bool IsBookAvailable(Book book, AppContext db)
    {
        if (book.User != null)
        {
            return false;
        }

        return true;
    }



    public Book GetLastBook(AppContext db)
    {
        var maxIssueYear = db.Books.Max(x => x.IssueYear);

        var lastBook = db.Books.FirstOrDefault(x => x.IssueYear == maxIssueYear);

        return lastBook;
    }

    public List<Book> GetSortedBooksAlphabet(AppContext db)
    {
        var sortedBooks = db.Books.OrderBy(x => x.Name).ToList();
        return sortedBooks;
    }
    
    public List<Book> GetSortedBooksIssueYear(AppContext db)
    {
        var sortedBooks = db.Books.OrderByDescending(x => x.IssueYear).ToList();
        return sortedBooks;
    }
}