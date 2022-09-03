namespace Application.Users.Commands;
public class CreateUserCommand : object, Infrastructure.Mediator.IRequest<Guid>
{
    public CreateUserCommand() : base()
    {
    }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }
}