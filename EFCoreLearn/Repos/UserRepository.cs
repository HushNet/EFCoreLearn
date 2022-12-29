// AlexeyQwake Qwake

namespace EFCoreLearn.Repos;

public class UserRepository
{
    public User GetUserById(int id, AppContext db)
    {
        User resultUser;
        resultUser = db.Users.FirstOrDefault(x => x.Id == id)!;

        return resultUser!;
    }

    public List<User> GetAllUsers(AppContext db)
    {
        List<User> userList;

        userList = db.Users.ToList();


        return userList;
    }

    public void AddUser(User user, AppContext db)
    {
        db.Users.Add(user);
    }

    public void DeleteUser(User user, AppContext db)
    {
        db.Users.Remove(user);
    }

    public void UpdateUserNameById(int id, string name, AppContext db)
    {
        db.Users.FirstOrDefault(x => x.Id == id)!.Name = name;
    }

    public void SetBookUser(User user, Book book, AppContext db)
    {
        user.Books.Add(book);
        book.User = user;
    }
    
    public int GetUserBooksCount(User user)
    {
        var count = user.Books.Count();
        return count;
    }
}