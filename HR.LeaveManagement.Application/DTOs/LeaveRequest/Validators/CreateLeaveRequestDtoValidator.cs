using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;

public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
        
        RuleFor(x => x.StartDate)
            .LessThan(x => x.EndDate).WithMessage("Property {nameof(StartDate)} should be less than {nameof(EndDate)}");
        
        RuleFor(x=>x.EndDate)
            .GreaterThan(x => x.StartDate).WithMessage("{propertyName} must be greater than {ComparisonValue}");
        
        RuleFor(x=>x.LeaveTypeId)
            .GreaterThan(0).WithMessage("{propertyName} must be greater than {ComparisonValue}")
            .MustAsync(async (id, token) =>
            {
                var leaveTypeExist = await _leaveTypeRepository.Exists(id);
                return !leaveTypeExist;
            })
            .WithMessage("{PropertyName} does not exist");
            
    }
}