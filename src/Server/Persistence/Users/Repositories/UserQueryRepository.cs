using Microsoft.EntityFrameworkCore;

namespace Persistence.Users.Repositories;
public class LogQueryRepository :
    Infrastructure.Persistence.QueryRepository<Domain.Models.Users.User>, IUserQueryRepository
{
    public LogQueryRepository(QueryDatabaseContext databaseContext) : base(databaseContext)
    {
    }

    public async Task<IList<ViewModels.GetUsersQueryResponseViewModel>> GetSomeAsync(int count)
    {
        var result = await DbSet
        .Skip(count: 0)
        .Take(count: count)
        .Select(current => new ViewModels.GetUsersQueryResponseViewModel()
        {
            Id = current.Id,
            Username = current.Username,
            Password = current.Password,
            Email = current.Email,

        })
        .ToListAsync();
        return result;
    }
}
