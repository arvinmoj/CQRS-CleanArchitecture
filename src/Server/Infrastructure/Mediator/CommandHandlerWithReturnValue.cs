//namespace Infrastructure.Mediator
//{
//    public abstract class CommandHandlerWithReturnValue<TCommand, TValue> :
//        object, MediatR.IRequestHandler<TCommand, FluentResults.Result<TValue>>
//        where TCommand : ICommandWithoutReturnValue
//    {
//        public CommandHandlerWithReturnValue() : base()
//        {
//        }

//        public abstract
//            System.Threading.Tasks.Task
//            <FluentResults.Result<TValue>>
//            Handle(TCommand request, System.Threading.CancellationToken cancellationToken);
//    }
//}