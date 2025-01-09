using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Application.Responses;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;

public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommandResponse>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveRequestCommandHandler(ILeaveRequestRepository repository, IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<BaseCommandResponse > Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();

        var leaverRequestValidator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
        var validatorResult = await leaverRequestValidator.ValidateAsync(request.LeaveRequestDto);
        if (!validatorResult.IsValid)
        {
             response.Success = false;
             response.Message = "Creation failed";
             response.Errors = validatorResult.Errors.Select(x => x.ErrorMessage).ToList();
        }
            
        
        var createLeaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
        createLeaveRequest = await _repository.Add(createLeaveRequest);
        
        response.Id = createLeaveRequest.Id;
        response.Success = true;
        response.Message = "Created leave request successfully";

        return response;
    }
}