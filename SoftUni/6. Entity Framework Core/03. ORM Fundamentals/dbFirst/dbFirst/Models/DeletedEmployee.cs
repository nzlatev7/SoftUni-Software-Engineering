using System;
using System.Collections.Generic;

namespace dbFirst.Models;

public partial class DeletedEmployee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;   

    public string? MiddleName { get; set; }

    public string JobTitle { get; set; } = null!;

    public int DepartmentId { get; set; }

    public decimal Salary { get; set; }
}
