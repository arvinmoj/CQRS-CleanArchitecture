namespace Persistence;
public interface IQueryUnitOfWork : Infrastructure.Persistence.IQueryUnitOfWork
{
    public Users.Repositories.IUserQueryRepository Users { get; }
}