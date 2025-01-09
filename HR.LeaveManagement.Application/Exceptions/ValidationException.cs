using FluentValidation.Results;

namespace HR.LeaveManagement.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string> Errors { get; set; } = new List<string>();
    
    public ValidationException(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Errors.Add( error.ErrorMessage);
        }
    }
}