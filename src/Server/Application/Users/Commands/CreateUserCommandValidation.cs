using FluentValidation;

namespace Application.Users.Commands;
public class CreateUserCommandValidation : FluentValidation.AbstractValidator<Commands.CreateUserCommand>
{
    public CreateUserCommandValidation() : base()
    {

        RuleFor(current => current.Username)
             .NotEmpty()
            .WithMessage(errorMessage: Resources.ErrorMessages.Required)

            .MaximumLength(maximumLength: 100)
            .WithMessage(errorMessage: Resources.ErrorMessages.MaxLength)
            ;

        RuleFor(current => current.Password)
            .NotEmpty()
            .WithMessage(errorMessage: Resources.ErrorMessages.Required)

            .MaximumLength(maximumLength: 100)
            .WithMessage(errorMessage: Resources.ErrorMessages.MaxLength)
            ;

        RuleFor(current => current.Email)
            .NotEmpty()
            .WithMessage(errorMessage: Resources.ErrorMessages.Required)

            .MaximumLength(maximumLength: 100)
            .WithMessage(errorMessage: Resources.ErrorMessages.MaxLength)
            ;

    }
}