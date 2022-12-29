using EFCoreLearn;
using EFCoreLearn.Repos;
using AppContext = EFCoreLearn.AppContext;

using (var db = new AppContext())
{
    UserRepository userRepository = new UserRepository();
    BookRepository bookRepository = new BookRepository();

    var user1 = new User { Name = "Arthur", Role = "Admin" };
    var user2 = new User { Name = "Bob", Role = "Admin" };
    var user3 = new User { Name = "Clark", Role = "User" , Email = "df@mail.ru"};

    var book1 = new Book() {Name = "WarAndPiece", IssueYear = 1867, Author = "Lev Tolstoi", Genre = "Roman"};
    var book2 = new Book() {Name = "Abradabra", IssueYear = 1999, Author = "Pushkin", Genre = "Drama"};
    var book3 = new Book() {Name = "Kalamala", IssueYear = 3001, Author = "Kushkevich", Genre = "Roman"};
    var book4 = new Book() {Name = "Burabi", IssueYear = 1888, Author = "Lev Tolstoi", Genre = "Boevik"};
    
    userRepository.AddUser(user1, db);
    userRepository.AddUser(user2, db);
    userRepository.AddUser(user3, db);
    
    
    bookRepository.AddBook(book1, db);
    bookRepository.AddBook(book2, db);
    bookRepository.AddBook(book3, db);
    bookRepository.AddBook(book4, db);
    
    db.SaveChanges();
    userRepository.SetBookUser(user1, book1, db);
    userRepository.SetBookUser(user1, book2, db);
    userRepository.SetBookUser(user3, book3, db);
    userRepository.SetBookUser(user3, book4, db);
    db.SaveChanges();

    Console.WriteLine(bookRepository.CheckBook("WarAndPiece", "Lev Tolstoi", db));
    Console.WriteLine(bookRepository.GetAllBooks(db)[3].Genre);
    Console.WriteLine(bookRepository.GetLastBook(db).Name);
    Console.WriteLine(bookRepository.IsBookAvailable(book1, db));
    Console.WriteLine(bookRepository.IsBookAvailable(book4, db));
    Console.WriteLine(bookRepository.BookCountByAuthor("Lev Tolstoi", db));
    Console.WriteLine(bookRepository.BookCountByGenre("Roman", db));
    
    var books = bookRepository.GetSortedBooksAlphabet(db);
    for (int i = 0; i < books.Count; i++)
    {
        Console.WriteLine(books[i].Name);
    }

    Console.WriteLine();
    Console.WriteLine();

    var books2 = bookRepository.GetSortedBooksIssueYear(db);

    for (int i = 0; i < books2.Count; i++)
    {
        Console.WriteLine(books2[i].Name);
    }

    Console.WriteLine(userRepository.GetUserBooksCount(user1));
    Console.WriteLine(userRepository.GetUserBooksCount(user3));

}