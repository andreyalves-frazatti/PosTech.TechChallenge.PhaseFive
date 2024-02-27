using FluentValidation.Results;

namespace TechChallenge.Application.Helpers;

public abstract class BaseResponse
{
    private IEnumerable<string> _errors = [];
    public bool IsSuccess
        => !_errors.Any();
    public IEnumerable<string> Errors
        => _errors;


    public void AddError(string errorMessage)
    {
        _errors = new List<string>(_errors) { errorMessage }.ToArray();
    }

    protected void AddError(ValidationResult? validationResult = null)
    {
        if (validationResult is not null)
        {
            _errors = validationResult
                .Errors
                .Select(c => c.ErrorMessage);
        }
    }
}
