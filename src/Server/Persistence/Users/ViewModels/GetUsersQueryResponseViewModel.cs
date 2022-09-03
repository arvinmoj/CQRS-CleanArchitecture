namespace Persistence.Users.ViewModels;
public class GetUsersQueryResponseViewModel : Object
{
    public GetUsersQueryResponseViewModel() : base()
    {
    }

    public Guid Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

}