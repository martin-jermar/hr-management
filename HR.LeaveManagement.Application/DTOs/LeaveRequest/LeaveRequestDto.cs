﻿using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Domain.common;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest;

public class LeaveRequestDto : BaseDomainEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveTypeDto LeaveTypeDto { get; set; }
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; }
    public DateTime? DateActioned { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    public string RequestingEmployeeId { get; set; }
}