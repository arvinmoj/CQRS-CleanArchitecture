namespace Application;
public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile() : base()
    {
        CreateMap<Users.Commands.CreateUserCommand, Domain.Models.Users.User>();
        CreateMap<Domain.Models.Users.User, Users.Commands.CreateUserCommand>();
    }
}