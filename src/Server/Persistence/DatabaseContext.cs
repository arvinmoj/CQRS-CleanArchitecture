using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class DatabaseContext : DbContext
{
    #region Constructor
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options: options)
    {
        Database.EnsureCreated();
    }
    #endregion / Constructor

    #region DbSet
    // Users
    public DbSet<Domain.Models.Users.User> Users { get; set; }
    #endregion / DbSet

    #region OnModelCreating 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    #endregion / OnModelCreating
}