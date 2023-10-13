using System;
using System.Collections.Generic;

namespace WorkSeekerAPI.Entities;

public partial class JobSearchForm
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int FieldId { get; set; }

    public int Experience { get; set; }

    public string Skills { get; set; } = null!;
}
