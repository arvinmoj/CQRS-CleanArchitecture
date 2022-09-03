namespace Application;
internal static class Utility
{
    static Utility()
    {
    }

    public static async Task<FluentResults.Result<TValue>> Validate<TCommand, TValue>
        (FluentValidation.AbstractValidator<TCommand> validator, TCommand command)
    {
        FluentResults.Result<TValue> result = new FluentResults.Result<TValue>();

        FluentValidation.Results.ValidationResult
            validationResult = await validator.ValidateAsync(instance: command).ConfigureAwait(true);

        if (validationResult.IsValid == false)
        {
            foreach (var error in validationResult.Errors)
            {
                result.WithError(errorMessage: error.ErrorMessage);
            }
        }

        return result;
    }
}
