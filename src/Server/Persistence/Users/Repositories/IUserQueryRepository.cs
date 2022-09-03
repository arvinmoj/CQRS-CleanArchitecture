namespace Persistence.Users.Repositories;
public interface IUserQueryRepository : Infrastructure.Persistence.IQueryRepository<Domain.Models.Users.User>
{
    Task<IList<ViewModels.GetUsersQueryResponseViewModel>> GetSomeAsync(int count);
}