using Microsoft.EntityFrameworkCore;

namespace Persistence.Users.Repositories;
public class UserRepository :
    Infrastructure.Persistence.Repository<Domain.Models.Users.User>, IUserRepository
{
    protected internal UserRepository(DbContext databaseContext) : base(databaseContext: databaseContext)
    {
    }
}