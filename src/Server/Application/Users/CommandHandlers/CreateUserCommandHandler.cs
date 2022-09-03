using FluentResults;

namespace Application.Users.CommandHandlers;
public class CreateUserCommandHandler : Object, Infrastructure.Mediator.IRequestHandler<Commands.CreateUserCommand, Guid>
{
    public CreateUserCommandHandler(AutoMapper.IMapper mapper, Persistence.IUnitOfWork unitOfWork) : base()
    {
        Mapper = mapper;
        UnitOfWork = unitOfWork;
    }

    protected AutoMapper.IMapper Mapper { get; }
    protected Persistence.IUnitOfWork UnitOfWork { get; }

    public async Task<FluentResults.Result<System.Guid>> Handle(Commands.CreateUserCommand request, CancellationToken cancellationToken)
    {
        var result =
            new FluentResults.Result<System.Guid>();

        try
        {
            // **************************************************
            var log = Mapper.Map<Domain.Models.Users.User>(source: request);
            // **************************************************

            // **************************************************
            await UnitOfWork.Users.InsertAsync(entity: log).ConfigureAwait(true);

            await UnitOfWork.SaveAsync().ConfigureAwait(true);
            // **************************************************

            // **************************************************
            result.WithValue(value: log.Id);

            string successInsert =
                string.Format(Resources.DataDictionary.IsSuccessful, nameof(Domain.Models.Users.User));

            result.WithSuccess
                (successMessage: successInsert);
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