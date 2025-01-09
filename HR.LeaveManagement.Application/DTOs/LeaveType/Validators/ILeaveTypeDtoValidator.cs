using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators;

public class ILeaveTypeDtoValidator: AbstractValidator<ILeaveTypeDto>
{
    public ILeaveTypeDtoValidator()
    {
        RuleFor(x=>x.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

        RuleFor(x => x.DefaultDays)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.")
            .LessThan(100).WithMessage("{PropertyName} must be less than {ComparisonValue}.");
    }
}