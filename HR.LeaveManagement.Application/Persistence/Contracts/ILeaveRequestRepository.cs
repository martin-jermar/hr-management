using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Persistence.Contracts;

public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
{
    Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
    Task<List<LeaveRequestDto>> GetLeaveRequestsWithDetails();
    
    Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus);
}