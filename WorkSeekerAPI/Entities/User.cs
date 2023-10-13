using System;
using System.Collections.Generic;

namespace WorkSeekerAPI.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime RegistrationDate { get; set; }

    public string Password { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int StatusId { get; set; }

    public int CompanyId { get; set; }
}
