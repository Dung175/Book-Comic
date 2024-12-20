using System;
using System.Collections.Generic;

namespace BookComic.Models;

public partial class TbUserActivity
{
    public int ActivityId { get; set; }

    public int? UserId { get; set; }

    public string? Title { get; set; }

    public string? Alias { get; set; }

    public string? ActivityType { get; set; }

    public DateTime? ActivityDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual TbUser? User { get; set; }
}
