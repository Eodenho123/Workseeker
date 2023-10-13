using System;
using System.Collections.Generic;

namespace WorkSeekerAPI.Models;

public partial class JobOfferForm
{
    public int Id { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int FieldId { get; set; }

    public int UserId { get; set; }

    public string Requirements { get; set; } = null!;

    public int TemplateId { get; set; }
}
