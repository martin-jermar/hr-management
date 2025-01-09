using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain.common;

namespace HR.LeaveManagement.Application.DTOs.LeaveAllocation;

public class LeaveAllocationDto : BaseDomainEntity
{
    public int NumberOfDays { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
}