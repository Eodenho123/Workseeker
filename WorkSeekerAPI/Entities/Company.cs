﻿using System;
using System.Collections.Generic;

namespace WorkSeekerAPI.Entities;

public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int Employees { get; set; }

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;
}
