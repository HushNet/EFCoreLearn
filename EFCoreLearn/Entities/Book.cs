// AlexeyQwake Qwake

namespace EFCoreLearn;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public int IssueYear { get; set; }
    public string? Author { get; set; }
    public string? Genre { get; set; }
    
    public User? User { get; set; }
}