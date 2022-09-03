using FluentValidation;

namespace Application.Users.Queries;
public class GetUsersQueryValidator : FluentValidation.AbstractValidator<GetUsersQuery>
{
    public GetUsersQueryValidator() : base()
    {
        RuleFor(current => current.Count)
            .NotEmpty()
            .WithMessage(errorMessage: Resources.ErrorMessages.Required)

            .GreaterThan(valueToCompare: 0)
            .WithMessage(errorMessage: Resources.DataDictionary.ErrorMessage)

            .LessThan(valueToCompare: 101)
            .WithMessage(errorMessage: Resources.DataDictionary.ErrorMessage)
            ;
    }
}