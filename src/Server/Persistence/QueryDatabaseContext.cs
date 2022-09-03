using Microsoft.EntityFrameworkCore;

namespace Persistence;
public class QueryDatabaseContext : DbContext
{
    #region Constructor
    public QueryDatabaseContext(DbContextOptions<QueryDatabaseContext> options) : base(options: options)
    {
        Database.EnsureCreated();
    }
    #endregion / Constructor

    #region DbSet
    public DbSet<Domain.Models.Users.User> Users { get; set; }
    #endregion / DbSet

    #region OnModelCreating
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
    #endregion / OnModelCreating
}
