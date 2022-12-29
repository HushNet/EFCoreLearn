

using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace EFCoreLearn;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Email { get; set; }
    public string Role { get; set; }

    public List<Book>? Books { get; set; }

    public User()
    {
        Books = new List<Book>();
    }

}