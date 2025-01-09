using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries;

public class GetLeaveRequestDetailHandler : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;

    public GetLeaveRequestDetailHandler(ILeaveRequestRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveRequest = await _repository.GetLeaveRequestWithDetails(request.Id);
        return _mapper.Map<LeaveRequestDto>(leaveRequest);
    }
}