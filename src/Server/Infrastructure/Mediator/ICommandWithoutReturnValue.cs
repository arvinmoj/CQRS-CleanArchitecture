namespace Infrastructure.Mediator
{
    public interface ICommandWithoutReturnValue : MediatR.IRequest<FluentResults.Result>
    {
    }
}