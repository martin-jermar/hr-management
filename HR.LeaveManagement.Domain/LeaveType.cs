using HR.LeaveManagement.Domain.common;

namespace HR.LeaveManagement.Domain;

public class LeaveType : BaseDomainEntity
{
    public string Name { get; set; }
    public int DefaultDays { get; set; }
}