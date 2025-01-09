using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveAllocations.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;

public class UpdateLeaveAllocationCommandHandler: IRequestHandler<UpdateLeaveAllocationCommand, Unit>
{
    private readonly ILeaveAllocationRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveAllocationCommandHandler(ILeaveAllocationRepository repository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveAllocationDtoValidator(_leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateLeaveAllocation);

        if (validationResult.IsValid == false)
        {
            throw new ValidationException(validationResult);
        }
        var leaveType = await _repository.Get(request.UpdateLeaveAllocation.Id);
        _mapper.Map(request.UpdateLeaveAllocation, leaveType);
        await _repository.Update(leaveType);
        return Unit.Value;
    }
}