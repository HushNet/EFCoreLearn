// AlexeyQwake Qwake

using Microsoft.EntityFrameworkCore;

namespace EFCoreLearn;

public class AppContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }


    public AppContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=TROETOCHIE\SQLEXPRESS03;database=EF; TrustServerCertificate=true;Integrated Security=SSPI;");
    }
}