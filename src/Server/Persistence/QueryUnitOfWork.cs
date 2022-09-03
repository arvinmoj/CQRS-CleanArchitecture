namespace Persistence;
public class QueryUnitOfWork :
    Infrastructure.Persistence.QueryUnitOfWork<QueryDatabaseContext>, IQueryUnitOfWork
{
    public QueryUnitOfWork(Infrastructure.Persistence.Options options) : base(options: options)
    {
    }

    // **************************************************
    private Users.Repositories.IUserQueryRepository _users;

    public Users.Repositories.IUserQueryRepository Users
    {
        get
        {
            if (_users == null)
            {
                _users =
                    new Users.Repositories.LogQueryRepository(databaseContext: DatabaseContext);
            }

            return _users;
        }
    }
    // **************************************************
}
