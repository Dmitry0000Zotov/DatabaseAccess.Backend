using System;
using System.Collections.Generic;

namespace DatabaseAccess.Domain;

public partial class Employee
{
    public Guid EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public string? Position { get; set; }
}
