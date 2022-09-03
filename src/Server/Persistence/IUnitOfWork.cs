namespace Persistence
{
    public interface IUnitOfWork : Infrastructure.Persistence.IUnitOfWork
    {
        public Users.Repositories.IUserRepository Users { get; }
    }
}
