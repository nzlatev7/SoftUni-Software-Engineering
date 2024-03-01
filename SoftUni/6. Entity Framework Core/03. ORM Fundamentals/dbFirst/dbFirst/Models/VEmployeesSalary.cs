using System;
using System.Collections.Generic;

namespace dbFirst.Models;

public partial class VEmployeesSalary
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public decimal Salary { get; set; }
}
