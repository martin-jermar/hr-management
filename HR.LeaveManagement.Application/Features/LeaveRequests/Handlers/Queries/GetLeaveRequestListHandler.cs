using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Application.Features.LeaveRequests.Requests.Queries;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequests.Handlers.Queries;

public class GetLeaveRequestListHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestDto>>
{
    private readonly ILeaveRequestRepository _repository;
    private readonly IMapper _mapper;

    public GetLeaveRequestListHandler(IMapper mapper, ILeaveRequestRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<List<LeaveRequestDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
    {
        var leaveRequests = await _repository.GetLeaveRequestsWithDetails();
        return _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
    }
}