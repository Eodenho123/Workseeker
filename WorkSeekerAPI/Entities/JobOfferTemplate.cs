using System;
using System.Collections.Generic;

namespace WorkSeekerAPI.Entities;

public partial class JobOfferTemplate
{
    public int Id { get; set; }

    public int FieldId { get; set; }

    public string Requirements { get; set; } = null!;

    public string Title { get; set; } = null!;

    public int UserId { get; set; }
}
