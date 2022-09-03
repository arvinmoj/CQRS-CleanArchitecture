using Persistence.Users.ViewModels;
namespace Application.Users.Queries;

public class GetUsersQuery : Object, Infrastructure.Mediator.IRequest<IEnumerable<GetUsersQueryResponseViewModel>>
{
    public GetUsersQuery()
    {
    }

    public int? Count { get; set; }
}