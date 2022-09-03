using Persistence.Users.ViewModels;

namespace Application.Users.QueryHandlers;
public class GetUsersQueryHandler : Object, Infrastructure.Mediator.IRequestHandler<Queries.GetUsersQuery, IEnumerable<GetUsersQueryResponseViewModel>>
{
    public GetUsersQueryHandler(AutoMapper.IMapper mapper, Persistence.IQueryUnitOfWork unitOfWork) : base()
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    protected AutoMapper.IMapper Mapper { get; }
    protected Persistence.IQueryUnitOfWork UnitOfWork { get; }

    public async Task<FluentResults.Result
        <IEnumerable<Persistence.Users.ViewModels.GetUsersQueryResponseViewModel>>>
            Handle(Queries.GetUsersQuery request, System.Threading.CancellationToken cancellationToken)
    {
        var result =
            new FluentResults.Result
            <System.Collections.Generic.IEnumerable
            <Persistence.Users.ViewModels.GetUsersQueryResponseViewModel>>();

        try
        {
            // **************************************************
            var logs =
                await UnitOfWork.Users
                .GetSomeAsync(count: request.Count.Value).ConfigureAwait(true);
            // **************************************************

            // **************************************************
            result.WithValue(value: logs);
            // **************************************************
        }
        catch (System.Exception ex)
        {
            //Logger.LogError
            //    (exception: ex, message: ex.Message);

            result.WithError
                (errorMessage: ex.Message);
        }

        return result;
    }
}