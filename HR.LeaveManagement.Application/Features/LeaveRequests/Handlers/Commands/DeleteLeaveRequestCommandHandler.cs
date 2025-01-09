using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Commands;

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;
    private IRequestHandler<DeleteLeaveRequestCommand> _requestHandlerImplementation;

    public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _repository.GetLeaveRequestWithDetails(request.Id);
        
        if (leaveRequest == null)
        {
            throw new NotFoundException(nameof(leaveRequest), request.Id);
        }
        
        await _repository.Delete(leaveRequest);
    }
}