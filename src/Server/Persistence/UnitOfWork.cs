namespace Persistence;

public class UnitOfWork :
    Infrastructure.Persistence.UnitOfWork<DatabaseContext>, IUnitOfWork
{
    public UnitOfWork
        (Infrastructure.Persistence.Options options) : base(options: options)
    {
    }

    // **************************************************
    private Users.Repositories.IUserRepository _users;

    public Users.Repositories.IUserRepository Users
    {
        get
        {
            if (_users == null)
            {
                _users =
                    new Users.Repositories.UserRepository(databaseContext: DatabaseContext);
            }

            return _users;
        }
    }
    // **************************************************
}